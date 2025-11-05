using DAL.Controler.Tables;
using DAL.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Funciones
{
    public class R_VentaUsuario_f
    {
        public static async Task<bool> GestionarRelacion(string db, int idventa, int idusuario)
        {
            try
            {
                int boton = 0;
                var relacion = await R_VentaUsuario_controler.Consultar_idVenta(db, idventa);
                if (relacion.id != null)
                {
                    boton = 1;
                    relacion.idUsuario = idusuario;
                }
                else
                {

                    relacion = new  R_VentaUsuario();
                    relacion.id = 0;
                    relacion.idVenta = idventa;
                    relacion.idUsuario = idusuario;
                }
                var resp = await R_VentaUsuario_controler.Crud(db,  relacion, boton);
                return resp;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }
    }
}
