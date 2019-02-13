#define DEBUG_MODE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;


namespace R.I.M.UI_Shell
{
    public partial class Main_wnd : Form
    {
        //Make an instance of the window that allows the user to configure UART-related settings
        private ConfigBox Cfg_box = new ConfigBox();

        //Enum to keep track of
        public enum Direction {CLOCKWISE, COUNTERCLOCKWISE};

        MLApp.MLApp matlab = new MLApp.MLApp();

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
        private bool Format_packet(int motor_id, ushort command, Direction dir, ref byte[] packet, int sz) {

#if (DEBUG_MODE)
            Console.WriteLine("Entered UART packet format function");
#endif
            for (int i = 0; i < sz; i++) 
                packet[i] = 0;

            if (motor_id > 7) {
                return false;
            }

            if (dir == Direction.COUNTERCLOCKWISE)
                packet[0] |= 0x80;

            packet[0] |= (byte)(motor_id << 4);
            packet[1] |= (byte)(command);
            packet[2] |= (byte)(command >> 8);

#if (DEBUG_MODE)
            Console.WriteLine("UART command formatted to: " + packet[0].ToString() + " " + packet[1].ToString() + " " + packet[2].ToString());
#endif
            return true;
        }

        int UART_wait_for_msg() {
            int r = 0;
            while (r == 0)
            {
                r = UART_COM.ReadChar();
            };
#if (DEBUG_MODE)
            Console.WriteLine("Recieved: " + r.ToString() + " from the PSoC");
#endif
            return r;
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
                    Format_packet(i+1, commands.motors[i], commands.motor_dirs[i], ref packet, 3);

#if (DEBUG_MODE)
                    Debug_Output(packet, 3);
#endif
                    UART_COM.Write(Byte_array_to_literal_string(packet, 3));
                    UART_wait_for_msg();
                    if (packet[1] != 0) UART_wait_for_msg();
                    if (packet[2] != 0) UART_wait_for_msg();
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

        private void Start_btn_Click(object sender, EventArgs e)
        {
            //Do Start Stuff
#if (DEBUG_MODE)
            Console.WriteLine("Start button pressed");
#endif
            PreciseExecution_steps commands = new PreciseExecution_steps(7);


            try
            {
                UART_COM.Open();
            }
            catch
            {
                MessageBox.Show("Error: COM Port " + UART_COM.PortName + " is in use or doesn't exist!");
                return;
            };

#if (DEBUG_MODE)
            Console.WriteLine("COM port " + UART_COM.PortName + " opened");
#endif
            switch (Check_enable()) {
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
            Start_btn.Enabled = false;

            Running_ind.BackColor = Color.LimeGreen;
            Running_lbl.BackColor = Color.LimeGreen;
            Running_lbl.Text = "Running";

        }

        private void Stop_btn_Click(object sender, EventArgs e)
        {
            //Do Stop Stuff
            UART_COM.Close();

            Stop_btn.Enabled = false;
            Start_btn.Enabled = true;

            Running_ind.BackColor = Color.IndianRed;
            Running_lbl.BackColor = Color.IndianRed;
            Running_lbl.Text = "Not Running";
        }

        private void setUARTCOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cfg_box.StartPosition = this.StartPosition;
            Cfg_box.ShowDialog();

            CurUartCom_lbl.Text = "Current COM" + Cfg_box.COMNumber.ToString();
            UART_COM.PortName = "COM" + Cfg_box.COMNumber.ToString();
        }

        private void Test_BTN_Click(object sender, EventArgs e)
        {
            matlab.Execute(@"cd A:\Github\RIM UI\MATLAB Script");
            matlab.Feval("myfunc", 2, out object result, 3.14, 42.0, "world");
            object[] res = result as object[];
            Console.WriteLine(res[0]);
            Console.WriteLine(res[1]);
        }
    }
}

