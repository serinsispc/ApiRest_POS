using DAL.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Requests_Responses.Caja
{
    public class NiewResponses
    {
        public int idventa { get; set; }
        public Guid guid { get; set; }
        public int idZonaDomicilio { get; set; }
        public List<V_CuentasVenta> listacuentas { get; set; }
        public V_CuentasVenta cuenta { get; set; }
        public V_TablaVentas venta { get; set; }
    }
}
