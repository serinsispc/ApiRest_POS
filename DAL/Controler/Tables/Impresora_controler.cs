using DAL.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class Impresora_controler
    {
        public static async Task<List<Impresora>> Lista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                string query = "SELECT *FROM Impresora";
                var resp = await cn.EjecutarConsulta(db, query, true);
                if (resp != null)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Impresora>>(resp);
                }
                else
                {
                    return new List<Impresora>();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return new List<Impresora>();
            }
        }
    }
}
