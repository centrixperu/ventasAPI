

using Entidades.ReporteClienteTienda;
using Entidades.ReporteClienteTienda.GuiasTienda;
using Entidades.ReporteClienteTienda.KardexPrecioTienda;
using Entidades.ReporteClienteTienda.KardexProductoTienda;
using Entidades.ReporteClienteTienda.RegistroVentaTienda;
using Entidades.ReporteClienteTienda.VentaPrecioTienda;
using Entidades.ReporteClienteTienda.VentaProductoTienda;
using Entidades.Utils;
using Logica.ReporteClienteTienda;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ReporteClienteTienda")]
    public class ReporteClienteTiendaController : ApiController
    {
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente)
        {
            try
            {
                ReporteClienteTiendaBL oReporteClienteTiendaBL = new ReporteClienteTiendaBL(idCliente);
                ReporteClienteTienda_DatosInicialesBE obe = oReporteClienteTiendaBL.ListarDatosIniciales(usuario, idCliente);

                if (obe != null && (obe.loTienda != null && obe.loTienda.Count > 1))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron registros."));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Almacen")]
        [HttpGet]
        public IHttpActionResult GetAlmacen(string usuario, int idCliente)
        {
            try
            {
                ReporteClienteTiendaBL oReporteClienteTiendaBL = new ReporteClienteTiendaBL(idCliente);
                ReporteClienteTienda_DatosInicialesBE obe = oReporteClienteTiendaBL.ListarAlmacen(usuario, idCliente);

                if (obe != null && (obe.loAlmacen != null && obe.loAlmacen.Count > 1))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron registros."));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("GuiaTienda")]
        [HttpGet]
        public IHttpActionResult GetVerGuiaTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                ReporteClienteTiendaBL oReporteClienteTiendaBL = new ReporteClienteTiendaBL(idCliente);
                GuiaTiendaBE obe = oReporteClienteTiendaBL.VerGuiaTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                if (obe != null && (obe.listado != null && obe.listado.Count > 0) && (obe.listadoDetalle != null && obe.listadoDetalle.Count > 0))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron registros."));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("VentaProductoTienda")]
        [HttpGet]
        public IHttpActionResult GetVentaProductoTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                ReporteClienteTiendaBL oReporteClienteTiendaBL = new ReporteClienteTiendaBL(idCliente);
                VentaProductoTiendaBE obe = oReporteClienteTiendaBL.VentaProductoTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                if (obe != null && (obe.listado != null && obe.listado.Count > 0))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron registros."));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("VentaPrecioTienda")]
        [HttpGet]
        public IHttpActionResult GetVentaPrecioTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                ReporteClienteTiendaBL oReporteClienteTiendaBL = new ReporteClienteTiendaBL(idCliente);
                VentaPrecioTiendaBE obe = oReporteClienteTiendaBL.VentaPrecioTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                if (obe != null && (obe.listado != null && obe.listado.Count > 0))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron registros."));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("KardexProductoTienda")]
        [HttpGet]
        public IHttpActionResult GetKardexProductoTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                ReporteClienteTiendaBL oReporteClienteTiendaBL = new ReporteClienteTiendaBL(idCliente);
                KardexProductoTiendaBE obe = oReporteClienteTiendaBL.KardexProductoTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                if (obe != null && (obe.listado != null && obe.listado.Count > 0))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron registros."));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("KardexPrecioTienda")]
        [HttpGet]
        public IHttpActionResult GetKardexPrecioTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                ReporteClienteTiendaBL oReporteClienteTiendaBL = new ReporteClienteTiendaBL(idCliente);
                KardexPrecioTiendaBE obe = oReporteClienteTiendaBL.KardexPrecioTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                if (obe != null && (obe.listado != null && obe.listado.Count > 0))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron registros."));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegistroVentasTienda")]
        [HttpGet]
        public IHttpActionResult GetRegistroVentasTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                ReporteClienteTiendaBL oReporteClienteTiendaBL = new ReporteClienteTiendaBL(idCliente);
                VentaTiendaBE obe = oReporteClienteTiendaBL.RegistroVentasTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                if (obe != null && (obe.listado != null && obe.listado.Count > 0))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron registros."));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }


        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("MovimientoAlmacen")]
        [HttpGet]
        public IHttpActionResult GetMovimientoAlmacen(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idAlmacen, string desAlmacen)
        {
            try
            {
                //ReporteClienteTiendaBL oReporteClienteTiendaBL = new ReporteClienteTiendaBL(idCliente);
                //VentaTiendaBE obe = oReporteClienteTiendaBL.RegistroVentasTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idAlmacen, desAlmacen);

                //if (obe != null && (obe.listado != null && obe.listado.Count > 0))
                //{
                //    return Ok(Models.Util.GetBodyResponse(200, obe));
                //}
                //else
                //{
                return Ok(Models.Util.GetBodyResponse(300, "No se encontraron registros."));
                //}
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }
        

    }
}