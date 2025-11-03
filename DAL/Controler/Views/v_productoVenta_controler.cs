using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class v_productoVenta_controler
    {
        public static async Task<List<v_productoVenta>>Lista(string db, int estadoProducto,int visible)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from v_productoVenta where estadoProducto={estadoProducto} and visible={visible}";
                var resp = await cn.EjecutarConsulta(db,query,true);
                if (resp != null) { return JsonConvert.DeserializeObject<List<v_productoVenta>>(resp); }
                return null;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
