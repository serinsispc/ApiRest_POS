using DAL.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class V_CuentasVenta_controler
    {
        public static async Task<List<V_CuentasVenta>> Lista(string db, int idusuario,bool multi)
        {
            try
            {
                var cn = new ConnectionSQL();
                string query = string.Empty;
                if (!multi)
                {
                    query = $"select *from V_CuentasVenta where numeroVenta=0";
                }
                else
                {
                    query = $"select *from V_CuentasVenta where numeroVenta=0 and idusuario={idusuario}";
                }
               
                var resp = await cn.EjecutarConsulta(db, query, true);
                if (resp != null)
                {
                    return JsonConvert.DeserializeObject<List<V_CuentasVenta>>(resp);
                }
                else
                {
                    return new List<V_CuentasVenta>();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new List<V_CuentasVenta>();
            }
        }
        public static async Task<List<V_CuentasVenta>> ListaMesero(
            string db,
            int idVEndedor)
        {
            try
            {
                string query;
                query = $"select *from V_CuentasVenta where numeroVenta={0} and idvendedor={idVEndedor}";
                var cn=new ConnectionSQL();
                var resp =await cn.EjecutarConsulta(db,query, true);
                if (resp != null) return JsonConvert.DeserializeObject<List<V_CuentasVenta>>(resp);
                return null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }

        }
    }
}
