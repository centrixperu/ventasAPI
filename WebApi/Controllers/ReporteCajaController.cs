

using Entidades.Almacen.AsignarAlmacen;
using Entidades.ReporteCaja;
using Entidades.Utils;
using Logica.ReporteCaja;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Caja")]
    public class ReporteCajaController : ApiController
    {

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("ReporteCaja")]
        [HttpGet]
        public IHttpActionResult GetReporteCaja(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            try
            {
                ReporteCajaBL oReporteClienteBL = new ReporteCajaBL(idCliente);
                CajaBE obe = oReporteClienteBL.ReporteCaja(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin);

                if (obe != null && (obe.listado != null && obe.listado.Count > 0))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponseF(300, "No se encontraron registros.",obe.CajaAnterior.ToString()));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpPost]
        public IHttpActionResult GetDatosIniciales(CajaBE obeCaja)
        {
            try
            {
                ReporteCajaBL oReporteCajaBL = new ReporteCajaBL(obeCaja.IdCliente);
                CajaBE lobe = oReporteCajaBL.ListarDatosIniciales(obeCaja.Usuario, obeCaja.IdCliente, obeCaja.loTienda);

                if (lobe != null)
                {
                    return Ok(Models.Util.GetBodyResponse(200, lobe));
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
        [Route("GuardarCaja")]
        [HttpPost]
        public async Task<IHttpActionResult> GuardarCaja(CajaBE obeCaja)
        {
            try
            {
                ReporteCajaBL oReporteCajaBL = new ReporteCajaBL(obeCaja.IdCliente);
                RespuestaBE rpta = new RespuestaBE();
                rpta = oReporteCajaBL.Guardar(obeCaja);

                if (rpta.codigo>0)
                {
                    return Ok(Models.Util.GetBodyResponse(200, rpta.descripcion));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, rpta.descripcion));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("ProductosCaja")]
        [HttpGet]
        public IHttpActionResult GetProductosCaja(string usuario, int idCliente, int idTienda, string busqueda)
        {
            try
            {
                ReporteCajaBL oReporteClienteBL = new ReporteCajaBL(idCliente);
                List<AsignarAlmacen_ProductoBE> obe = oReporteClienteBL.ProductosCaja(usuario, idCliente, idTienda, busqueda);

                if (obe != null && obe.Count > 0)
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