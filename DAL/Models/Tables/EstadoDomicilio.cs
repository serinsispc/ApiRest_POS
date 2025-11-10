using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class EstadoDomicilio
    {
        public int? id { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
    }
}
