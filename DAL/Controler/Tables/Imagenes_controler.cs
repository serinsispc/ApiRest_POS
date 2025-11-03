using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class Imagenes_controler
    {
        public static async Task<Imagenes> ConsultarGUID(string idimagen,string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from Imagenes where id=N'{idimagen}'";
                var resp = await cn.EjecutarConsulta(db,query);
                if(resp==null) 
                    return null;
                return JsonConvert.DeserializeObject<Imagenes>(resp);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
