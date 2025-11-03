using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class MediosDePagoInternos_controler
    {
        public static async Task<MediosDePagoInternos> Consulta(string db,int idmp)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT * FROM MediosDePagoInternos WHERE id = {idmp}";
                var result =await cn.EjecutarConsulta(db,query);
                return JsonConvert.DeserializeObject<MediosDePagoInternos>(result);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public static async Task<List<MediosDePagoInternos>> Lista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT * FROM MediosDePagoInternos";
                var result = await cn.EjecutarConsulta(db, query,true);
                return JsonConvert.DeserializeObject<List<MediosDePagoInternos>>(result);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
