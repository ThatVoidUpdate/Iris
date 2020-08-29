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
            this.pnl_Controls = new System.Windows.Forms.Panel();
            this.pbx_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Controls
            // 
            this.pnl_Controls.Location = new System.Drawing.Point(519, 13);
            this.pnl_Controls.Name = "pnl_Controls";
            this.pnl_Controls.Size = new System.Drawing.Size(270, 500);
            this.pnl_Controls.TabIndex = 0;
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
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 525);
            this.Controls.Add(this.pbx_Image);
            this.Controls.Add(this.pnl_Controls);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Controls;
        private System.Windows.Forms.PictureBox pbx_Image;
    }
}

