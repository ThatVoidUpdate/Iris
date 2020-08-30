using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Iris
{
    public partial class Form1 : Form
    {
        public byte[] FileBytes;
        public int LabelSize;

        Bitmap ConvertedBitmap;


        public Form1()
        {
            InitializeComponent();
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
            for (int i = 0; i < s.Length; i++)
            {
                pbx_Image.Image = Decoder.Decode(s[i]);
            }
        }        
    }
}
