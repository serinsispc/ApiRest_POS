using DAL.Models.Tables;
using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class R_VentaClienteDomicilio_controler
    {
        public static async Task<RespuestaCRUD> CRUD(string db,R_VentaClienteDomicilio objeto, int boton)
        {
            try
            {
                string json =JsonConvert.SerializeObject(objeto);
                json=AjustarJSON.Ajustar(json);
                var cn = new ConnectionSQL();
                var query = $"exec CRUD_R_VentaClienteDomicilio N'{json}',{boton}";
                var resp = await cn.EjecutarConsulta(db,query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaCRUD { estado=false, idAfectado="0", mensaje="error", nuevoId="0"  };
            }
        }

        public static async Task<V_R_VentaClienteDomicilio> ConsultarIdVenta(string db,int idVenta)
        {
            try
            {
                var cn =new ConnectionSQL();
                var query = $"select *from V_R_VentaClienteDomicilio where idVenta={idVenta}";
                var resp = await cn.EjecutarConsulta(db,query);
                if(resp != null)
                {
                    return JsonConvert.DeserializeObject<V_R_VentaClienteDomicilio>(resp);
                }
                else
                {
                    return new V_R_VentaClienteDomicilio();
                }
            }
            catch (Exception ex)
            {
                string errmsg = ex.Message;
                return new V_R_VentaClienteDomicilio();
            }
        }
    }
}
