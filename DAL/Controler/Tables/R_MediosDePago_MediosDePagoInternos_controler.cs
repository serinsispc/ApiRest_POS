using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class R_MediosDePago_MediosDePagoInternos_controler
    {
        public static async Task<List<R_MediosDePago_MediosDePagoInternos>> Lista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from R_MediosDePago_MediosDePagoInternos";
                var resp = await cn.EjecutarConsulta(db,query,true);
                if(resp != null)
                {
                    return JsonConvert.DeserializeObject<List<R_MediosDePago_MediosDePagoInternos>>(resp);
                }
                else
                {
                    return new List<R_MediosDePago_MediosDePagoInternos>();
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new List<R_MediosDePago_MediosDePagoInternos>();
            }
        }
    }
}
