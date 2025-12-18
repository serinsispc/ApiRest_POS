using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Tables
{
    public class ConfiguracionSMTP
    {
        public int id { get; set; }
        public string host { get; set; }
        public int port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string encryption { get; set; }
        public string from_address { get; set; }
        public string from_name { get; set; }
    }
}
