using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class R_VentaBase_controler
    {
        public static async Task<R_VentaBase>Consultar(string db, int idventa)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from R_VentaBase where idVenta={idventa}";
                var resp = await cn.EjecutarConsulta(db,query);
                if (resp != null) { return JsonConvert.DeserializeObject<R_VentaBase>(resp); }
                return null;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public static async Task<RespuestaCRUD> CRUD(string db, int boto,R_VentaBase ventaBase)
        {
            try
            {
                string json=JsonConvert.SerializeObject(ventaBase);
                json = AjustarJSON.Ajustar(json);
                var cn = new ConnectionSQL();
                var query = $"exec CRUD_R_VentaBase N'{json}',{boto}";
                var resp = await cn.EjecutarConsulta(db, query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
                
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
