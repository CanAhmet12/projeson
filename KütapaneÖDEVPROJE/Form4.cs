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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            bool dolu = true;
            foreach (Control c in this.Controls)
            {
                if(c is TextBox && c.TabStop== true)
                {
                    c.BackColor = Color.White;
                }
                

            }
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && c.TabStop == true && c.Tag =="B")
                {
                    if(c.Text == string.Empty)
                    {
                        dolu = false;
                        c.BackColor = Color.Red;
                    }
                }


            }
            if (!dolu)
            {
                MessageBox.Show("Bütün Bilgileri Girmeniz Gerekmektedir \nLütfen tüm bilgileri girdiginizden emin olun");
                
            }
            else
            {
                Kütüphane.BookSave(Kütüphane.KitapID, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text , textBox1.Text);
                MessageBox.Show("Kaydınız Başarıyla Gerçekleşti." , "Başarılı");
            }

           




        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {


            if(MessageBox.Show("Girmiş oldugunuz veriler silinecektir \nDevam etmek isityormuusnuz?" , "UYARI" , MessageBoxButtons.YesNo , MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach(Control c in this.Controls)
                {
                    if(c is TextBox && c.TabStop == true)
                    {
                        c.ResetText();
                    }
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = "Kütüphane Uygulması   Versiyon" + Assembly.GetExecutingAssembly().GetName().Version;

            if (Kütüphane.KitapID > 0)
            {
                SqlConnection con = new SqlConnection(Kütüphane.constr);
                SqlCommand com = new SqlCommand("select *from Book where ID = @ID" , con);
                com.Parameters.AddWithValue("ID", Kütüphane.KitapID);
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr["KitapAdı"].ToString();
                    textBox3.Text = dr["BarkodNo"].ToString();
                    textBox4.Text = dr["Yazar"].ToString();
                    textBox5.Text = dr["SayfaNo"].ToString();
                    textBox6.Text = dr["Tür"].ToString();
                    textBox7.Text = dr["Dil"].ToString();
                    textBox8.Text = dr["YayınEvi"].ToString();
                    textBox9.Text = dr["Yıl"].ToString();
                  
                }
                dr.Close();
                con.Close();

                
            }
        }
    }
}
