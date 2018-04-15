using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace кг
{
    class Opening : Morph
    {
        public Opening(Bitmap image, int size, int _TypeOfMorph) : base(image, size, _TypeOfMorph)
        {
            maxSize = size;

            image_temp = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                    image_temp.SetPixel(i, j, Erosion(image, i, j));
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                    image_temp.SetPixel(i, j, Dilation(image, i, j));
        }
    }
}