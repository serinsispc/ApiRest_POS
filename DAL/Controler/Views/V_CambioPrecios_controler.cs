using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_CambioPrecios_controler
    {
        public static async Task<List<Models.Views.V_CambioPrecios>> Lista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT * FROM V_CambioPrecios";
                var resultado = await cn.EjecutarConsulta(db, query, true);
                var lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.Views.V_CambioPrecios>>(resultado);
                return lista;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return new List<Models.Views.V_CambioPrecios>();
            }
        }
        public static async Task<bool> Guardar(string db, List<Models.Views.V_CambioPrecios> model)
        {
            try
            {
                var cn = new ConnectionSQL();
                foreach(var item in model)
                {
                    var query = $"update Presentacion set precioVenta={Convert.ToInt32(item.precioNuevo)} where id={item.id}";
                    await cn.EjecutarConsulta(db, query, false);
                }
                return true;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
    }
}
