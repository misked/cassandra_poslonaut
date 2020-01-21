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
    public partial class SviKomentari : Form
    {
        String nazivOglasa;
        public SviKomentari()
        {
            InitializeComponent();
        }
        public SviKomentari(String oglasId)
        {
            InitializeComponent();
            nazivOglasa = oglasId;
            popuniInicijalno();
            List<Komentar> komentari = new List<Komentar>();
            komentari = DataProvider.vratiKomentareDatomOglasu(oglasId);
            foreach(Komentar kom in komentari)
            {
                add(kom.oglasId, kom.radnikId, kom.poruka, kom.komentarId);
            }
        }

        public void popuniInicijalno()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Ime oglasa", 200);
            listView1.Columns.Add("Email korisnika", 200);
            listView1.Columns.Add("Komentar", 200);
            listView1.Columns.Add("IdKomentara", 100);
        }

        public void add(string imeOglaa, string email, string komentar, string idKomentara)
        {
            String[] row = { imeOglaa, email, komentar, idKomentara };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
