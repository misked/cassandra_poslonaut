using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraDataLayer.QueryEntities
{
    public class Zahtev
    {
        public string zahtevId { get; set; }
        public string potrazivacId { get; set; }
        public string radnikId { get; set; }
        public string oglasId { get; set; }
        public int odobren { get; set; }
    }
}
