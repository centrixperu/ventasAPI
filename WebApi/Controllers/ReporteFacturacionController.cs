

using Entidades.Utils;
using Logica.ReporteFacturacion;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ReporteFacturacion")]
    public class ReporteFacturacionController : ApiController
    {
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("ComprobanteTienda")]
        [HttpGet]
        public IHttpActionResult GetComprobanteTienda(string usuario, int idCliente, int idTienda)
        {
            try
            {
                ReporteFacturacionBL oReporteClienteTiendaBL = new ReporteFacturacionBL(idCliente);
                List<ListaComboBE> obe = oReporteClienteTiendaBL.ComprobanteTienda(usuario, idCliente, idTienda);

                if (obe != null && (obe.Count > 0))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron Comprobantes para Tienda."));
                }
            }
            catch (Exception ex)
            {
                //LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("ReporteComprobante")]
        [HttpGet]
        public IHttpActionResult GetVerGuiaTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda, string idComprobante)
        {
            try
            {
                //ReporteFacturacionBL oReporteClienteTiendaBL = new ReporteFacturacionBL(idCliente);
                //GuiaTiendaBE obe = oReporteClienteTiendaBL.VerGuiaTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                //if (obe != null && (obe.listado != null && obe.listado.Count > 0) && (obe.listadoDetalle != null && obe.listadoDetalle.Count > 0))
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

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("ResumenDiario")]
        [HttpGet]
        public IHttpActionResult GetResumenDiario(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                //ReporteFacturacionBL oReporteClienteTiendaBL = new ReporteFacturacionBL(idCliente);
                //GuiaTiendaBE obe = oReporteClienteTiendaBL.VerGuiaTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                //if (obe != null && (obe.listado != null && obe.listado.Count > 0) && (obe.listadoDetalle != null && obe.listadoDetalle.Count > 0))
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

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Boleta")]
        [HttpGet]
        public IHttpActionResult GetBoleta(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                //ReporteFacturacionBL oReporteClienteTiendaBL = new ReporteFacturacionBL(idCliente);
                //GuiaTiendaBE obe = oReporteClienteTiendaBL.VerGuiaTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                //if (obe != null && (obe.listado != null && obe.listado.Count > 0) && (obe.listadoDetalle != null && obe.listadoDetalle.Count > 0))
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

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Factura")]
        [HttpGet]
        public IHttpActionResult GetFactura(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                //ReporteFacturacionBL oReporteClienteTiendaBL = new ReporteFacturacionBL(idCliente);
                //GuiaTiendaBE obe = oReporteClienteTiendaBL.VerGuiaTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                //if (obe != null && (obe.listado != null && obe.listado.Count > 0) && (obe.listadoDetalle != null && obe.listadoDetalle.Count > 0))
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

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("NotaCredito")]
        [HttpGet]
        public IHttpActionResult GetNotaCredito(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                //ReporteFacturacionBL oReporteClienteTiendaBL = new ReporteFacturacionBL(idCliente);
                //GuiaTiendaBE obe = oReporteClienteTiendaBL.VerGuiaTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                //if (obe != null && (obe.listado != null && obe.listado.Count > 0) && (obe.listadoDetalle != null && obe.listadoDetalle.Count > 0))
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

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("NotaDebito")]
        [HttpGet]
        public IHttpActionResult GetNotaDebito(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                //ReporteFacturacionBL oReporteClienteTiendaBL = new ReporteFacturacionBL(idCliente);
                //GuiaTiendaBE obe = oReporteClienteTiendaBL.VerGuiaTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                //if (obe != null && (obe.listado != null && obe.listado.Count > 0) && (obe.listadoDetalle != null && obe.listadoDetalle.Count > 0))
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

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("ComunicacionBaja")]
        [HttpGet]
        public IHttpActionResult GetComunicacionBaja(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            try
            {
                //ReporteFacturacionBL oReporteClienteTiendaBL = new ReporteFacturacionBL(idCliente);
                //GuiaTiendaBE obe = oReporteClienteTiendaBL.VerGuiaTienda(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin, idTienda, desTienda);

                //if (obe != null && (obe.listado != null && obe.listado.Count > 0) && (obe.listadoDetalle != null && obe.listadoDetalle.Count > 0))
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