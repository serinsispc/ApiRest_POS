using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Views
{
    public class V_CambioPrecios
    {
        public int id { get; set; }
        public string codigoProducto { get; set; }
        public string nombreTipoPresentacion { get; set; }
        public string nombreProducto { get; set; }
        public string nombreCategoria { get; set; }
        public decimal precioVenta { get; set; }
        public string precioNuevo { get; set; }
    }
}
