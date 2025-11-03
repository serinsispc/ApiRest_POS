using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_TurnosCaja_controler
    {
        public static async Task<V_TurnosCaja> consultaBaseActiva(string Estado, int IdUsuario,string db)
        {
            try
            {
                string query = $@"
            SELECT * FROM V_TurnosCaja 
            WHERE estadoBase = '{Estado}' AND idUsuarioApertura = {IdUsuario}";
                var cn = new ConnectionSQL();
                var resp =await cn.EjecutarConsulta(db,query, true);
                if(resp != null)
                {
                    return JsonConvert.DeserializeObject<V_TurnosCaja>(resp);
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

        public static async Task<V_TurnosCaja> ConsutarID(int id, string db)
        {
            try
            {
                string query = $@"
            SELECT * FROM V_TurnosCaja 
            WHERE id = {id}";
                var cn = new ConnectionSQL();
                var resp = await cn.EjecutarConsulta(db, query);
                if (resp != null)
                {
                    return JsonConvert.DeserializeObject<V_TurnosCaja>(resp);
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
