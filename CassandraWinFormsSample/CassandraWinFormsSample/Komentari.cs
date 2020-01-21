using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CassandraDataLayer;
using CassandraDataLayer.QueryEntities;

namespace CassandraWinFormsSample
{
    public partial class Komentari : Form
    {
        String nazivOglasa;
        String radnikEmail;
        public Komentari()
        {
            InitializeComponent();
        }
        public Komentari(String oglasId, String radnikId)
        {
            InitializeComponent();
            nazivOglasa = oglasId;
            radnikEmail = radnikId;
            lblKomentar.Text = "Naziv oglasa: " + oglasId;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            String poruka = txtKomentar.Text;
            DataProvider.AddKomentar(radnikEmail, nazivOglasa, poruka);
            this.Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
