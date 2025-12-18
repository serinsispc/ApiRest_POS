using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class CargoDescuentoVentas_controler
    {
        public static async Task<List<CargoDescuentoVentas>>Lista_idventa(string db, int idventa)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from CargoDescuentoVentas where idVenta={idventa}";
                var resp = await cn.EjecutarConsulta(db,query,true);
                if (resp != null) { return JsonConvert.DeserializeObject<List<CargoDescuentoVentas>>(resp); }
                return new List<CargoDescuentoVentas>();
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new List<CargoDescuentoVentas>();
            }
        }
        public static async Task<RespuestaCRUD> crud(string db,CargoDescuentoVentas obj, int boton)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                json = AjustarJSON.Ajustar(json);
                var cn = new ConnectionSQL();
                var query = $"exec CRUD_CargoDescuentoVentas N'{json}',{boton}";
                var resp = await cn.EjecutarConsulta(db, query);
                if (resp != null) { return JsonConvert.DeserializeObject<RespuestaCRUD>(resp); }
                return new RespuestaCRUD();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaCRUD { estado=false, idAfectado="0", mensaje="Error", nuevoId="0" };
            }
        }
    }
}
