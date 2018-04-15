using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace кг
{
    class IdealMirrorer : filters
    {
        protected int maxR = 0;
        protected int maxG = 0;
        protected int maxB = 0;

        public IdealMirrorer(Bitmap image)
        {
            for (int i = 0; i < image.Width - 1; i++)
            {
                for (int j = 0; j < image.Height - 1; j++)
                {
                    Color curr = image.GetPixel(i, j);
                    if (curr.R > maxR)
                        maxR = curr.R;
                    if (curr.G > maxG)
                        maxG = curr.G;
                    if (curr.B > maxB)
                        maxB = curr.B;
                }
            }
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color curr = sourceImage.GetPixel(x, y);
            int resultR = curr.R * 255 / maxR;
            int resultG = curr.G * 255 / maxG;
            int resultB = curr.B * 255 / maxB;
            return Color.FromArgb(Clamp(resultR, 0, 255),
                                  Clamp(resultG, 0, 255),
                                  Clamp(resultB, 0, 255));
        }
    }
}
