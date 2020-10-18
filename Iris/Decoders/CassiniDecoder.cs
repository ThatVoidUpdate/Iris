using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iris.Decoders
{
    class CassiniDecoder : Decoder
    {
        public override DecodedImage Decode(string ImgPath, ProgressBar progressBar)
        {
            Console.WriteLine($"Filename: {ImgPath}");

            //Load file bytes
            byte[] FileBytes = File.ReadAllBytes(ImgPath);
            string FileString = Encoding.Default.GetString(FileBytes);

            //Regex to just extract numbers from a string
            Regex NumberRegex = new Regex(@"\d+", RegexOptions.Compiled);

            //Find the metadata length
            Regex LabelSizeRegex = new Regex(@"(LBLSIZE)\s?=\s?\d*\s", RegexOptions.Compiled);
            MatchCollection matches = LabelSizeRegex.Matches(FileString);

            int MetadataLength = Convert.ToInt32(NumberRegex.Matches(matches[0].Value)[0].Value);
            Console.WriteLine($"Metadata length: {MetadataLength}");
            string Metadata = FileString.Substring(0, MetadataLength);

            //Get width, height and line skip
            Regex WidthRegex = new Regex(@"(NS)\s?=\s?\d*\s", RegexOptions.Compiled);
            matches = WidthRegex.Matches(Metadata);
            int Width = Convert.ToInt32(NumberRegex.Matches(matches[0].Value)[0].Value);

            Regex HeightRegex = new Regex(@"(NL)\s?=\s?\d*\s", RegexOptions.Compiled);
            matches = HeightRegex.Matches(Metadata);
            int Height = Convert.ToInt32(NumberRegex.Matches(matches[0].Value)[0].Value);

            Regex SkipRegex = new Regex(@"(NBB)\s?=\s?\d*\s", RegexOptions.Compiled);
            matches = SkipRegex.Matches(Metadata);
            int LineSkip = Convert.ToInt32(NumberRegex.Matches(matches[0].Value)[0].Value);

            Console.WriteLine($"Dimensions: {Width}x{Height}, Skip per line: {LineSkip}");

            //Extract the data format, either BYTE or HALF for Cassini images
            Regex FormatRegex = new Regex(@"(FORMAT)\s?=\s?\S+\s", RegexOptions.Compiled);
            matches = FormatRegex.Matches(Metadata);
            String DataFormat = matches[0].Value.Split('=')[1];
            DataFormat = DataFormat.Substring(1, DataFormat.Length - 3);

            Console.WriteLine($"Data Format: {DataFormat}");

            //Crop the metadata off the top of the file
            int[] ImageData = FileBytes.Skip(MetadataLength).Select(x => (int)x).ToArray();

            //How many bytes each sample takes up in the file
            int BytesScale = 1;
            if (DataFormat == "HALF")
            {
                BytesScale = 2;
            }

            //Need to skip over the line header. For each line, skip NBB (LineSkip), then copy NS (Width) * ByteScale
            List<int> TempData = new List<int>();
            for (int i = 0; i < ImageData.Length; i++)
            {
                i += LineSkip;
                TempData.AddRange(ImageData.Skip(i).Take(Width * BytesScale));
                i += Width * BytesScale - 1;
            }
            ImageData = TempData.ToArray();


            //Take each pair of bytes, and compress into a single Binary16 (https://en.wikipedia.org/wiki/Half-precision_floating-point_format)
            if (DataFormat == "HALF")
            {
                ImageData = Enumerable.Range(0, ImageData.Length).Where(x => x % 2 == 0).Select(x => ((ImageData[x] << 8) + ImageData[x + 1]) >> 3).ToArray();
                ImageData = Enumerable.Range(0, ImageData.Length).Select(x => ImageData[x] > 255 ? 255 : ImageData[x]).ToArray();
            }

            //Create a new bitmap to render to, and set up the progress bar
            Bitmap ConvertedBitmap = new Bitmap(Width, Height);
            progressBar.Visible = true;
            progressBar.Maximum = Height;

            //For each byte in the file, write it out to the image
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    //int Valuebyte = (y * Width) + x + (y * LineSkip);
                    int Valuebyte = (y * Width) + x;
                    Color color = Color.FromArgb(ImageData[Valuebyte], ImageData[Valuebyte], ImageData[Valuebyte]);
                    ConvertedBitmap.SetPixel(x, y, color);
                }
                progressBar.Value = y;
            }

            //Hide the progress bar again
            progressBar.Visible = false;

            //Return the picture, and the metadata
            return new DecodedImage(ConvertedBitmap, Metadata.Split(new string[] { "  ", "\r\n" }, StringSplitOptions.None));
        }
    }
}

