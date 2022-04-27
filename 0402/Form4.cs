using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0402
{
    public partial class Form4 : Form
    {
        private Bitmap bmp;
        public Form4()
        {
            InitializeComponent();
        }
        private void tabBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tabBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.z1DataSet);
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "z1DataSet2.tab". При необходимости она может быть перемещена или удалена.
            this.tabTableAdapter2.Fill(this.z1DataSet2.tab);
        }
        private void tabDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabBindingSource1.RemoveCurrent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double[] x = new double[12];//месяца 
            Random rnd = new Random();
            string[] month = new string[12]{"09:12","10:40","13:12","15:15","20:45","19:01","01:30"
   ,"05:10","16:42","23:52","10:00","14:30"};
            int[] mo = new int[12]{1,2,3,4,5,6,7,8,9,10,11,12};
            int[] y = new int[12];//хранит данных по месяцам выбранного года 
            for (int i = 0; i < 12; i++)
            {
                x[i] = i;
                y[i] = rnd.Next(0, 15);
            }
            chart1.ChartAreas[0].AxisX.Minimum = 1;//начало по X 
            chart1.ChartAreas[0].AxisX.Maximum = 12;//конец по X 
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1;// Определяем шаг сетки 
            chart1.Series[0].Points.DataBindXY(month, mo);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, " + "*.GIF, *.PNG)|*.bmp; *.jpg; *.gif; *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName);
                bmp = new Bitmap(image);
                pictureBox1.Image = bmp;
            }
        }
    }
}
