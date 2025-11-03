using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Requests_Responses.AutorizacionPC
{
    public class ConsultarXSerial_Requests
    {
        public string Serial { get; set; }
        public string Manufacture { get; set; }
        public string Producto { get; set; }
        public string Vercion { get; set; }
        public int Estado { get; set; }
    }
}
