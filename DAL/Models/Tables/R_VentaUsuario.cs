using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class R_VentaUsuario
    {
        public int? id { get; set; }
        public int? idVenta { get; set; }
        public int? idUsuario { get; set; }
        public int? estado { get; set; }
    }
}
