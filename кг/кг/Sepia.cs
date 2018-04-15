using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace кг
{
    class Sepia : filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int Intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            int k = 10; // коэффициент сепии
            Color resultColor = Color.FromArgb(Clamp(Intensity + 2 * k, 0, 255), Clamp(Intensity + (int)0.5 * k, 0, 255), Clamp(Intensity - 1 * k, 0, 255));
            return resultColor;
        }
    }

}

