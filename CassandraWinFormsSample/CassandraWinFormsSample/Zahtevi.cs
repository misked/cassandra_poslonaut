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
    public partial class Zahtevi : Form
    {
        List<Zahtev> zahtevi = new List<Zahtev>();
        Radnik globalniRadnik;
        Potrazivac globalniPotrazivac;

        public Zahtevi()
        {
            InitializeComponent();
            popuniInicijalno();
        }

        public Zahtevi(Potrazivac novi)
        {
            InitializeComponent();
            popuniInicijalno();
            globalniPotrazivac = novi;
            zahtevi = DataProvider.vratiZahteveZaIzabranogPotrazivaca(globalniPotrazivac.email);
            foreach (Zahtev zahtev in zahtevi)
            {
                Radnik radnik = new Radnik();
                radnik = DataProvider.GetRadnik(zahtev.radnikId); //radnikId je zapravo email za radnika
                Oglas oglas = new Oglas();
                oglas = DataProvider.GetOglas(novi.email, zahtev.oglasId);
                this.add(radnik.ime, radnik.prezime, radnik.email, oglas.nazivoglasa, oglas.mestoposla, novi.email, zahtev.zahtevId, zahtev.odobren);
            }
            //naziv oglasa je zapravo id od oglasa,tj clustering key

            #region potrazivac deo
            btnPrihvati.Visible = true;
            btnOdbij.Visible = true;
            btnObrisi.Visible = false;
            #endregion
        }

        public Zahtevi(Radnik novi)
        {
            InitializeComponent();
            popuniInicijalno();
            globalniRadnik = novi;
            //ovo popravi
            zahtevi = DataProvider.vratiZahteveZaIzabranogRadnika(globalniRadnik.email);
            foreach (Zahtev zahtev in zahtevi)
            {
                Potrazivac noviPotrazivac = new Potrazivac();
                noviPotrazivac = DataProvider.GetPotrazivac(zahtev.potrazivacId);
                Oglas oglas = new Oglas();
                oglas = DataProvider.GetOglas(noviPotrazivac.email, zahtev.oglasId);
                this.add(globalniRadnik.ime, globalniRadnik.prezime, globalniRadnik.email, oglas.nazivoglasa, oglas.mestoposla, noviPotrazivac.email, zahtev.zahtevId, zahtev.odobren);
            }
            //naziv oglasa je zapravo id od oglasa,tj clustering key

            #region radnik deo
            btnPrihvati.Visible = false;
            btnOdbij.Visible = false;
            btnObrisi.Visible = true;
            #endregion
        }

        public void popuniInicijalno()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Ime radnika", 90);
            listView1.Columns.Add("Prezime radnika", 90);
            listView1.Columns.Add("Email Radnika", 100); //radnikId kolona
            listView1.Columns.Add("Naziv oglasa", 110); //oglasId
            listView1.Columns.Add("Mesto oglasa", 110);
            listView1.Columns.Add("Email potrazivaca", 100); //potrazivacId
            listView1.Columns.Add("IdZahteva", 10); //zahtevId
        }

        public void add(string ime, string prezime, string emailRadnika, string nazivOglasa, string mestoPosla, string emailPotrazivaca, string idZahteva, int odobren)
        {
            String[] row = { ime, prezime, emailRadnika, nazivOglasa, mestoPosla, emailPotrazivaca, idZahteva };
            ListViewItem item = new ListViewItem(row);
            if (odobren == 1)
                item.BackColor = Color.LightBlue;
            if (odobren == 2)
                item.BackColor = Color.DarkRed;
            listView1.Items.Add(item);
        }

        #region ne diraj ove prazne funkcije
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region za potrazivaca
        private void btnPrihvati_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                String radnikId = this.listView1.SelectedItems[0].SubItems[2].Text;
                String oglasId = this.listView1.SelectedItems[0].SubItems[3].Text;
                String potrazivacId = this.listView1.SelectedItems[0].SubItems[5].Text;
                String zahtevId = this.listView1.SelectedItems[0].SubItems[6].Text;
                Zahtev odobreniZahtev = new Zahtev();
                odobreniZahtev.oglasId = oglasId;
                odobreniZahtev.zahtevId = zahtevId;
                odobreniZahtev.potrazivacId = potrazivacId;
                odobreniZahtev.radnikId = radnikId;
                odobreniZahtev.odobren = 1;
                DataProvider.updateZahtev(odobreniZahtev);
                DataProvider.updateBrojTrenutnihRadnika(potrazivacId, oglasId);
                this.listView1.SelectedItems[0].BackColor = Color.LightBlue;
                MessageBox.Show("Zahtev prihvacen");
            }
            else MessageBox.Show("Niste selektovali ni jedan zahtev.");
        }

        private void btnOdbij_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                String radnikId = this.listView1.SelectedItems[0].SubItems[2].Text;
                String oglasId = this.listView1.SelectedItems[0].SubItems[3].Text;
                String potrazivacId = this.listView1.SelectedItems[0].SubItems[5].Text;
                String zahtevId = this.listView1.SelectedItems[0].SubItems[6].Text;
                Zahtev odobreniZahtev = new Zahtev();
                odobreniZahtev.oglasId = oglasId;
                odobreniZahtev.zahtevId = zahtevId;
                odobreniZahtev.potrazivacId = potrazivacId;
                odobreniZahtev.radnikId = radnikId;
                odobreniZahtev.odobren = 2;
                DataProvider.updateZahtev(odobreniZahtev);
                this.listView1.SelectedItems[0].BackColor = Color.DarkRed;
                MessageBox.Show("Zahtev Odbijen");
            }
            else MessageBox.Show("Niste selektovali ni jedan zahtev.");
        }
        #endregion

        #region za radnika
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                String oglasId = this.listView1.SelectedItems[0].SubItems[3].Text;
                String potrazivacId = this.listView1.SelectedItems[0].SubItems[5].Text;
                DataProvider.DeleteZahtev(potrazivacId, oglasId);
                this.listView1.SelectedItems[0].Remove();
                MessageBox.Show("Zahtev je obrisan!");
            }
            else MessageBox.Show("Niste selektovali ni jedan zahtev.");
        }
        #endregion
    }
}
