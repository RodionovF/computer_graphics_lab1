using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace кг
{
    class MatrixFilter : filters
    {
        protected float[,] kernelX = null;
        protected float[,] kernelY = null;
        protected MatrixFilter() { }
        protected int brightness = 0;
        public MatrixFilter(float[,] kernelX, float[,] kernelY)
        {
            this.kernelX = kernelX;
            this.kernelY = kernelY;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernelX.GetLength(0) / 2;
            int radiusY = kernelX.GetLength(1) / 2;

            float resultRX = 0;
            float resultGX = 0;
            float resultBX = 0;
            float resultRY = 0;
            float resultGY = 0;
            float resultBY = 0;

            for (int l = -radiusX; l <= radiusY; l++)
                for (int k = -radiusY; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultRX += neighborColor.R * kernelX[k + radiusX, l + radiusY];
                    resultGX += neighborColor.G * kernelX[k + radiusX, l + radiusY];
                    resultBX += neighborColor.B * kernelX[k + radiusX, l + radiusY];
                    if (kernelY != null)
                    {
                        Color neighborColor1 = sourceImage.GetPixel(idX, idY);
                        resultBY += neighborColor1.B * kernelY[k + radiusX, l + radiusY];
                        resultRY += neighborColor1.R * kernelY[k + radiusX, l + radiusY];
                        resultGY += neighborColor1.G * kernelY[k + radiusX, l + radiusY];
                    }
                }
            if (kernelY != null)
            {
                int resultColorR = (int)Math.Sqrt(resultRX * resultRX + resultRY * resultRY);
                int resultColorG = (int)Math.Sqrt(resultGX * resultGX + resultGY * resultGY);
                int resultColorB = (int)Math.Sqrt(resultBX * resultBX + resultBY * resultBY);
                return Color.FromArgb(
                    Clamp((int)resultColorR, 0, 255),
                    Clamp((int)resultColorG, 0, 255),
                    Clamp((int)resultColorB, 0, 255));
            }
            else if (brightness != 0)
            {
                return Color.FromArgb(
                    Clamp((int)resultRX + brightness, 0, 255),
                    Clamp((int)resultGX + brightness, 0, 255),
                    Clamp((int)resultBX + brightness, 0, 255));
            }
            else
            {
                return Color.FromArgb(
               Clamp((int)resultRX, 0, 255),
               Clamp((int)resultGX, 0, 255),
               Clamp((int)resultBX, 0, 255));
            }
            
        }
    }
}
