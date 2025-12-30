using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Views
{
    public class V_Inventario
    {
        public int id { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string nombreCategoria { get; set; }
        public decimal inventarioActual { get; set; }
        public string inventarioReal { get; set; }
        public string diferencia { get; set; }
    }
}
