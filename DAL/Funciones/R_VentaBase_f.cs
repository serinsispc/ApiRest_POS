using DAL.Controler.Tables;
using DAL.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Funciones
{
    public class R_VentaBase_f
    {
        public static async void GestionarRelacion(string db, int idventa, int idbase)
        {
            try
            {
                int boton = 0;
                var relacion = await R_VentaBase_controler.Consultar(db, idventa);
                if (relacion != null)
                {
                    boton = 1;
                    relacion.idBaseCaja = idbase;
                }
                else
                {

                    relacion = new R_VentaBase();
                    relacion.id = 0;
                    relacion.idVenta = idventa;
                    relacion.idBaseCaja = idbase;
                }
                var resp = await R_VentaBase_controler.CRUD(db, boton, relacion);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
