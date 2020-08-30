namespace Iris
{
    partial class AboutForm
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
            this.btn_AboutClose = new System.Windows.Forms.Button();
            this.lbl_About = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_AboutClose
            // 
            this.btn_AboutClose.Location = new System.Drawing.Point(56, 64);
            this.btn_AboutClose.Name = "btn_AboutClose";
            this.btn_AboutClose.Size = new System.Drawing.Size(75, 23);
            this.btn_AboutClose.TabIndex = 1;
            this.btn_AboutClose.Text = "Close";
            this.btn_AboutClose.UseVisualStyleBackColor = true;
            this.btn_AboutClose.Click += new System.EventHandler(this.btn_AboutClose_Click);
            // 
            // lbl_About
            // 
            this.lbl_About.AutoSize = true;
            this.lbl_About.Location = new System.Drawing.Point(12, 9);
            this.lbl_About.Name = "lbl_About";
            this.lbl_About.Size = new System.Drawing.Size(169, 52);
            this.lbl_About.TabIndex = 2;
            this.lbl_About.Text = "IRIS Photo Viewer\r\nMatthew Shaw (voidUpdate) 2020\r\nAll images are copyright of Na" +
    "sa\r\n#7582♥\r\n";
            this.lbl_About.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 93);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_About);
            this.Controls.Add(this.btn_AboutClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AboutForm";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AboutClose;
        private System.Windows.Forms.Label lbl_About;
    }
}