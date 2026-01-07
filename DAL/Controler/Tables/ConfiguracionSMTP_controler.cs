using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class ConfiguracionSMTP_controler
    {
        public static async Task<ConfiguracionSMTP>Consultar(string db)
        {
            try
            {
                var cn=new ConnectionSQL();
                var query = $"SELECT top 1 * FROM ConfiguracionSMTP";
                var resp = await cn.EjecutarConsulta(db,query);
                if(resp!=null && resp != "null")
                {
                    return JsonConvert.DeserializeObject<ConfiguracionSMTP>(resp);
                }
                else
                {
                    return new ConfiguracionSMTP();
                }
            }
            catch(Exception ex)
            {
                string mensaje = ex.Message;
                return new ConfiguracionSMTP();
            }
        }
    }
}
