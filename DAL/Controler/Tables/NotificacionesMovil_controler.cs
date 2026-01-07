using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class NotificacionesMovil_controler
    {
        public static async Task<RespuestaCRUD> CRUD(string db, NotificacionesMovil notificaciones, int funcion)
        {
            try
            {
                var json = JsonConvert.SerializeObject(notificaciones);
                var cn = new ConnectionSQL();
                json = json.Replace("'", "''"); // MUY importante

                var query = $"EXEC dbo.CRUD_NotificacionesMovil N'{json}', {funcion}";
                var resultado = await cn.EjecutarConsulta(db, query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resultado);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return new RespuestaCRUD
                {
                    estado = false,
                    mensaje = mensaje
                };
            }
        }

        public static async Task<RespuestaCRUD> Aprobar(string db, AprobarNotificacionMovil aprobar)
        {
            try
            {
                var json = JsonConvert.SerializeObject(aprobar);
                var cn = new ConnectionSQL();
                var query = $"EXEC CRUD_AprobarNotificacionMovil N'{json}',0";
                var resultado = await cn.EjecutarConsulta(db, query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resultado);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return new RespuestaCRUD
                {
                    estado = false,
                    mensaje = mensaje
                };
            }
        }
    }
}
