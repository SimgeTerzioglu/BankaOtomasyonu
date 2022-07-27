using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BankaTest
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9TA2NG8\SQLEXPRESS;Initial Catalog=DbBankaTest;Integrated Security=True");

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(1000, 10000);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into kisiler (ad,soyad,tc,tel_no,hesap_no,sifre) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textSoyad.Text);
            komut.Parameters.AddWithValue("@p3", maskedTextBoxTC.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBoxTel.Text);
            komut.Parameters.AddWithValue("@p5", maskedTextBoxHesapNo.Text);
            komut.Parameters.AddWithValue("@p6", textBoxSifre.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into hesap (hesapno,bakiye) values (@k1,@k2)", baglanti);
            komut2.Parameters.AddWithValue("@k1", maskedTextBoxHesapNo.Text);
            komut2.Parameters.AddWithValue("@k2", sayi);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Bilgileri Sisteme Kaydedildi.");
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(100000, 1000000);
            maskedTextBoxHesapNo.Text = sayi.ToString();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kisiler where hesap_no = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", sayi);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Random rastgele2 = new Random();
                int sayi2 = rastgele.Next(100000, 1000000);
                maskedTextBoxHesapNo.Text = sayi2.ToString();
            }
            baglanti.Close();
        }
    }
}
