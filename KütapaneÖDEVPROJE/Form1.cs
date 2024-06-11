using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütapaneÖDEVPROJE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Kütüphane.constr2);
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = Kütüphane.constr2;
    string query = "SELECT ID FROM User1 WHERE KullanıcıAdı = @KullanıcıAdı AND Şifre = @Şifre";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@KullanıcıAdı", textBox1.Text.Trim());
        command.Parameters.AddWithValue("@Şifre", textBox2.Text.Trim());

        try
        {
            connection.Open();
            object result = command.ExecuteScalar();
            if (result != null)
            {
                Kütüphane.UserID = Convert.ToInt32(result);
               
            }
            else
            {
                MessageBox.Show("Yanlış Kullancı Adı veya Şifre Girdiniz \nLütfen tekrar deneyiniz." , "UYARI");
                        return;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Bir hata oluştu: " + ex.Message);
        }
    }
            Form5 yeni = new Form5();
            yeni.Show();
            this.Hide();

        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (txtadminkullaniciadi.Text == "Admin" && txtadminşifre.Text == "1234")
            {
                Form3 yni = new Form3();
                yni.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre girdiniz \nLütfen tekrar deneyiniz.", "Uyarı");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Devam Ederseniz Program Sonlandırılacaktır.\nDevam etmek istiyormusunuz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 yeni = new Form2();
            yeni.ShowDialog();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kütüphane Uygulması   Versiyon" + Assembly.GetExecutingAssembly().GetName().Version;
        }
    } 
}
    

