using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace _0402
{
    public partial class Form1 : Form
    {
        public static string str = @"Data Source=PK312-120;Initial Catalog=z1;Integrated Security=True";
        private SqlConnection con = new SqlConnection(str);
        public string h = "";
        public Form1()
        {
            InitializeComponent();
           /* string result = Interaction.InputBox("Введите текст:");*/
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.OpenSubKey("WFWF");
            string ye;
            ye = helloKey.GetValue("Identifier").ToString();
            if (ye != "001")
            {
                MessageBox.Show("Вы пользуетесь нелицензионной программой");
                this.Close();
            }
            helloKey.Close();
        }     
        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
        }
        private void button1_Click(object sender, EventArgs e) // авторизация
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string lo = textBox1.Text;
            string qq = $"select [Логин] from [dbo].[tab] where [Логин] = '{lo}'";
            if (comboBox1.Text == "Администратор")
            {              
                   /* qq.Parameters.Add("@login", SqlDbType.VarChar).Value = textBox1.Text;*/
                SqlCommand Command2 = new SqlCommand(qq, con);
                Command2.ExecuteNonQuery();
                Form4 f = new Form4();
                f.Show();
                Hide();
            }
            else if(comboBox1.Text == "Сотрудник")
            {
                SqlCommand Command2 = new SqlCommand(qq, con);
                Command2.ExecuteNonQuery();
                Form3 f = new Form3();
                    f.Show();
                    Hide();
            }
            else
            {
                MessageBox.Show("0-0");
            }          
        }
        private void button2_Click(object sender, EventArgs e) // регистрация
        {
            A.a1 = textBox1.Text;
            A.lo = comboBox1.Text;
            if (comboBox1.Text == "Сотрудник")
            {
                string pata = @"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{6,}";
                Match isMatch = Regex.Match(textBox2.Text, pata, RegexOptions.IgnoreCase);
                if (textBox2.Text == isMatch.ToString())
                {
                    foreach (char t in textBox2.Text)
                    {
                        h += Convert.ToString(Convert.ToInt32(t) + 7) + "#";
                    }
                    A.a2 = h;
                    Form2 f = new Form2();
                    f.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            else
            {
                MessageBox.Show("0-0");
            }
        }
    }
}
