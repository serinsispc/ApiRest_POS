using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class CargoDescuentoVentas
    {
        public int id { get; set; }
        public int idVenta { get; set; }
        public bool tipo { get; set; }
        public int codigo { get; set; }
        public string razon { get; set; }
        public decimal valor { get; set; }
        public decimal baseCD { get; set; }

        public string descripcionCargoDescuento { get; set; }
    }
}
