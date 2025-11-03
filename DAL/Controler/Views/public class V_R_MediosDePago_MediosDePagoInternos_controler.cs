using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class public_class_V_R_MediosDePago_MediosDePagoInternos_controler
    {
        public static async Task<List<V_R_MediosDePago_MediosDePagoInternos>> Lista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT * FROM V_R_MediosDePago_MediosDePagoInternos";
                var resultado =await cn.EjecutarConsulta(db,query, true);
                if(resultado != null)
                {
                    return JsonConvert.DeserializeObject<List<V_R_MediosDePago_MediosDePagoInternos>>(resultado);
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
