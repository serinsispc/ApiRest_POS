using DAL.Models.Tables;
using DAL.Requests_Responses.AutorizacionPC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class AutorizacionPC_controler
    {
        public static async Task<bool> Crear_Editar_Eliminar_Equipo(AutorizacionPC objAE, int Boton,string db)
        {
            try
            {
                string json = JsonConvert.SerializeObject(objAE);
                string query = "";

                if (Boton == 0) query = $"EXEC INSERTINTO_AutorizacionPC '{json}'";
                if (Boton == 1) query = $"EXEC UPDATE_AutorizacionPC '{json}'";
                if (Boton == 2) query = $"EXEC DELETE_AutorizacionPC '{json}'";
                var cn = new ConnectionSQL();
                string resp =await cn.EjecutarConsulta(db,query);
                RespuestaCRUD resultado = JsonConvert.DeserializeObject<RespuestaCRUD>(resp);

                return (bool)resultado.estado;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                
                return false;
            }
        }
        public static async Task<AutorizacionPC> ConsultarXSerial(ConsultarXSerial_Requests requests,string db)
        {
            try
            {
                string query = $@"
                SELECT * FROM AutorizacionPC
                WHERE serialnumber_pc = '{requests.Serial}'
                AND Manufacturer_pc = '{requests.Manufacture}'
                AND product_pc = '{requests.Producto}'
                AND Version_pc = '{requests.Vercion}'
                AND estado_equipo = {requests.Estado}";
                var cn = new ConnectionSQL();
                dynamic resp =await cn.EjecutarConsulta(db, query);
                if(resp != null)
                {
                    return JsonConvert.DeserializeObject<AutorizacionPC>(resp);
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
