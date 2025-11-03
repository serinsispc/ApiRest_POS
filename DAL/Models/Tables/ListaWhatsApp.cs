using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class ListaWhatsApp
    {
        public int? id { get; set; }
        public int? idTipoWhatsApp { get; set; }
        public string numeroWhatsApp { get; set; }
        public int? estadoWhatsApp { get; set; }
    }
}
