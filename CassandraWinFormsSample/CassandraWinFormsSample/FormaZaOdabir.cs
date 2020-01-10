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
    public partial class FormaZaOdabir : Form
    {
        public Radnik noviRadnik;
        public Potrazivac noviPotrazivac;
        public FormaZaOdabir()
        {
            InitializeComponent();
        }

        private void btnPotrazivac_Click(object sender, EventArgs e)
        {
            noviPotrazivac = new Potrazivac();
            LogIn logovanje = new LogIn(noviPotrazivac);
            logovanje.ShowDialog();
        }

        private void btnRadnik_Click(object sender, EventArgs e)
        {
            noviRadnik = new Radnik();
            LogIn logovanje = new LogIn(noviRadnik);
            logovanje.ShowDialog();
        }
    }
}
