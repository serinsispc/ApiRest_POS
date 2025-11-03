using DAL.Models.Procedures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Procedures
{
    public class InformePagoInterno_Turno_controler
    {
        public static async Task<List<InformePagoInterno_Turno_Result>> Consultar(string db, int idBase)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"EXEC InformePagoInterno_Turno {idBase}";
                var resultado = await cn.EjecutarConsulta(db, query, true);
                if (resultado != null)
                {
                    return JsonConvert.DeserializeObject<List<InformePagoInterno_Turno_Result>>(resultado);
                }
                else
                {
                    return new List<InformePagoInterno_Turno_Result>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return new List<InformePagoInterno_Turno_Result>();
            }
        }

    }
}
