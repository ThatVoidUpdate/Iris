using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Iris
{
    class Decoder
    {
        public static DecodedImage Decode(string ImgPath)
        {
            Console.WriteLine($"Filename: {ImgPath}");

            //load image
            byte[] FileBytes = File.ReadAllBytes(ImgPath);

            //decode image
            string fileString = Encoding.Default.GetString(FileBytes);

            Regex NumberRegex = new Regex(@"\d+", RegexOptions.Compiled);

            //Find the metadata length
            Regex LabelSizeRegex = new Regex(@"LBLSIZE=\d*\s", RegexOptions.Compiled);
            MatchCollection matches = LabelSizeRegex.Matches(fileString);

            int MetadataLength = Convert.ToInt32(NumberRegex.Matches(matches[0].Value)[0].Value);
            Console.WriteLine($"Metadata length: {MetadataLength}");
            string Metadata = fileString.Substring(0, MetadataLength);

            /*Console.WriteLine("Metadata:");
            foreach (string item in Metadata.Split(new string[] { "  "}, StringSplitOptions.None))
            {
                Console.WriteLine(item);
            }*/

            

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

            Bitmap ConvertedBitmap = new Bitmap(Width, Height);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color color = Color.FromArgb(ImageData[(y * Width) + x], ImageData[(y * Width) + x], ImageData[(y * Width) + x]);
                    ConvertedBitmap.SetPixel(x, y, color);
                }
            }

            return new DecodedImage(ConvertedBitmap, Metadata.Split(new string[]{ "  " }, StringSplitOptions.None));
        }

        /*public static Bitmap Decode(string ImgPath, string LblPath)
        {

        }*/
    }
}
