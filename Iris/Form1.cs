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
                Decode(s[i]);
            }
        }


        public void Decode(string Filename)
        {
            Console.WriteLine($"Filename: {Filename}");

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

            /*Regex TargetRegex = new Regex(@"TARGET_NAME='[\s\w]+'", RegexOptions.Compiled);
            matches = TargetRegex.Matches(Metadata);
            String Target = matches[0].Value.Split('=')[1];
            Target = Target.Substring(1, Target.Length - 2);

            Console.WriteLine($"Target: {Target}");
            */
            /*
             * Get data format
            Format = re.findall(r"FORMAT='\w+'", Metadata)[0]
            Format = Format.split('=')[1][1:-1]
             */

            Regex FormatRegex = new Regex(@"FORMAT='\w+'", RegexOptions.Compiled);
            matches = FormatRegex.Matches(Metadata);
            String DataFormat = matches[0].Value.Split('=')[1];
            DataFormat = DataFormat.Substring(1, DataFormat.Length - 2);

            Console.WriteLine($"Data Format: {DataFormat}");

            //write image to pbx_Image

            int[] ImageData = FileBytes.Skip(MetadataLength).Select(x => (int)x).ToArray();

            if (DataFormat == "HALF")
            {
                Width = Width >> 1;
                //ImageFileData = [((ImageFileData[x] << 8) + ImageFileData[x+1]) / 8  for x in range(0, len(ImageFileData), 2)]
                //ImageData = Enumerable.Range(0, ImageData.Length).Where(x => x % 2 == 0).Select(x => (ImageData[x] << 8) + ImageData[x + 1]).ToArray();
                ImageData = Enumerable.Range(0, ImageData.Length).Where(x => x % 2 == 0).Select(x => ((ImageData[x] << 8) + ImageData[x + 1]) >> 3).ToArray();
                ImageData = Enumerable.Range(0, ImageData.Length).Select(x => ImageData[x] > 255 ? 255 : ImageData[x]).ToArray();
            }

            ConvertedBitmap = new Bitmap(Width, Height);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color color = Color.FromArgb(ImageData[(y * Width) + x], ImageData[(y * Width) + x], ImageData[(y * Width) + x]);
                    ConvertedBitmap.SetPixel(x, y, color);
                }
            }

            pbx_Image.Image = ConvertedBitmap;
        }
    }
}
