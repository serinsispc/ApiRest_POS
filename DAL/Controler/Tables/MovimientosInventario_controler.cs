using DAL.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class MovimientosInventario_controler
    {
        public static async Task<bool> CRUD (string db, MovimientosInventario movimiento, int funcion)
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(movimiento);
                json = AjustarJSON.Ajustar(json);
                var cn = new ConnectionSQL();
                var query = $"EXEC CRUD_MovimientosInventario N'{json}',{funcion}";
                var resultado = await cn.EjecutarConsultaJsonDirecto(db, query);
                return true;
            }
            catch(Exception ex)
            {
                               string error = ex.Message;
                return false;
            }
        }
    }
}
