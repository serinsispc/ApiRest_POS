using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class Vendedor
    {
        public int? id { get; set; }
        public string nombreVendedor { get; set; }
        public string telefonoVendedor { get; set; }
        public string calveVendedor { get; set; }
        public int? cajaMovil { get; set; }
    }
}
