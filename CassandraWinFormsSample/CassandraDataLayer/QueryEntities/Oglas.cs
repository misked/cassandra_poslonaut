using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraDataLayer.QueryEntities
{
    public class Oglas
    {
        public string nazivoglasa { get; set; }
        public string mestoposla { get; set; }
        public string potrazivacEmail { get; set; }
        public int brojradnika { get; set; }
        public int trenutnibrojradnika { get; set; }
        public List<Komentar> komentari { get; set; }
        public int brojlajkova { get; set; }
        public Boolean voznja { get; set; }
        public List<Zahtev> zahtevi { get; set; }
    }
}
