using DAL.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_Comandas_controler
    {
        public static async Task<List<V_Comandas>> Lista(string db)
        {
            try
            {
                var cn=new ConnectionSQL();
                var query = $"SELECT * FROM V_Comandas where estado=1";
                var resp = await cn.EjecutarConsulta(db, query, true);
                var lista = new List<V_Comandas>();
                if (resp != null && resp != "[]")
                {
                    lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<V_Comandas>>(resp);
                }
                else
                {
                    lista = new List<V_Comandas>();
                }
                return lista;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new List<V_Comandas>();
            }
        }
    }
}
