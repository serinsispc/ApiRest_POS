using DAL;
using DAL.Controler.Tables;
using DAL.Controler.Views;
using DAL.Funciones;
using DAL.Models.Tables;
using DAL.Models.Views;
using DAL.Requests_Responses.Caja;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaController : ControllerBase
    {
        [HttpPost("Load")]
        [TokenDbFilter]
        public async Task<IActionResult> Load(LoadCajaRequests requests)
        {
            var db = HttpContext.Items["DB"];
            //declaramos la respuesta
            var viewModel = new LoadCajaResponses();
            if (requests.Comandera)//identificamos si la caja es comandare o caja.
            {
                //procedemos a consultar si el mesero tiene cuantas activas
                viewModel.listacuentas =await V_CuentasVenta_controler.ListaMesero($"{db}",requests.IdVendedor);
                if(viewModel.listacuentas==null || viewModel.listacuentas.Count == 0)
                {
                    //creamos una nueva cuenta
                    var niewVenta = await TablaVentas_f.NuevaVenta($"{db}",0,requests.PorPropina);
                    if (niewVenta != null)
                    {
                        viewModel.idventa = niewVenta.idAfectado;
                        viewModel.guid = new Guid(niewVenta.mensaje);
                        //ahora creamos la relación del mesero con la venta
                        R_VentaVendedor_f.GestionarRelacion($"{db}", niewVenta.idAfectado, requests.IdVendedor);
                        viewModel.listacuentas = await RepetirVendedor($"{db}", requests.IdVendedor, requests.MultiCaja);
                        viewModel.cuenta = viewModel.listacuentas.LastOrDefault();
                        viewModel.venta = await V_TablaVentas_controler.Consulta_id(viewModel.idventa, $"{db}");
                    }
                    else
                    {
                        return Ok(new LoadCajaRequests());
                    }
                }
                else
                {
                    viewModel.cuenta = viewModel.listacuentas.FirstOrDefault();
                    viewModel.idventa = viewModel.cuenta.id;
                    viewModel.venta =await V_TablaVentas_controler.Consulta_id(viewModel.idventa, $"{db}");
                    viewModel.guid = (Guid)viewModel.venta.guidVenta;
                }
            }
            else
            {
                //en esta parte procedemos a consultar las cuentas activas por idBase
                //procedemos a consultar si el usuario tiene cuantas activas
                viewModel.listacuentas = await V_CuentasVenta_controler.Lista($"{db}", requests.IdUsuario,requests.MultiCaja);
                if (viewModel.listacuentas == null || viewModel.listacuentas.Count == 0)
                {
                    //creamos una nueva cuenta
                    var niewVenta = await TablaVentas_f.NuevaVenta($"{db}", 0, requests.PorPropina);
                    if (niewVenta != null)
                    {
                        viewModel.idventa = niewVenta.idAfectado;
                        viewModel.guid = new Guid(niewVenta.mensaje);
                        // ahora relacionamos el vendedor con la venta
                        var resprelacion = await R_VentaBase_f.GestionarRelacion($"{db}", niewVenta.idAfectado, requests.IdBase);
                        viewModel.listacuentas = await V_CuentasVenta_controler.Lista($"{db}", requests.IdUsuario, requests.MultiCaja);
                        viewModel.cuenta = viewModel.listacuentas.FirstOrDefault();
                        viewModel.venta = await V_TablaVentas_controler.Consulta_id(viewModel.idventa, $"{db}");
                    }
                    else
                    {
                        return Ok(new LoadCajaRequests());
                    }
                }
                else
                {
                    viewModel.cuenta = viewModel.listacuentas.FirstOrDefault();
                    viewModel.idventa = viewModel.cuenta.id;
                    viewModel.venta = await V_TablaVentas_controler.Consulta_id(viewModel.idventa, $"{db}");
                    viewModel.guid = (Guid)viewModel.venta.guidVenta;
                }
            }
            //ahora cargamos las listas estaticas
            viewModel.listazonas = await V_Zona_controler.Lista($"{db}");
            viewModel.listaMesas = await V_Mesas_controler.lista($"{db}");
            viewModel.listacategorias = await V_Categoria_controler.ListaActivas($"{db}");
            viewModel.listaproductos = await v_productoVenta_controler.Lista($"{db}",1,1);

            return Ok(viewModel);
        }


        [HttpPost("Niew")]
        [TokenDbFilter]
        public async Task<IActionResult> Niew(LoadCajaRequests requests)
        {
            var db = HttpContext.Items["DB"];
            //declaramos la respuesta
            var viewModel = new NiewResponses();
            if (requests.Comandera)//identificamos si la caja es comandare o caja.
            {
                //creamos una nueva cuenta
                var niewVenta = await TablaVentas_f.NuevaVenta($"{db}", 0, requests.PorPropina);
                if (niewVenta != null)
                {
                    viewModel.idventa = niewVenta.idAfectado;
                    viewModel.guid = new Guid(niewVenta.mensaje);
                    //ahora creamos la relación del mesero con la venta
                    R_VentaVendedor_f.GestionarRelacion($"{db}", niewVenta.idAfectado, requests.IdVendedor);
                    //procedemos a consultar si el mesero tiene cuantas activas
                    viewModel.listacuentas = await V_CuentasVenta_controler.ListaMesero($"{db}", requests.IdVendedor);
                    viewModel.cuenta = viewModel.listacuentas.LastOrDefault();
                    viewModel.idventa = viewModel.cuenta.id;
                    viewModel.venta = await V_TablaVentas_controler.Consulta_id(viewModel.idventa, $"{db}");
                    viewModel.guid = (Guid)viewModel.venta.guidVenta;
                }
                else
                {
                    return Ok(new LoadCajaRequests());
                }
            }
            else
            {
                //creamos una nueva cuenta
                var niewVenta = await TablaVentas_f.NuevaVenta($"{db}", requests.IdBase, requests.PorPropina);
                if (niewVenta.estado)
                {
                    viewModel.idventa = niewVenta.idAfectado;
                    viewModel.guid =new Guid(niewVenta.mensaje);
                    // ahora relacionamos el vendedor con la venta
                    var resprelacion=await R_VentaBase_f.GestionarRelacion($"{db}", niewVenta.idAfectado, requests.IdBase);
                    viewModel.listacuentas = await RepetirUsuario($"{db}", requests.IdUsuario, requests.MultiCaja);
                    viewModel.cuenta = viewModel.listacuentas.LastOrDefault();
                    viewModel.idventa = viewModel.cuenta.id;
                    viewModel.venta = await V_TablaVentas_controler.Consulta_id(viewModel.idventa, $"{db}");
                    viewModel.guid = (Guid)viewModel.venta.guidVenta;
                }
                else
                {
                    return Ok(new LoadCajaRequests());
                }
            }

            return Ok(viewModel);
        }

        public static async Task<List<V_CuentasVenta>> RepetirUsuario(
    string db, int idusuario, bool multiCaja, int reintentos = 3, int delayMs = 150)
        {
            List<V_CuentasVenta> resultado = null;

            for (int intento = 1; intento <= reintentos; intento++)
            {
                resultado = await V_CuentasVenta_controler.Lista(db, idusuario, multiCaja);

                if (resultado != null && resultado.Count > 0)
                    return resultado;

                if (intento < reintentos)
                    await Task.Delay(delayMs * intento); // backoff lineal
            }

            return resultado ?? new List<V_CuentasVenta>(); // jamás null
        }

        public static async Task<List<V_CuentasVenta>> RepetirVendedor(
string db, int idvendedor, bool multiCaja, int reintentos = 3, int delayMs = 150)
        {
            List<V_CuentasVenta> resultado = null;

            for (int intento = 1; intento <= reintentos; intento++)
            {
                resultado = await V_CuentasVenta_controler.ListaMesero(db, idvendedor);

                if (resultado != null && resultado.Count > 0)
                    return resultado;

                if (intento < reintentos)
                    await Task.Delay(delayMs * intento); // backoff lineal
            }

            return resultado ?? new List<V_CuentasVenta>(); // jamás null
        }
        [HttpPost("CargarDetalle")]
        [TokenDbFilter]
        public async Task<IActionResult> CargarDetalle(CargarDetalleRequests requests)
        {
            var db = HttpContext.Items["DB"];
            int Boton = 0;

            var detalleRequest = requests.detalleVenta;

            var detalleVenta = await DetalleVenta_controler.Consultar_DetalleCaja($"{db}",requests.IdVenta,requests.IdPresentacion);
            if (detalleVenta != null)
            {
                if (requests.ItemVentaUnico == true)
                {
                    Boton = 1;
                    detalleRequest.id = (int)detalleVenta.id;
                    detalleRequest.guidDetalle = new Guid($"{detalleVenta.guidDetalle}");
                    detalleRequest.cantidadDetalle = detalleRequest.cantidadDetalle + Convert.ToDecimal(detalleVenta.cantidadDetalle);
                }
                else
                {
                    Boton = 0;
                    detalleVenta = new DetalleVenta();
                    detalleRequest.id = 0;
                    detalleRequest.guidDetalle = Guid.NewGuid();
                }

            }
            else
            {
                Boton = 0;
                detalleVenta = new DetalleVenta();
                detalleRequest.id = 0;
                detalleRequest.guidDetalle = Guid.NewGuid();
                detalleVenta.opciones = detalleRequest.opciones;
                detalleVenta.adiciones = detalleRequest.adiciones;
            }
            detalleVenta.id = detalleRequest.id;
            detalleVenta.idVenta = detalleRequest.idVenta;
            detalleVenta.idPresentacion = detalleRequest.idPresentacion;
            detalleVenta.guidDetalle= detalleRequest.guidDetalle;
            detalleVenta.nombreProducto = detalleRequest.nombreProducto;
            detalleVenta.costoUnidad = detalleRequest.costoUnidad;
            detalleVenta.precioVenta = detalleRequest.precioVenta;
            detalleVenta.estadoDetalle = detalleRequest.estadoDetalle;
            detalleVenta.ivaDetalle = detalleRequest.ivaDetalle;
            detalleVenta.impuesto_id = detalleRequest.impuesto_id;
            detalleVenta.cantidadDetalle = detalleRequest.cantidadDetalle;
            detalleVenta.codigoProducto = detalleRequest.codigoProducto;
            detalleVenta.observacion = detalleRequest.observacion;
            detalleVenta.adiciones = detalleRequest.adiciones;
            detalleVenta.opciones = detalleRequest.opciones;
            bool sqlDetalle =await DetalleVenta_controler.GuardarEditarEliminar(detalleVenta, Boton,$"{db}");
            if (sqlDetalle == true)
            {
                var detalleCajas = await V_DetalleCaja_controler.Consultar_idVenta(requests.IdVenta, $"{db}");
                return Ok(detalleCajas);
            }
            else
            {
                return Ok(null);
            }
            
        }
        [HttpPost("Delete/{id}")]
        [TokenDbFilter]
        public async Task<IActionResult>DeleteDetalle(int id)
        {
            var db = HttpContext.Items["DB"];
            var detalle = await DetalleVenta_controler.Consultar_DetalleCaja($"{db}",id);
            if (detalle != null)
            {
                detalle.observacion = $"eliminado {DateTime.Now}";
                detalle.estadoDetalle = 0;
                bool sqlDetalle = await DetalleVenta_controler.GuardarEditarEliminar(detalle, 1, $"{db}");
                if (sqlDetalle == true)
                {
                    var detalleCajas = await V_DetalleCaja_controler.Consultar_idVenta((int)detalle.idVenta, $"{db}");
                    return Ok(detalleCajas);
                }
                else
                {
                    return Ok(new List<V_DetalleCaja>());
                }
            }
            else
            {
                return Ok(new List<V_DetalleCaja>());
            }
           
        }
    }
}
