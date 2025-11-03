using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_Categoria_controler
    {
        public static async Task<List<V_Categoria>> ListaActivas(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT * FROM V_Categoria WHERE visible = 1 ORDER BY nombreCategoria";
                var resp = await cn.EjecutarConsulta(db,query,true);
                if (resp != null) 
                {
                    return JsonConvert.DeserializeObject<List<V_Categoria>>(resp);
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
