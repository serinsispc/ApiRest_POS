using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class Impresora
    {
        public int id_impresora { get; set; }
        public string nombre_impresora { get; set; }
        public string nombrePunto { get; set; }
        public int codigo { get; set; }
        public int copias { get; set; }
        public bool estado { get; set; }
    }
}
