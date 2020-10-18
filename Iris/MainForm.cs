using System;
using System.Drawing.Imaging;
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
            SelectedDecoder = new VoyagerDecoder();
        }

        public void AttemptDecode(string path)
        {
            try
            {
                DecodedImage decodedImage = SelectedDecoder.Decode(path, pgs_Decode);
                pbx_Image.Image = decodedImage.Image;
                lbx_Properties.Items.Clear();
                lbx_Properties.Items.AddRange(decodedImage.Metadata);
                saveToolStripMenuItem.Enabled = true;
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show($"Error processing IMG file: {exception.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

            if (Path.GetExtension(s[0]).ToLower() == ".img")
            {
                AttemptDecode(s[0]);
            }
            else
            {
                MessageBox.Show("File is not an IMG file", "File Type Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog.FileName != "")
                {
                    pbx_Image.Image.Save(saveFileDialog.FileName, ImageFormat.Png);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "IMG Files|*.IMG";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AttemptDecode(openFileDialog.FileName);
                }
            }
        }
    }
}
