using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_Compra_controler
    {
        public static async Task<List<V_Compra>> ListaCompleta_Sede(int Estado,string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT * FROM V_Compra WHERE estadoCompra = {Estado} ORDER BY fechaCompra";
                var resp =await cn.EjecutarConsulta(db,query, true);
                if (resp != null)
                {
                    return JsonConvert.DeserializeObject<List<V_Compra>>(resp);
                }
                else { return new List<V_Compra>(); }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new List<V_Compra>();
            }
        }
        public static async Task<List<V_Compra>> FiltarFecha_dia(int Estado, DateTime fecha, string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $@"
            SELECT * FROM V_Compra 
            WHERE estadoCompra = {Estado}
            AND YEAR(fechaCompra) = {fecha.Year}
            AND MONTH(fechaCompra) = {fecha.Month}
            AND DAY(fechaCompra) = {fecha.Day}
            ORDER BY fechaCompra";

                string resp =await cn.EjecutarConsulta(db,query, true);
                if (resp != null) 
                {
                    return JsonConvert.DeserializeObject<List<V_Compra>>(resp);
                }
                else
                {
                    return new List<V_Compra>();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new List<V_Compra>();
            }
        }

        public static async Task<List<V_Compra>> FiltarFecha_mes(int Estado, DateTime fecha, string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $@"
            SELECT * FROM V_Compra 
            WHERE estadoCompra = {Estado} 
            AND YEAR(fechaCompra) = {fecha.Year} 
            AND MONTH(fechaCompra) = {fecha.Month} 
            ORDER BY fechaCompra";

                string resp = await cn.EjecutarConsulta(db, query, true);
                if (resp != null)
                {
                    return JsonConvert.DeserializeObject<List<V_Compra>>(resp);
                }
                else
                {
                    return new List<V_Compra>();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new List<V_Compra>();
            }
        }
        public static async Task<List<V_Compra>> FiltarFecha_ano(int Estado, DateTime fecha, string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $@"
            SELECT * FROM V_Compra 
            WHERE estadoCompra = {Estado} 
            AND YEAR(fechaCompra) = {fecha.Year} 
            ORDER BY fechaCompra";

                string resp = await cn.EjecutarConsulta(db, query, true);
                if (resp != null)
                {
                    return JsonConvert.DeserializeObject<List<V_Compra>>(resp);
                }
                else
                {
                    return new List<V_Compra>();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new List<V_Compra>();
            }
        }
    }
}
