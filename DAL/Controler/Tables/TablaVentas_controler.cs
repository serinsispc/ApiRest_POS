using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class TablaVentas_controler
    {
        public static async Task<RespuestaCRUD> Crud(TablaVentas tablaVentas, int Boton,string db)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tablaVentas);
                string query = string.Empty;
                query = $"EXEC CRUD_TablaVentas N'{json}',{Boton}";
                var cn = new ConnectionSQL();
                var respuestaJson =await cn.EjecutarConsulta(db,query);
                var respCRUD=JsonConvert.DeserializeObject<RespuestaCRUD>(respuestaJson);
                return respCRUD;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new RespuestaCRUD { estado=false, idAfectado=0, mensaje="error" };
            }
        }
        public static async Task<TablaVentas>ConsultarId(int id, string db)
        {
            try
            {
                var query = $"SELECT * FROM TablaVentas WHERE id = {id}";
                var cn = new ConnectionSQL();
                var respuestaJson = await cn.EjecutarConsulta(db, query);
                var respCRUD = JsonConvert.DeserializeObject<TablaVentas>(respuestaJson);
                return respCRUD;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<int> Consecutivo(int idResolucion, string db)
        {
            try
            {
                var query = $"SELECT MAX(numeroVenta) FROM TablaVentas WHERE idResolucion = {idResolucion}";
                var cn = new ConnectionSQL();
                var respuestaJson = await cn.EjecutarConsulta(db, query);
                var respCRUD = JsonConvert.DeserializeObject<int>(respuestaJson);
                return respCRUD;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
    }
}
