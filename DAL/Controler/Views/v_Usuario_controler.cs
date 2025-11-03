using DAL.Models.Views;
using DAL.Requests_Responses.Usuario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controler.Views
{
    public class v_Usuario_controler
    {
        public static async Task<v_Usuario> ConsultaUsuarioYClave(loginRequests requests,string db)
        {
            try
            {
                var cn = new ConnectionSQL();
                string query = $"SELECT * FROM v_Usuario WHERE cuentaUsuario = '{requests.user}' AND claveUsuario = '{requests.password}'";
                var respuesta =await cn.EjecutarConsulta(db,query);
                if(respuesta != null)
                {
                    return JsonConvert.DeserializeObject<v_Usuario>(respuesta);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
