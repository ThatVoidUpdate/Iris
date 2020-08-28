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

        Image convertedImage;
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
                Console.WriteLine(s[i]);
                Decode(s[i]);
            }
        }


        public void Decode(string Filename)
        {
            //load image
            FileBytes = File.ReadAllBytes(Filename);

            //decode image
            string fileString = Encoding.Default.GetString(FileBytes);

            Regex NumberRegex = new Regex(@"\d+", RegexOptions.Compiled);

            //Find the metadata length
            Regex LabelSizeRegex = new Regex(@"LBLSIZE=\d*\s", RegexOptions.Compiled);
            MatchCollection matches = LabelSizeRegex.Matches(fileString);

            int MetadataLength = Convert.ToInt32(NumberRegex.Matches(matches[0].Value)[0].Value);
            Console.WriteLine($"Metadata length: {MetadataLength}");
            string Metadata = fileString.Substring(0, MetadataLength);

            /*
             * Get width and height:
            width = re.findall(r"RECSIZE=\d*\s", Metadata)[0]
            width = int(re.findall(r"\d+", width)[0])

            height = re.findall(r"NL=\d*\s", Metadata)[0]
            height = int(re.findall(r"\d+", height)[0])
            */

            Regex WidthRegex = new Regex(@"RECSIZE=\d*\s", RegexOptions.Compiled);
            matches = WidthRegex.Matches(Metadata);
            int Width = Convert.ToInt32(NumberRegex.Matches(matches[0].Value)[0].Value);

            Regex HeightRegex = new Regex(@"NL=\d*\s", RegexOptions.Compiled);
            matches = HeightRegex.Matches(Metadata);
            int Height = Convert.ToInt32(NumberRegex.Matches(matches[0].Value)[0].Value);

            Console.WriteLine($"Dimensions: {Width}x{Height}");

            /*
             * Get Target
            Target = re.findall(r"TARGET_NAME='[\s\w]+'", Metadata)[0]
            Target= Target.split('=')[1][1:-1]
            */

            Regex TargetRegex = new Regex(@"TARGET_NAME='[\s\w]+'", RegexOptions.Compiled);
            matches = TargetRegex.Matches(Metadata);
            String Target = matches[0].Value;

            Console.WriteLine($"Target: {Target.Split('=')[1]}");


            //write image to pbx_Image
            ConvertedBitmap = new Bitmap(Width, Height);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color color = Color.FromArgb(FileBytes[MetadataLength + (y * Width) + x], FileBytes[MetadataLength + (y * Width) + x], FileBytes[MetadataLength + (y * Width) + x]);
                    ConvertedBitmap.SetPixel(x, y, color);
                }
            }

            pbx_Image.Image = ConvertedBitmap;
        }
    }
}
