using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Views
{
    public class V_R_VentaClienteDomicilio
    {
        public int id { get; set; }
        public int idVenta { get; set; }
        public Guid idClienteDomicilio { get; set; }
        public DateTime fechaVenta { get; set; }
        public decimal total_A_Pagar { get; set; }
        public string nombreCliente { get; set; }
        public string celularCliente { get; set; }
        public string direccionCliente { get; set; }

    }
}
