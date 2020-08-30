namespace Iris
{
    partial class Form1
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
            this.pbx_Image = new System.Windows.Forms.PictureBox();
            this.lbx_Properties = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_Image
            // 
            this.pbx_Image.Location = new System.Drawing.Point(13, 13);
            this.pbx_Image.Name = "pbx_Image";
            this.pbx_Image.Size = new System.Drawing.Size(500, 500);
            this.pbx_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_Image.TabIndex = 1;
            this.pbx_Image.TabStop = false;
            // 
            // lbx_Properties
            // 
            this.lbx_Properties.FormattingEnabled = true;
            this.lbx_Properties.Location = new System.Drawing.Point(519, 12);
            this.lbx_Properties.Name = "lbx_Properties";
            this.lbx_Properties.Size = new System.Drawing.Size(271, 498);
            this.lbx_Properties.TabIndex = 0;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 525);
            this.Controls.Add(this.lbx_Properties);
            this.Controls.Add(this.pbx_Image);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbx_Image;
        private System.Windows.Forms.ListBox lbx_Properties;
    }
}

