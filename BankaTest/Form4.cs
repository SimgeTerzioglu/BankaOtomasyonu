using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaTest
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void buttonGirisYap_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            
        }

        private void buttonMusteriEkle_Click(object sender, EventArgs e)
        {
            Form3 fr = new Form3();
            fr.Show();
        }
    }
}
