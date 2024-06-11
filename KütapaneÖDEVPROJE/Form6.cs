using System;
using System.Windows.Forms;

namespace KütapaneÖDEVPROJE
{
    public partial class Form6 : Form
    {
        private string kitapAdi;
        private string barkodNo;
        private string yazar;
        private string Kütüphane;
       

        public Form6(string kitapAdi, string barkodNo, string yazar , string Kütüphane)
        {
            InitializeComponent();
            this.kitapAdi = kitapAdi;
            this.barkodNo = barkodNo;
            this.yazar = yazar;
            this.Kütüphane = Kütüphane;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9(kitapAdi, barkodNo, yazar , Kütüphane );
            form9.FormClosed += Form9_FormClosed;
            form9.Show();
            this.Close();
        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnForm9Submitted(EventArgs.Empty);
        }

        public event EventHandler<Form9SubmittedEventArgs> Form9Submitted;

        protected virtual void OnForm9Submitted(EventArgs e)
        {
            Form9Submitted?.Invoke(this, new Form9SubmittedEventArgs());
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }

    public class Form9SubmittedEventArgs : EventArgs
    {
    }
}
