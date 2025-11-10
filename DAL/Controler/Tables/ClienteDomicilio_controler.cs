using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class ClienteDomicilio_controler
    {
        public static async Task<List<ClienteDomicilio>>FiltrarTelefono(string db,string telefono)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT * FROM ClienteDomicilio WHERE celularCliente = '{telefono}'";
                var resp = await cn.EjecutarConsulta(db, query, true);
                if (resp != null)
                {
                    return JsonConvert.DeserializeObject<List<ClienteDomicilio>>(resp);
                }
                else
                {
                    return new List<ClienteDomicilio>();
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new List<ClienteDomicilio>();
            }
        }
        public static async Task<RespuestaCRUD>CRUD(string db,ClienteDomicilio cliente,int boton)
        {
            try
            {
                string json=JsonConvert.SerializeObject(cliente);
                json = AjustarJSON.Ajustar(json);
                var cn=new ConnectionSQL();
                var query = $"exec CRUD_ClienteDomicilio N'{json}',{boton}";
                var resp = await cn.EjecutarConsulta(db,query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return new RespuestaCRUD { estado=false, idAfectado="0", mensaje="error", nuevoId="0" };
            }
        }

    }
}
