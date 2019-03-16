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
        static class PSoC_OpCodes
        {
            //RIM Operation codes 
            public const byte RIM_OP_MOTOR_RUN           = 0x00,
                              RIM_OP_MOTOR_STOP          = 0x10,
                              RIM_OP_MOTOR_SET_PARAM     = 0x20,
                              RIM_OP_MOTOR_STATUS        = 0x30,
                              RIM_OP_ENCODER_INFO        = 0x40,
                              RIM_OP_ERROR               = 0x50,
                              RIM_OP_RESET_DEV           = 0x60,

                              RIM_OP_MOTOR_EXTENDED_STEP = 0x80;


        };

        public class RIM_PExec
        {
            public Queue<string>[] Motor_cmds;
            public Queue<string>[] Encoder_cmds;

            public RIM_PExec()
            {
                Motor_cmds = new Queue<string>[7];
                Encoder_cmds = new Queue<string>[7];

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

            //Step Selector
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

        //Make an instance of the window that allows the user to configure UART-related settings
        private ConfigBox Cfg_box = new ConfigBox();

        //Enum to keep track of
        public enum Direction {CLOCKWISE, COUNTERCLOCKWISE};

        string file_content = string.Empty;

        //Matlab console instance for DH parameters
        //MLApp.MLApp matlab = new MLApp.MLApp();

        //Toggle for telling system whether or not to update the UI on the encoder position
        bool Encoder_Update_1 = false,
             Encoder_Update_2 = false,
             Encoder_Update_3 = false,
             Encoder_Update_4 = false,
             Encoder_Update_5 = false;

        volatile public bool[] Motor_Active = new bool[5];

        bool data_event_enabled = true;


        //For storing the stepper motor steps during percise execution mode
        public struct PreciseExecution_steps
        {
            public int motor_num; 

            public ushort[] motors;

            public Direction[] motor_dirs;

            public PreciseExecution_steps(int motor_amount = 7)
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

        public class Ind_Label_Ctrl
        {
            public enum Ind_status {RUNNING, IDLE, DISCONNECT};

            private Ind_status[] Ind_labels;

            public Ind_Label_Ctrl()
            {
                //0-6 for motor status'
                //7-13 for encoder status'
                Ind_labels = new Ind_status[14];
                for(int i = 0; i < 14; i++)
                {
                    Ind_labels[i] = Ind_status.DISCONNECT;

                }
            }
            
            public Ind_status this[int key]
            {
                get
                {
                    return Ind_labels[key];
                }
                set
                {
                    //Set_window_element(key, Check_status(value));
                }
            }

            private Color Check_status(Ind_status status)
            {
                Color c = Color.Gold;
                if (status == Ind_status.DISCONNECT)
                    c = Color.IndianRed;
                else if (status == Ind_status.RUNNING)
                    c = Color.LimeGreen;
                return c;
            }


        } 
        
        public void Set_ind_backcolor(int id, Color c)
        {
            switch (id)
            {
                case 0:
                    M1Running_ind.BackColor = c;
                    break;
                case 1:
                    M2Running_ind.BackColor = c;
                    break;
                case 2:
                    M3Running_ind.BackColor = c;
                    break;
                case 3:
                    M4Running_ind.BackColor = c;
                    break;
                case 4:
                    M5Running_ind.BackColor = c;
                    break;
                case 5:
                    M6Running_ind.BackColor = c;
                    break;
                case 6:
                    M7Running_ind.BackColor = c;
                    break;
                case 7:
                    E1Running_ind.BackColor = c;
                    break;
                case 8:
                    E2Running_ind.BackColor = c;
                    break;
                case 9:
                    E3Running_ind.BackColor = c;
                    break;
                case 10:
                    E4Running_ind.BackColor = c;
                    break;
                case 11:
                    E5Running_ind.BackColor = c;
                    break;
            }
                
        }


        public Main_wnd()
        {
            InitializeComponent();
        }

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

        private void Main_wnd_Load(object sender, EventArgs e)
        {
            Disable_all();

            for (int i = 0; i < 5; i++)
            {
                Motor_Active[i] = false;
            }


            //Change UART encoding to ASCII-Extended for charicter code transfers > 127
            UART_COM.Encoding = System.Text.Encoding.GetEncoding(28591);
            //matlab.Visible = 0;
            FileCheck_btn.Enabled = false;
            FileReload_btn.Enabled = false;
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

            if (Int32.TryParse(Stepper1_entry.Text, out int x))
            {
                if (x < 0)
                    commands.motor_dirs[0] = Direction.COUNTERCLOCKWISE;

                if (Math.Abs(x) > 0xFFFF)
                    commands.motors[0] = 0xFFFF;
                else
                    commands.motors[0] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Stepper2_entry.Text, out x))
            {
                if (x < 0)
                    commands.motor_dirs[1] = Direction.COUNTERCLOCKWISE;

                if (Math.Abs(x) > 0xFFFF)
                    commands.motors[1] = 0xFFFF;
                else
                    commands.motors[1] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Stepper3_entry.Text, out x))
            {
                if (x < 0)
                    commands.motor_dirs[2] = Direction.COUNTERCLOCKWISE;
                if (Math.Abs(x) > 0xFFFF)
                    commands.motors[2] = 0xFFFF;
                else
                    commands.motors[2] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Stepper4_entry.Text, out x))
            {
                if (x < 0)
                    commands.motor_dirs[3] = Direction.COUNTERCLOCKWISE;
                if (Math.Abs(x) > 0xFFFF)
                    commands.motors[3] = 0xFFFF;
                else
                    commands.motors[3] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Stepper5_entry.Text, out x))
            {
                if (x < 0)
                    commands.motor_dirs[4] = Direction.COUNTERCLOCKWISE;

                if (Math.Abs(x) > 0xFFFF)
                    commands.motors[4] = 0xFFFF;
                else
                    commands.motors[4] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Servo1_entry.Text, out x))
            {
                if (x < 0)
                    commands.motor_dirs[5] = Direction.COUNTERCLOCKWISE;

                if (Math.Abs(x) > 0xFFFF)
                    commands.motors[5] = 0xFFFF;
                else
                    commands.motors[5] = (ushort)Math.Abs(x);
            }

            if (Int32.TryParse(Servo2_entry.Text, out x))
            {
                if (x < 0)
                    commands.motor_dirs[6] = Direction.COUNTERCLOCKWISE;

                if (Math.Abs(x) > 0xFFFF)
                    commands.motors[6] = 0xFFFF;
                else
                    commands.motors[6] = (ushort)Math.Abs(x);
            }

#if (DEBUG_MODE)
            Console.WriteLine("Done!");
#endif
        }

        //Programmed Execution Mode support
        bool ProgExec_parse_and_load(ref RIM_PExec commands, string finfo)
        {
            int line_num = 1;

            byte id = 0;
                 
            Direction dir = 0;

            ushort steps = 0;

            byte[] packet = new byte[3];


            bool error = false;
            Queue<string> errlist = new Queue<string>();

            bool[] cmd_written = new bool[7];
            for (int i = 0; i < 7; i++)
            {
                cmd_written[i] = false;
            }


            string []split_info = finfo.Split('\n');

            foreach (string line in split_info)
            {
                //Ignore a line if it has one of the following
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

                    line_num++;
                    continue;
                }

                if (temp[0] == "MOVE")
                {
                    if(temp.Length < 4)
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Not enough parameters. Expected 4, given " + temp.Length.ToString());
                        error = true;
                        continue;
                    }


                    line_num++;
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

                    //Check for amount of steps
                    if (!ushort.TryParse(temp[3], out ushort y))
                    {
                        errlist.Enqueue("Error with line " + line_num.ToString() + ": Invalid amount of steps: " + temp[3]);
                        error = true;
                    }
                    else
                        steps = y;

                    if (error)
                        continue;

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
            }
            return !error;
        }

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
            }
            return r;
        }

        //Start sequence for programmed exeuction mode
        void ProgExec_start(RIM_PExec commands)
        {
            data_event_enabled = false;

            string temp = string.Empty;
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

            Stopwatch[] MRunTime = new Stopwatch[7];

            for (int i = 0; i < 7; i++)
                MRunTime[i] = new Stopwatch();

            for (int i = 0; i < total_cmds; i++)
            {

                for (int j = 0; j < 7; j++)
                {
                    temp = commands.Motor_cmds[j].Dequeue();
                    if (temp == "PASS")
                    {
                        temp = string.Empty;
                    }
                    else
                    {
                        UART_COM.Write(temp);
                        sent_commands++;
                        do
                        {
                            int ch = UART_COM.ReadByte();
                            Console.Write("1 Byte Recieved\n");
                            int OPCODE = (0xF0 & ch) >> 4;
                            int M_ID = ch & 0x07;
                            if (OPCODE == 0x00)
                            {
                                Set_ind_backcolor(M_ID, Color.LimeGreen);
                                motor_idle[M_ID] = false;
                                motor_running[M_ID] = true;
                                MRunTime[M_ID].Start();
                            }
                            else
                            {
                                Set_ind_backcolor(M_ID, Color.Gold);
                                motor_running[M_ID] = false;
                                motor_idle[M_ID] = true;
                                MRunTime[M_ID].Stop();
                                TimeSpan ts = MRunTime[M_ID].Elapsed;
                                Change_Encoder_Val_lbl(M_ID, String.Format("{2:00}.{3:00}",
                                    ts.Hours, ts.Minutes, ts.Seconds,
                                    ts.Milliseconds / 10));
                            }

                        } while (motor_idle[j] == true);

                    }
                }

                //Wait for motors to be done
                while (!All_idle(motor_idle, 7))
                {
                    int ch = UART_COM.ReadByte();
                    Console.Write("1 Byte Recieved\n");
                    int OPCODE = (0xF0 & ch) >> 4;
                    int M_ID = ch & 0x07;
                    if (OPCODE == 0x00)
                    {
                        Set_ind_backcolor(M_ID, Color.LimeGreen);
                        motor_idle[M_ID] = false;
                        motor_running[M_ID] = true;
                        MRunTime[M_ID].Start();
                    }
                    else
                    {
                        Set_ind_backcolor(M_ID, Color.Gold);
                        motor_running[M_ID] = false;
                        motor_idle[M_ID] = true;
                        MRunTime[M_ID].Stop();
                        TimeSpan ts = MRunTime[M_ID].Elapsed;
                        Change_Encoder_Val_lbl(M_ID, String.Format("{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10));
                    }
                }

            }
            data_event_enabled = true;
            for (int i = 0; i < 7; i++)
                MRunTime[i].Reset();

        }

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
        private bool Format_packet(byte OPCODE, Direction dir, int motor_id, ushort command, ref byte[] packet, int sz) {

            #if (DEBUG_MODE)
                Console.WriteLine("Entered UART packet format function");
            #endif

            for (int i = 0; i < sz; i++) 
                packet[i] = 0;

            switch (OPCODE) {
                case PSoC_OpCodes.RIM_OP_MOTOR_RUN:

                    packet[0] |= PSoC_OpCodes.RIM_OP_MOTOR_RUN;

                    if (dir == Direction.COUNTERCLOCKWISE)
                        packet[0] |= 0x08;

                    if (motor_id > 7)
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
            }



            #if (DEBUG_MODE)
                Console.WriteLine("UART command formatted to: " + packet[0].ToString() + " " + packet[1].ToString() + " " + packet[2].ToString());
            #endif

            return true;
        }

        byte UART_wait_for_msg() {
            int r = 0;
            while (r == 0)
            {
                r = UART_COM.ReadChar();
            };
                #if (DEBUG_MODE)
                    Console.WriteLine("Recieved: " + r.ToString() + " from the PSoC");
                #endif
            return (byte)r;
        }


        //Send a given stepper commands through UART
        private void UART_prep_send_command(PreciseExecution_steps commands)
        {

            #if (DEBUG_MODE)
                Console.WriteLine("Entered UART SendCommand");
            #endif

            byte[] packet = new byte[3];


            for (int i = 0; i < commands.motor_num; i++)
            {
                if (commands.motors[i] != 0)
                {
                    //Format packet into motor id, the command, and direction
                    Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_RUN, commands.motor_dirs[i], i, commands.motors[i], ref packet, 3);

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
            TryOpenCom();

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
                case 'o':
                    break;
                case 'p':
                    PreciseExecutionMode_CheckValid(ref commands);
                    UART_prep_send_command(commands);
                    break;
                case 'a':
                    if (ProgExec_parse_and_load(ref prog_commands, file_content))
                        ProgExecFLoad_lbl.Text = "File loaded succesfully";
                    else
                    {
                        ProgExecFLoad_lbl.Text = "File load failed!";
                        return;
                    }
                    ProgExec_start(prog_commands);
                    break;
                case 't':
                    break;
                default:
                    break;
            }


            Stop_btn.Enabled = true;
            //Start_btn.Enabled = false;

            //M1Running_ind.BackColor = Color.LimeGreen;
            //M1_lbl.BackColor = Color.LimeGreen;
            //M1_lbl.Text = "Running";

        }

        private void Stop_btn_Click(object sender, EventArgs e)
        {
            //Do Stop Stuff
            try
            {
                UART_COM.Close();
            }
            catch
            {
                return;
            }

            Stop_btn.Enabled = false;
            //Start_btn.Enabled = true;

            //M1Running_ind.BackColor = Color.IndianRed;
            //M1_lbl.BackColor = Color.IndianRed;
            //M1_lbl.Text = "Not Running";
        }

        private void SetUARTCOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cfg_box.StartPosition = this.StartPosition;
            Cfg_box.ShowDialog();

            if (UART_COM.IsOpen == true)
                UART_COM.Close();

            CurUartCom_lbl.Text = "Current COM" + Cfg_box.COMNumber.ToString();
            UART_COM.PortName = "COM" + Cfg_box.COMNumber.ToString();

            TryOpenCom();
        }

        private void Test_BTN_Click(object sender, EventArgs e)
        {
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

            UART_COM.Write(Byte_array_to_literal_string(packet, 3));
            

            //matlab.Execute(@"cd C:\MATLAB_Script");
            //matlab.Feval("myfunc", 2, out object result, 3.14, 42.0, "world");
            //object[] res = result as object[];
            //Console.WriteLine(res[0]);
            //Console.WriteLine(res[1]);
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

        //Event handler for PSoC data recieved
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
                Console.WriteLine("Recieved Opcode: " + opcode.ToString() + ", Info: " + info.ToString());
            #endif

            if (opcode == PSoC_OpCodes.RIM_OP_MOTOR_RUN)
            {
                switch (info)
                {
                    case 0:
                        M1Running_ind.BackColor = Color.LimeGreen;
                        Motor_Active[0] = true;
                        #if (DEBUG_MODE)
                            Console.WriteLine("Recieved a motor start confirm");
                        #endif

                        Encoder_Update_1 = true;

                        break;
                    case 1:
                        Motor_Active[1] = true;
                        M2Running_ind.BackColor = Color.LimeGreen;

                        #if (DEBUG_MODE)
                            Console.WriteLine("Recieved a motor start confirm");
                        #endif

                        break;

                    case 2:
                        Motor_Active[2] = true;
                        M3Running_ind.BackColor = Color.LimeGreen;

                        #if (DEBUG_MODE)
                            Console.WriteLine("Recieved a motor start confirm");
                        #endif
                        break;

                    case 3:
                        Motor_Active[3] = true;
                        M4Running_ind.BackColor = Color.LimeGreen;

                        #if (DEBUG_MODE)
                        Console.WriteLine("Recieved a motor start confirm");
                        #endif
                        break;

                    default:

                        break;
                }
            }
            else if (opcode == PSoC_OpCodes.RIM_OP_MOTOR_STOP)
            {
                switch (info)
                {
                    case 0:
                        M1Running_ind.BackColor = Color.Gold;

                        Motor_Active[0] = false;

                        if (Stop_btn.InvokeRequired)
                            Stop_btn.Invoke(new MethodInvoker(delegate { Stop_btn.Enabled = false; }));
                        if (Start_btn.InvokeRequired)
                            Start_btn.Invoke(new MethodInvoker(delegate { Start_btn.Enabled = true; }));

                        Encoder_Update_1 = false;

                        #if (DEBUG_MODE)
                            Console.WriteLine("Recieved a motor stop message");
                        #endif

                        break;

                    case 1:
                        Motor_Active[1] = false;
                        M2Running_ind.BackColor = Color.Gold;

                        if (Stop_btn.InvokeRequired)
                            Stop_btn.Invoke(new MethodInvoker(delegate { Stop_btn.Enabled = false; }));
                        if (Start_btn.InvokeRequired)
                            Start_btn.Invoke(new MethodInvoker(delegate { Start_btn.Enabled = true; }));

                        #if (DEBUG_MODE)
                            Console.WriteLine("Recieved a motor stop message");
                        #endif

                        break;

                    case 2:
                        Motor_Active[2] = false;
                        M3Running_ind.BackColor = Color.Gold;

                        if (Stop_btn.InvokeRequired)
                            Stop_btn.Invoke(new MethodInvoker(delegate { Stop_btn.Enabled = false; }));
                        if (Start_btn.InvokeRequired)
                            Start_btn.Invoke(new MethodInvoker(delegate { Start_btn.Enabled = true; }));

                        #if (DEBUG_MODE)
                            Console.WriteLine("Recieved a motor stop message");
                        #endif

                        break;

                    case 3:
                        Motor_Active[3] = false;
                        M4Running_ind.BackColor = Color.Gold;

                        if (Stop_btn.InvokeRequired)
                            Stop_btn.Invoke(new MethodInvoker(delegate { Stop_btn.Enabled = false; }));
                        if (Start_btn.InvokeRequired)
                            Start_btn.Invoke(new MethodInvoker(delegate { Start_btn.Enabled = true; }));

                        #if (DEBUG_MODE)
                            Console.WriteLine("Recieved a motor stop message");
                        #endif

                        break;

                    default:
                        break;
                }
            }
            else if (opcode == PSoC_OpCodes.RIM_OP_MOTOR_STATUS)
            {
                switch (info)
                {
                    case 0:
                        rx[0] = (byte)UART_COM.ReadChar();
                        rx[1] = (byte)UART_COM.ReadChar();
                        response |= rx[0];
                        response |= (ushort)(rx[1] << 8);

                        M1Running_ind.BackColor = Color.Gold;

                        #if (DEBUG_MODE)
                            Console.WriteLine("Motor Driver id 0 Responded with: " + response.ToString("X2"));
                        #endif

                        break;
                    case 1:
                        rx[0] = (byte)UART_COM.ReadChar();
                        rx[1] = (byte)UART_COM.ReadChar();
                        response |= rx[0];
                        response |= (ushort)(rx[1] << 8);

                        M2Running_ind.BackColor = Color.Gold;

                        #if (DEBUG_MODE)
                            Console.WriteLine("Motor Driver id 1 Responded with: " + response.ToString("X2"));
                        #endif

                        break;

                    case 2:
                        rx[0] = (byte)UART_COM.ReadChar();
                        rx[1] = (byte)UART_COM.ReadChar();
                        response |= rx[0];
                        response |= (ushort)(rx[1] << 8);

                        M3Running_ind.BackColor = Color.Gold;

                        #if (DEBUG_MODE)
                            Console.WriteLine("Motor Driver id 2 Responded with: " + response.ToString("X2"));
                        #endif

                        break;
                    case 3:
                        rx[0] = (byte)UART_COM.ReadChar();
                        rx[1] = (byte)UART_COM.ReadChar();
                        response |= rx[0];
                        response |= (ushort)(rx[1] << 8);

                        M4Running_ind.BackColor = Color.Gold;

                        #if (DEBUG_MODE)
                            Console.WriteLine("Motor Driver id 3 Responded with: " + response.ToString("X2"));
                        #endif

                        break;


                }
            }
            else if (opcode == PSoC_OpCodes.RIM_OP_RESET_DEV)
            {
                switch (info)
                {
                    case 0:
                        rx[0] = (byte)UART_COM.ReadChar();
                        rx[1] = (byte)UART_COM.ReadChar();
                        response |= rx[0];
                        response |= (ushort)(rx[1] << 8);

                        M1Running_ind.BackColor = Color.Gold;

                        #if (DEBUG_MODE)
                            Console.WriteLine("Motor Driver id 0 Responded with: " + response.ToString("X2"));
                        #endif

                        break;
                    case 1:
                        rx[0] = (byte)UART_COM.ReadChar();
                        rx[1] = (byte)UART_COM.ReadChar();
                        response |= rx[0];
                        response |= (ushort)(rx[1] << 8);


                        M2Running_ind.BackColor = Color.Gold;

                        #if (DEBUG_MODE)
                            Console.WriteLine("Motor Driver id 1 Responded with: " + response.ToString("X2"));
                        #endif

                        break;

                }
            }

            else if (opcode == PSoC_OpCodes.RIM_OP_ENCODER_INFO)
            {
                switch (info)
                {
                    case 0:
                        E1Running_ind.BackColor = Color.Gold;
                        rx[0] = (byte)UART_COM.ReadChar();
                        rx[1] = (byte)UART_COM.ReadChar();
                        response |= rx[0];
                        response |= (ushort)(rx[1] << 8);
                        


                        #if (DEBUG_MODE)
                            Console.WriteLine("Encoder id 0 is currently at position: " + response.ToString());
                        #endif


                        if (Encoder1Val_lbl.InvokeRequired)
                            Encoder1Val_lbl.Invoke(new MethodInvoker(delegate { Encoder1Val_lbl.Text = response.ToString(); }));
                        

                        break;
                }

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
            //matlab.Execute(@"cd C:\MATLAB_Script");
            //matlab.Feval("myfunc", 2, out object result, 3.14, 42.0, "world");
            //object[] res = result as object[];
            //Console.WriteLine(res[0]);
            //Console.WriteLine(res[1]);
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
            Ind_Label_Ctrl status = new Ind_Label_Ctrl();
            //status.i status[0];
        }

        private void DeviceStatusCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[3];

            Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_STATUS, 0, 0, 0, ref packet, 3);

            TryOpenCom();

            #if (DEBUG_MODE)
            Debug_Output(packet, 3);
            #endif

            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            //Check Motor 2
            Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_STATUS, 0, 1, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            //Check Motor 3
            Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_STATUS, 0, 2, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

            //Check Motor 4
            Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_STATUS, 0, 3, 0, ref packet, 3);
            UART_COM.Write(Byte_array_to_literal_string(packet, 3));

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
            Encoder_Update_1 = !Encoder_Update_1;
        }

        private void Encoder_FetchTimer_Tick(object sender, EventArgs e)
        {
            //TryOpenCom();

            byte[] packet = new byte[3];

            for (int i = 0; i < 2; i++)
            {
                if (Encoder_Update_1) {
                    //Format_packet(PSoC_OpCodes.RIM_OP_ENCODER_INFO, 0, 0, 0, ref packet, 3);
                    //UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                }
                //if (Encoder_Update_2)
                //{
                //    Format_packet(PSoC_OpCodes.RIM_OP_RESET_DEV, 0, 0, 0, ref packet, 3);
                //    UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                //}

            }
        }
    }
}

