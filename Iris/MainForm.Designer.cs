namespace Iris
{
    partial class MainForm
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
            this.mst_Menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pgs_Decode = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Image)).BeginInit();
            this.mst_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbx_Image
            // 
            this.pbx_Image.Location = new System.Drawing.Point(13, 27);
            this.pbx_Image.Name = "pbx_Image";
            this.pbx_Image.Size = new System.Drawing.Size(500, 500);
            this.pbx_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_Image.TabIndex = 1;
            this.pbx_Image.TabStop = false;
            // 
            // lbx_Properties
            // 
            this.lbx_Properties.FormattingEnabled = true;
            this.lbx_Properties.Location = new System.Drawing.Point(519, 27);
            this.lbx_Properties.Name = "lbx_Properties";
            this.lbx_Properties.Size = new System.Drawing.Size(271, 524);
            this.lbx_Properties.TabIndex = 0;
            // 
            // mst_Menu
            // 
            this.mst_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mst_Menu.Location = new System.Drawing.Point(0, 0);
            this.mst_Menu.Name = "mst_Menu";
            this.mst_Menu.Size = new System.Drawing.Size(802, 24);
            this.mst_Menu.TabIndex = 2;
            this.mst_Menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pgs_Decode
            // 
            this.pgs_Decode.Location = new System.Drawing.Point(12, 533);
            this.pgs_Decode.Name = "pgs_Decode";
            this.pgs_Decode.Size = new System.Drawing.Size(501, 23);
            this.pgs_Decode.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgs_Decode.TabIndex = 3;
            this.pgs_Decode.Visible = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 561);
            this.Controls.Add(this.pgs_Decode);
            this.Controls.Add(this.lbx_Properties);
            this.Controls.Add(this.pbx_Image);
            this.Controls.Add(this.mst_Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mst_Menu;
            this.Name = "MainForm";
            this.Text = "IRIS Photo Viewer";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Image)).EndInit();
            this.mst_Menu.ResumeLayout(false);
            this.mst_Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbx_Image;
        private System.Windows.Forms.ListBox lbx_Properties;
        private System.Windows.Forms.MenuStrip mst_Menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar pgs_Decode;
    }
}

