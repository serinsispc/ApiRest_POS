using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class AdminControl_controler
    {
        public static async Task<AdminControl> Consultar(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                string query = "SELECT TOP 1 * FROM AdminControl WHERE tipo_admincontrol != 0";
                var resp =await cn.EjecutarConsulta(db,query);
                if (resp != null) 
                {
                    return JsonConvert.DeserializeObject<AdminControl>(resp);
                }
                else
                {
                    return new AdminControl();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                
                return null;
            }
        }
    }
}
