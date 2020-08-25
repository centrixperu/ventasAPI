

using Entidades.ReporteCliente;
using Entidades.ReporteCliente.KardexPrecio;
using Entidades.ReporteCliente.KardexProducto;
using Entidades.ReporteCliente.VentaPrecio;
using Entidades.ReporteCliente.VentaProducto;
using Logica.ReporteCliente;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ReporteCliente")]
    public class ReporteClienteController : ApiController
    {
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("VerGuia")]
        [HttpGet]
        public IHttpActionResult GetVerGuia(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango, 
                                                    string fechaInicio, string fechaFin)
        {
            try
            {
                ReporteClienteBL oReporteClienteBL = new ReporteClienteBL(idCliente);
                GuiaBE obe = oReporteClienteBL.VerGuia(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin);

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
        [Route("VentaProducto")]
        [HttpGet]
        public IHttpActionResult GetVentaProducto(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            try
            {
                ReporteClienteBL oReporteClienteBL = new ReporteClienteBL(idCliente);
                VentaProductoBE obe = oReporteClienteBL.VentaProducto(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin);

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
        [Route("VentaPrecio")]
        [HttpGet]
        public IHttpActionResult GetVentaPrecio(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            try
            {
                ReporteClienteBL oReporteClienteBL = new ReporteClienteBL(idCliente);
                VentaPrecioBE obe = oReporteClienteBL.VentaPrecio(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin);

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
        [Route("KardexProducto")]
        [HttpGet]
        public IHttpActionResult GetKardexProducto(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            try
            {
                ReporteClienteBL oReporteClienteBL = new ReporteClienteBL(idCliente);
                KardexProductoBE obe = oReporteClienteBL.KardexProducto(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin);

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
        [Route("KardexPrecio")]
        [HttpGet]
        public IHttpActionResult GetKardexPrecio(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            try
            {
                ReporteClienteBL oReporteClienteBL = new ReporteClienteBL(idCliente);
                KardexPrecioBE obe = oReporteClienteBL.KardexPrecio(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin);

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

    }
}