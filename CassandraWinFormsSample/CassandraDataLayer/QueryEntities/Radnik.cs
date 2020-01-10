using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraDataLayer.QueryEntities
{
    public class Radnik
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string brtelefona { get; set; }
        public int brojgodina { get; set; }
        public string pol { get; set; }
        public string email { get; set; }
        public string sifra { get; set; }
        public List<Oglas> listaPoslova { get; set; }
        public List<Zahtev> listaZahteva { get; set; }
    }
}
