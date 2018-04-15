using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace кг
{
    class Waves_Vert : filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = (int)(x + 20 * Math.Sin(2 * Math.PI * x / 30));
            int newY = y;
            return sourceImage.GetPixel(Clamp(newX, 0, sourceImage.Width - 1), newY);
        }
    }
}
