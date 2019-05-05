#define DEBUG_MODE

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace R.I.M.UI_Shell
{

    public partial class Main_wnd : Form
    {
        //Accessors
        


        //This class is the RIM 
        //See packet format function for details on packet structure
        static class PSoC_OpCodes
        {
            //RIM Operation codes
            public const byte RIM_OP_MOTOR_RUN           = 0x00,
                              RIM_OP_MOTOR_STOP          = 0x10,
                              RIM_OP_MOTOR_GETSET_PARAM  = 0x20,
                              RIM_OP_MOTOR_STATUS        = 0x30,
                              RIM_OP_ENCODER_INFO        = 0x40,
                              RIM_OP_ERROR               = 0x50,
                              RIM_OP_RESET_DEV           = 0x60,
                              RIM_OP_SERVO               = 0x70,
                              RIM_OP_MOTOR_EXTENDED_STEP = 0x80;

            //For RIM_OP_MOTOR_STOP
            public const byte ONE_SSTOP  = 0x00,
                              ONEHSTOP   = 0x01,
                              ALL_SSTOP  = 0x02,
                              ALL_HSTOPP = 0x03;

            public const byte GETSET_GET_PARAM         = 0x00,
                              GETSET_SET_PARAM         = 0x01,
                              GETSET_RECEIVED_ACCESSOR = 0x08;
            
            public const ushort GETSET_RECEIVED_PARAM_DATA = 0xFFE0,
                                GETSET_RECEIVED_PARAM_TYPE = 0x001F;



        };

        //Class for defining gearing ratios constants on RIM
        static class RIM_MotorConstants
        {
            //public static readonly decimal[] Motor_Ratios =    {8   , 100      , 100   , 13.79M, 51     };
            //public static readonly decimal[] Motor_StepAngle = {0.1125M, 0.018M, 0.018M, 0.131M, 0.036M };
            //Actual motor one step angle is 0.9, but factoring gearing it is different
            //public static readonly decimal[] Motor_StepDiv = {2, 4, 2, 2, 4};

            public static readonly decimal[] Motor_Slopes = {0.0561M, 0.0045M, 0.0089M, 0.0655M, 0.0089M};
            public static readonly decimal[] Motor_Offset = {0.0626M, -0.1088M, -0.0879M, -1.1927M, -1.36M};

            public static readonly int[] M_Limit_Start = { 1316, 350, 876, 3737, 3493 };
            public static readonly int[] M_Limit_End = { 1275, 2130, 1465, 1296, 2784 };

            public static readonly decimal E_to_D = 360M / 4096M;

            /*
            public const decimal M1_ratio = 8,
                           M1_StepAngle = 0.9M,
                           //M1_StepDiv = 2,

                           M2_ratio = 50, 
                           M2_StepAngle = 0.018M,
                           //M2_StepDiv = 4,

                           M3_ratio = 100,
                           M3_StepAngle = 0.09M,
                           //M3_StepDiv = 2,

                           M4_ratio = 13.79M,
                           M4_StepAngle = 0.131M,
                           //M4_StepDiv = 2,

                           M5_ratio = 50,
                           M5_StepAngle = 0.018M;
            */

        };


        //Class to keep track of the command list for programmed execution mode
        public class RIM_PExec
        {
            public Queue<string>[] Motor_cmds;
            public Queue<string>[] Encoder_cmds;

            public Queue<string> Special_cmds;
            public Queue<string> Timer_Starts;
            public Queue<string> Timer_Stops;
            
            public string fpath;

            public RIM_PExec()
            {
                Motor_cmds = new Queue<string>[7];
                Encoder_cmds = new Queue<string>[7];

                Special_cmds = new Queue<string>();
                Timer_Starts = new Queue<string>();
                Timer_Stops = new Queue<string>();

                fpath = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
                fpath += "\\outfile.csv";

                for (int i = 0; i < 7; i++)
                {
                    Motor_cmds[i] = new Queue<string>();
                }

                for (int i = 0; i < 7; i++)
                {
                    Encoder_cmds[i] = new Queue<string>();
                }

            }

        }

        //Stores hex paramters for the L6470 motor driver chip
        static class L6470_Params {
            //Overcurrent Parameters
            public const byte OCD_TH_375mA  = 0x00,
                              OCD_TH_750mA  = 0x01,
                              OCD_TH_1125mA = 0x02,
                              OCD_TH_1500mA = 0x03,
                              OCD_TH_1875mA = 0x04,
                              OCD_TH_2250mA = 0x05,
                              OCD_TH_2625mA = 0x06,
                              OCD_TH_3000mA = 0x07,
                              OCD_TH_3375mA = 0x08,
                              OCD_TH_3750mA = 0x09,
                              OCD_TH_4125mA = 0x0A,
                              OCD_TH_4500mA = 0x0B,
                              OCD_TH_4875mA = 0x0C,
                              OCD_TH_5250mA = 0x0D,
                              OCD_TH_5625mA = 0x0E,
                              OCD_TH_6000mA = 0x0F;

            //Step select constants
            public const byte STEP_SEL_1     = 0x00,
                              STEP_SEL_1_2   = 0x01,
                              STEP_SEL_1_4   = 0x02,
                              STEP_SEL_1_8   = 0x03,
                              STEP_SEL_1_16  = 0x04,
                              STEP_SEL_1_32  = 0x05,
                              STEP_SEL_1_64  = 0x06,
                              STEP_SEL_1_128 = 0x07;


            //All the registers within the the L6470
            public const byte ABS_POS      =       0x01,
                              EL_POS       =       0x02,
                              MARK         =       0x03,
                              SPEED        =       0x04,
                              ACC          =       0x05,
                              DECEL        =       0x06,
                              MAX_SPEED    =       0x07,
                              MIN_SPEED    =       0x08,
                              FS_SPD       =       0x15,
                              KVAL_HOLD    =       0x09,
                              KVAL_RUN     =       0x0A,
                              KVAL_ACC     =       0x0B,
                              KVAL_DEC     =       0x0C,
                              INT_SPD      =       0x0D,
                              ST_SLP       =       0x0E,
                              FN_SLP_ACC   =       0x0F,
                              FN_SLP_DEC   =       0x10,
                              K_THERM      =       0x11,
                              ADC_OUT      =       0x12,
                              OCD_TH       =       0x13,
                              STALL_TH     =       0x14,
                              STEP_MODE    =       0x16,
                              ALARM_EN     =       0x17,
                              CONFIG       =       0x18,
                              STATUS       =       0x19;
        }

        public class Motor_Settings
        {
            public enum Step_types {Step_1   = 1,
                                    Step_2   = 2,
                                    Step_4   = 4,
                                    Step_8   = 8,
                                    Step_16  = 16,
                                    Step_32  = 32,
                                    Step_64  = 64,
                                    Step_128 = 128
            };

            public struct MParam
            {
                public int accel,
                           decel,
                          max_speed;
                public Step_types step_div;
            }

            public Motor_Settings()
            {
                for (int i = 0; i < CONNECTED_MOTORS; i++)
                {
                    All_Motor_Settings[i] = new MParam
                    {
                        accel = 0,
                        decel = 0,
                        step_div = Step_types.Step_1,
                        max_speed = 0
                    };

                }
            }


            public void Copy(ref Motor_Settings input)
            {
                for(int i = 0; i < CONNECTED_MOTORS; i++)
                {
                    input.All_Motor_Settings[i].accel     = All_Motor_Settings[i].accel;
                    input.All_Motor_Settings[i].decel     = All_Motor_Settings[i].decel;
                    input.All_Motor_Settings[i].step_div  = All_Motor_Settings[i].step_div;
                    input.All_Motor_Settings[i].max_speed = All_Motor_Settings[i].max_speed;
                }
            }

            public MParam[] All_Motor_Settings = new MParam[CONNECTED_MOTORS];

            public void Set_acc(int index, int value)
            {
                All_Motor_Settings[index].accel = (int)Math.Round(value / 0.137438 / 2.0);
            }

            public void Set_decel(int index, int value)
            {
                All_Motor_Settings[index].decel = (int)Math.Round(value / 0.137438 / 2.0);
            }

            public void Set_max_speed(int index, int value)
            {
                All_Motor_Settings[index].max_speed = (int)Math.Round(value / 0.065536 / 2.0);
            }

            public void Set_step_div(int index, int value)
            {
                value = value & 0x07;
                switch(value)
                {
                    case L6470_Params.STEP_SEL_1:
                        All_Motor_Settings[index].step_div = Step_types.Step_1;
                        break;
                    case L6470_Params.STEP_SEL_1_2:
                        All_Motor_Settings[index].step_div = Step_types.Step_2;
                        break;
                    case L6470_Params.STEP_SEL_1_4:
                        All_Motor_Settings[index].step_div = Step_types.Step_4;
                        break;
                    case L6470_Params.STEP_SEL_1_8:
                        All_Motor_Settings[index].step_div = Step_types.Step_8;
                        break;
                    case L6470_Params.STEP_SEL_1_16:
                        All_Motor_Settings[index].step_div = Step_types.Step_16;
                        break;
                    case L6470_Params.STEP_SEL_1_32:
                        All_Motor_Settings[index].step_div = Step_types.Step_32;
                        break;
                    case L6470_Params.STEP_SEL_1_64:
                        All_Motor_Settings[index].step_div = Step_types.Step_64;
                        break;
                    case L6470_Params.STEP_SEL_1_128:
                        All_Motor_Settings[index].step_div = Step_types.Step_128;
                        break;
                }
            }

            public byte Step_div_to_L6470Param(int index)
            {
                byte r = 0;
                switch (All_Motor_Settings[index].step_div)
                {
                    case Step_types.Step_1:
                        r = L6470_Params.STEP_SEL_1;
                        break;
                    case Step_types.Step_2:
                        r = L6470_Params.STEP_SEL_1_2;
                        break;
                    case Step_types.Step_4:
                        r = L6470_Params.STEP_SEL_1_4;
                        break;
                    case Step_types.Step_8:
                        r = L6470_Params.STEP_SEL_1_8;
                        break;
                    case Step_types.Step_16:
                        r = L6470_Params.STEP_SEL_1_16;
                        break;
                    case Step_types.Step_32:
                        r = L6470_Params.STEP_SEL_1_32;
                        break;
                    case Step_types.Step_64:
                        r = L6470_Params.STEP_SEL_1_64;
                        break;
                    case Step_types.Step_128:
                        r = L6470_Params.STEP_SEL_1_128;
                        break;
                }
                return r;
            }




            //is_changed needs to have a size of 4
            //is changed is orginized like this:
            //0 - Step_div
            //1 - max_speed
            //2 - accel
            //3 - decel
            public bool Compare(MParam compare_val, int index, ref bool[] is_changed)
            {
                bool r = false;

                if (is_changed.Length != 4)
                    return r;

                for (int i = 0; i < 4; i++)
                    r = false;

                //If one of these is changed, then return true
                is_changed[0] = compare_val.step_div != All_Motor_Settings[index].step_div;
                is_changed[1] = compare_val.max_speed != All_Motor_Settings[index].max_speed;
                is_changed[2] = compare_val.accel != All_Motor_Settings[index].accel;
                is_changed[3] = compare_val.decel != All_Motor_Settings[index].decel;


                for (int i = 0; i < 4; i++)
                    r |= is_changed[i];

                //If true then they are the same
                return !r;
            }

        };

        public volatile Motor_Settings All_MSettings = new Motor_Settings();

        

        //Enum to keep track of motor direction
        public enum Direction {CLOCKWISE, COUNTERCLOCKWISE};

        //Global variable for keeping track of input file for programmed execution mode
        string file_content = string.Empty;

        //Matlab console instance for DH parameters
        

        //Toggle for telling system whether or not to update the UI on the encoder position
        bool Encoder_Update_1 = false,
             Encoder_Update_2 = false,
             Encoder_Update_3 = false,
             Encoder_Update_4 = false,
             Encoder_Update_5 = false;

        //Keep track of what motors are active--currently not in use
        const int CONNECTED_MOTORS   = 5,
                  CONNECTED_ENCODERS = 5;

        volatile public bool[] Motor_Active = new bool[CONNECTED_MOTORS];

        volatile public int[] Encoder_Values = new int[CONNECTED_ENCODERS];

        //Boolean that enables the data received event handler for the UART_COM object
        bool data_event_enabled = true;
        
        //Degree mode bool
        bool degree_mode = false;

        //For storing the stepper motor steps during percise execution mode
        public struct PreciseExecution_steps
        {
            public int motor_num; 

            //For motor steps
            public ushort[] motors;

            public Direction[] motor_dirs;

            public PreciseExecution_steps(int motor_amount = CONNECTED_MOTORS)
            {
                motor_num = motor_amount;

                motors = new ushort[motor_num];
                motor_dirs = new Direction[motor_num];

                for (int i = 0; i < motor_num; i++) 
                    motors[i] = 0;

                for (int i = 0; i < motor_num; i++)
                    motor_dirs[i] = Direction.CLOCKWISE;

            }
        };

        //MLApp.MLApp matlab = new MLApp.MLApp();

        private void Main_wnd_Load(object sender, EventArgs e)
        {
            Encoder_FetchTimer.Stop();

            Disable_all();

            for (int i = 0; i < CONNECTED_MOTORS; i++)
            {
                Motor_Active[i] = false;
            }
            for (int i = 0; i < CONNECTED_ENCODERS; i++)
            {
                Encoder_Values[i] = 0;
            }

            //Change UART encoding to ASCII-Extended for charicter code transfers > 127
            UART_COM.Encoding = System.Text.Encoding.GetEncoding(28591);

            //matlab.Visible = 0;
            FileCheck_btn.Enabled = false;
            FileReload_btn.Enabled = false;
        }

        //Function that sets an indicator that corrisponds to ID to a color C
        //Motors have an id of 0-6, encoders have ids of 7-11
        public void Set_ind_backcolor(int id, Color c)
        {
            switch (id)
            {
                case 0:
                    if (M1Running_ind.InvokeRequired)
                        M1Running_ind.Invoke(new MethodInvoker(delegate { M1Running_ind.BackColor = c; }));
                    else
                        M1Running_ind.BackColor = c;
                    break;
                case 1:
                    if (M2Running_ind.InvokeRequired)
                        M2Running_ind.Invoke(new MethodInvoker(delegate { M2Running_ind.BackColor = c; }));
                    else
                        M2Running_ind.BackColor = c;
                    break;
                case 2:
                    if (M3Running_ind.InvokeRequired)
                        M3Running_ind.Invoke(new MethodInvoker(delegate { M3Running_ind.BackColor = c; }));
                    else
                        M3Running_ind.BackColor = c;
                    break;
                case 3:
                    if (M4Running_ind.InvokeRequired)
                        M4Running_ind.Invoke(new MethodInvoker(delegate { M4Running_ind.BackColor = c; }));
                    else
                        M4Running_ind.BackColor = c;
                    break;
                case 4:
                    if (M5Running_ind.InvokeRequired)
                        M5Running_ind.Invoke(new MethodInvoker(delegate { M5Running_ind.BackColor = c; }));
                    else
                        M5Running_ind.BackColor = c;
                    break;
                case 5:
                    if (M6Running_ind.InvokeRequired)
                        M6Running_ind.Invoke(new MethodInvoker(delegate { M6Running_ind.BackColor = c; }));
                    else
                        M6Running_ind.BackColor = c;
                    break;
                case 6:
                    if (M7Running_ind.InvokeRequired)
                        M7Running_ind.Invoke(new MethodInvoker(delegate { M7Running_ind.BackColor = c; }));
                    else
                        M7Running_ind.BackColor = c;
                    break;
                case 7:
                    if (E1Running_ind.InvokeRequired)
                        E1Running_ind.Invoke(new MethodInvoker(delegate { E1Running_ind.BackColor = c; }));
                    else
                        E1Running_ind.BackColor = c;
                    break;
                case 8:
                    if (E2Running_ind.InvokeRequired)
                        E2Running_ind.Invoke(new MethodInvoker(delegate { E2Running_ind.BackColor = c; }));
                    else
                        E2Running_ind.BackColor = c;
                    break;
                case 9:
                    if (E3Running_ind.InvokeRequired)
                        E3Running_ind.Invoke(new MethodInvoker(delegate { E3Running_ind.BackColor = c; }));
                    else
                        E3Running_ind.BackColor = c;
                    break;
                case 10:
                    if (E4Running_ind.InvokeRequired)
                        E4Running_ind.Invoke(new MethodInvoker(delegate { E4Running_ind.BackColor = c; }));
                    else
                        E4Running_ind.BackColor = c;
                    break;
                case 11:
                    if (E5Running_ind.InvokeRequired)
                        E5Running_ind.Invoke(new MethodInvoker(delegate { E5Running_ind.BackColor = c; }));
                    else
                        E5Running_ind.BackColor = c;
                    break;
            }
                
        }

        void Set_Encoder_label(int id, string text)
        {
            switch (id)
            {
                case 0:
                    if (Encoder1Val_lbl.InvokeRequired)
                        Encoder1Val_lbl.Invoke(new MethodInvoker(delegate { Encoder1Val_lbl.Text = text; }));
                    else
                        Encoder1Val_lbl.Text = text;
                    break;
                case 1:
                    if (Encoder2Val_lbl.InvokeRequired)
                        Encoder2Val_lbl.Invoke(new MethodInvoker(delegate { Encoder2Val_lbl.Text = text; }));
                    else       
                        Encoder2Val_lbl.Text = text;
                    break;

                case 2:
                    if (Encoder3Val_lbl.InvokeRequired)
                        Encoder3Val_lbl.Invoke(new MethodInvoker(delegate { Encoder3Val_lbl.Text = text; }));
                    else       
                        Encoder3Val_lbl.Text = text;
                    break;
                case 3:
                    if (Encoder4Val_lbl.InvokeRequired)
                        Encoder4Val_lbl.Invoke(new MethodInvoker(delegate { Encoder4Val_lbl.Text = text; }));
                    else       
                        Encoder4Val_lbl.Text = text;
                    break;
                case 4:
                    if (Encoder5Val_lbl.InvokeRequired)
                        Encoder5Val_lbl.Invoke(new MethodInvoker(delegate { Encoder5Val_lbl.Text = text; }));
                    else       
                        Encoder5Val_lbl.Text = text;
                    break;
                default:
                    break;
            }
        }

        string Get_Encoder_label(int id)
        {
            string text = "";

            switch (id)
            {
                case 0:
                    text = Encoder1Val_lbl.Text;
                    break;
                case 1:
                    text = Encoder2Val_lbl.Text;
                    break;
                case 2:
                    text = Encoder3Val_lbl.Text;
                    break;
                case 3:
                    text = Encoder4Val_lbl.Text;
                    break;
                case 4:
                    text = Encoder5Val_lbl.Text;
                    break;
                default:
                    text = "ERR";
                    break;
            }
            return text;
        }




        //Init window
        public Main_wnd()
        {
            InitializeComponent();
        }

        //Attempts to open up the com port
        //If it fails to open, notify the user
        private bool TryOpenCom() {
            bool r = true;
            if (!UART_COM.IsOpen)
            {
                try
                {
                    UART_COM.Open();  
                }
                catch
                {
                    MessageBox.Show("Error: COM Port " + UART_COM.PortName + " is in use or doesn't exist!");
                    r = false;
                };
            }
            return r;
        }




        //Debug mode output when transfering packets
#if (DEBUG_MODE)
        private void Debug_Output(byte[] packet, int sz)
        {
            Console.WriteLine("Sending UART packet: " + Byte_array_to_string(packet, 3));
            Console.WriteLine("Sending physical UART packet: " + Byte_array_to_literal_string(packet, 3));
            Console.WriteLine("------------------");
        }
        #endif

        //Disables all controls on a given control group
        private void Disable_all(char type = 'n')
        {
#if (DEBUG_MODE)
            Console.WriteLine("Disabling all window mode controls");
#endif
            PreciseExecutionMode_grp.Enabled = false;
            ProgrammedExecutionMode_grp.Enabled = false;
            TraverseLineMode_grp.Enabled = false;
            OvrCurpos_lbl.Visible = false;

            if (type == 'o')
                OvrCurpos_lbl.Visible = true;
            else if (type == 'p')
                PreciseExecutionMode_grp.Enabled = true;
            else if (type == 'a')
                ProgrammedExecutionMode_grp.Enabled = true;
            else if (type == 't')
                TraverseLineMode_grp.Enabled = true;

#if (DEBUG_MODE)
            Console.WriteLine("Enabled window control for \'" + type + "\'");
#endif
        }

        //Checks to see which control group is enabled
        private char Check_enable() {
            char r = 'o';
#if (DEBUG_MODE)
            Console.WriteLine("Checking which groups are enabled");
#endif
            if (PreciseExecutionMode_grp.Enabled == true)
                r = 'p';
            else if (ProgrammedExecutionMode_grp.Enabled == true)
                r = 'a';
            else if (TraverseLineMode_grp.Enabled == true)
                r = 't';
#if (DEBUG_MODE)
            Console.WriteLine("Group " + r + " is currently enabled");
#endif
            return r;
        }

        //Check if input is valid and set the values of the 'commands' variable as dictated. 
        private void PreciseExecutionMode_CheckValid(ref PreciseExecution_steps commands) {

#if (DEBUG_MODE)
            Console.WriteLine("Started input validation for Precise Execution Mode");
#endif

            //Toggle for degree mode
            ushort max_steps = 0xFFFF;
            if (degree_mode)
            {
                max_steps = 360;
                
            }

            if (Int32.TryParse(Stepper1_entry.Text.Replace('°', ' '), out int x))
            {
                if (x < 0)
                    commands.motor_dirs[0] = Direction.COUNTERCLOCKWISE;

                if (Math.Abs(x) > max_steps)
                    commands.motors[0] = max_steps;
                else
                    commands.motors[0] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Stepper2_entry.Text.Replace('°', ' '), out x))
            {
                if (x < 0)
                    commands.motor_dirs[1] = Direction.COUNTERCLOCKWISE;

                if (Math.Abs(x) > max_steps)
                    commands.motors[1] = max_steps;
                else
                    commands.motors[1] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Stepper3_entry.Text.Replace('°', ' '), out x))
            {
                if (x < 0)
                    commands.motor_dirs[2] = Direction.COUNTERCLOCKWISE;
                if (Math.Abs(x) > max_steps)
                    commands.motors[2] = max_steps;
                else
                    commands.motors[2] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Stepper4_entry.Text.Replace('°', ' '), out x))
            {
                if (x < 0)
                    commands.motor_dirs[3] = Direction.COUNTERCLOCKWISE;
                if (Math.Abs(x) > max_steps)
                    commands.motors[3] = max_steps;
                else
                    commands.motors[3] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Stepper5_entry.Text.Replace('°', ' '), out x))
            {
                if (x < 0)
                    commands.motor_dirs[4] = Direction.COUNTERCLOCKWISE;

                if (Math.Abs(x) > max_steps)
                    commands.motors[4] = max_steps;
                else
                    commands.motors[4] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Servo1_entry.Text.Replace('°', ' '), out x))
            {
                commands.motor_dirs[5] = 0;
                if (x < 0)
                    commands.motors[5] = 0;
                else if (x > 130)
                    commands.motors[5] = 130;
                else
                    commands.motors[5] = (ushort)x;
            }

            if (Int32.TryParse(Servo2_entry.Text.Replace('°', ' '), out x))
            {
                commands.motor_dirs[6] = 0;
                if (x < 0)
                    commands.motors[6] = 0;
                else if (x > 4096)
                    commands.motors[6] = 4096;
                else
                    commands.motors[6] = (ushort)x;
            }

            if (degree_mode)
                Degrees_to_steps_PExecMode(ref commands);
            

#if (DEBUG_MODE)
            Console.WriteLine("Done!");
#endif
        }

        //Degrees to steps for percise execution mode
        void Degrees_to_steps_PExecMode(ref PreciseExecution_steps commands)
        {
            for(int i = 0; i < CONNECTED_MOTORS; i++)
            {
                if (commands.motors[i] != 0)
                    commands.motors[i] = Degrees_to_steps((uint)i, commands.motors[i]);
            }
        }

        //Converts from degrees to steps
        ushort Degrees_to_steps(uint motor_id, decimal degrees)
        {

            if (motor_id >= CONNECTED_MOTORS)
                motor_id = CONNECTED_MOTORS - 1;

            if (degrees > 360)
                degrees = 360;


            return (ushort)Math.Round((Math.Abs(degrees) - RIM_MotorConstants.Motor_Offset[motor_id])/RIM_MotorConstants.Motor_Slopes[motor_id]); 
        }

        //Programmed Execution Mode support
        //Parses an input files and converts it to commands that can be sent to RIM
        //Commands are stored in queues corrisponding to the motor and encoder
        bool ProgExec_parse_and_load(ref RIM_PExec commands, string finfo)
        {
            //Start at line 1
            int line_num = 1;

            byte id = 0; 
            Direction dir = 0;
            ushort steps = 0;
            decimal deg_steps = 0;

            byte[] packet = new byte[3];

            //Keep track of syntax errors
            bool error = false;

            //Degree mode flag
            bool deg_mode = false;

            //Queue for keeping track of syntax errors
            Queue<string> errlist = new Queue<string>();

            //Keep track of what motors are give a commmand to execute
            bool[] cmd_written = new bool[7];
            bool[] encoder_cmd_written = new bool[5];

            for (int i = 0; i < 7; i++)
                cmd_written[i] = false;

            for (int i = 0; i < 5; i++)
                encoder_cmd_written[i] = false;

            bool special_cmd_written = false;
            bool timer_start_cmd_written = false;
            bool timer_stop_cmd_written = false;

            //Split the file by line
            string []split_info = finfo.Split('\n');

            foreach (string line in split_info)
            {
                //Ignore a line if it has one of the following leading chars
                if (line.Length == 0 || line[0] == '#')
                {
                    line_num++;
                    continue;
                }
                
                //Remove all extra spaces and split by commas
                string[] temp = line.Replace(" ", "").Split(',');

                if (temp[0] == "-")
                {
                    //Fill out the rest of the queue with motor pass commands
                    for (int i = 0; i < 7; i++)
                    {
                        if (!cmd_written[i])
                            commands.Motor_cmds[i].Enqueue("PASS");
                        else
                            cmd_written[i] = false;
                    }

                    if (!special_cmd_written)
                        commands.Special_cmds.Enqueue("PASS");
                    else
                        special_cmd_written = false;

                    if (!timer_start_cmd_written)
                        commands.Timer_Starts.Enqueue("PASS");
                    else
                        timer_start_cmd_written = false;

                    if(!timer_stop_cmd_written)
                        commands.Timer_Stops.Enqueue("PASS");
                    else
                        timer_stop_cmd_written = false;

                    line_num++;
                    continue;
                }
                else if(temp[0] == "FPATH")
                {
                    if (temp.Length < 2)
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Not enough parameters. Expected 2, given " + temp.Length.ToString());
                        error = true;
                        line_num++;
                        continue;
                    }

                    if (Directory.Exists(temp[1]))
                    {
                        commands.fpath = temp[1];
                        line_num++;
                    }
                    else
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Given directory " + temp[1] + " does not exist!");
                        error = true;
                        line_num++;
                        continue;
                    }

                }
                else if(temp[0] == "FNAME")
                {
                    if (temp.Length < 2)
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Not enough parameters. Expected 2, given " + temp.Length.ToString());
                        error = true;
                        line_num++;
                        continue;
                    }
                    commands.fpath += "\\" + temp[1];
                    line_num++;
                }

                else if (temp[0] == "TSTART")
                {
                    commands.Timer_Starts.Enqueue("TSTART" + line_num);
                    timer_start_cmd_written = true;
                    line_num++;
                }
                else if(temp[0] == "TSTOP")
                {
                    commands.Timer_Stops.Enqueue("TSTOP" + line_num);

                    int count_start = 0,
                         count_stop = 0;

                    foreach (string s in commands.Timer_Starts.ToArray())
                    {
                        if (s.Substring(0, 4) == "TSTA")
                            count_start++;
                    }

                    foreach (string s in commands.Timer_Stops.ToArray())
                    {
                        if (s.Substring(0, 4) == "TSTO")
                            count_stop++;
                    }

                    if(count_start != count_stop)
                    {
                        errlist.Enqueue("Error encountered on line " + line_num.ToString() + ": number of timer starts and stops are not equal: " +
                              "TSTART = "  + count_start + ", " +
                              "TSTOP  = " + count_stop);
                        error = true;
                    }
                    timer_stop_cmd_written = true;
                    line_num++;
                }

                //Mode selecter
                else if(temp[0] == "MODE")
                {
                    if (temp.Length < 2)
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Not enough parameters. Expected 2, given " + temp.Length.ToString());
                        error = true;
                    }
                    if(temp[1] == "DEGREE" || temp[1] == "DEG")
                        deg_mode = true;
                    if (temp[1] == "STEP")
                        deg_mode = false;
                    line_num++;
                }

                else if(temp[0] == "SLEEP")
                {
                    if(temp.Length < 2)
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Not enough parameters. Expected at least 2, given " + temp.Length.ToString());
                        error = true;
                        line_num++;
                        continue;
                    }

                    if (!int.TryParse(temp[1], out int x))
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Invalid value entered: " + temp[1] + ".\nMake sure to enter a whole number\n");
                        error = true;
                        line_num++;
                        continue;
                    }
                    else
                        commands.Special_cmds.Enqueue("S" + x.ToString());

                    line_num++;
                }


                //Command for move
                else if (temp[0] == "MOVE")
                {
                    if(temp.Length < 4)
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Not enough parameters. Expected 4, given " + temp.Length.ToString());
                        error = true;
                        line_num++;
                        continue;
                    }


                    //Check for valid motor ID (bounds and user entry)
                    if (!byte.TryParse(temp[1], out byte x))
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Invalid motor ID " + temp[1]);
                        error = true;
                    }
                    else
                    {
                        if ((x - 1) < 0 || (x - 1) > 6)
                        {
                            errlist.Enqueue("Error with line " + line_num.ToString() + ": Motor ID " + x + " is out of bounds!");
                            error = true;
                        }
                    }

                    //Set the motor ID
                    id = (byte)(x - 1);

                    //Set CCW or CW
                    if (temp[2] == "CCW")
                        dir = Direction.COUNTERCLOCKWISE;
                    else if (temp[2] == "CW")
                        dir = Direction.CLOCKWISE;
                    else
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Invalid entered direction " + temp[2]);
                        error = true;
                    }

                    if(deg_mode)
                    {
                        if (!decimal.TryParse(temp[3], out decimal y))
                        {
                            errlist.Enqueue("Error with line " + line_num.ToString() + ": Invalid amount of degrees: " + temp[3]);
                            error = true;
                        }
                        else
                            deg_steps = y;
                    }

                    else
                    {
                        if (!ushort.TryParse(temp[3], out ushort y))
                        {
                            errlist.Enqueue("Error with line " + line_num.ToString() + ": Invalid amount of steps: " + temp[3]);
                            error = true;
                        }
                        else
                            steps = y;

                    }

                    line_num++;
                    if (error)
                        continue;

                    if (deg_mode)
                        steps = Degrees_to_steps(id, deg_steps);

                    Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_RUN, dir, id, steps, ref packet, 3);

                    commands.Motor_cmds[id].Enqueue(Byte_array_to_literal_string(packet, 3));
                    cmd_written[id] = true;
                }
                else
                {
                    errlist.Enqueue("Error with line " + line_num.ToString() + ": Invalid/unimplemented command: " + temp[0]);
                    error = true;
                }
                

            }

            //Test that all queues have an equal number of commands
            double all_counts = commands.Timer_Starts.Count;
            all_counts += commands.Timer_Stops.Count;
            all_counts += commands.Special_cmds.Count;
            for (int i = 0; i < 7; i++)
                all_counts += commands.Motor_cmds[i].Count;

            //Divide by 10 total queues
            all_counts /= 10;
            if(all_counts % 1 != 0)
            {
                errlist.Enqueue("Error: Queue length mismatch. Make sure to use only one command type per -");
                error = true;
            }


            if (error)
            {
                ProgExecFLoad_lbl.Text = "File load Failed";
                int max = errlist.Count;
                #if (DEBUG_MODE)
                    for (int i = 0; i < max; i++)
                    {
                        Console.WriteLine(errlist.Dequeue());
                    }
                #endif

                for(int i = 0; i < 7; i++)
                    commands.Motor_cmds[i].Clear();

                commands.Special_cmds.Clear();
                commands.Timer_Starts.Clear();
                commands.Timer_Starts.Clear();
            }

            return !error;
        }

        //Checks to see if motor is active based on the color its indicator
        //This function is a really bad way to check for this, and will be changed in the future
        bool Motors_Active(int motor_id)
        {
            bool r = false;
            switch (motor_id) {
                case 0:
                    M1Running_ind.Update();
                    if (M1Running_ind.BackColor == Color.LimeGreen)
                        r = true;
                    break;
                case 1:
                    M2Running_ind.Update();
                    if (M2Running_ind.BackColor == Color.LimeGreen)
                        r = true;
                    break;
                case 2:
                    M3Running_ind.Update();
                    if (M3Running_ind.BackColor == Color.LimeGreen)
                        r = true;
                    break;
                case 3:
                    M4Running_ind.Update();
                    if (M4Running_ind.BackColor == Color.LimeGreen)
                        r = true;
                    break;
                case 4:
                    M5Running_ind.Update();
                    if (M5Running_ind.BackColor == Color.LimeGreen)
                        r = true;
                    break;
            }
            return r;
        }

        //Start sequence for programmed exeuction mode
        void ProgExec_start(RIM_PExec commands)
        {

            //Disable event based UART handling
            data_event_enabled = false;

            string temp = string.Empty;

            //Since all the command queues are the same length, taking the length of any of them yields the maximum ammount of commands
            int total_cmds = commands.Motor_cmds[0].Count;

            bool[] motor_running = new bool[7],
                      motor_idle = new bool[7];

            for (int i = 0; i < 7; i++)
            {
                motor_running[i] = false;
                motor_idle[i] = true;
            }

            //Total number of commands to send is the ammount times  
            int sent_commands = 0;

            //Open file to write 
            StreamWriter outFile = new StreamWriter(commands.fpath);


            outFile.WriteLine("-----------------------------------------");
            outFile.WriteLine("RIM Programmed Execution Mode Output File");
            outFile.WriteLine(DateTime.Now);
            outFile.WriteLine("-----------------------------------------");
            outFile.WriteLine("CommandType, LineEncountered, TimeElapsed(ms)");


            Stopwatch RIM_Stopwatch = new Stopwatch();


            //Loops for the total ammount of commands
            for (int i = 0; i < total_cmds; i++)
            {
                temp = commands.Timer_Starts.Dequeue();
                if(temp != "PASS")
                {
                    RIM_Stopwatch.Start();
                }

                //j represents the motor ids
                //Loops though for each of the motors
                for (int j = 0; j < 7; j++)
                {
                    //Load motor command into temp
                    temp = commands.Motor_cmds[j].Dequeue();

                    //If the motor command was PASS, then move onto the next motor
                    if (temp == "PASS")
                    {
                        temp = string.Empty;
                    }
                    else
                    {
                        
                        UART_COM.Write(temp);
                        sent_commands++;

                        //The following loop ensures that the motor has started running before sending the command to the next motor
                        do
                        {
                            //Polls until a response is received
                            int ch = UART_COM.ReadByte();
                            Console.Write("1 Byte received\n");

                            //Get relevent information out of received packet
                            int OPCODE = (0xF0 & ch) >> 4;
                            int M_ID = ch & 0x07;

                            if (OPCODE == 0x00)
                            {
                                //Enters loop if device responded with the motor start indicator
                                Set_ind_backcolor(M_ID, Color.LimeGreen);
                                motor_idle[M_ID] = false;
                                motor_running[M_ID] = true;
                            }
                            else
                            {
                                //If not starting, assume the motor sent a stop command. Turn the relevent indicator yellow to indicate that it is idle,
                                //and set the approprate motor_running and motor_idle variables
                                Set_ind_backcolor(M_ID, Color.Gold);
                                motor_running[M_ID] = false;
                                motor_idle[M_ID] = true;
                            }
                        //Move onto the next motor command once the motor has started moving
                        //loops in case a motor stop is received from another motor's completion 
                        } while (motor_idle[j] == true);

                    }
                }

                //Wait for motors to be done
                while (!All_idle(motor_idle, 7))
                {
                    int ch = UART_COM.ReadByte();
                    Console.Write("1 Byte received\n");
                    int OPCODE = (0xF0 & ch) >> 4;
                    int M_ID = ch & 0x07;
                    if (OPCODE == 0x00)
                    {
                        Set_ind_backcolor(M_ID, Color.LimeGreen);
                        motor_idle[M_ID] = false;
                        motor_running[M_ID] = true;
                    }
                    else
                    {
                        Set_ind_backcolor(M_ID, Color.Gold);
                        motor_running[M_ID] = false;
                        motor_idle[M_ID] = true;
                    }
                }

                temp = commands.Timer_Stops.Dequeue();
                if(temp != "PASS")
                {
                    RIM_Stopwatch.Stop();
                    long time_taken = RIM_Stopwatch.ElapsedMilliseconds;
                    int line_number = int.Parse(temp.Remove(0, 5));
                    outFile.WriteLine(string.Format("TSTOP, {0}, {1}", line_number, time_taken));
                    RIM_Stopwatch.Reset();
                }

                temp = commands.Special_cmds.Dequeue();
                if (temp == "PASS")
                    temp = string.Empty;
                else if (temp.Substring(0, 1) == "S")
                {
                    Thread.Sleep(int.Parse(temp.Replace('S', ' ')));
                }
            }
            //After precise execution mode has finished running, re-enable the UART data received event handler

            outFile.Close();

            data_event_enabled = true;

            Stop_btn.Enabled = false;
            Start_btn.Enabled = true;
        }

        //Translater function for writing to different encoder labels
        private void Change_Encoder_Val_lbl(int id, string val)
        {
            switch (id)
            {
                case 0:
                    Encoder1Val_lbl.Text = val;
                    break;
                case 1:
                    Encoder2Val_lbl.Text = val;
                    break;
                case 2:
                    Encoder3Val_lbl.Text = val;
                    break;
                case 3:
                    Encoder4Val_lbl.Text = val;
                    break;
                case 4:
                    Encoder5Val_lbl.Text = val;
                    break;
                default:
                    break;
            }
            return;
        }

        //Checks to see if all values in the given bool array are true
        private bool All_idle(bool[] arr, int sz)
        {
            bool ret = true;

            for (int i = 0; i < sz; i++)
                ret &= arr[i];

            return ret;
        }


        //Turn byte array into the literal ASCII values and puts it into a string
        string Byte_array_to_literal_string(byte[] packet, int sz) {
            var temp = Encoding.GetEncoding("iso-8859-1");

            return temp.GetString(packet).ToString();           
        }

        //Turns byte array into human readable string
        string Byte_array_to_string(byte[] packet, int sz) {
            
            string temp = "";
            for (int i = 0; i < sz; i++)
                temp += packet[i].ToString() + " ";

            return temp;
        }


        //Formats into UART packet to be sent
        //Packet structure is as follows:
        // | _ _ _ _ | _ _ _ _ | _ _ _ _ _ _ _ _ | _ _ _ _ _ _ _ _ |
        // | OPCODE  |  INFO   |   LOWER BYTE    |    UPPER BYTE   |
        //Example move packet:
        //| _ _ _ _  |    _    |   _ _ _  | _ _ _ _ _ _ _ _ | _ _ _ _ _ _ _ _ |
        //|  OPCODE  |Direction| Motor Id | Lower step byte | upper step byte |
        private bool Format_packet(byte OPCODE, Direction dir, int motor_id, ushort command, ref byte[] packet, int sz) {

            #if (DEBUG_MODE)
                Console.WriteLine("Entered UART packet format function");
            #endif

            for (int i = 0; i < sz; i++) 
                packet[i] = 0;

            switch (OPCODE) {
                case PSoC_OpCodes.RIM_OP_MOTOR_STOP:
                    packet[0] |= PSoC_OpCodes.RIM_OP_MOTOR_STOP;

                    if (motor_id > CONNECTED_MOTORS)
                        return false;

                    packet[0] |= (byte)motor_id;
                    packet[1] |= (byte)command;
                    packet[2] |= (byte)(command >> 8);
                    break;

                case PSoC_OpCodes.RIM_OP_MOTOR_RUN:

                    packet[0] |= PSoC_OpCodes.RIM_OP_MOTOR_RUN;

                    if (dir == Direction.COUNTERCLOCKWISE)
                        packet[0] |= 0x08;

                    if (motor_id > CONNECTED_MOTORS)
                    {
                        return false;
                    }

                    packet[0] |= (byte)motor_id;
                    packet[1] |= (byte)command;
                    packet[2] |= (byte)(command >> 8);
                    break;
                case PSoC_OpCodes.RIM_OP_MOTOR_STATUS:
                    packet[0] |= PSoC_OpCodes.RIM_OP_MOTOR_STATUS;
                    packet[0] |= (byte)motor_id;
                    break;

                case PSoC_OpCodes.RIM_OP_ENCODER_INFO:
                    packet[0] |= PSoC_OpCodes.RIM_OP_ENCODER_INFO;
                    packet[0] |= (byte)motor_id;
                    break;

                case PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM:
                    packet[0] |= PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM;
                    if (dir == Direction.COUNTERCLOCKWISE)
                        packet[0] |= 0x08;
                    packet[0] |= (byte)motor_id;
                    packet[1] |= (byte)command;
                    packet[2] |= (byte)(command >> 8);
                    break;
                case PSoC_OpCodes.RIM_OP_SERVO:
                    packet[0] |= (byte)motor_id;
                    packet[0] |= PSoC_OpCodes.RIM_OP_SERVO;
                    packet[1] |= (byte)command;
                    packet[2] |= (byte)(command >> 8);
                    break;
            }



            #if (DEBUG_MODE)
                Console.WriteLine("UART command formatted to: " + packet[0].ToString() + " " + packet[1].ToString() + " " + packet[2].ToString());
            #endif

            return true;
        }

        //Send a set of given stepper commands through UART
        private void UART_prep_send_command(PreciseExecution_steps commands)
        {

            #if (DEBUG_MODE)
                Console.WriteLine("Entered UART SendCommand");
            #endif

            byte[] packet = new byte[3];


            for (int i = 0; i < commands.motor_num; i++)
            {
                if (commands.motors[i] != 0 && i < 5)
                {
                    //Format packet into motor id, the command, and direction
                    Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_RUN, commands.motor_dirs[i], i, commands.motors[i], ref packet, 3);

                    #if (DEBUG_MODE)
                        Debug_Output(packet, 3);
                    #endif

                    UART_COM.Write(Byte_array_to_literal_string(packet, 3));


                }
                else if (i > 4)
                {
                    Format_packet(PSoC_OpCodes.RIM_OP_SERVO, commands.motor_dirs[i], i, commands.motors[i], ref packet, 3);

                #if (DEBUG_MODE)
                    Debug_Output(packet, 3);
                #endif

                    UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                }
                

            }

        }


        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to quit?", "Quit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void OVRModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurMode_lbl.Text = "Current Mode: OVR Mode";
            Disable_all('o');
        }

        private void PreciseExecutionModeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CurMode_lbl.Text = "Current Mode: Precise Execution Mode";
            Disable_all('p');
        }

        private void ProgrammedExecutionModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurMode_lbl.Text = "Current Mode: Programmed Execution Mode";
            Disable_all('a');
        }

        private void TraverseLineModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurMode_lbl.Text = "Current Mode: Traverse Line Mode";
            Disable_all('t');
        }

        //When the start button is clicked
        private void Start_btn_Click(object sender, EventArgs e)
        {
            //Try to open the UART port
            if (!TryOpenCom())
                return;

            #if (DEBUG_MODE)
            Console.WriteLine("COM port " + UART_COM.PortName + " opened");
            #endif

            #if (DEBUG_MODE)
                Console.WriteLine("Start button pressed");
            #endif

            PreciseExecution_steps commands = new PreciseExecution_steps(7);
            RIM_PExec prog_commands = new RIM_PExec();
            


            switch (Check_enable())
            {
                //Case for OVR (Oculus Virtual Reality) mode. Currently TODO
                case 'o':
                    break;
                //Case for precise execution mode
                case 'p':
                    //Load the commands from the entry boxes into the 'commands' object 
                    PreciseExecutionMode_CheckValid(ref commands);
                    
                    //Format the commands and send them to the device
                    UART_prep_send_command(commands);
                    Stop_btn.Enabled = true;
                    Start_btn.Enabled = false;
                    break;
                //Case for programmed execution mode
                case 'a':
                    //Try to load the given script. If the script has an error in it, then fail the file load and return
                    if (ProgExec_parse_and_load(ref prog_commands, file_content))
                        ProgExecFLoad_lbl.Text = "File loaded succesfully";
                    else
                    {
                        ProgExecFLoad_lbl.Text = "File load failed!";
                        return;
                    }
                    Stop_btn.Enabled = true;
                    Start_btn.Enabled = false;

                    //Start programmed execution mode
                    ProgExec_start(prog_commands);
                    break;
                
                //Case for traverse line mode. Currently TODO
                case 't':
                    break;
                default:
                    break;
            }


        }

        //Stop button code. Currently does nothing except changed the state of the start and stop buttons.
        //TODO
        private void Stop_btn_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[3];

            Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_STOP, 0, 0, PSoC_OpCodes.ALL_SSTOP,ref packet, 3);

            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            Stop_btn.Enabled = false;
            Start_btn.Enabled = true;
        }

        ConfigBox Cfg_box = new ConfigBox();

        //Function to load the config menu for the motor driver parameters
        private void SetUARTCOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bool intended to be used for detecting if a value changes within a user entry box
            bool[] is_changed = new bool[4];
            for (int i = 0; i < 4; i++)
                is_changed[i] = false;

            
            Cfg_box.StartPosition = StartPosition;

            //Update the information of the config box to match the actual settings
            var temp = Cfg_box.CfgBox_Motor_Settings;
            All_MSettings.Copy(ref temp);
            Cfg_box.CfgBox_Motor_Settings = temp;

            Cfg_box.ShowDialog();

            if (UART_COM.IsOpen == true)
                UART_COM.Close();

            CurUartCom_lbl.Text = "Current COM" + Cfg_box.COMNumber.ToString();
            UART_COM.PortName = "COM" + Cfg_box.COMNumber.ToString();
            if (!TryOpenCom())
                return;

            AUEncoder_toggle.Enabled = true;

            //Loop until user presses the "Ok" button on the config menu
            while (true)
            {
                //If the user has asked the device for all of its parameters, fetch them and display to the user
                if (Cfg_box.Fetch_btn_pressed == true)
                {
                    Cfg_box.Param_Enables = true;
                    Cfg_box.Fetch_btn_pressed = false;

                    byte[] packet = new byte[3];

                    //Fetch the maximum acceleration of each connected motor mode (in steps/s^2)
                    for (int i = 0; i < CONNECTED_MOTORS; i++)
                    {
                        Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM, PSoC_OpCodes.GETSET_GET_PARAM, i, 0 | L6470_Params.ACC, ref packet, 3);
                        UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                    }
                    Thread.Sleep(10);

                    //Fetch the maximum decceleration of each connected motor mode (in steps/s^2)
                    for (int i = 0; i < CONNECTED_MOTORS; i++)
                    {
                        Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM, PSoC_OpCodes.GETSET_GET_PARAM, i, 0 | L6470_Params.DECEL, ref packet, 3);
                        UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                    }
                    Thread.Sleep(10);

                    //Fetch the step mode of each connected motor (full step, half step etc)
                    for (int i = 0; i < CONNECTED_MOTORS; i++)
                    {
                        Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM, PSoC_OpCodes.GETSET_GET_PARAM, i, 0 | L6470_Params.STEP_MODE, ref packet, 3);
                        UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                    }
                    Thread.Sleep(10);

                    //Fetch the step mode of each connected motor (full step, half step etc)
                    for (int i = 0; i < CONNECTED_MOTORS; i++)
                    {
                        Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM, PSoC_OpCodes.GETSET_GET_PARAM, i, 0 | L6470_Params.MAX_SPEED, ref packet, 3);
                        UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                    }
                    Thread.Sleep(10);

                }

                //If the user has pressed the "set" button, check to see what the user has changed. 
                //Send any changed parameters to the device and update the config menu accordingly 
                if (Cfg_box.Set_btn_pressed == true)
                {
                    byte[] packet = new byte[3];
                    Cfg_box.Set_btn_pressed = false;
                    for (int i = 0; i < CONNECTED_MOTORS; i++)
                    {
                        if (!All_MSettings.Compare(Cfg_box.CfgBox_Motor_Settings.All_Motor_Settings[i], i, ref is_changed))
                        {
                            //Find which parameter has been changed, and for those send a parameter change command
                            if (All_MSettings.All_Motor_Settings[i].step_div != Cfg_box.CfgBox_Motor_Settings.All_Motor_Settings[i].step_div)
                            {
                                //For clarity, the following line does the following: I am sending a parameter set command, and I want to send the step mode that was typed into the config box by the user
                                Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM, (Direction)PSoC_OpCodes.GETSET_SET_PARAM, i, (ushort)(L6470_Params.STEP_MODE | (Cfg_box.CfgBox_Motor_Settings.Step_div_to_L6470Param(i) << 5)), ref packet, 3);
                                UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                                Thread.Sleep(10);
                            }
                            if (All_MSettings.All_Motor_Settings[i].max_speed != Cfg_box.CfgBox_Motor_Settings.All_Motor_Settings[i].max_speed)
                            {
                                //For clarity, the following line does the following: I am sending a parameter set command, and I want to send the max speed that was typed into the config box by the user
                                Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM, (Direction)PSoC_OpCodes.GETSET_SET_PARAM, i, (ushort)(L6470_Params.MAX_SPEED | (Cfg_box.CfgBox_Motor_Settings.All_Motor_Settings[i].max_speed << 5)), ref packet, 3);
                                UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                                Thread.Sleep(10);
                            }
                            if (All_MSettings.All_Motor_Settings[i].accel != Cfg_box.CfgBox_Motor_Settings.All_Motor_Settings[i].accel)
                            {
                                //For clarity, the following line does the following: I am sending a parameter set command, and I want to send the acceleration that was typed into the config box by the user
                                Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM, (Direction)PSoC_OpCodes.GETSET_SET_PARAM, i, (ushort)(L6470_Params.ACC | (Cfg_box.CfgBox_Motor_Settings.All_Motor_Settings[i].accel << 5)), ref packet, 3);
                                UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                                Thread.Sleep(10);
                            }
                            if (All_MSettings.All_Motor_Settings[i].decel != Cfg_box.CfgBox_Motor_Settings.All_Motor_Settings[i].decel)
                            {
                                //For clarity, the following line does the following: I am sending a parameter set command, and I want to send the decceleration that was typed into the config box by the user
                                Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM, (Direction)PSoC_OpCodes.GETSET_SET_PARAM, i, (ushort)(L6470_Params.DECEL | (Cfg_box.CfgBox_Motor_Settings.All_Motor_Settings[i].decel << 5)), ref packet, 3);
                                UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                                Thread.Sleep(10);
                            }
                        }
                    }
                    Thread.Sleep(100);
                }
                //If the user has pressed the ok button, just exit
                if(Cfg_box.Ok_btn_pressed == true)
                {
                    Cfg_box.Ok_btn_pressed = false;
                    break;
                }
                //Update the config settings
                All_MSettings.Copy(ref temp);
                Cfg_box.CfgBox_Motor_Settings = temp;

                Cfg_box.ShowDialog();
            }
        }

        private void Test_BTN_Click(object sender, EventArgs e)
        {
            /*
            byte[] packet = new byte[3];

            Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_STATUS, 0, 1, 0, ref packet, 3);

            if (!UART_COM.IsOpen)
            {
                try
                {
                    UART_COM.Open();
                }
                catch
                {
                    MessageBox.Show("Error: COM Port " + UART_COM.PortName + " is in use or doesn't exist!");
                    return;
                };
            }
            
            #if (DEBUG_MODE)
                Debug_Output(packet, 3);
            #endif
            */
        }

        //Get encoder info
        private void EncoderStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[3];

            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 0, 0, ref packet, 3);

            if (!UART_COM.IsOpen)
            {
                try
                {
                    UART_COM.Open();
                }
                catch
                {
                    MessageBox.Show("Error: COM Port " + UART_COM.PortName + " is in use or doesn't exist!");
                    return;
                };
            }

            #if (DEBUG_MODE)
                Debug_Output(packet, 3);
            #endif

            for (int i = 0; i < 100; i++)
            {
                
                UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                E1Running_ind.BackColor = Color.LimeGreen;
                Thread.Sleep(100);
            }
        }

        volatile bool Final_Encoder_Set = false;

        //Event handler for device data received
        private void UART_COM_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (!data_event_enabled)
                return;

            int msg;
            byte opcode = 0,
                   info = 0;

            byte[] rx = new byte[2];
            ushort response = 0;

            msg = UART_COM.ReadChar();
            opcode = (byte)(msg & 0xF0);
            info   = (byte)(msg & 0x0F);

            #if (DEBUG_MODE)
                Console.WriteLine("Received Opcode: " + opcode.ToString() + ", Info: " + info.ToString());
#endif

            if (opcode == PSoC_OpCodes.RIM_OP_MOTOR_RUN)
            {
                Motor_Active[info] = true;
                Set_ind_backcolor(info, Color.LimeGreen);

#if (DEBUG_MODE)
                Console.WriteLine("Received a motor start confirm");
#endif

            }
            else if (opcode == PSoC_OpCodes.RIM_OP_SERVO)
            {
                if (info == 0x05)
                {
                    rx[0] = (byte)UART_COM.ReadChar();
                    
                    response = rx[0];
                    
                    Set_ind_backcolor(info, Color.Gold);
                    
                    Console.Write("Servo 1 angle: " + response + "\n");

                    if (Start_btn.InvokeRequired)
                        Start_btn.Invoke(new MethodInvoker(delegate { Start_btn.Enabled = true; }));
                    if (Stop_btn.InvokeRequired)
                        Stop_btn.Invoke(new MethodInvoker(delegate { Stop_btn.Enabled = false; }));

                }
                else
                {
                    Set_ind_backcolor(info, Color.Gold);
                    
                    Console.Write("Servo 2 confirmation: " + response + "\n");

                    if (Start_btn.InvokeRequired)
                        Start_btn.Invoke(new MethodInvoker(delegate { Start_btn.Enabled = true; }));
                    if (Stop_btn.InvokeRequired)
                        Stop_btn.Invoke(new MethodInvoker(delegate { Stop_btn.Enabled = false; }));
                }
            }
            else if (opcode == PSoC_OpCodes.RIM_OP_MOTOR_STOP)
            {
                Set_ind_backcolor(info, Color.Gold);
                Motor_Active[info] = false;

                //Checker for if at least one motor is active
                bool motor_on = false;

                for (int i = 0; i < CONNECTED_MOTORS; i++)
                {
                    if (Motor_Active[i] == true)
                        motor_on = true;
                }

                //If all motors are off, reenable the start button
                if (!motor_on)
                {
                    if (Start_btn.InvokeRequired)
                        Start_btn.Invoke(new MethodInvoker(delegate { Start_btn.Enabled = true; }));
                    if (Stop_btn.InvokeRequired)
                        Stop_btn.Invoke(new MethodInvoker(delegate { Stop_btn.Enabled = false; }));
                }

#if (DEBUG_MODE)
                Console.WriteLine("Received a motor stop message");
#endif

            }
            else if (opcode == PSoC_OpCodes.RIM_OP_MOTOR_STATUS)
            {

                rx[0] = (byte)UART_COM.ReadChar();
                rx[1] = (byte)UART_COM.ReadChar();
                response |= rx[0];
                response |= (ushort)(rx[1] << 8);

                Set_ind_backcolor(info, Color.Gold);

#if (DEBUG_MODE)
                Console.WriteLine("Motor Driver id" + info.ToString() + "Responded with: " + response.ToString("X2"));
#endif

            }
            else if (opcode == PSoC_OpCodes.RIM_OP_RESET_DEV)
            {

                rx[0] = (byte)UART_COM.ReadChar();
                rx[1] = (byte)UART_COM.ReadChar();
                response |= rx[0];
                response |= (ushort)(rx[1] << 8);

                Set_ind_backcolor(info, Color.Gold);

#if (DEBUG_MODE)
                Console.WriteLine("Motor Driver id" + info.ToString() + "Responded with: " + response.ToString("X2"));
#endif
            }
            else if (opcode == PSoC_OpCodes.RIM_OP_MOTOR_GETSET_PARAM)
            {
                rx[0] = (byte)UART_COM.ReadChar();
                rx[1] = (byte)UART_COM.ReadChar();
                response |= rx[0];
                response |= (ushort)(rx[1] << 8);

                byte m_id = (byte)(info & 0x07);
                byte param_type = (byte)(response & PSoC_OpCodes.GETSET_RECEIVED_PARAM_TYPE);
                ushort param_info = (ushort)((response & PSoC_OpCodes.GETSET_RECEIVED_PARAM_DATA) >> 5);
                switch (param_type)
                {
                    case L6470_Params.ACC:
                        All_MSettings.Set_acc(m_id, param_info * 2);
                        break;
                    case L6470_Params.STEP_MODE:
                        All_MSettings.Set_step_div(m_id, param_info * 1);
                        break;
                    case L6470_Params.DECEL:
                        All_MSettings.Set_decel(m_id, param_info * 2);
                        break;
                    case L6470_Params.MAX_SPEED:
                        All_MSettings.Set_max_speed(m_id, param_info * 2);
                        break;
                }

#if (DEBUG_MODE)
                Console.WriteLine("Motor Driver id: " + m_id.ToString() + " With PARAM TYPE: " + param_type.ToString("X2") + " Responded with: " + param_info.ToString("X2"));
#endif



            }
            else if (opcode == PSoC_OpCodes.RIM_OP_ENCODER_INFO)
            {
                Final_Encoder_Set = false;

                rx[0] = (byte)UART_COM.ReadChar();
                rx[1] = (byte)UART_COM.ReadChar();
                response |= rx[0];
                response |= (ushort)(rx[1] << 8);

                byte m_id = (byte)(info & 0x07);
                if (m_id > CONNECTED_ENCODERS)
                {
#if (DEBUG_MODE)
                    Console.WriteLine("Encoder id " + info.ToString() + " is out of bounds!\n");
#endif

                    return;
                }

                if (response == 0xFFFF)
                {
#if (DEBUG_MODE)
                    Console.WriteLine("Encoder id " + info.ToString() + " timed out!\n");
#endif

                    Set_Encoder_label(m_id, "ERR");
                    return;
                }


                Encoder_Values[m_id] = response;

                Set_ind_backcolor(m_id + 7, Color.Gold);

#if (DEBUG_MODE)
                Console.WriteLine("Encoder id " + info.ToString() + " is currently at position: " + response.ToString());
#endif

                if (m_id == 4)
                {
                    Final_Encoder_Set = true;
                }

                Set_Encoder_label(m_id, response.ToString());

            }

            #if (DEBUG_MODE)
                Console.WriteLine("---------------------");
            #endif

        }

        //Closes the port on form close
        private void Main_wnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            UART_COM.Close();
        }

        private void MATLABScriptRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //matlab.Execute(@"cd C:\MATLABScript\");
            //matlab.Feval("moveRIM", 6, out object result, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 400.0, 400.0, 400.0, 0.0, 0.0, 0.0);
            //object[] res = result as object[];
            //Console.WriteLine(res[0]);
            //Console.WriteLine(res[1]);
            //Console.WriteLine(res[2]);
            //Console.WriteLine(res[3]);
            //Console.WriteLine(res[4]);
            //Console.WriteLine(res[5]);
        }

        private void ClearConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.Clear();
        }

        private void LoadFile_btn_Click(object sender, EventArgs e)
        {
            string fpath = string.Empty;
            //string startpath = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = startpath;
                openFileDialog.Filter = "RIM Execution Files (*.rime)|*.rime";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    fpath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        file_content = reader.ReadToEnd();
                        
                    }
                    //Remove cariage return
                    file_content = file_content.Replace("\r", "");
                    ProgExecFLoad_lbl.Text = "File Loaded";

                    FileCheck_btn.Enabled = true;
                    FileReload_btn.Enabled = true;
                }
            }
            
        }
        //Checks to see if the file has any syntax errors.
        //If there is no errors, then inform the user that it has passed the file check
        //Else there is syntax errors 
        private void FileCheck_btn_Click(object sender, EventArgs e)
        {
            RIM_PExec temp = new RIM_PExec();
            if (ProgExec_parse_and_load(ref temp, file_content))
            {
                ProgExecFLoad_lbl.Text = "File passed check";
            }
            else
            {
                ProgExecFLoad_lbl.Text = "File failed check";
            }
        }


        private void IndStatusCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ind_Label_Ctrl status = new Ind_Label_Ctrl();
            //status.i status[0];
        }


        private void StepMode_btn_Click(object sender, EventArgs e)
        {
            //Clear all text from controls
            Stepper1_entry.Clear();
            Stepper2_entry.Clear();
            Stepper3_entry.Clear();
            Stepper4_entry.Clear();
            Stepper5_entry.Clear();
            Servo1_entry.Clear();
            Servo2_entry.Clear();
            //Reset control masks
            if (degree_mode)
            {
                Stepper1_entry.Mask = "#00000000000";
                Stepper2_entry.Mask = "#00000000000";
                Stepper3_entry.Mask = "#00000000000";
                Stepper4_entry.Mask = "#00000000000";
                Stepper5_entry.Mask = "#00000000000";
                Servo1_entry.Mask = @"000\°";
                Servo2_entry.Mask = "#00000000000";
                degree_mode = false;
                StepMode_lbl.Text = "Step Mode";
            }
            else
            {
                Stepper1_entry.Mask = @"#000\°";
                Stepper2_entry.Mask = @"#000\°";
                Stepper3_entry.Mask = @"#000\°";
                Stepper4_entry.Mask = @"#000\°";
                Stepper5_entry.Mask = @"#000\°";
                Servo1_entry.Mask = @"#000\°";
                Servo2_entry.Mask = @"#000\°";
                degree_mode = true;
                StepMode_lbl.Text = "Degree Mode";
            }
            
        }

        private void Status_Check()
        {
            byte[] packet = new byte[3];


            if (!TryOpenCom())
                return;

            #if (DEBUG_MODE)
                Debug_Output(packet, 3);
            #endif

            //Fetch the motor status from all connected motors
            for(int i = 0; i < CONNECTED_MOTORS; i++)
            {
                Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_STATUS, 0, i, 0, ref packet, 3);
                UART_COM.Write(Byte_array_to_literal_string(packet, 3));
            }
        }

        private void Encoder2Val_lbl_Click(object sender, EventArgs e)
        {
            if (UART_COM.IsOpen == false)
            {
                if (!TryOpenCom()) { return; };
            }

            byte[] packet = new byte[3];
            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 1, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));
        }

        private void Encoder3Val_lbl_Click(object sender, EventArgs e)
        {
            if (UART_COM.IsOpen == false)
            {
                if (!TryOpenCom()) { return; };
            }

            byte[] packet = new byte[3];
            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 2, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));
        }

        private void Encoder4Val_lbl_Click(object sender, EventArgs e)
        {
            if (UART_COM.IsOpen == false)
            {
                if (!TryOpenCom()) { return; };
            }

            byte[] packet = new byte[3];
            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 3, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));
        }

        private void Encoder5Val_lbl_Click(object sender, EventArgs e)
        {
            if (UART_COM.IsOpen == false)
            {
                if (!TryOpenCom()) { return; };
            }

            byte[] packet = new byte[3];
            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 4, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));
        }

        private void AUEncoder_toggle_Click(object sender, EventArgs e)
        {
            if (AUEncoder_toggle.Checked == true)
            {
                Encoder_FetchTimer.Start();
            }
            else
            {
                Encoder_FetchTimer.Stop();
            }
        }

        private void RstEncoder_btn_Click(object sender, EventArgs e)
        {
            Change_Encoder_Val_lbl(0, "0");
            Change_Encoder_Val_lbl(1, "0");
            Change_Encoder_Val_lbl(2, "0");
            Change_Encoder_Val_lbl(3, "0");
            Change_Encoder_Val_lbl(4, "0");
        }



        private bool Do_DH_Conversion(ref double[] DH_Convert, double[] Cur_position)
        {
            if (DH_Convert.Length != 6 || Cur_position.Length != 6)
            {
                for (int i = 0; i < DH_Convert.Length; i++)
                {
                    DH_Convert[i] = 0;
                }
                return false;
            }

            for (int i = 0; i < DH_Convert.Length; i++)
            {
                DH_Convert[i] = 0;
            }


            double x_pos,
                   y_pos,
                   z_pos,
                   pitch,
                   roll,
                   yaw;

            //Masked text box parser
            //X
            if (double.TryParse(X_entry.Text.Replace(" ", ""), out double x))
                x_pos = x * 1000;
            else
                x_pos = 0;
            //Y
            if (double.TryParse(Y_entry.Text.Replace(" ", ""), out x))
                y_pos = x * 1000;
            else
                y_pos = 0;

            //Z
            if (double.TryParse(Z_entry.Text.Replace(" ", ""), out x))
                z_pos = x * 1000;
            else
                z_pos = 0;

            //Pitch
            if (double.TryParse(Pitch_entry.Text.Replace("°", ""), out x))
                pitch = x * 1000;
            else
                pitch = 0;

            //Roll
            if (double.TryParse(Roll_entry.Text.Replace("°", ""), out x))
                roll = x * 1000;
            else
                roll = 0;

            //Yaw
            if (double.TryParse(Yaw_entry.Text.Replace("°", ""), out x))
                yaw = x * 1000;
            else
                yaw = 0;



            try
            {
                /*
                //matlab.Execute(@"cd C:\Users\kalfusg\Desktop\MatLab_Kinematics_Updated_for_Actual_DH_Parameters");
                //matlab.Feval("moveRIM", 6, out object result, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, x_pos, y_pos, z_pos, pitch, roll, yaw);
                object[] res = result as object[];
                Console.WriteLine(res[0]);
                Console.WriteLine(res[1]);
                Console.WriteLine(res[2]);
                Console.WriteLine(res[3]);
                Console.WriteLine(res[4]);
                Console.WriteLine(res[5]);

                for (int i = 0; i < 6; i++)
                    DH_Convert[i] = (double)res[i];

                
                if(DH_Convert[0] == -999)
                    return false;
                else
                    return true;
                */
            }
            catch (Exception e)
            {
                MessageBox.Show("Error encountered:  " + e.Message + "\n");
                return false;
            }
            return true;
        }



        private void Traverse_calc_Click(object sender, EventArgs e)
        {
            double[] DH_Stuff = new double[6];
            double[] curpos = new double[6];
            ushort result = 0;
            string sign = "";


            //If the DH conversion was successfull 
            if(Do_DH_Conversion(ref DH_Stuff, curpos))
            {
                for (uint i = 0; i < 6; i++)
                {
                    result = Degrees_to_steps(i, (decimal)Math.Abs(DH_Stuff[i]));

                    sign = DH_Stuff[i] < 0.0 ? "-" : "";

                    Console.Write("Motor ID " + i.ToString() + " needs to step: " + sign + result.ToString() + "\n");
                }
                TravModeError_lbl.Text = "Pass";
            }
            else
            {
                Console.Write("Error: Input was out of bounds!");
                TravModeError_lbl.Text = "Fail";
            }



        }

        private void DeviceStatusCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status_Check();
            //Check encoder 1
            //Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 0, 0, ref packet, 3);
            //UART_COM.Write(Byte_array_to_literal_string(packet, 3));
        }

        private void ResetDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If Com port could not be opened
            if (!TryOpenCom()) { return; };

            byte[] packet = new byte[3];
            Format_packet(PSoC_OpCodes.RIM_OP_RESET_DEV, 0, 0, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            Format_packet(PSoC_OpCodes.RIM_OP_RESET_DEV, 0, 1, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));
        }

        private void Encoder1Val_lbl_Click(object sender, EventArgs e)
        {
            if (UART_COM.IsOpen == false)
            {
                if (!TryOpenCom()) { return; };
            }

            byte[] packet = new byte[3];
            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 0, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            //Encoder_Update_1 = !Encoder_Update_1;
        }

        private void Get_All_Encoder_Values(bool wait = true)
        {


            byte[] packet = new byte[3];
            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 0, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 1, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 2, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 3, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 4, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            if (wait)
            {
                while (!Final_Encoder_Set); 
            }

        }



        private void Encoder_FetchTimer_Tick(object sender, EventArgs e)
        {
            if (!TryOpenCom())
            {
                Encoder_FetchTimer.Stop();
                if (AUEncoder_toggle.InvokeRequired)
                    AUEncoder_toggle.Invoke(new MethodInvoker(delegate { AUEncoder_toggle.Checked = false; }));
                return;
            }

            byte[] packet = new byte[3];

            for (int i = 0; i < CONNECTED_ENCODERS; i++)
            {
                if (Get_Encoder_label(i) == "ERR")
                    continue;

                Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, i, 0, ref packet, 3);
                UART_COM.Write(Byte_array_to_literal_string(packet, 3));
            }
        }
    }
}

