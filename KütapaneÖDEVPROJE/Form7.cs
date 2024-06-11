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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Options();
            GetAllUser();
            dataGridView1.Columns["ID"].Visible = false;
        }
        private void Options()
        {
            this.Text = "Kütüphane Uygulması   Versiyon " + Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void GetAllUser()
        {
            dataGridView1.DataSource = Kütüphane.GetUser().Tables[0];
            dataGridView1.Columns["ID"].Visible = false;

        }
        int satır = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kullanıcı Silenecektir \nDevam etmek isitoyrmuusnuz ? ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Kütüphane.UserID = Convert.ToInt32(dataGridView1.Rows[satır].Cells["ID"].Value);
                Kütüphane.DeleteUser();
                GetAllUser();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 yeni = new Form2();
            yeni.ShowDialog();
            GetAllUser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string ID = selectedRow.Cells["ID"].Value?.ToString();
                string Adı = selectedRow.Cells["Adı"].Value?.ToString();
                string Soyadı = selectedRow.Cells["Soyadı"].Value?.ToString();
                string Meslek = selectedRow.Cells["Meslek"].Value?.ToString();
                string Şehir = selectedRow.Cells["Şehir"].Value?.ToString();
                string DoğumTarihi = selectedRow.Cells["Doğum Tarihi"].Value?.ToString();
                string KullanıcıAdı = selectedRow.Cells["Kullanıcı Adı"].Value?.ToString();
                string Şifre = selectedRow.Cells["Şifre"].Value?.ToString();



                Form8 form8 = new Form8( Convert.ToInt32(ID) , Adı, Soyadı, Meslek, Şehir, DoğumTarihi, KullanıcıAdı, Şifre); 
                form8.Show();
              
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
        public void LoadData()
        {
            GetAllUser();
        }
       
    }
}
