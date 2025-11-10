using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class R_VentaVendedor_controler
    {
        public static async Task<R_VentaVendedor> Consultar_IdVenta(string db,int IdVenta)
        {
            try
            {
                var cn = new ConnectionSQL();
                string query = $"SELECT * FROM R_VentaVendedor WHERE idVenta = {IdVenta}";
                var resultado =await cn.EjecutarConsulta(db,query);
                if (resultado != null)
                {
                    return JsonConvert.DeserializeObject<R_VentaVendedor>(resultado);
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

        public static async Task<RespuestaCRUD> CRUD(string db, R_VentaVendedor relacion,int boton)
        {
            try
            {
                string json=JsonConvert.SerializeObject(relacion);
                json = AjustarJSON.Ajustar(json);
                var cn=new ConnectionSQL();
                var query = $"exec CRUD_R_VentaVendedor N'{json}',{boton}";
                var resp = await cn.EjecutarConsulta(db, query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch(Exception ex)
            {
                string error=ex.Message;
                return new RespuestaCRUD { estado=false, idAfectado="0", mensaje="error" };
            }
        }

    }
}
