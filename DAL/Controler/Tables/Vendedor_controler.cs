using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class Vendedor_controler
    {
        public static async Task<Vendedor> ConsultarID(string db,int IdVendedor)
        {
            try
            {
                var cn = new ConnectionSQL();
                string query = $"SELECT * FROM Vendedor WHERE id = {IdVendedor}";
                var respuesta =await cn.EjecutarConsulta(db,query);
                if (respuesta != null) { return JsonConvert.DeserializeObject<Vendedor>(respuesta); }
                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}
