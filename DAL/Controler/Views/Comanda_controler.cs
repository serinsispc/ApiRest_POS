using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class Comanda_controler
    {
        public static async Task<List<Comanda>> Lista(string db, int idventa, string Tipo, string estado)
        {
            try
            {
                string query = $"select *from Comanda where " +
                    $"idVenta={idventa} and " +
                    $"tipoComanda='{Tipo}' and " +
                    $"estado='{estado}'";
                var cn = new ConnectionSQL();
                var resp =await cn.EjecutarConsulta(db,query, true);
                if (resp != null)
                {
                    return JsonConvert.DeserializeObject<List<Comanda>>(resp);
                }
                else
                {
                    return null;
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
