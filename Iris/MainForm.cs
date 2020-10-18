using System;
using System.IO;
using System.Windows.Forms;
using Iris.Decoders;

namespace Iris
{
    public partial class MainForm : Form
    {
        public static Decoder SelectedDecoder;
        public MainForm()
        {
            InitializeComponent();
            SelectedDecoder = new CassiniDecoder();
        }
        

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            Console.WriteLine(s[0]);

            if (Path.GetExtension(s[0]).ToLower() == ".img")
            {
                try
                {
                    DecodedImage decodedImage = SelectedDecoder.Decode(s[0], pgs_Decode);
                    pbx_Image.Image = decodedImage.Image;
                    lbx_Properties.Items.Clear();
                    lbx_Properties.Items.AddRange(decodedImage.Metadata);
                }
                catch (ArgumentException exception)
                {
                    MessageBox.Show($"Error processing IMG file: {exception.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Dropped file is not an IMG file", "File Type Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }
    }
}
