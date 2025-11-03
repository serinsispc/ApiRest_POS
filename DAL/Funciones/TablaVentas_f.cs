using DAL.Controler.Tables;
using DAL.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Funciones
{
    public class TablaVentas_f
    {
        public static async Task<RespuestaCRUD> NuevaVenta(string db,int idBase,int porpropina)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                TablaVentas venta = new TablaVentas();
                venta.id = 0;
                venta.fechaVenta = DateTime.Now;
                venta.numeroVenta = 0;
                venta.descuentoVenta = 0;
                venta.efectivoVenta = 0;
                venta.cambioVenta = 0;
                venta.estadoVenta = "--";
                venta.numeroReferenciaPago = "--";
                venta.diasCredito = 0;
                venta.IdSede = 0;
                venta.observacionVenta = "--";
                venta.guidVenta = guid;
                venta.abonoTarjeta = 0;
                venta.propina = 0;
                venta.abonoEfectivo = 0;
                venta.idMedioDePago = 10;
                venta.idResolucion = 0;
                venta.idBaseCaja = idBase;
                venta.razonDescuento = "--";
                venta.idFormaDePago = 1;
                venta.porpropina = Convert.ToDecimal(porpropina) / 100;
                venta.aliasVenta = "--";
                venta.eliminada = false;
                var respCrud =await TablaVentas_controler.Crud(venta, 0,db);
                if (respCrud.estado)
                {
                    return new RespuestaCRUD { estado = true, idAfectado = respCrud.IdFinal, mensaje = $"{guid}" };
                }
                else
                {
                    return new RespuestaCRUD { estado=false, idAfectado=0, mensaje="error" };
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new RespuestaCRUD { estado=false, idAfectado=0, mensaje=error };
            }
        }
    }
}
