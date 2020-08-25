using Entidades.Ajustes;
using Logica.Ajustes;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/AjusteComprobanteXCliente")]
    public class AjusteComprobanteXClienteController : ApiController
    {
        ComprobanteXClienteBL oComprobanteXClienteBL = new ComprobanteXClienteBL();

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario)//, int idCliente)
        {
            try
            {
                ComprobanteXCliente_DatosInicialesBE lobe = oComprobanteXClienteBL.ListarDatosIniciales(usuario);//, idCliente);

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

        [Route("Guardar")]
        [HttpPost]
        public async Task<IHttpActionResult> Guardar(ComprobanteXClienteBE obe)
        {
            try
            {
                bool rpta = false;
                rpta = oComprobanteXClienteBL.Guardar(obe);

                if (rpta)
                {
                    return Ok(Models.Util.GetBodyResponse(200, "OK"));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "Ocurrió un error al guardar."));
                }
            }
            catch (Exception ex)
            {
                //LogSA.GrabarLogError("SOL TR", model.user, "EditarTareas", ex);
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [Route("Actualizar")]
        [HttpPost]
        public async Task<IHttpActionResult> Actualizar(ComprobanteXClienteBE obe)
        {
            try
            {
                bool rpta = false;
                rpta = oComprobanteXClienteBL.Actualizar(obe);

                if (rpta)
                {
                    return Ok(Models.Util.GetBodyResponse(200, "OK"));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "Ocurrió un error al actualizar."));
                }
            }
            catch (Exception ex)
            {
                //LogSA.GrabarLogError("SOL TR", model.user, "EditarTareas", ex);
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [Route("Eliminar")]
        [HttpGet]
        public async Task<IHttpActionResult> Eliminar(int Id, int IdCliente, string UsrModificador)
        {
            try
            {
                ComprobanteXClienteBE obe = new ComprobanteXClienteBE();
                obe.Id = Id;
                obe.IdCliente = IdCliente;
                obe.UsrModificador = UsrModificador;
                bool rpta = false;
                rpta = oComprobanteXClienteBL.Eliminar(obe);

                if (rpta)
                {
                    return Ok(Models.Util.GetBodyResponse(200, "OK"));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "Ocurrió un error al actualizar."));
                }
            }
            catch (Exception ex)
            {
                //LogSA.GrabarLogError("SOL TR", model.user, "EditarTareas", ex);
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }
    }
}