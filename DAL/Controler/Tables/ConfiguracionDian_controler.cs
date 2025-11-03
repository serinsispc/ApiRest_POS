using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class ConfiguracionDian_controler
    {
        public static async Task<ConfiguracionDian> Consultar_idAmbiente(int IdAmbiente,string db)
        {
            try
            {
                string query = $@"
        SELECT TOP 1 * 
        FROM ConfiguracionDian 
        WHERE idAnbiente = {IdAmbiente}";
                var cn = new ConnectionSQL();
                string resp = await cn.EjecutarConsulta(db,query);
                if (resp != null)
                {
                    return JsonConvert.DeserializeObject<ConfiguracionDian>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
