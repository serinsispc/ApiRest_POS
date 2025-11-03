using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class AutorizacionPC
    {
        public int? id_autorizacion_pc { get; set; }
        public string serialnumber_pc { get; set; }
        public string Manufacturer_pc { get; set; }
        public string product_pc { get; set; }
        public string Version_pc { get; set; }
        public string nombre_equipo { get; set; }
        public int? estado_equipo { get; set; }
    }
}
