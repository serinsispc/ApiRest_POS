using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class R_MediosDePago_MediosDePagoInternos
    {
        public int? id { get; set; }
        public int? idMedioDePago { get; set; }
        public int? idMediosDePagoInternos { get; set; }
    }
}
