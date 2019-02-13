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
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.Ok_btn = new System.Windows.Forms.Button();
            this.COMPort_lbl = new System.Windows.Forms.Label();
            this.COMPortEntry_sel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.COMPortEntry_sel)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(12, 58);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(89, 38);
            this.Cancel_btn.TabIndex = 2;
            this.Cancel_btn.Text = "&Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(139, 58);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(89, 38);
            this.Ok_btn.TabIndex = 1;
            this.Ok_btn.Text = "&OK";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // COMPort_lbl
            // 
            this.COMPort_lbl.AutoSize = true;
            this.COMPort_lbl.Location = new System.Drawing.Point(9, 20);
            this.COMPort_lbl.Name = "COMPort_lbl";
            this.COMPort_lbl.Size = new System.Drawing.Size(131, 17);
            this.COMPort_lbl.TabIndex = 3;
            this.COMPort_lbl.Text = "COM Port Number: ";
            // 
            // COMPortEntry_sel
            // 
            this.COMPortEntry_sel.Location = new System.Drawing.Point(166, 17);
            this.COMPortEntry_sel.Name = "COMPortEntry_sel";
            this.COMPortEntry_sel.Size = new System.Drawing.Size(62, 22);
            this.COMPortEntry_sel.TabIndex = 0;
            // 
            // ConfigBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 104);
            this.Controls.Add(this.COMPortEntry_sel);
            this.Controls.Add(this.COMPort_lbl);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Cancel_btn);
            this.Name = "ConfigBox";
            this.Text = "ConfigBox";
            ((System.ComponentModel.ISupportInitialize)(this.COMPortEntry_sel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Button Ok_btn;
        private System.Windows.Forms.Label COMPort_lbl;
        private System.Windows.Forms.NumericUpDown COMPortEntry_sel;
    }
}