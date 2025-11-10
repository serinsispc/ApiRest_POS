using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Views
{
    public class V_Domicilios
    {
        public Guid? id { get; set; }
        public DateTime? fecha { get; set; }
        public int? idVenta { get; set; }
        public Guid? idCliente { get; set; }
        public string celular { get; set; }
        public string cliente { get; set; }
        public string direccion { get; set; }
        public int? idEstado { get; set; }
        public string estado { get; set; }
        public string descripcionEstado { get; set; }
    }
}
