using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class MovimientosInventario
    {
        public int id { get; set; }
        public DateTime fechaMovimiento { get; set; }
        public int idUsuario { get; set; }
        public int idProducto { get; set; }
        public decimal cantidadMovimiento { get; set; }
    }
}
