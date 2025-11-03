using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class DetalleVenta_controler
    {
        public static async Task<DetalleVenta> Consultar_DetalleCaja(string db,int idVenta, int idPresentacion)
        {
            try
            {
                string query = $@"
            SELECT * 
            FROM DetalleVenta 
            WHERE idVenta = {idVenta} 
              AND idPresentacion = {idPresentacion}";
                var cn = new ConnectionSQL();
                var resp =await cn.EjecutarConsulta(db,query);
                if(resp != null) { return JsonConvert.DeserializeObject<DetalleVenta>(resp); }
                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
               
                return null;
            }
        }
        public static async Task<DetalleVenta> Consultar_DetalleCaja(string db, int id)
        {
            try
            {
                string query = $@"
            SELECT * 
            FROM DetalleVenta 
            WHERE id = {id}";
                var cn = new ConnectionSQL();
                var resp = await cn.EjecutarConsulta(db, query);
                if (resp != null) { return JsonConvert.DeserializeObject<DetalleVenta>(resp); }
                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;

                return null;
            }
        }
        public static async Task<bool> GuardarEditarEliminar(DetalleVenta objDetalleV, int Boton, string db)
        {
            try
            {
                string json = JsonConvert.SerializeObject(objDetalleV);
                string query = string.Empty;

                if (Boton == 0) { query = $"EXEC INSERTINTO_DetalleVenta '{json}'"; }
                if (Boton == 1) { query = $"EXEC UPDATE_DetalleVenta '{json}'"; }
                if (Boton == 2) { query = $"EXEC DELETE_DetalleVenta '{json}'"; }
                var cn = new ConnectionSQL();
                string resp =await cn.EjecutarConsulta(db,query);
                var respuestasql = JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
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
