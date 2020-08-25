
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
    [RoutePrefix("api/AjusteCliente")]
    public class AjusteClienteController : ApiController
    {
        ClienteBL oClienteBL = new ClienteBL();

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente)
        {
            try
            {
                Cliente_DatosInicialesBE lobe = oClienteBL.ListarDatosIniciales(usuario, idCliente);

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
        public async Task<IHttpActionResult> Guardar(ClienteBE obe)
        {
            try
            {
                bool rpta = false;
                bool rpta2 = false;
                bool rpta3 = false;
                rpta = oClienteBL.Guardar(obe, out rpta2, out rpta3);

                if (rpta)
                {
                    if (rpta2)
                    {
                        if (rpta3)
                        {
                            return Ok(Models.Util.GetBodyResponse(200, "OK"));
                        }
                        else
                        {
                            return Ok(Models.Util.GetBodyResponse(210, "Se grabó Datos de Cliente. Ocurrió un error al guardar Logo."));
                        }
                    }
                    else
                    {
                        return Ok(Models.Util.GetBodyResponse(210, "Se grabó Datos de Cliente. Ocurrió un error al guardar Certificado."));
                    }
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
        public async Task<IHttpActionResult> Actualizar(ClienteBE obe)
        {
            try
            {
                bool rpta = false;
                bool rpta2 = false;
                bool rpta3 = false;
                rpta = oClienteBL.Actualizar(obe, out rpta2, out rpta3);

                if (rpta)
                {
                    if (rpta2)
                    {
                        if (rpta3)
                        {
                            return Ok(Models.Util.GetBodyResponse(200, "OK"));
                        }
                        else
                        {
                            return Ok(Models.Util.GetBodyResponse(210, "Se grabó Datos de Cliente. Ocurrió un error al guardar Logo."));
                        }
                    }
                    else
                    {
                        return Ok(Models.Util.GetBodyResponse(210, "Se grabó Datos de Cliente. Ocurrió un error al guardar Certificado."));
                    }
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
        public async Task<IHttpActionResult> Eliminar(int Id, string UsrModificador)
        {
            try
            {
                ClienteBE obe = new ClienteBE();
                obe.Id = Id;
                obe.UsrModificador = UsrModificador;
                bool rpta = false;
                rpta = oClienteBL.Eliminar(obe);

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

        [Route("EliminarLogo")]
        [HttpGet]
        public async Task<IHttpActionResult> EliminarLogo(string URL, int Id, string UsrModificador)
        {
            try
            {
                ClienteBE obe = new ClienteBE();
                obe.Id = Id;
                obe.URLLogo = URL;
                obe.UsrModificador = UsrModificador;
                bool rpta = false;
                rpta = oClienteBL.EliminarLogo(obe);

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