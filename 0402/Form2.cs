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
using System.Drawing;
using System.Text.RegularExpressions;

namespace _0402
{
    public partial class Form2 : Form
    {
        private Bitmap bmp;
        public static string str = @"Data Source=PK312-120;Initial Catalog=z1;Integrated Security=True";
        private SqlConnection con = new SqlConnection(str);
        public Form2()
        {
            con.Open();
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string fio = textBox1.Text;
            string name = textBox2.Text;
            string midname = textBox3.Text;
            string date = textBox4.Text;
            string pass = textBox5.Text;
            string email = textBox8.Text;
            string phone = textBox9.Text;
            A.Time = dateTimePicker1.Text;
            A.f = textBox1.Text;
            A.n = textBox2.Text;
            A.md = textBox3.Text;
            A.date = textBox4.Text;
            A.pas = textBox5.Text;
            A.pod = comboBox2.Text;
            A.dol = comboBox3.Text;
            A.email = textBox8.Text;
            A.phone = textBox9.Text;
            // проверка ЕМейла на правильность наличие @ и .
            string pata = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            Match isMatch = Regex.Match(email, pata, RegexOptions.IgnoreCase);
            if (textBox8.Text == isMatch.ToString() || textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != ""
                || textBox9.Text != "")
            {
                if (A.lo == "Администратор")
                {
                    string Query2 = $"INSERT INTO [dbo].[tab]([Фамилия],[Имя],[Отчество],[ДатаРождения],[Серия и номер паспорта],[Подразделение],[Должность],[Фото],[Логин],[Пароль],[Email],[Номертелефона]) " +
                $"values ('" + fio + "','" + name + "','" + midname + "','" + date + "','" + pass + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox1.Text + "','" + A.a1 + "','" + A.a2 + "','" + email + "','" + phone + "')";
                    SqlCommand Command2 = new SqlCommand(Query2, con);
                    Command2.ExecuteNonQuery();
                    Form4 f = new Form4();
                    f.Show();
                    Close();
                }
                else if (A.lo == "Сотрудник")
                {
                    string Query2 = $"INSERT INTO [dbo].[tab]([Фамилия],[Имя],[Отчество],[ДатаРождения],[Серия и номер паспорта],[Подразделение],[Должность],[Фото],[Логин],[Пароль],[Email],[Номертелефона]) " +
                $"values ('" + fio + "','" + name + "','" + midname + "','" + date + "','" + pass + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox1.Text + "','" + A.a1 + "','" + A.a2 + "','" + email + "','" + phone + "')";
                    SqlCommand Command2 = new SqlCommand(Query2, con);
                    Command2.ExecuteNonQuery();
                    Form3 f = new Form3();
                    f.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Email неверный");
            }  
        }
        private void button2_Click(object sender, EventArgs e)
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
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
