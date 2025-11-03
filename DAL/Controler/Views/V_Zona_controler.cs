using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_Zona_controler
    {
        public static async Task<V_Zona> ZonaDOMICILIOS(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                string query = "SELECT TOP 1 * FROM Zonas WHERE nombreZona = 'DOMICILIOS'";
                var resp = await cn.EjecutarConsulta(db, query);
                if (resp == null)
                    return null;
                return JsonConvert.DeserializeObject<V_Zona>(resp);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        public static async Task<List<V_Zona>> Lista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                string query = "SELECT * FROM Zonas WHERE estadoZona = 1";
                var resp = await cn.EjecutarConsulta(db, query, true);
                if (resp == null)
                    return null;
                return JsonConvert.DeserializeObject<List<V_Zona>>(resp);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
