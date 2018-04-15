using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace кг
{
    class Main_color : filters
    {
        int Ravg = 0;
        int Gavg = 0;
        int Bavg = 0;
        int XRavg = 0;
        int XGavg = 0;
        int XBavg = 0;
        int r, g, b;
        double Avg = 0;
        int S = 0;
        Color pipetkaColor;


        protected int maxR = 0;
        protected int maxG = 0;
        protected int maxB = 0;

        public Main_color(Bitmap image, Color key)
        {
            pipetkaColor = key;
            int a = pipetkaColor.R;
             S = (int)(image.Width-1) * (image.Height-1);
            for (int i = 0; i < image.Width - 1; i++)
            {
                for (int j = 0; j < image.Height - 1; j++)
                {
                    Color c = image.GetPixel(i, j);

                    Ravg = Ravg + c.R;
                    Gavg = Gavg + c.G;
                    Bavg = Bavg + c.B;
                    Color curr = image.GetPixel(i, j);
                    if (curr.R > maxR)
                        maxR = curr.R;
                    if (curr.G > maxG)
                        maxG = curr.G;
                    if (curr.B > maxB)
                        maxB = curr.B;
                }
            }
            XRavg = (Ravg / S);
            XGavg = (Gavg / S);
            XBavg = (Bavg / S);
            Avg = (XRavg + XGavg + XBavg) / 3;


           
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
           
           
            r = (int)(pipetkaColor.R * Avg / XRavg);
            g = (int)(pipetkaColor.G * Avg / XGavg);
            b = (int)(pipetkaColor.B * Avg / XBavg);
            Color curr = sourceImage.GetPixel(x, y);
            int resultR = (int)( ( curr.R * 100) / pipetkaColor.R);
            int resultG = (int)((curr.G * 100) / pipetkaColor.G);
            int resultB = (int)((curr.B * 100) / pipetkaColor.B);
            /*int resultR = curr.R * Math.Abs(126 - curr.R) / 126;
            int resultG = curr.G * Math.Abs(150 - curr.G) / 150;
            int resultB = curr.B * Math.Abs(173 - curr.B) / 173;*/
            return Color.FromArgb(Clamp(resultR, 0, 255),
                                  Clamp(resultG, 0, 255),
                                  Clamp(resultB, 0, 255));
        }
    }
}