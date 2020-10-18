using System;
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


            DecodedImage decodedImage = SelectedDecoder.Decode(s[0], pgs_Decode);


            pbx_Image.Image = decodedImage.Image;
            lbx_Properties.Items.Clear();
            lbx_Properties.Items.AddRange(decodedImage.Metadata);
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
