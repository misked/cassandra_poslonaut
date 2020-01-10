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
    public partial class Pregled : Form
    {
        int brojZahteva = 3;
        Potrazivac globalniPotrazivac;
        Radnik globalniRadnik;
        List<Oglas> oglasi = new List<Oglas>();
        Boolean RadnikBoolean = false;

        public Pregled()
        {
            InitializeComponent();
            this.popuniInicijalno();
        }

        #region za radnika
        public Pregled(Radnik radnik)
        {
            InitializeComponent();
            globalniRadnik = radnik;
            RadnikBoolean = true;
            this.refreshFunkcija();         
            
            #region visible
            btnDodajOglas.Visible = false;
            btnObrisiOglas.Visible = false;
            btnZahtevi.Visible = false;
            btnLajk.Visible = true;
            btnSvojiZahtevi.Visible = true;
            btnBrojZahteva.Visible = true;
            btnPosaljiZahtev.Visible = true;
            #endregion
        }

        private void btnSvojiZahtevi_Click(object sender, EventArgs e)
        {
            Zahtevi novo = new Zahtevi(globalniRadnik);
            novo.ShowDialog();
            this.refreshFunkcija();
        }

        //moguce je jednom oglasu poslati vise zahteva,zato sto je moguce da jedna osoba povede dve ili vise
        private void btnPosaljiZahtev_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                Zahtev novi = new Zahtev();
                novi.radnikId = this.globalniRadnik.email;
                novi.oglasId = this.listView1.SelectedItems[0].SubItems[0].Text;
                novi.potrazivacId = this.listView1.SelectedItems[0].SubItems[5].Text;
                DataProvider.AddZahtev(novi);
                this.listView1.SelectedItems[0].BackColor=Color.Green;
                MessageBox.Show("Zahtev je poslat na oglas " + novi.oglasId + ", sacekajte potvrdu osobe koja je izdala oglas.");
                this.brojZahteva--;
                btnBrojZahteva.Text = "BROJ MOGUCIH ZAHTEVA: " + this.brojZahteva.ToString();
                if (brojZahteva == 0)
                    btnPosaljiZahtev.Enabled = false;
                //posle nekog vremena omoguciti slanje zahteva
            }
            else MessageBox.Show("Niste selektovali ni jedan oglas.");
        }

        private void btnLajk_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {               
                String nazivoglasa = this.listView1.SelectedItems[0].SubItems[0].Text;
                String potrazivacEmail = this.listView1.SelectedItems[0].SubItems[5].Text;                
                DataProvider.updateLike(potrazivacEmail, nazivoglasa);
                this.listView1.SelectedItems[0].BackColor = Color.Aqua;
                this.refreshFunkcija();
            }
            else MessageBox.Show("Niste selektovali ni jedan oglas.");
        }

        public void popuniZaRadnika()
        {
            oglasi = DataProvider.vratiSveOglase();
            foreach (Oglas oglas in oglasi)
            {
                String voznjaUStringu, lajkovi;
                lajkovi = oglas.brojlajkova.ToString();
                if (oglas.voznja == true)
                    voznjaUStringu = "+";
                else voznjaUStringu = "-";
                this.add(oglas.nazivoglasa, oglas.mestoposla, oglas.brojradnika.ToString(), oglas.trenutnibrojradnika.ToString(), voznjaUStringu, oglas.potrazivacEmail, lajkovi);
            }
            lblGodine.Visible = true;
            lblIme.Text = globalniRadnik.ime;
            lblPrezime.Text = globalniRadnik.prezime;
            lblBrojTelefona.Text = "Broj telefona: " + globalniRadnik.brtelefona;
            lblEmail.Text = "Email: " + globalniRadnik.email;
            lblPol.Text = "Pol: " + globalniRadnik.pol;
            lblGodine.Text = "Broj godina: " + globalniRadnik.brojgodina.ToString();
            btnBrojZahteva.Text += this.brojZahteva.ToString();
        }
        #endregion

        #region zajednicki deo
        public void popuniInicijalno()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Naziv oglasa", 90);
            listView1.Columns.Add("Mesto posla", 90);
            listView1.Columns.Add("Potreban broj ljudi", 100);
            listView1.Columns.Add("Trenutni broj ljudi", 100);
            listView1.Columns.Add("Obezbedjeni prevoz", 110);
            listView1.Columns.Add("Email potrazivaca", 100);
            listView1.Columns.Add("Lajkovi", 60);
        }

        public void refreshFunkcija()
        {
            listView1.Clear();
            this.popuniInicijalno();
            if (this.RadnikBoolean == true)
                this.popuniZaRadnika();
            else this.popuniZaPotrazivaca();
        }

        public void add(string naziv, string mesto, string potrebanBr,string trenutniBr, string prevoz, string potrazivacEmail, string brojLajkova)
        {
            String[] row = { naziv, mesto, potrebanBr, trenutniBr , prevoz, potrazivacEmail, brojLajkova };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }
        #endregion

        #region potrazivacki deo
        public Pregled(Potrazivac potrazivac)
        {
            InitializeComponent();
            globalniPotrazivac = potrazivac;
            RadnikBoolean = false;
            this.refreshFunkcija();            

            #region visible
            btnDodajOglas.Visible = true;
            btnObrisiOglas.Visible = true;
            btnZahtevi.Visible = true;
            btnLajk.Visible = false;
            btnSvojiZahtevi.Visible = false;
            btnBrojZahteva.Visible = false;
            btnPosaljiZahtev.Visible = false;
            #endregion
        }

        public void popuniZaPotrazivaca()
        {
            oglasi = DataProvider.vratiSveOglasePrekoMejla(globalniPotrazivac.email);
            foreach (Oglas oglas in oglasi)
            {
                String voznjaUStringu, lajkovi;
                lajkovi = oglas.brojlajkova.ToString();
                if (oglas.voznja == true)
                    voznjaUStringu = "+";
                else voznjaUStringu = "-";
                this.add(oglas.nazivoglasa, oglas.mestoposla, oglas.brojradnika.ToString() , oglas.trenutnibrojradnika.ToString(), voznjaUStringu, oglas.potrazivacEmail, lajkovi);
            }
            lblIme.Text = globalniPotrazivac.ime;
            lblPrezime.Text = globalniPotrazivac.prezime;
            lblBrojTelefona.Text = "Broj telefona: " + globalniPotrazivac.brtelefona;
            lblEmail.Text = "Email: " + globalniPotrazivac.email;
            lblPol.Text = "Pol: " + globalniPotrazivac.pol;
        }
        
        private void btnDodajOglas_Click(object sender, EventArgs e)
        {
            NoviOglas novi = new NoviOglas(globalniPotrazivac);
            novi.ShowDialog();
            this.refreshFunkcija();
        }

        private void btnObrisiOglas_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                String satana = this.listView1.SelectedItems[0].SubItems[0].Text;
                String username = this.listView1.SelectedItems[0].SubItems[5].Text;
                if (satana != null)
                {
                    DataProvider.DeleteOglas(username, satana);
                    MessageBox.Show("Obrisan je oglas " + satana);
                }
                this.refreshFunkcija();
            }
            else MessageBox.Show("Niste selektovali ni jedan oglas.");
        }
        
        private void btnZahtevi_Click(object sender, EventArgs e)
        {
            Zahtevi novo = new Zahtevi(globalniPotrazivac);
            novo.ShowDialog();
            this.refreshFunkcija();
        }
        #endregion

        #region ne diraj ispod prazne funkcije
        private void Pregled_Load(object sender, EventArgs e)
        {

        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            /*String satana = listView1.SelectedItems[0].SubItems[0].Text;
            MessageBox.Show(satana);*/

        }

        private void btnBrojZahteva_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
