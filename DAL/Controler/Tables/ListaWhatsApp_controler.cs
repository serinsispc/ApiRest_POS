using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public  class ListaWhatsApp_controler
    {
        public static async Task<List<ListaWhatsApp>> lista(string db)
        {
            try
            {
                string query = "SELECT * FROM ListaWhatsApp";
                var cn = new ConnectionSQL();
                var resultado =await cn.EjecutarConsulta(db,query, true);
                if (resultado != null)
                {
                    return JsonConvert.DeserializeObject<List<ListaWhatsApp>>(resultado);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
