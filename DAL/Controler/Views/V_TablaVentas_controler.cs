using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_TablaVentas_controler
    {
        public static async Task<V_TablaVentas> Consulta_id(int idventa,string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                string query = $"select *from V_TablaVentas where id={idventa}";
                var resp =await cn.EjecutarConsulta(db,query);
                if (resp != null) 
                {
                    return JsonConvert.DeserializeObject<V_TablaVentas>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
