using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace кг
{
    public partial class Form2 : Form
    {
        public int size = 0;
        public string selectedIndex = "Null";
        public bool[,] structEl = null;


        public Form2()
        {
            Form1 Form1 = (Form1)this.Owner;
            InitializeComponent();
        }
        public Form2(Form f)
        {

            InitializeComponent();
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            dataGridView1.Hide();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Rows.Clear();

            selectedIndex = comboBox1.SelectedItem.ToString();
            size = mSize;
            dataGridView1.Show();
            dataGridView1.RowCount = size;
            dataGridView1.ColumnCount = size;
            for (int m = 0; m < size; m++)
                for (int n = 0; n < size; n++)
                    dataGridView1.Rows[m].Cells[n].Value = Convert.ToString(0);
            Refresh();
        }
        public int mSize
        {
            get
            {
                return Convert.ToInt32(selectedIndex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (size != 0 && selectedIndex != "Null")
            {
                structEl = new bool[size, size];
                for (int m = 0; m < size; m++)
                    for (int n = 0; n < size; n++)
                        structEl[m, n] = false;

             

            for (int m = 0; m < size; m++)
                for (int n = 0; n < size; n++)
                    if ( dataGridView1[n, m].Style.BackColor == Color.Red)
                        structEl[m, n] = true;
        
            }
            else
            {
                MessageBox.Show("Введите размер и тип структурного элемента.", "Ошибка",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value = Convert.ToString(1);
                        break;
                    case MouseButtons.Right:
                        dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value = Convert.ToString(0);
                    break;
                }
            
        }
    }
}
