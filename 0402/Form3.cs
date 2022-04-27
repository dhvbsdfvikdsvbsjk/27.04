using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0402
{
    public partial class Form3 : Form
    {
        private Bitmap bmp;       
        public static string str = @"Data Source=PK312-120;Initial Catalog=z1;Integrated Security=True";
        private SqlConnection con = new SqlConnection(str);
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "z1DataSet.tab". При необходимости она может быть перемещена или удалена.
            textBox1.Text = A.f;
            textBox2.Text = A.n;
            textBox3.Text = A.md;
            textBox4.Text = A.date;
            textBox5.Text = A.pas;
            textBox6.Text = A.pod;
            textBox7.Text = A.dol;
            textBox8.Text = A.email;
            textBox9.Text = A.phone;
            label11.Text = A.Time;
            con.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string fio = textBox1.Text;
            string name = textBox2.Text;
            string midname = textBox3.Text;
            string date = textBox4.Text;
            string pass = textBox5.Text;
            string pod = textBox6.Text;
            string dol = textBox7.Text;
            string Query2 = $"update [dbo].[tab]([Фамилия],[Имя],[Отчество],[ДатаРождения],[Серия и номер паспорта],[Подразделение],[Должность],[Фото],[Логин],[Пароль],[Email],[Номертелефона]) " +
        $"values ('" + fio + "','" + name + "','" + midname + "','" + date + "','" + pass + "','" + pod + "','" + dol + "','" + comboBox1.Text + "''" + A.a1 + "','" + A.a2 + "')";
            SqlCommand Command2 = new SqlCommand(Query2, con);
            Command2.ExecuteNonQuery();
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
