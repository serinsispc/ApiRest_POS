using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class BaseCaja_controler
    {
        public static async Task<RespuestaCRUD> CrearEditarEliminarBaseCaja(BaseCaja objBase, int Boton,string db)
        {
            try
            {
                string json = JsonConvert.SerializeObject(objBase);
                string query = "";

                if (Boton == 0) query = $"EXEC INSERTINTO_BaseCaja '[{json}]'";
                if (Boton == 1) query = $"EXEC UPDATE_BaseCaja '{json}'";
                if (Boton == 2) query = $"EXEC DELETE_BaseCaja '{json}'";
                var cn = new ConnectionSQL();
                var resp =await cn.EjecutarConsulta(db,query);
                var respCRUD=JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
                return respCRUD;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new RespuestaCRUD { estado=false, idAfectado="0", mensaje="error" };
            }
        }
        public static async Task<BaseCaja> ConultarIdUsuario(int idusuario,string db)
        {
            try
            {
                string query = $@"SELECT TOP 1 * 
FROM BaseCaja
WHERE idUsuarioApertura = {idusuario}
  AND estadoBase = 'ACTIVA'
ORDER BY id ASC";
                var cn = new ConnectionSQL();
                var result =await cn.EjecutarConsulta(db,query);
                if(result != null)
                {
                    return JsonConvert.DeserializeObject<BaseCaja>(result);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        public static async Task<BaseCaja> ConultarId(int id, string db)
        {
            try
            {
                string query = $@"
                SELECT * 
                FROM BaseCaja 
                WHERE id = {id}";
                var cn = new ConnectionSQL();
                var result = await cn.EjecutarConsulta(db, query);
                if (result != null)
                {
                    return JsonConvert.DeserializeObject<BaseCaja>(result);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
