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
    [RoutePrefix("api/AjusteUsuario")]
    public class AjusteUsuarioController : ApiController
    {

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente)
        {
            try
            {
                UsuarioBL oUsuarioBL = new UsuarioBL(idCliente);
                Usuario_DatosInicialesBE lobe = oUsuarioBL.ListarDatosIniciales(usuario, idCliente);

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
        [Route("DatosCambioCliente")]
        [HttpGet]
        public IHttpActionResult GetDatosCambioCliente(string usuario, int idCliente)
        {
            try
            {
                UsuarioBL oUsuarioBL = new UsuarioBL(idCliente);
                Usuario_DatosInicialesBE lobe = oUsuarioBL.ListarDatosCambioCliente(usuario, idCliente);

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
        public async Task<IHttpActionResult> Guardar(UsuarioBE obe)
        {
            try
            {
                UsuarioBL oUsuarioBL = new UsuarioBL(obe.IdCliente);
                bool rpta = false;
                bool rptaL = false;
                rpta = oUsuarioBL.Guardar(obe, out rptaL);

                if (rpta)
                {
                    if (rptaL)
                    {
                        return Ok(Models.Util.GetBodyResponse(200, "OK"));
                    }else
                    {
                        return Ok(Models.Util.GetBodyResponse(210, "Se grabó Datos de Usuario. Ocurrió un error al guardar Logo."));
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
        public async Task<IHttpActionResult> Actualizar(UsuarioBE obe)
        {
            try
            {
                UsuarioBL oUsuarioBL = new UsuarioBL(obe.IdCliente);
                bool rpta = false;
                bool rptaL = false;
                rpta = oUsuarioBL.Actualizar(obe, out rptaL);

                if (rpta)
                {
                    if (rptaL)
                    {
                        return Ok(Models.Util.GetBodyResponse(200, "OK"));
                    }
                    else
                    {
                        return Ok(Models.Util.GetBodyResponse(210, "Se actualizó Datos de Usuario. Ocurrió un error al guardar Logo."));
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
        public async Task<IHttpActionResult> Eliminar(int Id, int IdCliente, string UsrModificador)
        {
            try
            {
                UsuarioBL oUsuarioBL = new UsuarioBL(IdCliente);
                UsuarioBE obe = new UsuarioBE();
                obe.Id = Id;
                obe.UsrModificador = UsrModificador;
                bool rpta = false;
                rpta = oUsuarioBL.Eliminar(obe);

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