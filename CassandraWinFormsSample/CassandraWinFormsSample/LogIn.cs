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
    public partial class LogIn : Form
    {
        public Radnik noviRadnik;
        public Potrazivac noviPotrazivac;
        public Boolean radnik;
        public LogIn()
        {
            InitializeComponent();
        }
        public LogIn(Radnik r)
        {
            InitializeComponent();
            noviRadnik = r;
            radnik = true;
            lblGodine.Visible = true;
            txtGodine.Visible = true;
        }
        public LogIn(Potrazivac p)
        {
            InitializeComponent();
            noviPotrazivac = p;
            lblGodine.Visible = false;
            txtGodine.Visible = false;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string Email, Sifra;
            Email = txtUsername.Text;
            Sifra = txtPassword.Text;
            if (radnik == true) 
            {
                noviRadnik=DataProvider.proveriSifruRadniku(txtUsername.Text, txtPassword.Text);
                if(noviRadnik==null)
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    //forma za radnika
                    Pregled novi = new Pregled(noviRadnik);
                    novi.ShowDialog();
                }
            }
            else
            {
                noviPotrazivac = DataProvider.proveriSifruPotrazivacu(txtUsername.Text, txtPassword.Text);
                if(noviPotrazivac == null)
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    //forma za potrazivaca
                    Pregled novi = new Pregled(noviPotrazivac);
                    novi.ShowDialog();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(radnik==true)
            {
                Boolean tacno = DataProvider.emailZaRegistrovanjeRadnika(txtNewUsername.Text);
                if (tacno == true)
                {
                    Radnik novi = new Radnik();
                    novi.ime = txtIme.Text;
                    if (radioMusko.Checked == true)
                        novi.pol = "Musko";
                    else novi.pol = "Zensko";
                    novi.prezime = txtPrezime.Text;
                    novi.brojgodina = Int32.Parse(txtGodine.Text);
                    novi.brtelefona = txtTelefon.Text;
                    novi.sifra = txtNewPassword.Text;
                    novi.email = txtNewUsername.Text;
                    noviRadnik = novi;
                    DataProvider.AddRadnik(noviRadnik);
                    //forma za radnika
                    Pregled noviPregled = new Pregled(noviRadnik);
                    noviPregled.ShowDialog();
                }
                else
                {
                    txtNewUsername.Text = "";
                    MessageBox.Show("Email vec postoji! Unesite drugi email.");
                }
            }
            else
            {
                Boolean tacno = DataProvider.emailZaRegistrovanjePotrazivaca(txtNewUsername.Text);
                if (tacno == true)
                {
                    Potrazivac novi = new Potrazivac();
                    novi.ime = txtIme.Text;
                    if (radioMusko.Checked == true)
                        novi.pol = "Musko";
                    else novi.pol = "Zensko";
                    novi.prezime = txtPrezime.Text;
                    novi.brtelefona = txtTelefon.Text;
                    novi.sifra = txtNewPassword.Text;
                    novi.email = txtNewUsername.Text;
                    noviPotrazivac = novi;
                    DataProvider.AddPotrazivac(noviPotrazivac);                    
                    //forma za potrazivaca
                    Pregled noviPregled = new Pregled(noviPotrazivac);
                    noviPregled.ShowDialog();
                }
                else
                {
                    txtNewUsername.Text = "";
                    MessageBox.Show("Email vec postoji! Unesite drugi email.");
                }
            }
        }
    }
}
