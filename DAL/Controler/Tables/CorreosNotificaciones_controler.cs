using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class CorreosNotificaciones_controler
    {
        public static async Task<List<CorreosNotificaciones>> Lista(string db)
        {
            try
            {
                string query = $"SELECT *FROM CorreosNotificaciones";
                var cn = new ConnectionSQL();
                var resp = await cn.EjecutarConsulta(db, query, true);
                if (resp != null)
                {
                    return JsonConvert.DeserializeObject<List<CorreosNotificaciones>>(resp);
                }
                else
                {
                    return new List<CorreosNotificaciones>();
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new List<CorreosNotificaciones>();
            }
        }
    }
}
