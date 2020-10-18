using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iris
{
    public abstract class Decoder
    {
        public abstract DecodedImage Decode(string ImgPath, ProgressBar progressBar);
    }
}
