using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütapaneÖDEVPROJE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            bool dolu = true;

            foreach(Control c in this.Controls)
            {
                if(c is TextBox && c.TabStop == true)
                {
                    c.BackColor = Color.White;
                }
            }

            foreach (Control c in this.Controls)
            {
                if (c is TextBox && c.TabStop == true)

                {
                    if (c.Text == string.Empty)
                    {
                        dolu = false;
                        c.BackColor = Color.Red;
                    }
                   
                }
            }
            if (!dolu)
            {
                MessageBox.Show("Lütfen tüm bilgilerinizi giriniz.");
            }
            else
            {
                if (txtşifre.Text != txtşifretekrar.Text)
                {
                    MessageBox.Show("Girdiginiz şifreler uyuşmuyor lütfen tekrar deneyiniz.");
                }
                else
                {
                    Kütüphane.UserSave(Kütüphane.UserID, txtAdi.Text, txtSoyadi.Text, txtmeslek.Text, txtşehir.Text, txtdtarihi.Text, txtkullanıcıadi.Text, txtşifre.Text, txtşifretekrar.Text);
                    MessageBox.Show("Kayıt Başarılı.");

                }

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Girdiginiz bilgiler silinecektir \nDevma etmek istiyormusunuz. ", "Uyarı" , MessageBoxButtons.YesNo , MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox && c.TabStop == true)
                    {
                        c.ResetText();
                    }
                }
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Kütüphane Uygulması   Versiyon" + Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}
