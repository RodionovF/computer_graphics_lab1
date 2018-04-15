using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace кг
{
    class TopHat : Closing
    {
        public TopHat(Bitmap image, int size, int _TypeOfMorph) : base(image, size, _TypeOfMorph)
        {
            maxSize = size;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color curr = sourceImage.GetPixel(x, y);
            Color open = image_temp.GetPixel(x, y);
            return Color.FromArgb(Clamp(open.R - curr.R, 0, 255),
                                  Clamp(open.G - curr.G, 0, 255),
                                  Clamp(open.B - curr.B, 0, 255));
        }
    }
}
