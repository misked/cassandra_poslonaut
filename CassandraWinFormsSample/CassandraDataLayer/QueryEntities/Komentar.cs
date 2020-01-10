using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraDataLayer.QueryEntities
{
    public class Komentar
    {
        public string radnikId { get; set; }
        public string komentarId { get; set; }
        public string oglasId { get; set; }
        public string poruka { get; set; }
    }
}
