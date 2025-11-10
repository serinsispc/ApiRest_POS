using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class EstadoDomicilio_controler
    {
        public static async Task<List<EstadoDomicilio>> Lista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT * FROM EstadoDomicilio";
                var resp = await cn.EjecutarConsulta(db,query,true);
                if (resp != null) 
                {
                    return JsonConvert.DeserializeObject<List<EstadoDomicilio>>(resp);
                }
                else
                {
                    return new List<EstadoDomicilio>();
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new List<EstadoDomicilio>();
            }
        }
    }
}
