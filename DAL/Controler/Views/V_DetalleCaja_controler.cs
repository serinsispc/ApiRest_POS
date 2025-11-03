using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_DetalleCaja_controler
    {
        public static async Task<List<V_DetalleCaja>> Consultar_idVenta(int idventa,string db)
        {
            try
            {
                var cn =new ConnectionSQL();
                string query = $"select *from V_DetalleCaja where idVenta={idventa} ORDER BY id DESC";
                var resp =await cn.EjecutarConsulta(db,query, true);
                if (resp != null) 
                {
                    return JsonConvert.DeserializeObject<List<V_DetalleCaja>>($"{resp}");
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
