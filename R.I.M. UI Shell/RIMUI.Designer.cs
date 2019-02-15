namespace R.I.M.UI_Shell
{
    partial class Main_wnd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_wnd));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.File_btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.setUARTCOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurUartCom_lbl = new System.Windows.Forms.ToolStripTextBox();
            this.Test_BTN = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SetO_btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.setXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setvYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SetMode_btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.OVRModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PreciseExecutionModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgrammedExecutionModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TraverseLineModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CurMode_lbl = new System.Windows.Forms.ToolStripLabel();
            this.Common_grp = new System.Windows.Forms.GroupBox();
            this.Stop_btn = new System.Windows.Forms.Button();
            this.Start_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.M1Error_ind = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TraverseLineMode_grp = new System.Windows.Forms.GroupBox();
            this.NextPos_entry = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TL_curPos_lbl = new System.Windows.Forms.TextBox();
            this.MoveToPos_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgrammedExecutionMode_grp = new System.Windows.Forms.GroupBox();
            this.PassFail_lbl = new System.Windows.Forms.Label();
            this.NewFile_btn = new System.Windows.Forms.Button();
            this.EditFile_btn = new System.Windows.Forms.Button();
            this.LoadFile_btn = new System.Windows.Forms.Button();
            this.PreciseExecutionMode_grp = new System.Windows.Forms.GroupBox();
            this.Servo2_entry = new System.Windows.Forms.MaskedTextBox();
            this.Servo1_entry = new System.Windows.Forms.MaskedTextBox();
            this.Stepper5_entry = new System.Windows.Forms.MaskedTextBox();
            this.Stepper4_entry = new System.Windows.Forms.MaskedTextBox();
            this.Stepper3_entry = new System.Windows.Forms.MaskedTextBox();
            this.Stepper2_entry = new System.Windows.Forms.MaskedTextBox();
            this.Stepper1_entry = new System.Windows.Forms.MaskedTextBox();
            this.Stepper1_lbl = new System.Windows.Forms.Label();
            this.Stepper2_lbl = new System.Windows.Forms.Label();
            this.Stepper3_lbl = new System.Windows.Forms.Label();
            this.Stepper4_lbl = new System.Windows.Forms.Label();
            this.Stepper5_lbl = new System.Windows.Forms.Label();
            this.Servo1_lbl = new System.Windows.Forms.Label();
            this.Servo2_lbl = new System.Windows.Forms.Label();
            this.OvrCurpos_lbl = new System.Windows.Forms.Label();
            this.UART_COM = new System.IO.Ports.SerialPort(this.components);
            this.M2Running_ind = new System.Windows.Forms.PictureBox();
            this.M3Running_ind = new System.Windows.Forms.PictureBox();
            this.M4Running_ind = new System.Windows.Forms.PictureBox();
            this.M5Running_ind = new System.Windows.Forms.PictureBox();
            this.M6Running_ind = new System.Windows.Forms.PictureBox();
            this.M7Running_ind = new System.Windows.Forms.PictureBox();
            this.M1Running_ind = new System.Windows.Forms.PictureBox();
            this.M1_lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.feedback_grd = new System.Windows.Forms.TableLayoutPanel();
            this.M2Error_ind = new System.Windows.Forms.PictureBox();
            this.M3Error_ind = new System.Windows.Forms.PictureBox();
            this.M4Error_ind = new System.Windows.Forms.PictureBox();
            this.M5Error_ind = new System.Windows.Forms.PictureBox();
            this.M6Error_ind = new System.Windows.Forms.PictureBox();
            this.M7Error_ind = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.MotorRunning_lbl = new System.Windows.Forms.Label();
            this.MotorError_lbl = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.Common_grp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M1Error_ind)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.TraverseLineMode_grp.SuspendLayout();
            this.ProgrammedExecutionMode_grp.SuspendLayout();
            this.PreciseExecutionMode_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M2Running_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M3Running_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M4Running_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M5Running_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M6Running_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M7Running_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M1Running_ind)).BeginInit();
            this.feedback_grd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M2Error_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M3Error_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M4Error_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M5Error_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M6Error_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M7Error_ind)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_btn,
            this.toolStripSeparator3,
            this.SetO_btn,
            this.toolStripSeparator2,
            this.SetMode_btn,
            this.toolStripSeparator1,
            this.CurMode_lbl});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(598, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // File_btn
            // 
            this.File_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.File_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUARTCOMToolStripMenuItem,
            this.Test_BTN,
            this.quitToolStripMenuItem});
            this.File_btn.Image = ((System.Drawing.Image)(resources.GetObject("File_btn.Image")));
            this.File_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.File_btn.Name = "File_btn";
            this.File_btn.Size = new System.Drawing.Size(38, 22);
            this.File_btn.Text = "File";
            // 
            // setUARTCOMToolStripMenuItem
            // 
            this.setUARTCOMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurUartCom_lbl});
            this.setUARTCOMToolStripMenuItem.Name = "setUARTCOMToolStripMenuItem";
            this.setUARTCOMToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.setUARTCOMToolStripMenuItem.Text = "Set UART COM";
            this.setUARTCOMToolStripMenuItem.Click += new System.EventHandler(this.setUARTCOMToolStripMenuItem_Click);
            // 
            // CurUartCom_lbl
            // 
            this.CurUartCom_lbl.Name = "CurUartCom_lbl";
            this.CurUartCom_lbl.ReadOnly = true;
            this.CurUartCom_lbl.Size = new System.Drawing.Size(100, 23);
            this.CurUartCom_lbl.Text = "Current COM: 3";
            // 
            // Test_BTN
            // 
            this.Test_BTN.Name = "Test_BTN";
            this.Test_BTN.Size = new System.Drawing.Size(153, 22);
            this.Test_BTN.Text = "TEST";
            this.Test_BTN.Click += new System.EventHandler(this.Test_BTN_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // SetO_btn
            // 
            this.SetO_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SetO_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setXToolStripMenuItem,
            this.setvYToolStripMenuItem,
            this.setZToolStripMenuItem,
            this.setAllToolStripMenuItem});
            this.SetO_btn.Image = ((System.Drawing.Image)(resources.GetObject("SetO_btn.Image")));
            this.SetO_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetO_btn.Name = "SetO_btn";
            this.SetO_btn.Size = new System.Drawing.Size(72, 22);
            this.SetO_btn.Text = "Set Origin";
            // 
            // setXToolStripMenuItem
            // 
            this.setXToolStripMenuItem.Name = "setXToolStripMenuItem";
            this.setXToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.setXToolStripMenuItem.Text = "Set X";
            // 
            // setvYToolStripMenuItem
            // 
            this.setvYToolStripMenuItem.Name = "setvYToolStripMenuItem";
            this.setvYToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.setvYToolStripMenuItem.Text = "Set Y";
            // 
            // setZToolStripMenuItem
            // 
            this.setZToolStripMenuItem.Name = "setZToolStripMenuItem";
            this.setZToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.setZToolStripMenuItem.Text = "Set Z";
            // 
            // setAllToolStripMenuItem
            // 
            this.setAllToolStripMenuItem.Name = "setAllToolStripMenuItem";
            this.setAllToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.setAllToolStripMenuItem.Text = "Set All";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SetMode_btn
            // 
            this.SetMode_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SetMode_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OVRModeToolStripMenuItem,
            this.PreciseExecutionModeToolStripMenuItem,
            this.ProgrammedExecutionModeToolStripMenuItem,
            this.TraverseLineModeToolStripMenuItem});
            this.SetMode_btn.Image = ((System.Drawing.Image)(resources.GetObject("SetMode_btn.Image")));
            this.SetMode_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetMode_btn.Name = "SetMode_btn";
            this.SetMode_btn.Size = new System.Drawing.Size(85, 22);
            this.SetMode_btn.Text = "Mode Select";
            // 
            // OVRModeToolStripMenuItem
            // 
            this.OVRModeToolStripMenuItem.Name = "OVRModeToolStripMenuItem";
            this.OVRModeToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.OVRModeToolStripMenuItem.Text = "OVR Mode";
            this.OVRModeToolStripMenuItem.Click += new System.EventHandler(this.OVRModeToolStripMenuItem_Click);
            // 
            // PreciseExecutionModeToolStripMenuItem
            // 
            this.PreciseExecutionModeToolStripMenuItem.Name = "PreciseExecutionModeToolStripMenuItem";
            this.PreciseExecutionModeToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.PreciseExecutionModeToolStripMenuItem.Text = "Precise Execution Mode";
            this.PreciseExecutionModeToolStripMenuItem.Click += new System.EventHandler(this.PreciseExecutionModeToolStripMenuItem_Click);
            // 
            // ProgrammedExecutionModeToolStripMenuItem
            // 
            this.ProgrammedExecutionModeToolStripMenuItem.Name = "ProgrammedExecutionModeToolStripMenuItem";
            this.ProgrammedExecutionModeToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.ProgrammedExecutionModeToolStripMenuItem.Text = "Programmed Execution Mode";
            this.ProgrammedExecutionModeToolStripMenuItem.Click += new System.EventHandler(this.ProgrammedExecutionModeToolStripMenuItem_Click);
            // 
            // TraverseLineModeToolStripMenuItem
            // 
            this.TraverseLineModeToolStripMenuItem.Name = "TraverseLineModeToolStripMenuItem";
            this.TraverseLineModeToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.TraverseLineModeToolStripMenuItem.Text = "Traverse Line Mode";
            this.TraverseLineModeToolStripMenuItem.Click += new System.EventHandler(this.TraverseLineModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // CurMode_lbl
            // 
            this.CurMode_lbl.Name = "CurMode_lbl";
            this.CurMode_lbl.Size = new System.Drawing.Size(81, 22);
            this.CurMode_lbl.Text = "Current Mode";
            // 
            // Common_grp
            // 
            this.Common_grp.Controls.Add(this.Stop_btn);
            this.Common_grp.Controls.Add(this.Start_btn);
            this.Common_grp.Location = new System.Drawing.Point(9, 225);
            this.Common_grp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Common_grp.Name = "Common_grp";
            this.Common_grp.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Common_grp.Size = new System.Drawing.Size(124, 179);
            this.Common_grp.TabIndex = 1;
            this.Common_grp.TabStop = false;
            this.Common_grp.Text = "Common Controls";
            // 
            // Stop_btn
            // 
            this.Stop_btn.Enabled = false;
            this.Stop_btn.Location = new System.Drawing.Point(4, 96);
            this.Stop_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Stop_btn.Name = "Stop_btn";
            this.Stop_btn.Size = new System.Drawing.Size(112, 75);
            this.Stop_btn.TabIndex = 1;
            this.Stop_btn.Text = "Stop";
            this.Stop_btn.UseVisualStyleBackColor = true;
            this.Stop_btn.Click += new System.EventHandler(this.Stop_btn_Click);
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(4, 17);
            this.Start_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(112, 75);
            this.Start_btn.TabIndex = 0;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.feedback_grd);
            this.groupBox1.Location = new System.Drawing.Point(143, 224);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(446, 180);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Common Feedback";
            // 
            // M1Error_ind
            // 
            this.M1Error_ind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.M1Error_ind.BackColor = System.Drawing.Color.LimeGreen;
            this.M1Error_ind.Location = new System.Drawing.Point(57, 93);
            this.M1Error_ind.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.M1Error_ind.Name = "M1Error_ind";
            this.M1Error_ind.Size = new System.Drawing.Size(49, 62);
            this.M1Error_ind.TabIndex = 1;
            this.M1Error_ind.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TraverseLineMode_grp);
            this.groupBox2.Controls.Add(this.ProgrammedExecutionMode_grp);
            this.groupBox2.Controls.Add(this.PreciseExecutionMode_grp);
            this.groupBox2.Controls.Add(this.OvrCurpos_lbl);
            this.groupBox2.Location = new System.Drawing.Point(9, 24);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(580, 196);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode Controls";
            // 
            // TraverseLineMode_grp
            // 
            this.TraverseLineMode_grp.Controls.Add(this.NextPos_entry);
            this.TraverseLineMode_grp.Controls.Add(this.label3);
            this.TraverseLineMode_grp.Controls.Add(this.TL_curPos_lbl);
            this.TraverseLineMode_grp.Controls.Add(this.MoveToPos_lbl);
            this.TraverseLineMode_grp.Controls.Add(this.label2);
            this.TraverseLineMode_grp.Controls.Add(this.label1);
            this.TraverseLineMode_grp.Location = new System.Drawing.Point(435, 18);
            this.TraverseLineMode_grp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TraverseLineMode_grp.Name = "TraverseLineMode_grp";
            this.TraverseLineMode_grp.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TraverseLineMode_grp.Size = new System.Drawing.Size(141, 173);
            this.TraverseLineMode_grp.TabIndex = 17;
            this.TraverseLineMode_grp.TabStop = false;
            this.TraverseLineMode_grp.Text = "Traverse Line Mode";
            // 
            // NextPos_entry
            // 
            this.NextPos_entry.Location = new System.Drawing.Point(7, 82);
            this.NextPos_entry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NextPos_entry.Mask = "(0.00, 0.00, 0.00)";
            this.NextPos_entry.Name = "NextPos_entry";
            this.NextPos_entry.Size = new System.Drawing.Size(131, 20);
            this.NextPos_entry.TabIndex = 19;
            this.NextPos_entry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Error: [None | Input Error]";
            // 
            // TL_curPos_lbl
            // 
            this.TL_curPos_lbl.Enabled = false;
            this.TL_curPos_lbl.Location = new System.Drawing.Point(7, 33);
            this.TL_curPos_lbl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TL_curPos_lbl.Name = "TL_curPos_lbl";
            this.TL_curPos_lbl.Size = new System.Drawing.Size(131, 20);
            this.TL_curPos_lbl.TabIndex = 15;
            // 
            // MoveToPos_lbl
            // 
            this.MoveToPos_lbl.AutoSize = true;
            this.MoveToPos_lbl.Location = new System.Drawing.Point(4, 66);
            this.MoveToPos_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MoveToPos_lbl.Name = "MoveToPos_lbl";
            this.MoveToPos_lbl.Size = new System.Drawing.Size(117, 13);
            this.MoveToPos_lbl.TabIndex = 17;
            this.MoveToPos_lbl.Text = "Move To Position: x,y,z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Current Position:";
            // 
            // ProgrammedExecutionMode_grp
            // 
            this.ProgrammedExecutionMode_grp.Controls.Add(this.PassFail_lbl);
            this.ProgrammedExecutionMode_grp.Controls.Add(this.NewFile_btn);
            this.ProgrammedExecutionMode_grp.Controls.Add(this.EditFile_btn);
            this.ProgrammedExecutionMode_grp.Controls.Add(this.LoadFile_btn);
            this.ProgrammedExecutionMode_grp.Location = new System.Drawing.Point(269, 17);
            this.ProgrammedExecutionMode_grp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProgrammedExecutionMode_grp.Name = "ProgrammedExecutionMode_grp";
            this.ProgrammedExecutionMode_grp.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProgrammedExecutionMode_grp.Size = new System.Drawing.Size(160, 174);
            this.ProgrammedExecutionMode_grp.TabIndex = 16;
            this.ProgrammedExecutionMode_grp.TabStop = false;
            this.ProgrammedExecutionMode_grp.Text = "Programmed Execution Mode";
            // 
            // PassFail_lbl
            // 
            this.PassFail_lbl.AutoSize = true;
            this.PassFail_lbl.Location = new System.Drawing.Point(23, 141);
            this.PassFail_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PassFail_lbl.Name = "PassFail_lbl";
            this.PassFail_lbl.Size = new System.Drawing.Size(127, 13);
            this.PassFail_lbl.TabIndex = 5;
            this.PassFail_lbl.Text = "File Load: [Success | Fail]";
            // 
            // NewFile_btn
            // 
            this.NewFile_btn.Location = new System.Drawing.Point(4, 94);
            this.NewFile_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NewFile_btn.Name = "NewFile_btn";
            this.NewFile_btn.Size = new System.Drawing.Size(152, 32);
            this.NewFile_btn.TabIndex = 4;
            this.NewFile_btn.Text = "New File";
            this.NewFile_btn.UseVisualStyleBackColor = true;
            // 
            // EditFile_btn
            // 
            this.EditFile_btn.Location = new System.Drawing.Point(4, 58);
            this.EditFile_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EditFile_btn.Name = "EditFile_btn";
            this.EditFile_btn.Size = new System.Drawing.Size(152, 32);
            this.EditFile_btn.TabIndex = 3;
            this.EditFile_btn.Text = "Edit Current File";
            this.EditFile_btn.UseVisualStyleBackColor = true;
            // 
            // LoadFile_btn
            // 
            this.LoadFile_btn.Location = new System.Drawing.Point(4, 21);
            this.LoadFile_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadFile_btn.Name = "LoadFile_btn";
            this.LoadFile_btn.Size = new System.Drawing.Size(152, 32);
            this.LoadFile_btn.TabIndex = 2;
            this.LoadFile_btn.Text = "Load File";
            this.LoadFile_btn.UseVisualStyleBackColor = true;
            // 
            // PreciseExecutionMode_grp
            // 
            this.PreciseExecutionMode_grp.Controls.Add(this.Servo2_entry);
            this.PreciseExecutionMode_grp.Controls.Add(this.Servo1_entry);
            this.PreciseExecutionMode_grp.Controls.Add(this.Stepper5_entry);
            this.PreciseExecutionMode_grp.Controls.Add(this.Stepper4_entry);
            this.PreciseExecutionMode_grp.Controls.Add(this.Stepper3_entry);
            this.PreciseExecutionMode_grp.Controls.Add(this.Stepper2_entry);
            this.PreciseExecutionMode_grp.Controls.Add(this.Stepper1_entry);
            this.PreciseExecutionMode_grp.Controls.Add(this.Stepper1_lbl);
            this.PreciseExecutionMode_grp.Controls.Add(this.Stepper2_lbl);
            this.PreciseExecutionMode_grp.Controls.Add(this.Stepper3_lbl);
            this.PreciseExecutionMode_grp.Controls.Add(this.Stepper4_lbl);
            this.PreciseExecutionMode_grp.Controls.Add(this.Stepper5_lbl);
            this.PreciseExecutionMode_grp.Controls.Add(this.Servo1_lbl);
            this.PreciseExecutionMode_grp.Controls.Add(this.Servo2_lbl);
            this.PreciseExecutionMode_grp.Location = new System.Drawing.Point(115, 14);
            this.PreciseExecutionMode_grp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PreciseExecutionMode_grp.Name = "PreciseExecutionMode_grp";
            this.PreciseExecutionMode_grp.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PreciseExecutionMode_grp.Size = new System.Drawing.Size(150, 177);
            this.PreciseExecutionMode_grp.TabIndex = 15;
            this.PreciseExecutionMode_grp.TabStop = false;
            this.PreciseExecutionMode_grp.Text = "Precise Execution Controls";
            // 
            // Servo2_entry
            // 
            this.Servo2_entry.Location = new System.Drawing.Point(66, 154);
            this.Servo2_entry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Servo2_entry.Mask = "#00000000000";
            this.Servo2_entry.Name = "Servo2_entry";
            this.Servo2_entry.PromptChar = ' ';
            this.Servo2_entry.Size = new System.Drawing.Size(76, 20);
            this.Servo2_entry.TabIndex = 24;
            // 
            // Servo1_entry
            // 
            this.Servo1_entry.Location = new System.Drawing.Point(66, 131);
            this.Servo1_entry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Servo1_entry.Mask = "#00000000000";
            this.Servo1_entry.Name = "Servo1_entry";
            this.Servo1_entry.PromptChar = ' ';
            this.Servo1_entry.Size = new System.Drawing.Size(76, 20);
            this.Servo1_entry.TabIndex = 23;
            // 
            // Stepper5_entry
            // 
            this.Stepper5_entry.Location = new System.Drawing.Point(66, 108);
            this.Stepper5_entry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Stepper5_entry.Mask = "#00000000000";
            this.Stepper5_entry.Name = "Stepper5_entry";
            this.Stepper5_entry.PromptChar = ' ';
            this.Stepper5_entry.Size = new System.Drawing.Size(76, 20);
            this.Stepper5_entry.TabIndex = 22;
            // 
            // Stepper4_entry
            // 
            this.Stepper4_entry.Location = new System.Drawing.Point(66, 85);
            this.Stepper4_entry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Stepper4_entry.Mask = "#00000000000";
            this.Stepper4_entry.Name = "Stepper4_entry";
            this.Stepper4_entry.PromptChar = ' ';
            this.Stepper4_entry.Size = new System.Drawing.Size(76, 20);
            this.Stepper4_entry.TabIndex = 21;
            // 
            // Stepper3_entry
            // 
            this.Stepper3_entry.Location = new System.Drawing.Point(66, 63);
            this.Stepper3_entry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Stepper3_entry.Mask = "#00000000000";
            this.Stepper3_entry.Name = "Stepper3_entry";
            this.Stepper3_entry.PromptChar = ' ';
            this.Stepper3_entry.Size = new System.Drawing.Size(76, 20);
            this.Stepper3_entry.TabIndex = 20;
            // 
            // Stepper2_entry
            // 
            this.Stepper2_entry.Location = new System.Drawing.Point(66, 40);
            this.Stepper2_entry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Stepper2_entry.Mask = "#00000000000";
            this.Stepper2_entry.Name = "Stepper2_entry";
            this.Stepper2_entry.PromptChar = ' ';
            this.Stepper2_entry.Size = new System.Drawing.Size(76, 20);
            this.Stepper2_entry.TabIndex = 19;
            // 
            // Stepper1_entry
            // 
            this.Stepper1_entry.Location = new System.Drawing.Point(66, 17);
            this.Stepper1_entry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Stepper1_entry.Mask = "#00000000000";
            this.Stepper1_entry.Name = "Stepper1_entry";
            this.Stepper1_entry.PromptChar = ' ';
            this.Stepper1_entry.Size = new System.Drawing.Size(76, 20);
            this.Stepper1_entry.TabIndex = 18;
            this.Stepper1_entry.ValidatingType = typeof(int);
            // 
            // Stepper1_lbl
            // 
            this.Stepper1_lbl.AutoSize = true;
            this.Stepper1_lbl.Location = new System.Drawing.Point(6, 20);
            this.Stepper1_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stepper1_lbl.Name = "Stepper1_lbl";
            this.Stepper1_lbl.Size = new System.Drawing.Size(56, 13);
            this.Stepper1_lbl.TabIndex = 1;
            this.Stepper1_lbl.Text = "Stepper 1:";
            // 
            // Stepper2_lbl
            // 
            this.Stepper2_lbl.AutoSize = true;
            this.Stepper2_lbl.Location = new System.Drawing.Point(6, 42);
            this.Stepper2_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stepper2_lbl.Name = "Stepper2_lbl";
            this.Stepper2_lbl.Size = new System.Drawing.Size(56, 13);
            this.Stepper2_lbl.TabIndex = 3;
            this.Stepper2_lbl.Text = "Stepper 2:";
            // 
            // Stepper3_lbl
            // 
            this.Stepper3_lbl.AutoSize = true;
            this.Stepper3_lbl.Location = new System.Drawing.Point(6, 65);
            this.Stepper3_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stepper3_lbl.Name = "Stepper3_lbl";
            this.Stepper3_lbl.Size = new System.Drawing.Size(56, 13);
            this.Stepper3_lbl.TabIndex = 4;
            this.Stepper3_lbl.Text = "Stepper 3:";
            // 
            // Stepper4_lbl
            // 
            this.Stepper4_lbl.AutoSize = true;
            this.Stepper4_lbl.Location = new System.Drawing.Point(6, 88);
            this.Stepper4_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stepper4_lbl.Name = "Stepper4_lbl";
            this.Stepper4_lbl.Size = new System.Drawing.Size(56, 13);
            this.Stepper4_lbl.TabIndex = 5;
            this.Stepper4_lbl.Text = "Stepper 4:";
            // 
            // Stepper5_lbl
            // 
            this.Stepper5_lbl.AutoSize = true;
            this.Stepper5_lbl.Location = new System.Drawing.Point(6, 110);
            this.Stepper5_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stepper5_lbl.Name = "Stepper5_lbl";
            this.Stepper5_lbl.Size = new System.Drawing.Size(56, 13);
            this.Stepper5_lbl.TabIndex = 6;
            this.Stepper5_lbl.Text = "Stepper 5:";
            // 
            // Servo1_lbl
            // 
            this.Servo1_lbl.AutoSize = true;
            this.Servo1_lbl.Location = new System.Drawing.Point(16, 133);
            this.Servo1_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Servo1_lbl.Name = "Servo1_lbl";
            this.Servo1_lbl.Size = new System.Drawing.Size(47, 13);
            this.Servo1_lbl.TabIndex = 7;
            this.Servo1_lbl.Text = "Servo 1:";
            // 
            // Servo2_lbl
            // 
            this.Servo2_lbl.AutoSize = true;
            this.Servo2_lbl.Location = new System.Drawing.Point(16, 156);
            this.Servo2_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Servo2_lbl.Name = "Servo2_lbl";
            this.Servo2_lbl.Size = new System.Drawing.Size(47, 13);
            this.Servo2_lbl.TabIndex = 8;
            this.Servo2_lbl.Text = "Servo 2:";
            // 
            // OvrCurpos_lbl
            // 
            this.OvrCurpos_lbl.AutoSize = true;
            this.OvrCurpos_lbl.Location = new System.Drawing.Point(4, 17);
            this.OvrCurpos_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OvrCurpos_lbl.Name = "OvrCurpos_lbl";
            this.OvrCurpos_lbl.Size = new System.Drawing.Size(84, 13);
            this.OvrCurpos_lbl.TabIndex = 0;
            this.OvrCurpos_lbl.Text = "Current Position:";
            this.OvrCurpos_lbl.Visible = false;
            // 
            // UART_COM
            // 
            this.UART_COM.BaudRate = 115200;
            this.UART_COM.PortName = "COM4";
            this.UART_COM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.UART_COM_DataReceived);
            // 
            // M2Running_ind
            // 
            this.M2Running_ind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.M2Running_ind.BackColor = System.Drawing.Color.IndianRed;
            this.M2Running_ind.Location = new System.Drawing.Point(111, 27);
            this.M2Running_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M2Running_ind.Name = "M2Running_ind";
            this.M2Running_ind.Size = new System.Drawing.Size(49, 61);
            this.M2Running_ind.TabIndex = 4;
            this.M2Running_ind.TabStop = false;
            // 
            // M3Running_ind
            // 
            this.M3Running_ind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.M3Running_ind.BackColor = System.Drawing.Color.IndianRed;
            this.M3Running_ind.Location = new System.Drawing.Point(165, 27);
            this.M3Running_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M3Running_ind.Name = "M3Running_ind";
            this.M3Running_ind.Size = new System.Drawing.Size(49, 61);
            this.M3Running_ind.TabIndex = 5;
            this.M3Running_ind.TabStop = false;
            // 
            // M4Running_ind
            // 
            this.M4Running_ind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.M4Running_ind.BackColor = System.Drawing.Color.IndianRed;
            this.M4Running_ind.Location = new System.Drawing.Point(219, 27);
            this.M4Running_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M4Running_ind.Name = "M4Running_ind";
            this.M4Running_ind.Size = new System.Drawing.Size(49, 61);
            this.M4Running_ind.TabIndex = 6;
            this.M4Running_ind.TabStop = false;
            // 
            // M5Running_ind
            // 
            this.M5Running_ind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.M5Running_ind.BackColor = System.Drawing.Color.IndianRed;
            this.M5Running_ind.Location = new System.Drawing.Point(273, 27);
            this.M5Running_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M5Running_ind.Name = "M5Running_ind";
            this.M5Running_ind.Size = new System.Drawing.Size(49, 61);
            this.M5Running_ind.TabIndex = 7;
            this.M5Running_ind.TabStop = false;
            // 
            // M6Running_ind
            // 
            this.M6Running_ind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.M6Running_ind.BackColor = System.Drawing.Color.IndianRed;
            this.M6Running_ind.Location = new System.Drawing.Point(327, 27);
            this.M6Running_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M6Running_ind.Name = "M6Running_ind";
            this.M6Running_ind.Size = new System.Drawing.Size(49, 61);
            this.M6Running_ind.TabIndex = 8;
            this.M6Running_ind.TabStop = false;
            // 
            // M7Running_ind
            // 
            this.M7Running_ind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.M7Running_ind.BackColor = System.Drawing.Color.IndianRed;
            this.M7Running_ind.Location = new System.Drawing.Point(381, 27);
            this.M7Running_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M7Running_ind.Name = "M7Running_ind";
            this.M7Running_ind.Size = new System.Drawing.Size(50, 61);
            this.M7Running_ind.TabIndex = 9;
            this.M7Running_ind.TabStop = false;
            // 
            // M1Running_ind
            // 
            this.M1Running_ind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.M1Running_ind.BackColor = System.Drawing.Color.IndianRed;
            this.M1Running_ind.Location = new System.Drawing.Point(57, 27);
            this.M1Running_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M1Running_ind.Name = "M1Running_ind";
            this.M1Running_ind.Size = new System.Drawing.Size(49, 61);
            this.M1Running_ind.TabIndex = 0;
            this.M1Running_ind.TabStop = false;
            // 
            // M1_lbl
            // 
            this.M1_lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.M1_lbl.AutoSize = true;
            this.M1_lbl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.M1_lbl.ForeColor = System.Drawing.Color.Black;
            this.M1_lbl.Location = new System.Drawing.Point(60, 6);
            this.M1_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.M1_lbl.Name = "M1_lbl";
            this.M1_lbl.Size = new System.Drawing.Size(43, 13);
            this.M1_lbl.TabIndex = 2;
            this.M1_lbl.Text = "Motor 1";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(114, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Motor 2";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(168, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Motor 3";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(222, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Motor 4";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(276, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Motor 5";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(330, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Motor 6";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(384, 6);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Motor 7";
            // 
            // feedback_grd
            // 
            this.feedback_grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.feedback_grd.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.feedback_grd.ColumnCount = 8;
            this.feedback_grd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.feedback_grd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.feedback_grd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.feedback_grd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.feedback_grd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.feedback_grd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.feedback_grd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.feedback_grd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.feedback_grd.Controls.Add(this.MotorError_lbl, 0, 2);
            this.feedback_grd.Controls.Add(this.M7Running_ind, 7, 1);
            this.feedback_grd.Controls.Add(this.M6Running_ind, 6, 1);
            this.feedback_grd.Controls.Add(this.M7Error_ind, 7, 2);
            this.feedback_grd.Controls.Add(this.M6Error_ind, 6, 2);
            this.feedback_grd.Controls.Add(this.M5Error_ind, 5, 2);
            this.feedback_grd.Controls.Add(this.M5Running_ind, 5, 1);
            this.feedback_grd.Controls.Add(this.M4Running_ind, 4, 1);
            this.feedback_grd.Controls.Add(this.M4Error_ind, 4, 2);
            this.feedback_grd.Controls.Add(this.M3Running_ind, 3, 1);
            this.feedback_grd.Controls.Add(this.M3Error_ind, 3, 2);
            this.feedback_grd.Controls.Add(this.M2Running_ind, 2, 1);
            this.feedback_grd.Controls.Add(this.M2Error_ind, 2, 2);
            this.feedback_grd.Controls.Add(this.M1Error_ind, 1, 2);
            this.feedback_grd.Controls.Add(this.M1Running_ind, 1, 1);
            this.feedback_grd.Controls.Add(this.label9, 7, 0);
            this.feedback_grd.Controls.Add(this.label8, 6, 0);
            this.feedback_grd.Controls.Add(this.label7, 5, 0);
            this.feedback_grd.Controls.Add(this.label6, 4, 0);
            this.feedback_grd.Controls.Add(this.label5, 3, 0);
            this.feedback_grd.Controls.Add(this.label4, 2, 0);
            this.feedback_grd.Controls.Add(this.M1_lbl, 1, 0);
            this.feedback_grd.Controls.Add(this.label10, 0, 0);
            this.feedback_grd.Controls.Add(this.MotorRunning_lbl, 0, 1);
            this.feedback_grd.Location = new System.Drawing.Point(5, 17);
            this.feedback_grd.Name = "feedback_grd";
            this.feedback_grd.RowCount = 3;
            this.feedback_grd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.feedback_grd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.feedback_grd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.feedback_grd.Size = new System.Drawing.Size(434, 158);
            this.feedback_grd.TabIndex = 4;
            // 
            // M2Error_ind
            // 
            this.M2Error_ind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.M2Error_ind.BackColor = System.Drawing.Color.LimeGreen;
            this.M2Error_ind.Location = new System.Drawing.Point(111, 93);
            this.M2Error_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M2Error_ind.Name = "M2Error_ind";
            this.M2Error_ind.Size = new System.Drawing.Size(49, 62);
            this.M2Error_ind.TabIndex = 15;
            this.M2Error_ind.TabStop = false;
            // 
            // M3Error_ind
            // 
            this.M3Error_ind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.M3Error_ind.BackColor = System.Drawing.Color.LimeGreen;
            this.M3Error_ind.Location = new System.Drawing.Point(165, 93);
            this.M3Error_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M3Error_ind.Name = "M3Error_ind";
            this.M3Error_ind.Size = new System.Drawing.Size(49, 62);
            this.M3Error_ind.TabIndex = 16;
            this.M3Error_ind.TabStop = false;
            // 
            // M4Error_ind
            // 
            this.M4Error_ind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.M4Error_ind.BackColor = System.Drawing.Color.LimeGreen;
            this.M4Error_ind.Location = new System.Drawing.Point(219, 93);
            this.M4Error_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M4Error_ind.Name = "M4Error_ind";
            this.M4Error_ind.Size = new System.Drawing.Size(49, 62);
            this.M4Error_ind.TabIndex = 17;
            this.M4Error_ind.TabStop = false;
            // 
            // M5Error_ind
            // 
            this.M5Error_ind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.M5Error_ind.BackColor = System.Drawing.Color.LimeGreen;
            this.M5Error_ind.Location = new System.Drawing.Point(273, 93);
            this.M5Error_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M5Error_ind.Name = "M5Error_ind";
            this.M5Error_ind.Size = new System.Drawing.Size(49, 62);
            this.M5Error_ind.TabIndex = 18;
            this.M5Error_ind.TabStop = false;
            // 
            // M6Error_ind
            // 
            this.M6Error_ind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.M6Error_ind.BackColor = System.Drawing.Color.LimeGreen;
            this.M6Error_ind.Location = new System.Drawing.Point(327, 93);
            this.M6Error_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M6Error_ind.Name = "M6Error_ind";
            this.M6Error_ind.Size = new System.Drawing.Size(49, 62);
            this.M6Error_ind.TabIndex = 19;
            this.M6Error_ind.TabStop = false;
            // 
            // M7Error_ind
            // 
            this.M7Error_ind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.M7Error_ind.BackColor = System.Drawing.Color.LimeGreen;
            this.M7Error_ind.Location = new System.Drawing.Point(381, 93);
            this.M7Error_ind.Margin = new System.Windows.Forms.Padding(2);
            this.M7Error_ind.Name = "M7Error_ind";
            this.M7Error_ind.Size = new System.Drawing.Size(50, 61);
            this.M7Error_ind.TabIndex = 20;
            this.M7Error_ind.TabStop = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(11, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Desc";
            // 
            // MotorRunning_lbl
            // 
            this.MotorRunning_lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MotorRunning_lbl.AutoSize = true;
            this.MotorRunning_lbl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MotorRunning_lbl.ForeColor = System.Drawing.Color.Black;
            this.MotorRunning_lbl.Location = new System.Drawing.Point(4, 44);
            this.MotorRunning_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MotorRunning_lbl.Name = "MotorRunning_lbl";
            this.MotorRunning_lbl.Size = new System.Drawing.Size(47, 26);
            this.MotorRunning_lbl.TabIndex = 22;
            this.MotorRunning_lbl.Text = "Motor Running";
            // 
            // MotorError_lbl
            // 
            this.MotorError_lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MotorError_lbl.AutoSize = true;
            this.MotorError_lbl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MotorError_lbl.ForeColor = System.Drawing.Color.Black;
            this.MotorError_lbl.Location = new System.Drawing.Point(9, 111);
            this.MotorError_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MotorError_lbl.Name = "MotorError_lbl";
            this.MotorError_lbl.Size = new System.Drawing.Size(37, 26);
            this.MotorError_lbl.TabIndex = 23;
            this.MotorError_lbl.Text = "Motor Error";
            // 
            // Main_wnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 409);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Common_grp);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Main_wnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "R.I.M. Test App";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Common_grp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.M1Error_ind)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TraverseLineMode_grp.ResumeLayout(false);
            this.TraverseLineMode_grp.PerformLayout();
            this.ProgrammedExecutionMode_grp.ResumeLayout(false);
            this.ProgrammedExecutionMode_grp.PerformLayout();
            this.PreciseExecutionMode_grp.ResumeLayout(false);
            this.PreciseExecutionMode_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M2Running_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M3Running_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M4Running_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M5Running_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M6Running_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M7Running_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M1Running_ind)).EndInit();
            this.feedback_grd.ResumeLayout(false);
            this.feedback_grd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M2Error_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M3Error_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M4Error_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M5Error_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M6Error_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M7Error_ind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton File_btn;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton SetO_btn;
        private System.Windows.Forms.ToolStripMenuItem setXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setvYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setZToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem setAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton SetMode_btn;
        private System.Windows.Forms.ToolStripMenuItem OVRModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PreciseExecutionModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProgrammedExecutionModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TraverseLineModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel CurMode_lbl;
        private System.Windows.Forms.GroupBox Common_grp;
        private System.Windows.Forms.Button Stop_btn;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox M1Error_ind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label OvrCurpos_lbl;
        private System.Windows.Forms.Label Servo2_lbl;
        private System.Windows.Forms.Label Servo1_lbl;
        private System.Windows.Forms.Label Stepper5_lbl;
        private System.Windows.Forms.Label Stepper4_lbl;
        private System.Windows.Forms.Label Stepper3_lbl;
        private System.Windows.Forms.Label Stepper2_lbl;
        private System.Windows.Forms.Label Stepper1_lbl;
        private System.Windows.Forms.GroupBox PreciseExecutionMode_grp;
        private System.Windows.Forms.GroupBox ProgrammedExecutionMode_grp;
        private System.Windows.Forms.Label PassFail_lbl;
        private System.Windows.Forms.Button NewFile_btn;
        private System.Windows.Forms.Button EditFile_btn;
        private System.Windows.Forms.Button LoadFile_btn;
        private System.Windows.Forms.GroupBox TraverseLineMode_grp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TL_curPos_lbl;
        private System.Windows.Forms.Label MoveToPos_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox NextPos_entry;
        private System.Windows.Forms.ToolStripMenuItem setUARTCOMToolStripMenuItem;
        private System.IO.Ports.SerialPort UART_COM;
        private System.Windows.Forms.ToolStripTextBox CurUartCom_lbl;
        private System.Windows.Forms.MaskedTextBox Servo2_entry;
        private System.Windows.Forms.MaskedTextBox Servo1_entry;
        private System.Windows.Forms.MaskedTextBox Stepper5_entry;
        private System.Windows.Forms.MaskedTextBox Stepper4_entry;
        private System.Windows.Forms.MaskedTextBox Stepper3_entry;
        private System.Windows.Forms.MaskedTextBox Stepper2_entry;
        private System.Windows.Forms.MaskedTextBox Stepper1_entry;
        private System.Windows.Forms.ToolStripMenuItem Test_BTN;
        private System.Windows.Forms.PictureBox M6Running_ind;
        private System.Windows.Forms.PictureBox M5Running_ind;
        private System.Windows.Forms.PictureBox M4Running_ind;
        private System.Windows.Forms.PictureBox M3Running_ind;
        private System.Windows.Forms.PictureBox M2Running_ind;
        private System.Windows.Forms.PictureBox M7Running_ind;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label M1_lbl;
        private System.Windows.Forms.TableLayoutPanel feedback_grd;
        private System.Windows.Forms.PictureBox M1Running_ind;
        private System.Windows.Forms.Label MotorError_lbl;
        private System.Windows.Forms.PictureBox M7Error_ind;
        private System.Windows.Forms.PictureBox M6Error_ind;
        private System.Windows.Forms.PictureBox M5Error_ind;
        private System.Windows.Forms.PictureBox M4Error_ind;
        private System.Windows.Forms.PictureBox M3Error_ind;
        private System.Windows.Forms.PictureBox M2Error_ind;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label MotorRunning_lbl;
    }
}

