using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static кг.filters;

namespace кг
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(300, 300);
            ListBm = new List<Bitmap>();
            ListBm.Add(new Bitmap(bm));
        }

        Bitmap image;
        private Bitmap bm;
        private List<Bitmap> ListBm;
        private int maxSize = 0;
        private bool[,] StrEl = null;
        Color pipetkaColor=Color.FromArgb(0, 0, 0); 

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //создаем диалог для открытия файла
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
            }
            image = new Bitmap(dialog.FileName);
            pictureBox1.Image = image;
            pictureBox1.Refresh();
            ListBm.Add(image);
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
            {
                image = newImage;
                ListBm.Add(image);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void batton1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                //string format = full_name_of_image.Substring(full_name_of_image.Length - 4, 4);
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ListBm.Remove(ListBm.Last());
                image = ListBm.Last();
                pictureBox1.Image = image;
            }
            catch
            {
                MessageBox.Show("Невозможно отменить", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void черноБелыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new GreyScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Brightness_();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Embossing(20);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            filters filter = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собеляToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            filters filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void щарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Sharr();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void прюиттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Prewitte();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            filters filter = new Embossing(60);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныВертикальныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Waves_Vert();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныГоризонтальныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Waves_Horiz();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Glass();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void стекло2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Glass();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Morph filter;
            
                filter = new Morph(image, this.maxSize, 1);

                filter.SetStrEl(StrEl);
                backgroundWorker1.RunWorkerAsync(filter);
         

           
        }

        private void erosingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

                Morph filter;
                filter = new Morph(image, this.maxSize, 2);

                filter.SetStrEl(StrEl);
                backgroundWorker1.RunWorkerAsync(filter);
            


        }
        

        private void задатьСтруктурныйЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                Form2 Form2 = new Form2(this);
                Form2.Owner = this;
                Form2.ShowDialog();
                this.maxSize = Form2.mSize;
                this.StrEl = Form2.structEl;
            }
            catch
            {
                MessageBox.Show("Задайте структурный элемент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Morph filter;
            filter = new Opening(image, this.maxSize, 2);
            filter.SetStrEl(StrEl);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Morph filter;
            filter = new Closing(image, this.maxSize, 2);
            filter.SetStrEl(StrEl);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Morph filter;
            filter = new TopHat(image, this.maxSize, 2);
            filter.SetStrEl(StrEl);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void линейноеРастяжениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new linear_stretching();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new MedianFilter(5);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void линейноеРастяжениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            filters filter = new IdealMirrorer(image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Test();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void коррекцияСОпорнымЦветомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters filter = new Main_color(image, pipetkaColor);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int a = 10;
            pipetkaColor = image.GetPixel(e.X, e.Y);
            int aa = pipetkaColor.R;
            int ab = pipetkaColor.G;
            int bb = pipetkaColor.B;
            a = 10 + a;        }
    }
}