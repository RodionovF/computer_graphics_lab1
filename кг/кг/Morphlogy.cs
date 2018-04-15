using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace кг
{
    class Morph : filters
    {
        public int maxSize;
        public int TypeOfMorph;
        public Bitmap image_temp;
        public bool[,] SEl = null;

        public Morph(Bitmap image, int size, int _TypeOfMorph)
        {
            maxSize = size;
            TypeOfMorph = _TypeOfMorph;
            image_temp = image;
        }

        public void SetStrEl(bool[,] _strEl)
        {
            SEl = _strEl;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            switch (TypeOfMorph)
            {
                case 1:
                    return Dilation(image_temp, x, y);
                case 2:
                    return Erosion(image_temp, x, y);
            }
            return Color.Black;

        }

        protected Color Dilation(Bitmap sourceImage, int x, int y)
        {
            int maxR = 0;
            int maxG = 0;
            int maxB = 0;

            int radius = maxSize / 2;
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    if (SEl == null || SEl[radius + i, radius + j])
                    {
                        int newX = Clamp(x + i, 0, sourceImage.Width - 1);
                        int newY = Clamp(y + j, 0, sourceImage.Height - 1);

                        Color curr = sourceImage.GetPixel(newX, newY);
                        if (curr.R > maxR)
                            maxR = curr.R;
                        if (curr.G > maxG)
                            maxG = curr.G;
                        if (curr.B > maxB)
                            maxB = curr.B;
                    }

                }
            }
            return Color.FromArgb(maxR, maxG, maxB);
        }

        protected Color Erosion(Bitmap sourceImage, int x, int y)
        {
            int minR = 255;
            int minG = 255;
            int minB = 255;

            int radius = maxSize / 2;
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    if (SEl == null || SEl[radius + i, radius + j])
                    {
                        int newX = Clamp(x + i, 0, sourceImage.Width - 1);
                        int newY = Clamp(y + j, 0, sourceImage.Height - 1);

                        Color curr = sourceImage.GetPixel(newX, newY);
                        if (curr.R < minR)
                            minR = curr.R;
                        if (curr.G < minG)
                            minG = curr.G;
                        if (curr.B < minB)
                            minB = curr.B;
                    }
                }
            }
            return Color.FromArgb(minR, minG, minB);
        }
    }
}
