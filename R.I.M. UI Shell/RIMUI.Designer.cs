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
            this.Error_lbl = new System.Windows.Forms.Label();
            this.Running_lbl = new System.Windows.Forms.Label();
            this.Error_ind = new System.Windows.Forms.PictureBox();
            this.Running_ind = new System.Windows.Forms.PictureBox();
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
            this.Test_BTN = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.Common_grp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error_ind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Running_ind)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.TraverseLineMode_grp.SuspendLayout();
            this.ProgrammedExecutionMode_grp.SuspendLayout();
            this.PreciseExecutionMode_grp.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(798, 27);
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
            this.File_btn.Size = new System.Drawing.Size(46, 24);
            this.File_btn.Text = "File";
            // 
            // setUARTCOMToolStripMenuItem
            // 
            this.setUARTCOMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurUartCom_lbl});
            this.setUARTCOMToolStripMenuItem.Name = "setUARTCOMToolStripMenuItem";
            this.setUARTCOMToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.setUARTCOMToolStripMenuItem.Text = "Set UART COM";
            this.setUARTCOMToolStripMenuItem.Click += new System.EventHandler(this.setUARTCOMToolStripMenuItem_Click);
            // 
            // CurUartCom_lbl
            // 
            this.CurUartCom_lbl.Name = "CurUartCom_lbl";
            this.CurUartCom_lbl.ReadOnly = true;
            this.CurUartCom_lbl.Size = new System.Drawing.Size(100, 27);
            this.CurUartCom_lbl.Text = "Current COM: 3";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
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
            this.SetO_btn.Size = new System.Drawing.Size(89, 24);
            this.SetO_btn.Text = "Set Origin";
            // 
            // setXToolStripMenuItem
            // 
            this.setXToolStripMenuItem.Name = "setXToolStripMenuItem";
            this.setXToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.setXToolStripMenuItem.Text = "Set X";
            // 
            // setvYToolStripMenuItem
            // 
            this.setvYToolStripMenuItem.Name = "setvYToolStripMenuItem";
            this.setvYToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.setvYToolStripMenuItem.Text = "Set Y";
            // 
            // setZToolStripMenuItem
            // 
            this.setZToolStripMenuItem.Name = "setZToolStripMenuItem";
            this.setZToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.setZToolStripMenuItem.Text = "Set Z";
            // 
            // setAllToolStripMenuItem
            // 
            this.setAllToolStripMenuItem.Name = "setAllToolStripMenuItem";
            this.setAllToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.setAllToolStripMenuItem.Text = "Set All";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
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
            this.SetMode_btn.Size = new System.Drawing.Size(106, 24);
            this.SetMode_btn.Text = "Mode Select";
            // 
            // OVRModeToolStripMenuItem
            // 
            this.OVRModeToolStripMenuItem.Name = "OVRModeToolStripMenuItem";
            this.OVRModeToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.OVRModeToolStripMenuItem.Text = "OVR Mode";
            this.OVRModeToolStripMenuItem.Click += new System.EventHandler(this.OVRModeToolStripMenuItem_Click);
            // 
            // PreciseExecutionModeToolStripMenuItem
            // 
            this.PreciseExecutionModeToolStripMenuItem.Name = "PreciseExecutionModeToolStripMenuItem";
            this.PreciseExecutionModeToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.PreciseExecutionModeToolStripMenuItem.Text = "Precise Execution Mode";
            this.PreciseExecutionModeToolStripMenuItem.Click += new System.EventHandler(this.PreciseExecutionModeToolStripMenuItem_Click);
            // 
            // ProgrammedExecutionModeToolStripMenuItem
            // 
            this.ProgrammedExecutionModeToolStripMenuItem.Name = "ProgrammedExecutionModeToolStripMenuItem";
            this.ProgrammedExecutionModeToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.ProgrammedExecutionModeToolStripMenuItem.Text = "Programmed Execution Mode";
            this.ProgrammedExecutionModeToolStripMenuItem.Click += new System.EventHandler(this.ProgrammedExecutionModeToolStripMenuItem_Click);
            // 
            // TraverseLineModeToolStripMenuItem
            // 
            this.TraverseLineModeToolStripMenuItem.Name = "TraverseLineModeToolStripMenuItem";
            this.TraverseLineModeToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.TraverseLineModeToolStripMenuItem.Text = "Traverse Line Mode";
            this.TraverseLineModeToolStripMenuItem.Click += new System.EventHandler(this.TraverseLineModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // CurMode_lbl
            // 
            this.CurMode_lbl.Name = "CurMode_lbl";
            this.CurMode_lbl.Size = new System.Drawing.Size(100, 24);
            this.CurMode_lbl.Text = "Current Mode";
            // 
            // Common_grp
            // 
            this.Common_grp.Controls.Add(this.Stop_btn);
            this.Common_grp.Controls.Add(this.Start_btn);
            this.Common_grp.Location = new System.Drawing.Point(12, 277);
            this.Common_grp.Name = "Common_grp";
            this.Common_grp.Size = new System.Drawing.Size(166, 173);
            this.Common_grp.TabIndex = 1;
            this.Common_grp.TabStop = false;
            this.Common_grp.Text = "Common Controls";
            // 
            // Stop_btn
            // 
            this.Stop_btn.Enabled = false;
            this.Stop_btn.Location = new System.Drawing.Point(6, 96);
            this.Stop_btn.Name = "Stop_btn";
            this.Stop_btn.Size = new System.Drawing.Size(149, 69);
            this.Stop_btn.TabIndex = 1;
            this.Stop_btn.Text = "Stop";
            this.Stop_btn.UseVisualStyleBackColor = true;
            this.Stop_btn.Click += new System.EventHandler(this.Stop_btn_Click);
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(6, 21);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(149, 69);
            this.Start_btn.TabIndex = 0;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Error_lbl);
            this.groupBox1.Controls.Add(this.Running_lbl);
            this.groupBox1.Controls.Add(this.Error_ind);
            this.groupBox1.Controls.Add(this.Running_ind);
            this.groupBox1.Location = new System.Drawing.Point(189, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 173);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Common Feedback";
            // 
            // Error_lbl
            // 
            this.Error_lbl.AutoSize = true;
            this.Error_lbl.BackColor = System.Drawing.Color.LimeGreen;
            this.Error_lbl.Location = new System.Drawing.Point(264, 122);
            this.Error_lbl.Name = "Error_lbl";
            this.Error_lbl.Size = new System.Drawing.Size(69, 17);
            this.Error_lbl.TabIndex = 3;
            this.Error_lbl.Text = "No Errors";
            // 
            // Running_lbl
            // 
            this.Running_lbl.AutoSize = true;
            this.Running_lbl.BackColor = System.Drawing.Color.IndianRed;
            this.Running_lbl.ForeColor = System.Drawing.Color.Black;
            this.Running_lbl.Location = new System.Drawing.Point(255, 47);
            this.Running_lbl.Name = "Running_lbl";
            this.Running_lbl.Size = new System.Drawing.Size(87, 17);
            this.Running_lbl.TabIndex = 2;
            this.Running_lbl.Text = "Not Running";
            // 
            // Error_ind
            // 
            this.Error_ind.BackColor = System.Drawing.Color.LimeGreen;
            this.Error_ind.Location = new System.Drawing.Point(6, 96);
            this.Error_ind.Name = "Error_ind";
            this.Error_ind.Size = new System.Drawing.Size(585, 69);
            this.Error_ind.TabIndex = 1;
            this.Error_ind.TabStop = false;
            // 
            // Running_ind
            // 
            this.Running_ind.BackColor = System.Drawing.Color.IndianRed;
            this.Running_ind.Location = new System.Drawing.Point(6, 21);
            this.Running_ind.Name = "Running_ind";
            this.Running_ind.Size = new System.Drawing.Size(585, 69);
            this.Running_ind.TabIndex = 0;
            this.Running_ind.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TraverseLineMode_grp);
            this.groupBox2.Controls.Add(this.ProgrammedExecutionMode_grp);
            this.groupBox2.Controls.Add(this.PreciseExecutionMode_grp);
            this.groupBox2.Controls.Add(this.OvrCurpos_lbl);
            this.groupBox2.Location = new System.Drawing.Point(12, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(774, 241);
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
            this.TraverseLineMode_grp.Location = new System.Drawing.Point(580, 22);
            this.TraverseLineMode_grp.Name = "TraverseLineMode_grp";
            this.TraverseLineMode_grp.Size = new System.Drawing.Size(188, 213);
            this.TraverseLineMode_grp.TabIndex = 17;
            this.TraverseLineMode_grp.TabStop = false;
            this.TraverseLineMode_grp.Text = "Traverse Line Mode";
            // 
            // NextPos_entry
            // 
            this.NextPos_entry.Location = new System.Drawing.Point(9, 101);
            this.NextPos_entry.Mask = "(0.00, 0.00, 0.00)";
            this.NextPos_entry.Name = "NextPos_entry";
            this.NextPos_entry.Size = new System.Drawing.Size(173, 22);
            this.NextPos_entry.TabIndex = 19;
            this.NextPos_entry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Error: [None | Input Error]";
            // 
            // TL_curPos_lbl
            // 
            this.TL_curPos_lbl.Enabled = false;
            this.TL_curPos_lbl.Location = new System.Drawing.Point(9, 41);
            this.TL_curPos_lbl.Name = "TL_curPos_lbl";
            this.TL_curPos_lbl.Size = new System.Drawing.Size(173, 22);
            this.TL_curPos_lbl.TabIndex = 15;
            // 
            // MoveToPos_lbl
            // 
            this.MoveToPos_lbl.AutoSize = true;
            this.MoveToPos_lbl.Location = new System.Drawing.Point(6, 81);
            this.MoveToPos_lbl.Name = "MoveToPos_lbl";
            this.MoveToPos_lbl.Size = new System.Drawing.Size(153, 17);
            this.MoveToPos_lbl.TabIndex = 17;
            this.MoveToPos_lbl.Text = "Move To Position: x,y,z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Current Position:";
            // 
            // ProgrammedExecutionMode_grp
            // 
            this.ProgrammedExecutionMode_grp.Controls.Add(this.PassFail_lbl);
            this.ProgrammedExecutionMode_grp.Controls.Add(this.NewFile_btn);
            this.ProgrammedExecutionMode_grp.Controls.Add(this.EditFile_btn);
            this.ProgrammedExecutionMode_grp.Controls.Add(this.LoadFile_btn);
            this.ProgrammedExecutionMode_grp.Location = new System.Drawing.Point(359, 21);
            this.ProgrammedExecutionMode_grp.Name = "ProgrammedExecutionMode_grp";
            this.ProgrammedExecutionMode_grp.Size = new System.Drawing.Size(214, 214);
            this.ProgrammedExecutionMode_grp.TabIndex = 16;
            this.ProgrammedExecutionMode_grp.TabStop = false;
            this.ProgrammedExecutionMode_grp.Text = "Programmed Execution Mode";
            // 
            // PassFail_lbl
            // 
            this.PassFail_lbl.AutoSize = true;
            this.PassFail_lbl.Location = new System.Drawing.Point(31, 173);
            this.PassFail_lbl.Name = "PassFail_lbl";
            this.PassFail_lbl.Size = new System.Drawing.Size(168, 17);
            this.PassFail_lbl.TabIndex = 5;
            this.PassFail_lbl.Text = "File Load: [Success | Fail]";
            // 
            // NewFile_btn
            // 
            this.NewFile_btn.Location = new System.Drawing.Point(6, 116);
            this.NewFile_btn.Name = "NewFile_btn";
            this.NewFile_btn.Size = new System.Drawing.Size(202, 39);
            this.NewFile_btn.TabIndex = 4;
            this.NewFile_btn.Text = "New File";
            this.NewFile_btn.UseVisualStyleBackColor = true;
            // 
            // EditFile_btn
            // 
            this.EditFile_btn.Location = new System.Drawing.Point(6, 71);
            this.EditFile_btn.Name = "EditFile_btn";
            this.EditFile_btn.Size = new System.Drawing.Size(202, 39);
            this.EditFile_btn.TabIndex = 3;
            this.EditFile_btn.Text = "Edit Current File";
            this.EditFile_btn.UseVisualStyleBackColor = true;
            // 
            // LoadFile_btn
            // 
            this.LoadFile_btn.Location = new System.Drawing.Point(6, 26);
            this.LoadFile_btn.Name = "LoadFile_btn";
            this.LoadFile_btn.Size = new System.Drawing.Size(202, 39);
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
            this.PreciseExecutionMode_grp.Location = new System.Drawing.Point(153, 17);
            this.PreciseExecutionMode_grp.Name = "PreciseExecutionMode_grp";
            this.PreciseExecutionMode_grp.Size = new System.Drawing.Size(200, 218);
            this.PreciseExecutionMode_grp.TabIndex = 15;
            this.PreciseExecutionMode_grp.TabStop = false;
            this.PreciseExecutionMode_grp.Text = "Precise Execution Controls";
            // 
            // Servo2_entry
            // 
            this.Servo2_entry.Location = new System.Drawing.Point(88, 189);
            this.Servo2_entry.Mask = "#00000000000";
            this.Servo2_entry.Name = "Servo2_entry";
            this.Servo2_entry.PromptChar = ' ';
            this.Servo2_entry.Size = new System.Drawing.Size(100, 22);
            this.Servo2_entry.TabIndex = 24;
            // 
            // Servo1_entry
            // 
            this.Servo1_entry.Location = new System.Drawing.Point(88, 161);
            this.Servo1_entry.Mask = "#00000000000";
            this.Servo1_entry.Name = "Servo1_entry";
            this.Servo1_entry.PromptChar = ' ';
            this.Servo1_entry.Size = new System.Drawing.Size(100, 22);
            this.Servo1_entry.TabIndex = 23;
            // 
            // Stepper5_entry
            // 
            this.Stepper5_entry.Location = new System.Drawing.Point(88, 133);
            this.Stepper5_entry.Mask = "#00000000000";
            this.Stepper5_entry.Name = "Stepper5_entry";
            this.Stepper5_entry.PromptChar = ' ';
            this.Stepper5_entry.Size = new System.Drawing.Size(100, 22);
            this.Stepper5_entry.TabIndex = 22;
            // 
            // Stepper4_entry
            // 
            this.Stepper4_entry.Location = new System.Drawing.Point(88, 105);
            this.Stepper4_entry.Mask = "#00000000000";
            this.Stepper4_entry.Name = "Stepper4_entry";
            this.Stepper4_entry.PromptChar = ' ';
            this.Stepper4_entry.Size = new System.Drawing.Size(100, 22);
            this.Stepper4_entry.TabIndex = 21;
            // 
            // Stepper3_entry
            // 
            this.Stepper3_entry.Location = new System.Drawing.Point(88, 77);
            this.Stepper3_entry.Mask = "#00000000000";
            this.Stepper3_entry.Name = "Stepper3_entry";
            this.Stepper3_entry.PromptChar = ' ';
            this.Stepper3_entry.Size = new System.Drawing.Size(100, 22);
            this.Stepper3_entry.TabIndex = 20;
            // 
            // Stepper2_entry
            // 
            this.Stepper2_entry.Location = new System.Drawing.Point(88, 49);
            this.Stepper2_entry.Mask = "#00000000000";
            this.Stepper2_entry.Name = "Stepper2_entry";
            this.Stepper2_entry.PromptChar = ' ';
            this.Stepper2_entry.Size = new System.Drawing.Size(100, 22);
            this.Stepper2_entry.TabIndex = 19;
            // 
            // Stepper1_entry
            // 
            this.Stepper1_entry.Location = new System.Drawing.Point(88, 21);
            this.Stepper1_entry.Mask = "#00000000000";
            this.Stepper1_entry.Name = "Stepper1_entry";
            this.Stepper1_entry.PromptChar = ' ';
            this.Stepper1_entry.Size = new System.Drawing.Size(100, 22);
            this.Stepper1_entry.TabIndex = 18;
            this.Stepper1_entry.ValidatingType = typeof(int);
            // 
            // Stepper1_lbl
            // 
            this.Stepper1_lbl.AutoSize = true;
            this.Stepper1_lbl.Location = new System.Drawing.Point(8, 24);
            this.Stepper1_lbl.Name = "Stepper1_lbl";
            this.Stepper1_lbl.Size = new System.Drawing.Size(74, 17);
            this.Stepper1_lbl.TabIndex = 1;
            this.Stepper1_lbl.Text = "Stepper 1:";
            // 
            // Stepper2_lbl
            // 
            this.Stepper2_lbl.AutoSize = true;
            this.Stepper2_lbl.Location = new System.Drawing.Point(8, 52);
            this.Stepper2_lbl.Name = "Stepper2_lbl";
            this.Stepper2_lbl.Size = new System.Drawing.Size(74, 17);
            this.Stepper2_lbl.TabIndex = 3;
            this.Stepper2_lbl.Text = "Stepper 2:";
            // 
            // Stepper3_lbl
            // 
            this.Stepper3_lbl.AutoSize = true;
            this.Stepper3_lbl.Location = new System.Drawing.Point(8, 80);
            this.Stepper3_lbl.Name = "Stepper3_lbl";
            this.Stepper3_lbl.Size = new System.Drawing.Size(74, 17);
            this.Stepper3_lbl.TabIndex = 4;
            this.Stepper3_lbl.Text = "Stepper 3:";
            // 
            // Stepper4_lbl
            // 
            this.Stepper4_lbl.AutoSize = true;
            this.Stepper4_lbl.Location = new System.Drawing.Point(8, 108);
            this.Stepper4_lbl.Name = "Stepper4_lbl";
            this.Stepper4_lbl.Size = new System.Drawing.Size(74, 17);
            this.Stepper4_lbl.TabIndex = 5;
            this.Stepper4_lbl.Text = "Stepper 4:";
            // 
            // Stepper5_lbl
            // 
            this.Stepper5_lbl.AutoSize = true;
            this.Stepper5_lbl.Location = new System.Drawing.Point(8, 136);
            this.Stepper5_lbl.Name = "Stepper5_lbl";
            this.Stepper5_lbl.Size = new System.Drawing.Size(74, 17);
            this.Stepper5_lbl.TabIndex = 6;
            this.Stepper5_lbl.Text = "Stepper 5:";
            // 
            // Servo1_lbl
            // 
            this.Servo1_lbl.AutoSize = true;
            this.Servo1_lbl.Location = new System.Drawing.Point(21, 164);
            this.Servo1_lbl.Name = "Servo1_lbl";
            this.Servo1_lbl.Size = new System.Drawing.Size(61, 17);
            this.Servo1_lbl.TabIndex = 7;
            this.Servo1_lbl.Text = "Servo 1:";
            // 
            // Servo2_lbl
            // 
            this.Servo2_lbl.AutoSize = true;
            this.Servo2_lbl.Location = new System.Drawing.Point(21, 192);
            this.Servo2_lbl.Name = "Servo2_lbl";
            this.Servo2_lbl.Size = new System.Drawing.Size(61, 17);
            this.Servo2_lbl.TabIndex = 8;
            this.Servo2_lbl.Text = "Servo 2:";
            // 
            // OvrCurpos_lbl
            // 
            this.OvrCurpos_lbl.AutoSize = true;
            this.OvrCurpos_lbl.Location = new System.Drawing.Point(6, 21);
            this.OvrCurpos_lbl.Name = "OvrCurpos_lbl";
            this.OvrCurpos_lbl.Size = new System.Drawing.Size(113, 17);
            this.OvrCurpos_lbl.TabIndex = 0;
            this.OvrCurpos_lbl.Text = "Current Position:";
            this.OvrCurpos_lbl.Visible = false;
            // 
            // UART_COM
            // 
            this.UART_COM.BaudRate = 115200;
            this.UART_COM.PortName = "COM3";
            // 
            // Test_BTN
            // 
            this.Test_BTN.Name = "Test_BTN";
            this.Test_BTN.Size = new System.Drawing.Size(216, 26);
            this.Test_BTN.Text = "TEST";
            this.Test_BTN.Click += new System.EventHandler(this.Test_BTN_Click);
            // 
            // Main_wnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 457);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Common_grp);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Main_wnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "R.I.M. Test App";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Common_grp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error_ind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Running_ind)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TraverseLineMode_grp.ResumeLayout(false);
            this.TraverseLineMode_grp.PerformLayout();
            this.ProgrammedExecutionMode_grp.ResumeLayout(false);
            this.ProgrammedExecutionMode_grp.PerformLayout();
            this.PreciseExecutionMode_grp.ResumeLayout(false);
            this.PreciseExecutionMode_grp.PerformLayout();
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
        private System.Windows.Forms.Label Error_lbl;
        private System.Windows.Forms.Label Running_lbl;
        private System.Windows.Forms.PictureBox Error_ind;
        private System.Windows.Forms.PictureBox Running_ind;
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
    }
}

