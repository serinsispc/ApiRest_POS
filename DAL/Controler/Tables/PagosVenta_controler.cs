using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class PagosVenta_controler
    {
        public static async Task<RespuestaCRUD> InsertPago(string db,string json)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"EXEC INSERT_INTO_PagosVenta '{json}'";
                var res = await cn.EjecutarConsulta(db,query);
                var respcru=JsonConvert.DeserializeObject<RespuestaCRUD>(res);
                return respcru;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaCRUD { estado = false, idAfectado = "0", mensaje="error" };
            }
        }
    }
}
