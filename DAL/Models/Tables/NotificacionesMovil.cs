using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class NotificacionesMovil
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string celular { get; set; }
        public string db { get; set; }
        public string representateLegal { get; set; }
        public string establecimiento { get; set; }
        public string tipo { get; set; }
        public string mensaje { get; set; }
        public bool estado { get; set; }
    }
}
