using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Views
{
    public class Comanda
    {
        public int id { get; set; }
        public int idVenta { get; set; }
        public string nombreProducto { get; set; }
        public string presentacion { get; set; }
        public decimal unidad { get; set; }
        public string observacion { get; set; }
        public string adiciones { get; set; }
        public string estado { get; set; }
        public string tipoComanda { get; set; }
        public string nombreCuenta { get; set; }

    }
}
