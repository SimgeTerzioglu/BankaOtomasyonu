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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9TA2NG8\SQLEXPRESS;Initial Catalog=DbBankaTest;Integrated Security=True");

        private void linkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 fr = new Form3();
            fr.Show();
        }

        private void buttonGirişYap_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kisiler where hesap_no=@p1 and sifre = @p2", baglanti);
            komut.Parameters.AddWithValue("@p1", maskedTextBoxHesapNo.Text);
            komut.Parameters.AddWithValue("@p2", textBoxSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Form2 fr = new Form2();
                fr.hesap = maskedTextBoxHesapNo.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi");
            }
            baglanti.Close();

        }
    }
}
