using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R.I.M.UI_Shell
{
    public partial class ConfigBox : Form
    {
        public ConfigBox()
        {
            InitializeComponent();
            Param_Enables = false;
            Set_btn_pressed = false;

            PortList_lst.Items.Clear();
            PortList_lst.Items.AddRange(SerialPort.GetPortNames());
        }

        public bool Set_btn_pressed   { get; set; }
        public bool Fetch_btn_pressed { get; set; }
        public bool Ok_btn_pressed    { get; set; }

        public Main_wnd.Motor_Settings CfgBox_Motor_Settings{ get; set; } = new Main_wnd.Motor_Settings(); 

        public bool Param_Enables
        {
            get { return Dev_Config.Enabled; }
            set
            {
                Dev_Config.Enabled = value;
                Ok_btn.Enabled = value;
                Set_btn.Enabled = value;
            }
        }


        public int COMNumber { get; private set; }


        private int Step_type_entry_index_translator(Main_wnd.Motor_Settings.Step_types step_type)
        {
            int r = 0;
            switch (step_type)
            {
                case Main_wnd.Motor_Settings.Step_types.Step_1:
                    r = 0;
                    break;
                case Main_wnd.Motor_Settings.Step_types.Step_2:
                    r = 1;
                    break;
                case Main_wnd.Motor_Settings.Step_types.Step_4:
                    r = 2;
                    break;
                case Main_wnd.Motor_Settings.Step_types.Step_8:
                    r = 3;
                    break;
                case Main_wnd.Motor_Settings.Step_types.Step_16:
                    r = 4;
                    break;
                case Main_wnd.Motor_Settings.Step_types.Step_32:
                    r = 5;
                    break;
                case Main_wnd.Motor_Settings.Step_types.Step_64:
                    r = 6;
                    break;
                case Main_wnd.Motor_Settings.Step_types.Step_128:
                    r = 7;
                    break;
            }
            return r;
        }

        private void Select_step_type(int index)
        {
            switch (index)
            {
                case 0:
                    M1StepType_entry.SelectedIndex = Step_type_entry_index_translator(CfgBox_Motor_Settings.All_Motor_Settings[0].step_div);
                    break;
                case 1:
                    M2StepType_entry.SelectedIndex = Step_type_entry_index_translator(CfgBox_Motor_Settings.All_Motor_Settings[1].step_div);
                    break;
                case 2:
                    M3StepType_entry.SelectedIndex = Step_type_entry_index_translator(CfgBox_Motor_Settings.All_Motor_Settings[2].step_div);
                    break;
                case 3:
                    M4StepType_entry.SelectedIndex = Step_type_entry_index_translator(CfgBox_Motor_Settings.All_Motor_Settings[3].step_div);
                    break;
                case 4:
                    M5StepType_entry.SelectedIndex = Step_type_entry_index_translator(CfgBox_Motor_Settings.All_Motor_Settings[4].step_div);
                    break;
            }
        }



        private void Pull_from_settings_var()
        {
            M1MaxSpeed_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[0].max_speed;
            M1MaxDecel_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[0].decel;
            M1MaxAccel_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[0].accel;
            Select_step_type(0);

            M2MaxSpeed_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[1].max_speed;
            M2MaxDecel_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[1].decel;
            M2MaxAccel_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[1].accel;
            Select_step_type(1);

            M3MaxSpeed_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[2].max_speed;
            M3MaxDecel_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[2].decel;
            M3MaxAccel_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[2].accel;
            Select_step_type(2);

            M4MaxSpeed_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[3].max_speed;
            M4MaxDecel_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[3].decel;
            M4MaxAccel_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[3].accel;
            Select_step_type(3);
        }

        private void Push_to_settings_var()
        {
            CfgBox_Motor_Settings.All_Motor_Settings[0].max_speed = (int) M1MaxSpeed_entry.Value; 
            CfgBox_Motor_Settings.All_Motor_Settings[0].decel     = (int) M1MaxDecel_entry.Value; 
            CfgBox_Motor_Settings.All_Motor_Settings[0].accel     = (int) M1MaxAccel_entry.Value; 
                    
            CfgBox_Motor_Settings.All_Motor_Settings[1].max_speed = (int) M2MaxSpeed_entry.Value; 
            CfgBox_Motor_Settings.All_Motor_Settings[1].decel     = (int) M2MaxDecel_entry.Value; 
            CfgBox_Motor_Settings.All_Motor_Settings[1].accel     = (int) M2MaxAccel_entry.Value; 

            CfgBox_Motor_Settings.All_Motor_Settings[2].max_speed = (int) M3MaxSpeed_entry.Value; 
            CfgBox_Motor_Settings.All_Motor_Settings[2].decel     = (int) M3MaxDecel_entry.Value; 
            CfgBox_Motor_Settings.All_Motor_Settings[2].accel     = (int) M3MaxAccel_entry.Value; 

            CfgBox_Motor_Settings.All_Motor_Settings[3].max_speed = (int) M4MaxSpeed_entry.Value; 
            CfgBox_Motor_Settings.All_Motor_Settings[3].decel     = (int) M4MaxDecel_entry.Value;
            CfgBox_Motor_Settings.All_Motor_Settings[3].accel     = (int) M4MaxAccel_entry.Value;

        }


        private void ConfigBox_Load(object sender, EventArgs e)
        {
            Pull_from_settings_var();
        }

        private bool Checkport()
        {
            bool r = true;
            try
            {
                string curport = PortList_lst.Text;
                COMNumber = int.Parse(curport.TrimStart('C', 'O', 'M'));
                
            }
            catch
            {
                MessageBox.Show("Please select a valid COM port");
                r = false;
            }

            return r;
        }

        private void Fetch_btn_Click(object sender, EventArgs e)
        {
            
            if (Checkport())
            {
                Fetch_btn_pressed = true;
                Push_to_settings_var();
                Close();
            }
                
        }

        private void Set_btn_Click(object sender, EventArgs e)
        {
            
            if (Checkport())
            {
                Set_btn_pressed = true;
                Push_to_settings_var();
                Close();
            }

        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (Checkport())
            {
                Ok_btn_pressed = true;
                Push_to_settings_var();
                Close();
            }

        }
    }
}
