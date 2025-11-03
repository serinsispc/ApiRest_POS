using DAL.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Requests_Responses.Caja
{
    public class CargarDetalleResponses
    {
        public bool estado { get; set; }
        public List<V_DetalleCaja> detalleCajas {  get; set; }
        public V_TablaVentas venta {  get; set; }
    }
}
