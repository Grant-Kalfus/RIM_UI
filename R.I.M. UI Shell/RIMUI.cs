#define DEBUG_MODE

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;

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

        class RIM_PExec
        {
            RIM_PExec()
            {
                Queue[] Motor_Cmds   = new Queue[7];
                Queue[] Encoder_Cmds = new Queue[7];
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

        //Matlab console instance for DH parameters
        MLApp.MLApp matlab = new MLApp.MLApp();

        //Toggle for telling system whether or not to update the UI on the encoder position
        bool Encoder_Update_1 = false,
             Encoder_Update_2 = false,
             Encoder_Update_3 = false,
             Encoder_Update_4 = false,
             Encoder_Update_5 = false;


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


        public Main_wnd()
        {
            InitializeComponent();
            Disable_all();
            //Change UART encoding to ASCII-Extended for charicter code transfers > 127
            UART_COM.Encoding = System.Text.Encoding.GetEncoding(28591);
            matlab.Visible = 0;
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

        //Programmed Execution Mode supports
        void PMode_parse_and_load(ref Queue[] cmds, string[] finfo)
        {
            int index = 0;
            bool error = false;
            Queue errlist;

            foreach (string line in finfo) {

                if (line[0] == '#')
                {
                    index++;
                    continue;
                }

                string[] temp = line.Split(',');
                if (temp[0] == "move")
                {
                    if (!int.TryParse(temp[1], out int x))
                    {
                        //Console.WriteLine("Syntax error with line: " + index.ToString() + " ");
                        //errlist.Enqueue(index.ToString() + );
                        error = true;
                        continue;
                    }
                    else
                    {

                    }

                }


                index++;
            }
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
            //Do Start Stuff
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
                Console.WriteLine("COM port " + UART_COM.PortName + " opened");
            #endif

            #if (DEBUG_MODE)
                Console.WriteLine("Start button pressed");
            #endif

            PreciseExecution_steps commands = new PreciseExecution_steps(7);

            switch (Check_enable())
            {
                case 'o':
                    break;
                case 'p':
                    PreciseExecutionMode_CheckValid(ref commands);
                    UART_prep_send_command(commands);
                    break;
                case 'a':
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

            CurUartCom_lbl.Text = "Current COM" + Cfg_box.COMNumber.ToString();
            UART_COM.PortName = "COM" + Cfg_box.COMNumber.ToString();
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

                        #if (DEBUG_MODE)
                            Console.WriteLine("Recieved a motor start confirm");
                        #endif

                        Encoder_Update_1 = true;

                        break;
                    case 1:
                        M2Running_ind.BackColor = Color.LimeGreen;

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
                        M2Running_ind.BackColor = Color.Gold;

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
            matlab.Execute(@"cd C:\MATLAB_Script");
            matlab.Feval("myfunc", 2, out object result, 3.14, 42.0, "world");
            object[] res = result as object[];
            Console.WriteLine(res[0]);
            Console.WriteLine(res[1]);
        }

        private void ClearConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.Clear();
        }

        private void LoadFile_btn_Click(object sender, EventArgs e)
        {
            string fpath = string.Empty;
            string fileContent = string.Empty;
            string startpath = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = startpath;
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
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

        }

        private void DeviceStatusCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[3];

            Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_STATUS, 0, 0, 0, ref packet, 3);

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

            //Check Motor 2
            Format_packet(PSoC_OpCodes.RIM_OP_MOTOR_STATUS, 0, 1, 0, ref packet, 3);
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

