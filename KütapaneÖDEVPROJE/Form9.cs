using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace KütapaneÖDEVPROJE
{
    public partial class Form9 : Form
    {
        public Form9(string kitapAdi, string barkodNo, string yazar , string Kütüphane )
        {
            InitializeComponent();
            textBox6.Text = kitapAdi;
            textBox5.Text = barkodNo;
            textBox4.Text = yazar;
            textBox2.Text = Kütüphane;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateReservationDates())
                {
                    Kütüphane.RezervasyonSave(Kütüphane.rezervasyonID, textBox6.Text, textBox5.Text, textBox4.Text, textBox2.Text, textBox3.Text, textBox1.Text);
                    MessageBox.Show("Rezervasyon Başarılı", "BAŞARILI");
                    OnFormClosedEvent();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }

        }

        public event EventHandler FormClosedEvent;

        protected virtual void OnFormClosedEvent()
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (DateTime.TryParse(textBox1.Text, out DateTime endDate))
            {
                if (DateTime.TryParse(textBox3.Text, out DateTime startDate))
                {
                    TimeSpan dateDifference = endDate - startDate;
                    if (dateDifference.TotalDays > 10)
                    {
                        MessageBox.Show("En fazla 10 günlük rezervasyon yapabilirsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true; 
                    }
                }
            }
            else
            {
                MessageBox.Show("Geçersiz tarih formatı! Lütfen doğru bir tarih girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; 
            }
        }

      
        private bool ValidateReservationDates()
        {
            if (DateTime.TryParse(textBox3.Text, out DateTime startDate) && DateTime.TryParse(textBox1.Text, out DateTime endDate))
            {
                TimeSpan dateDifference = endDate - startDate;
                if (dateDifference.TotalDays > 10)
                {
                    MessageBox.Show("En fazla 10 günlük rezervasyon yapabilirsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Geçersiz tarih formatı! Lütfen doğru bir tarih girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
