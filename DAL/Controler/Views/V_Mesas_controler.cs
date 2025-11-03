using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_Mesas_controler
    {
        public static async Task<List<V_Mesas>> lista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from V_Mesas";
                var resp = await cn.EjecutarConsulta(db,query,true);
                if (resp != null) { return JsonConvert.DeserializeObject<List<V_Mesas>>(resp); }
                return null;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
