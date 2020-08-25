

using Entidades.Login;
using Logica.Login;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        LoginBL oLoginBL = new LoginBL();

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Sesion")]
        [HttpPost]
        public IHttpActionResult GetSesion(LoginBE be)
        {
            try
            {
                LoginBE obe = oLoginBL.IniciarSesion(be);

                if (obe != null && (obe.loMenu != null))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "Usuario y contraseña no concuerdan."));
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