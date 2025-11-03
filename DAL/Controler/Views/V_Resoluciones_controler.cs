using DAL.Models.Views;
using DAL.Requests_Responses.V_Resoluciones_rr;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_Resoluciones_controler
    {
        public static async Task<List<V_Resoluciones>> Lista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from V_Resoluciones where estado = 1";
                var resp = await cn.EjecutarConsulta(db,query);
                if(resp != null )
                {
                    return JsonConvert.DeserializeObject<List<V_Resoluciones>>(resp);
                }
                else
                {
                    return new List<V_Resoluciones>();
                }
            }
            catch (Exception ex) 
            {
                string msg = ex.Message;
                return new List<V_Resoluciones>();
            }
        }
    }
}
