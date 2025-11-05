using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Requests_Responses.Caja
{
    public class LoadCajaRequests
    {
        public bool Comandera {  get; set; }
        public int IdBase { get; set; }
        public int IdUsuario { get; set; }
        public int IdVendedor { get; set; }
        public int PorPropina { get; set; }
        public bool MultiCaja { get; set; }
    }
}
