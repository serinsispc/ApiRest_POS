using DAL.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Requests_Responses.Caja
{
    public class CargarDetalleRequests
    {
        public bool ItemVentaUnico { get; set; }
        public int IdVenta { get; set; }
        public int IdPresentacion { get; set; }
        public DetalleVenta detalleVenta { get; set; }
    }
}
