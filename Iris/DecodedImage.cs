using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris
{
    class DecodedImage
    {
        public Bitmap Image;
        public Dictionary<string, string> Metadata;

        public DecodedImage(Bitmap _Image, Dictionary<string, string> _Metadata)
        {
            Image = _Image;
            Metadata = _Metadata;
        }
    }
}
