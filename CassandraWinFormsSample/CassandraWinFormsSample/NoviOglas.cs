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
    public partial class NoviOglas : Form
    {
        Potrazivac globalniPotrazivac;
        Oglas noviOglas;
        public NoviOglas()
        {
            InitializeComponent();
        }

        public NoviOglas(Potrazivac novi)
        {
            InitializeComponent();
            globalniPotrazivac = novi;
            txtIme.Text = globalniPotrazivac.ime;
            txtPrezime.Text = globalniPotrazivac.prezime;
            txtEmail.Text = globalniPotrazivac.email;
            txtLajkovi.Text = "0";
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            noviOglas = new Oglas();
            noviOglas.brojlajkova = 0;
            noviOglas.trenutnibrojradnika = Int32.Parse(txtTrenutniBr.Text);
            noviOglas.brojradnika = Int32.Parse(txtUkupanBr.Text);
            noviOglas.mestoposla = txtMestoPosla.Text;
            noviOglas.potrazivacEmail = txtEmail.Text;
            noviOglas.nazivoglasa = txtNazivOglasa.Text;
            if (checkVoznja.Checked == true)
                noviOglas.voznja = true;
            else noviOglas.voznja = false;
            DataProvider.AddOglas(noviOglas);
            this.Close();
        }
    }
}
