using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_Domicilios_controler
    {
        public static async Task<List<V_Domicilios>> Filtrar(string db,string fecha)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $@"SELECT * FROM V_Domicilios
            WHERE idEstado < 7 AND CONVERT(date, fecha) = '{fecha}'
            ORDER BY id";
                var resp = await cn.EjecutarConsulta(db,query,true);
                if(resp != null)
                {
                    return JsonConvert.DeserializeObject<List<V_Domicilios>>(resp);
                }
                else
                {
                    return new List<V_Domicilios>();
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new List<V_Domicilios>();
            }
        }
    }
}
