using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RespuestaCRUD
    {
        public bool estado {  get; set; }
        public int nuevoId { get; set; }
        public int idAfectado { get; set; }
        public string mensaje { get; set; }

        [JsonIgnore] // opcional: para no enviarla en el JSON
        public int IdFinal => idAfectado != 0 ? idAfectado : nuevoId;

    }
}
