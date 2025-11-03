using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Tables
{
    public class Licencia_controler
    {
        public static async Task<bool> Crear_Editar_Eliminar_LicenciaSoftware(Licencia objLicencia, int Boton,string db)
        {
            try
            {
                string json = JsonConvert.SerializeObject(objLicencia);
                string query = "";

                if (Boton == 0)
                    query = $"EXEC INSERT_INTO_Licencia '{json}'";

                if (Boton == 1)
                    query = $"EXEC UPDATE_Licencia '{json}'";

                if (Boton == 2)
                    query = $"EXEC DELETE_Licencia '{json}'";
                var cn = new ConnectionSQL();
                var resultado =await cn.EjecutarConsulta(db,query);

                if(resultado == null)
                    return false;

                var respuesta = JsonConvert.DeserializeObject<List<RespuestaCRUD>>(resultado)?.FirstOrDefault();

                return respuesta != null && respuesta.estado == false;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                
                return false;
            }
        }

        public static async Task<Licencia> ConsultarLicencia(string claveLicencia,string db)
        {
            try
            {
                string query = $"SELECT * FROM Licencia WHERE clave = '{claveLicencia}'";
                var cn = new ConnectionSQL();
                var resultado =await cn.EjecutarConsulta(db,query);

                if (resultado == null)
                    return null;

                return JsonConvert.DeserializeObject<Licencia>(resultado);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                
                return null;
            }

        }

        public static async Task<List<Licencia>> ListaCompleta(string db)
        {
            try
            {
                string query = "SELECT * FROM Licencia";
                var cn = new ConnectionSQL();
                var resultado =await cn.EjecutarConsulta(db,query, true);

                if (resultado == null)
                    return null;

                return JsonConvert.DeserializeObject<List<Licencia>>(resultado);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}
