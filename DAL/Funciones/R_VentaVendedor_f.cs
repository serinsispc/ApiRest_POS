using DAL.Controler.Tables;
using DAL.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Funciones
{
    public class R_VentaVendedor_f
    {
        public static async void GestionarRelacion(string db,int idventa,int idvendedor)
        {
            try
            {
                int boton = 0;
                var relacion = await R_VentaVendedor_controler.Consultar_IdVenta(db, idventa);
                if (relacion != null) 
                {
                    boton = 1;
                    relacion.idVendedor = idvendedor;
                }
                else
                {
                    relacion = new R_VentaVendedor();
                    relacion.id = 0;
                    relacion.idVenta = idventa;
                    relacion.idVendedor=idvendedor;
                }
                var resp = await R_VentaVendedor_controler.CRUD(db,relacion,boton);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
