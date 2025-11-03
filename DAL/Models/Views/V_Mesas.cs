using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Views
{
    public class V_Mesas
    {
        public int? id { get; set; }
        public Guid? guidMesa { get; set; }
        public string nombreMesa { get; set; }
        public int? idZona { get; set; }
        public string nombreZona { get; set; }
        public int? estadoMesa { get; set; }
        public string estadoTexto { get; set; }
    }
}
