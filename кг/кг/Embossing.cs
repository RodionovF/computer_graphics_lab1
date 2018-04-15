using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кг
{
    class Embossing : MatrixFilter
    {
        public Embossing(int _brightness)
        {
            int size = 3;
            float norm = 0;
            kernelX = new float[3, 3] { { 0, 1, 0 }, { 1, 0, -1 }, { 0, -1, 0 } };

            for (int i = -1; i < 1; i++)
                for (int j = -1; j < 1; j++)
                    norm += kernelX[i + 1, j + 1];

            // нормировка
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernelX[i, j] /= norm;
            brightness = _brightness;            
        }
    }
}
