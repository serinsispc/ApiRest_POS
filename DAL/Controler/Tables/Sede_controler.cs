using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class Sede_controler
    {
        public static async Task<Sede> Consultar(string db)
        {
            try
            {
                var query = $"select *from Sede";
                var cn = new ConnectionSQL();
                string resp =await cn.EjecutarConsulta(db,query);
                if (resp == null) 
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<Sede>(resp);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
