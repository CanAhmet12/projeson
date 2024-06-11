using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütapaneÖDEVPROJE
{
    public partial class Form8 : Form
    {
       
        

        public Form8()
        {
            InitializeComponent();
        }

        public Form8( int ID ,string Adı, string Soyadı, string Meslek, string Şehir, string DoğumTarihi , string KullanıcıAdı , string Şifre )
        {
            InitializeComponent();
            txtID.Text = ID.ToString();
            txtAdi.Text = Adı;
            txtSoyadi.Text = Soyadı;
            txtmeslek.Text= Meslek;
            txtşehir.Text = Şehir;
            txtdtarihi.Text = DoğumTarihi;
            txtkullanıcıadi.Text = KullanıcıAdı;
            txtşifre.Text = Şifre;
            
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Kütüphane.UserUpdate(Kütüphane.UserID , txtAdi.Text , txtSoyadi.Text , txtmeslek.Text , txtşehir.Text , txtdtarihi.Text , txtkullanıcıadi.Text , txtşifre.Text , txtşifretekrar.Text);
            MessageBox.Show("Düzenleme Başarılı");
           

        }
     

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kullanıcı bilgileri silinecektir \nOnaylıyomusunuz ? ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
    }
}
