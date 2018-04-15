using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace кг
{
    class Glass : filters
    {
        Random Rand = new Random(DateTime.Now.Millisecond);
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            
            int newX = (int)(x + (Rand.NextDouble()-  0.5) * 10);
            int newY = (int)(y + (Rand.NextDouble() - 0.5) * 10);
            return sourceImage.GetPixel(Clamp(newX, 0, sourceImage.Width - 1), Clamp(newY, 0, sourceImage.Height - 1));
        }
    }

}
