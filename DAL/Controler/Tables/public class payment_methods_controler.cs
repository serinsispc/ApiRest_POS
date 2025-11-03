using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DAL.Controler.Tables
{
    public class payment_methods_controler
    {
        public static async Task<List<payment_methods>> Lista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                string query = "SELECT * FROM payment_methods";
                var result =await cn.EjecutarConsulta(db,query, true);
                if (result != null) 
                {
                    return JsonConvert.DeserializeObject<List<payment_methods>>(result);
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
