using DAL.Controler.Tables;
using DAL.Models.Tables;
using DAL.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_Inventario_controler
    {
        public static async Task<List<V_Inventario>> ConsultarLista(string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT * FROM V_Inventario";
                var resultado = await cn.EjecutarConsulta(db, query, true);
                var lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<V_Inventario>>(resultado);
                return lista;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return new List<V_Inventario>();
            }
        }
        public static async Task<int> AjustarInventario(string db, List<V_Inventario> lista)
        {
            try
            {
                int contador = 0;
                foreach (var item in lista)
                {
                    item.diferencia= (decimal.Parse(item.inventarioReal) - item.inventarioActual).ToString();
                    // enviamos a ajustar inventario
                    var ajuste = new MovimientosInventario { 
                     id=0,
                     fechaMovimiento=DateTime.Now,
                        idUsuario=1,
                        idProducto=item.id,
                        cantidadMovimiento= decimal.Parse( item.diferencia)
                    };
                    bool res = await MovimientosInventario_controler.CRUD(db, ajuste,0);
                    if (res)
                    {
                        contador++;
                    }
                }
                return contador;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
    }
}
