using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class R_VentaUsuario_controler
    {
        public static async Task<R_VentaUsuario> Consultar_idVenta(string db,int IdVenta)
        {
            try
            {
                string query = $"SELECT * FROM R_VentaUsuario WHERE idVenta = {IdVenta}";
                var cn = new ConnectionSQL();
                var resultado =await cn.EjecutarConsulta(db,query);
                if(resultado != null)
                {
                    return JsonConvert.DeserializeObject<R_VentaUsuario>(resultado);
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
        public static async Task<bool> Crud(string db,R_VentaUsuario objR, int Boton)
        {
            try
            {
                string json = JsonConvert.SerializeObject(objR);
                string query = "";

                if (Boton == 0) query = $"EXEC INSERT_INTO_R_VentaUsuario '[{json}]'";
                if (Boton == 1) query = $"EXEC UPDATE_R_VentaUsuario '{json}'";
                if (Boton == 2) query = $"EXEC DELETE_R_VentaUsuario '{json}'";

                var cn=new ConnectionSQL();
                var resultado =await cn.EjecutarConsulta(db,query);
                var respuestasql = JsonConvert.DeserializeObject<RespuestaCRUD>(resultado);
                return respuestasql.estado;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
    }
}
