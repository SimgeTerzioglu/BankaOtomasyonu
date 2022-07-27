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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9TA2NG8\SQLEXPRESS;Initial Catalog=DbBankaTest;Integrated Security=True");

        public string hesap;

        private void Form2_Load(object sender, EventArgs e)
        {
            labelHesapNo.Text = hesap;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from kisiler where hesap_no = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", hesap);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelAd.Text = dr[1] + " " + dr[2];
                labelTc.Text = dr[3].ToString();
                labelTel.Text = dr[4].ToString(); 
            }
            baglanti.Close();
        }

        private void buttonGonder_Click(object sender, EventArgs e)
        {
            labelHesapNo.Text = hesap;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update hesap set bakiye = bakiye + @p1 where hesapno=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", decimal.Parse(textBoxTutar.Text));
            komut.Parameters.AddWithValue("@p2", maskedTextBoxHesapNo.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("update hesap set bakiye = bakiye - @k1 where hesapno=@k2", baglanti);
            komut1.Parameters.AddWithValue("@k1", decimal.Parse(textBoxTutar.Text));
            komut1.Parameters.AddWithValue("@k2", hesap);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into hareket (gonderen,alici,tutar) values (@p1,@p2,@p3)", baglanti);
            komut2.Parameters.AddWithValue("@p1", hesap);
            komut2.Parameters.AddWithValue("@p2", maskedTextBoxHesapNo.Text);
            komut2.Parameters.AddWithValue("@p3", textBoxTutar.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarıyla Gerçekleşti.");

        }

        private void verileriGoster()
        {
            labelHesapNo.Text = hesap;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from hareket where gonderen=@p1 or alici=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", hesap);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["gonderen"].ToString());
                ekle.SubItems.Add(oku["alici"].ToString());
                ekle.SubItems.Add(oku["tutar"].ToString());
      
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

            private void button1_Click(object sender, EventArgs e)
        {
            verileriGoster();
        }

        
    }
}
