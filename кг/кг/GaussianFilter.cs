using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кг
{
    class GaussianFilter : MatrixFilter
    {
        public GaussianFilter()
        {
            createGaussianKernel(3, 2);
        }
        public void createGaussianKernel(int radius, float sigma)
        {
            //
            int size = 2 * radius + 1;
            // 
            kernelX = new float[size, size];
            // коэффициент нормировки ядра
            float norm = 0;
            //
            for( int i =-radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    kernelX[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (sigma * sigma)));
                    norm += kernelX[i + radius, j + radius];
                }
            // нормируем ядро
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernelX[i, j] /= norm;
        }
    }
}
