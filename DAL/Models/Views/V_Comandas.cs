using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Views
{
    public class V_Comandas
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int idServicio { get; set; }
        public int idMesero { get; set; }
        public string nombreMesero { get; set; }
        public string mesas { get; set; }
        public int estado { get; set; }
        public string nombreServicio { get; set; }
    }
}
