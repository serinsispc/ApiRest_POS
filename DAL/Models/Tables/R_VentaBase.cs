using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class R_VentaBase
    {
        public int id { get; set; }
        public int idVenta { get; set; }
        public int idBaseCaja { get; set; }
    }
}
