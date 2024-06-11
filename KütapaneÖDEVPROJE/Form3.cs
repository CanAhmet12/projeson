using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütapaneÖDEVPROJE
{
    public partial class Form3 : Form
    {
       
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Oturumunuz sonlandırılacaktır \n Devam etmek istiyormusunuz?" , "Uyarı" , MessageBoxButtons.YesNo , MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Form1 yeni = new Form1();
                yeni.Show();
                this.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Kütüphane Uygulması   Versiyon " + Assembly.GetExecutingAssembly().GetName().Version;
         
            GetAllBooks();
            dataGridView1.Columns["ID"].Visible = false;

        }

        private void GetAllBooks()
        {
            dataGridView1.DataSource = Kütüphane.GetBooks().Tables[0];
            dataGridView1.Columns["ID"].Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 yeni = new Form4();
            yeni.ShowDialog();
            GetAllBooks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Kitap Bilgileri Silenecektir \nDevam etmek isitoyrmuusnuz ? " , "UYARI" , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Kütüphane.KitapID = Convert.ToInt32(dataGridView1.Rows[satır].Cells["ID"].Value);
                Kütüphane.DeleteBook();
                GetAllBooks();
            }
          
           
        }
        int satır = 0;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            satır = e.RowIndex;
            Kütüphane.KitapID = Convert.ToInt32(dataGridView1.Rows[satır].Cells["ID"].Value);
            Form4 yeni = new Form4();
            yeni.ShowDialog();
            GetAllBooks();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            satır = e.RowIndex;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Kütüphane.serach = !Kütüphane.serach;
            if (Kütüphane.serach)
            {
                textBox1.ResetText();
            }
            groupBox1.Visible = Kütüphane.serach;

            GetAllBooks();
           
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text;

            if (string.IsNullOrEmpty(filterText))
            {
                // Filtreyi temizle
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                // Filtreyi uygula
                string rowFilter = string.Format("[Kitap Adı] LIKE '%{0}%' OR [Barkod Numarası] LIKE '%{0}%' OR [Yazar] LIKE '%{0}%'", filterText);
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 yeni = new Form7();
            yeni.ShowDialog();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    
}
