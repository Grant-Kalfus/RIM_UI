namespace R.I.M.UI_Shell
{
    partial class ConfigBox
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
            this.Set_btn = new System.Windows.Forms.Button();
            this.Ok_btn = new System.Windows.Forms.Button();
            this.COMPort_lbl = new System.Windows.Forms.Label();
            this.PortList_lst = new System.Windows.Forms.ComboBox();
            this.Dev_Config = new System.Windows.Forms.TabControl();
            this.M1_cfg = new System.Windows.Forms.TabPage();
            this.M1MaxDecel_entry = new System.Windows.Forms.NumericUpDown();
            this.M1MaxAccel_entry = new System.Windows.Forms.NumericUpDown();
            this.M1MaxSpeed_entry = new System.Windows.Forms.NumericUpDown();
            this.M1MaxDecel_lbl = new System.Windows.Forms.Label();
            this.M1MaxAccel_lbl = new System.Windows.Forms.Label();
            this.M1MaxSpeed_lbl = new System.Windows.Forms.Label();
            this.M1StepType_lbl = new System.Windows.Forms.Label();
            this.M1StepType_entry = new System.Windows.Forms.ComboBox();
            this.M2_cfg = new System.Windows.Forms.TabPage();
            this.M2MaxDecel_entry = new System.Windows.Forms.NumericUpDown();
            this.M2MaxAccel_entry = new System.Windows.Forms.NumericUpDown();
            this.M2StepType_entry = new System.Windows.Forms.ComboBox();
            this.M2MaxSpeed_entry = new System.Windows.Forms.NumericUpDown();
            this.M2StepType_lbl = new System.Windows.Forms.Label();
            this.M2MaxDecel_lbl = new System.Windows.Forms.Label();
            this.M2MaxSpeed_lbl = new System.Windows.Forms.Label();
            this.M2MaxAccel_lbl = new System.Windows.Forms.Label();
            this.M3_cfg = new System.Windows.Forms.TabPage();
            this.M4_cfg = new System.Windows.Forms.TabPage();
            this.M5_cfg = new System.Windows.Forms.TabPage();
            this.Fetch_btn = new System.Windows.Forms.Button();
            this.Dev_Config.SuspendLayout();
            this.M1_cfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M1MaxDecel_entry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M1MaxAccel_entry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M1MaxSpeed_entry)).BeginInit();
            this.M2_cfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M2MaxDecel_entry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M2MaxAccel_entry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M2MaxSpeed_entry)).BeginInit();
            this.SuspendLayout();
            // 
            // Set_btn
            // 
            this.Set_btn.Enabled = false;
            this.Set_btn.Location = new System.Drawing.Point(10, 204);
            this.Set_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Set_btn.Name = "Set_btn";
            this.Set_btn.Size = new System.Drawing.Size(67, 31);
            this.Set_btn.TabIndex = 2;
            this.Set_btn.Text = "Set";
            this.Set_btn.UseVisualStyleBackColor = true;
            // 
            // Ok_btn
            // 
            this.Ok_btn.Enabled = false;
            this.Ok_btn.Location = new System.Drawing.Point(144, 204);
            this.Ok_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(67, 31);
            this.Ok_btn.TabIndex = 1;
            this.Ok_btn.Text = "&OK";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // COMPort_lbl
            // 
            this.COMPort_lbl.AutoSize = true;
            this.COMPort_lbl.Location = new System.Drawing.Point(7, 16);
            this.COMPort_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.COMPort_lbl.Name = "COMPort_lbl";
            this.COMPort_lbl.Size = new System.Drawing.Size(99, 13);
            this.COMPort_lbl.TabIndex = 3;
            this.COMPort_lbl.Text = "COM Port Number: ";
            // 
            // PortList_lst
            // 
            this.PortList_lst.FormattingEnabled = true;
            this.PortList_lst.Location = new System.Drawing.Point(111, 12);
            this.PortList_lst.Name = "PortList_lst";
            this.PortList_lst.Size = new System.Drawing.Size(100, 21);
            this.PortList_lst.TabIndex = 4;
            // 
            // Dev_Config
            // 
            this.Dev_Config.Controls.Add(this.M1_cfg);
            this.Dev_Config.Controls.Add(this.M2_cfg);
            this.Dev_Config.Controls.Add(this.M3_cfg);
            this.Dev_Config.Controls.Add(this.M4_cfg);
            this.Dev_Config.Controls.Add(this.M5_cfg);
            this.Dev_Config.Enabled = false;
            this.Dev_Config.Location = new System.Drawing.Point(12, 39);
            this.Dev_Config.Name = "Dev_Config";
            this.Dev_Config.SelectedIndex = 0;
            this.Dev_Config.Size = new System.Drawing.Size(199, 160);
            this.Dev_Config.TabIndex = 5;
            // 
            // M1_cfg
            // 
            this.M1_cfg.Controls.Add(this.M1MaxDecel_entry);
            this.M1_cfg.Controls.Add(this.M1MaxAccel_entry);
            this.M1_cfg.Controls.Add(this.M1MaxSpeed_entry);
            this.M1_cfg.Controls.Add(this.M1MaxDecel_lbl);
            this.M1_cfg.Controls.Add(this.M1MaxAccel_lbl);
            this.M1_cfg.Controls.Add(this.M1MaxSpeed_lbl);
            this.M1_cfg.Controls.Add(this.M1StepType_lbl);
            this.M1_cfg.Controls.Add(this.M1StepType_entry);
            this.M1_cfg.Location = new System.Drawing.Point(4, 22);
            this.M1_cfg.Name = "M1_cfg";
            this.M1_cfg.Padding = new System.Windows.Forms.Padding(3);
            this.M1_cfg.Size = new System.Drawing.Size(191, 134);
            this.M1_cfg.TabIndex = 0;
            this.M1_cfg.Text = "M1";
            this.M1_cfg.UseVisualStyleBackColor = true;
            // 
            // M1MaxDecel_entry
            // 
            this.M1MaxDecel_entry.Location = new System.Drawing.Point(132, 111);
            this.M1MaxDecel_entry.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.M1MaxDecel_entry.Name = "M1MaxDecel_entry";
            this.M1MaxDecel_entry.Size = new System.Drawing.Size(56, 20);
            this.M1MaxDecel_entry.TabIndex = 8;
            // 
            // M1MaxAccel_entry
            // 
            this.M1MaxAccel_entry.Location = new System.Drawing.Point(132, 76);
            this.M1MaxAccel_entry.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.M1MaxAccel_entry.Name = "M1MaxAccel_entry";
            this.M1MaxAccel_entry.Size = new System.Drawing.Size(56, 20);
            this.M1MaxAccel_entry.TabIndex = 7;
            // 
            // M1MaxSpeed_entry
            // 
            this.M1MaxSpeed_entry.Location = new System.Drawing.Point(132, 41);
            this.M1MaxSpeed_entry.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.M1MaxSpeed_entry.Name = "M1MaxSpeed_entry";
            this.M1MaxSpeed_entry.Size = new System.Drawing.Size(56, 20);
            this.M1MaxSpeed_entry.TabIndex = 6;
            // 
            // M1MaxDecel_lbl
            // 
            this.M1MaxDecel_lbl.AutoSize = true;
            this.M1MaxDecel_lbl.Location = new System.Drawing.Point(6, 114);
            this.M1MaxDecel_lbl.Name = "M1MaxDecel_lbl";
            this.M1MaxDecel_lbl.Size = new System.Drawing.Size(126, 13);
            this.M1MaxDecel_lbl.TabIndex = 5;
            this.M1MaxDecel_lbl.Text = "Max Decel (steps/sec^2)";
            // 
            // M1MaxAccel_lbl
            // 
            this.M1MaxAccel_lbl.AutoSize = true;
            this.M1MaxAccel_lbl.Location = new System.Drawing.Point(6, 79);
            this.M1MaxAccel_lbl.Name = "M1MaxAccel_lbl";
            this.M1MaxAccel_lbl.Size = new System.Drawing.Size(125, 13);
            this.M1MaxAccel_lbl.TabIndex = 4;
            this.M1MaxAccel_lbl.Text = "Max Accel (steps/sec^2)";
            // 
            // M1MaxSpeed_lbl
            // 
            this.M1MaxSpeed_lbl.AutoSize = true;
            this.M1MaxSpeed_lbl.Location = new System.Drawing.Point(6, 44);
            this.M1MaxSpeed_lbl.Name = "M1MaxSpeed_lbl";
            this.M1MaxSpeed_lbl.Size = new System.Drawing.Size(117, 13);
            this.M1MaxSpeed_lbl.TabIndex = 2;
            this.M1MaxSpeed_lbl.Text = "Max Speed (steps/sec)";
            // 
            // M1StepType_lbl
            // 
            this.M1StepType_lbl.AutoSize = true;
            this.M1StepType_lbl.Location = new System.Drawing.Point(6, 9);
            this.M1StepType_lbl.Name = "M1StepType_lbl";
            this.M1StepType_lbl.Size = new System.Drawing.Size(56, 13);
            this.M1StepType_lbl.TabIndex = 1;
            this.M1StepType_lbl.Text = "Step Type";
            // 
            // M1StepType_entry
            // 
            this.M1StepType_entry.FormattingEnabled = true;
            this.M1StepType_entry.Items.AddRange(new object[] {
            "Full",
            "1/2",
            "1/4",
            "1/8",
            "1/16",
            "1/32",
            "1/64",
            "1/128"});
            this.M1StepType_entry.Location = new System.Drawing.Point(68, 5);
            this.M1StepType_entry.Name = "M1StepType_entry";
            this.M1StepType_entry.Size = new System.Drawing.Size(117, 21);
            this.M1StepType_entry.TabIndex = 0;
            // 
            // M2_cfg
            // 
            this.M2_cfg.Controls.Add(this.M2MaxDecel_entry);
            this.M2_cfg.Controls.Add(this.M2MaxAccel_entry);
            this.M2_cfg.Controls.Add(this.M2StepType_entry);
            this.M2_cfg.Controls.Add(this.M2MaxSpeed_entry);
            this.M2_cfg.Controls.Add(this.M2StepType_lbl);
            this.M2_cfg.Controls.Add(this.M2MaxDecel_lbl);
            this.M2_cfg.Controls.Add(this.M2MaxSpeed_lbl);
            this.M2_cfg.Controls.Add(this.M2MaxAccel_lbl);
            this.M2_cfg.Location = new System.Drawing.Point(4, 22);
            this.M2_cfg.Name = "M2_cfg";
            this.M2_cfg.Padding = new System.Windows.Forms.Padding(3);
            this.M2_cfg.Size = new System.Drawing.Size(191, 134);
            this.M2_cfg.TabIndex = 1;
            this.M2_cfg.Text = "M2";
            this.M2_cfg.UseVisualStyleBackColor = true;
            // 
            // M2MaxDecel_entry
            // 
            this.M2MaxDecel_entry.Location = new System.Drawing.Point(132, 111);
            this.M2MaxDecel_entry.Name = "M2MaxDecel_entry";
            this.M2MaxDecel_entry.Size = new System.Drawing.Size(56, 20);
            this.M2MaxDecel_entry.TabIndex = 16;
            // 
            // M2MaxAccel_entry
            // 
            this.M2MaxAccel_entry.Location = new System.Drawing.Point(132, 76);
            this.M2MaxAccel_entry.Name = "M2MaxAccel_entry";
            this.M2MaxAccel_entry.Size = new System.Drawing.Size(56, 20);
            this.M2MaxAccel_entry.TabIndex = 15;
            // 
            // M2StepType_entry
            // 
            this.M2StepType_entry.FormattingEnabled = true;
            this.M2StepType_entry.Items.AddRange(new object[] {
            "Full",
            "1/2",
            "1/4",
            "1/8",
            "1/16",
            "1/32",
            "1/64",
            "1/128"});
            this.M2StepType_entry.Location = new System.Drawing.Point(68, 5);
            this.M2StepType_entry.Name = "M2StepType_entry";
            this.M2StepType_entry.Size = new System.Drawing.Size(117, 21);
            this.M2StepType_entry.TabIndex = 9;
            // 
            // M2MaxSpeed_entry
            // 
            this.M2MaxSpeed_entry.Location = new System.Drawing.Point(132, 41);
            this.M2MaxSpeed_entry.Name = "M2MaxSpeed_entry";
            this.M2MaxSpeed_entry.Size = new System.Drawing.Size(56, 20);
            this.M2MaxSpeed_entry.TabIndex = 14;
            // 
            // M2StepType_lbl
            // 
            this.M2StepType_lbl.AutoSize = true;
            this.M2StepType_lbl.Location = new System.Drawing.Point(6, 9);
            this.M2StepType_lbl.Name = "M2StepType_lbl";
            this.M2StepType_lbl.Size = new System.Drawing.Size(56, 13);
            this.M2StepType_lbl.TabIndex = 10;
            this.M2StepType_lbl.Text = "Step Type";
            // 
            // M2MaxDecel_lbl
            // 
            this.M2MaxDecel_lbl.AutoSize = true;
            this.M2MaxDecel_lbl.Location = new System.Drawing.Point(6, 114);
            this.M2MaxDecel_lbl.Name = "M2MaxDecel_lbl";
            this.M2MaxDecel_lbl.Size = new System.Drawing.Size(126, 13);
            this.M2MaxDecel_lbl.TabIndex = 13;
            this.M2MaxDecel_lbl.Text = "Max Decel (steps/sec^2)";
            // 
            // M2MaxSpeed_lbl
            // 
            this.M2MaxSpeed_lbl.AutoSize = true;
            this.M2MaxSpeed_lbl.Location = new System.Drawing.Point(6, 44);
            this.M2MaxSpeed_lbl.Name = "M2MaxSpeed_lbl";
            this.M2MaxSpeed_lbl.Size = new System.Drawing.Size(117, 13);
            this.M2MaxSpeed_lbl.TabIndex = 11;
            this.M2MaxSpeed_lbl.Text = "Max Speed (steps/sec)";
            // 
            // M2MaxAccel_lbl
            // 
            this.M2MaxAccel_lbl.AutoSize = true;
            this.M2MaxAccel_lbl.Location = new System.Drawing.Point(6, 79);
            this.M2MaxAccel_lbl.Name = "M2MaxAccel_lbl";
            this.M2MaxAccel_lbl.Size = new System.Drawing.Size(125, 13);
            this.M2MaxAccel_lbl.TabIndex = 12;
            this.M2MaxAccel_lbl.Text = "Max Accel (steps/sec^2)";
            // 
            // M3_cfg
            // 
            this.M3_cfg.Location = new System.Drawing.Point(4, 22);
            this.M3_cfg.Name = "M3_cfg";
            this.M3_cfg.Padding = new System.Windows.Forms.Padding(3);
            this.M3_cfg.Size = new System.Drawing.Size(191, 134);
            this.M3_cfg.TabIndex = 2;
            this.M3_cfg.Text = "M3";
            this.M3_cfg.UseVisualStyleBackColor = true;
            // 
            // M4_cfg
            // 
            this.M4_cfg.Location = new System.Drawing.Point(4, 22);
            this.M4_cfg.Name = "M4_cfg";
            this.M4_cfg.Padding = new System.Windows.Forms.Padding(3);
            this.M4_cfg.Size = new System.Drawing.Size(191, 134);
            this.M4_cfg.TabIndex = 3;
            this.M4_cfg.Text = "M4";
            this.M4_cfg.UseVisualStyleBackColor = true;
            // 
            // M5_cfg
            // 
            this.M5_cfg.Location = new System.Drawing.Point(4, 22);
            this.M5_cfg.Name = "M5_cfg";
            this.M5_cfg.Padding = new System.Windows.Forms.Padding(3);
            this.M5_cfg.Size = new System.Drawing.Size(191, 134);
            this.M5_cfg.TabIndex = 4;
            this.M5_cfg.Text = "M5";
            this.M5_cfg.UseVisualStyleBackColor = true;
            // 
            // Fetch_btn
            // 
            this.Fetch_btn.Location = new System.Drawing.Point(81, 204);
            this.Fetch_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Fetch_btn.Name = "Fetch_btn";
            this.Fetch_btn.Size = new System.Drawing.Size(59, 31);
            this.Fetch_btn.TabIndex = 6;
            this.Fetch_btn.Text = "Fetch";
            this.Fetch_btn.UseVisualStyleBackColor = true;
            this.Fetch_btn.Click += new System.EventHandler(this.Fetch_btn_Click);
            // 
            // ConfigBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 246);
            this.Controls.Add(this.Fetch_btn);
            this.Controls.Add(this.Dev_Config);
            this.Controls.Add(this.PortList_lst);
            this.Controls.Add(this.COMPort_lbl);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Set_btn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConfigBox";
            this.Text = "ConfigBox";
            this.Load += new System.EventHandler(this.ConfigBox_Load);
            this.Dev_Config.ResumeLayout(false);
            this.M1_cfg.ResumeLayout(false);
            this.M1_cfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M1MaxDecel_entry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M1MaxAccel_entry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M1MaxSpeed_entry)).EndInit();
            this.M2_cfg.ResumeLayout(false);
            this.M2_cfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M2MaxDecel_entry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M2MaxAccel_entry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M2MaxSpeed_entry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Set_btn;
        private System.Windows.Forms.Button Ok_btn;
        private System.Windows.Forms.Label COMPort_lbl;
        private System.Windows.Forms.ComboBox PortList_lst;
        private System.Windows.Forms.TabControl Dev_Config;
        private System.Windows.Forms.TabPage M1_cfg;
        private System.Windows.Forms.NumericUpDown M1MaxDecel_entry;
        private System.Windows.Forms.NumericUpDown M1MaxAccel_entry;
        private System.Windows.Forms.NumericUpDown M1MaxSpeed_entry;
        private System.Windows.Forms.Label M1MaxDecel_lbl;
        private System.Windows.Forms.Label M1MaxAccel_lbl;
        private System.Windows.Forms.Label M1MaxSpeed_lbl;
        private System.Windows.Forms.Label M1StepType_lbl;
        private System.Windows.Forms.ComboBox M1StepType_entry;
        private System.Windows.Forms.TabPage M2_cfg;
        private System.Windows.Forms.TabPage M3_cfg;
        private System.Windows.Forms.TabPage M4_cfg;
        private System.Windows.Forms.TabPage M5_cfg;
        private System.Windows.Forms.NumericUpDown M2MaxDecel_entry;
        private System.Windows.Forms.NumericUpDown M2MaxAccel_entry;
        private System.Windows.Forms.ComboBox M2StepType_entry;
        private System.Windows.Forms.NumericUpDown M2MaxSpeed_entry;
        private System.Windows.Forms.Label M2StepType_lbl;
        private System.Windows.Forms.Label M2MaxDecel_lbl;
        private System.Windows.Forms.Label M2MaxSpeed_lbl;
        private System.Windows.Forms.Label M2MaxAccel_lbl;
        private System.Windows.Forms.Button Fetch_btn;
    }
}