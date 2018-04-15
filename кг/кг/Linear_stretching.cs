using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace кг
{
    class linear_stretching : filters
    {
        int maxR = 0;
        int maxG = 0;
        int maxB = 0;
        int t = 0;
        int minR = 255;
        int minG = 255;
        int minB = 255;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
           
            Color sourceColor = sourceImage.GetPixel(x, y);
            if (t == 0)
            {
                for (int n = 0; n < sourceImage.Width; n++)
                {
                    for (int m = 0; m < sourceImage.Height; m++)
                    {
                        Color color = sourceImage.GetPixel(n, m);
                        maxR = Math.Max(maxR, color.R);
                        maxG = Math.Max(maxG, color.G);
                        maxB = Math.Max(maxB, color.B);

                        minR = Math.Min(minR, color.R);
                        minG = Math.Min(minG, color.G);
                        minB = Math.Min(minB, color.B);
                    }
                }
            }
            t++;
            int r = Clamp(((sourceColor.R - minR) * 255 / (maxR - minR)), 0, 255);
            int g = Clamp(((sourceColor.G - minG) * 255 / (maxG - minG)), 0, 255);
            int b = Clamp(((sourceColor.B - minB) * 255 / (maxB - minB)), 0, 255);
            Color resultColor = Color.FromArgb(Clamp(r, 0, 255), Clamp(g, 0, 255), Clamp(b, 0, 255));
            return resultColor;
           
        }

    }
}
