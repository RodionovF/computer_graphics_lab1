using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace кг
{
    class MedianFilter : MatrixFilter
    {
        protected int maxSize;
        public MedianFilter(int size)
        {
            maxSize = size;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = maxSize / 2;
            List<byte> PixR = new List<byte>();
            List<byte> PixG = new List<byte>();
            List<byte> PixB = new List<byte>();
            for (int i = -radius; i < radius; i++)
            {
                for (int j = -radius; j < radius; j++)
                {
                    int newX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int newY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color temp_image = sourceImage.GetPixel(newX, newY);
                    PixR.Add(temp_image.R);
                    PixG.Add(temp_image.G);
                    PixB.Add(temp_image.B);
                }
            }
            PixR.Sort();
            PixG.Sort();
            PixB.Sort();
            return Color.FromArgb(PixR[PixR.Count / 2], PixG[PixG.Count / 2], PixB[PixB.Count / 2]);
        }
    }
}
