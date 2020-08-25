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
    [RoutePrefix("api/AjusteAlmacenXTienda")]
    public class AjusteAlmacenXTiendaController : ApiController
    {

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente)
        {
            try
            {
                AlmacenXTiendaBL oAlmacenBL = new AlmacenXTiendaBL(idCliente);
                AlmacenXTienda_DatosInicialesBE lobe = oAlmacenBL.ListarDatosIniciales(usuario, idCliente);

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
                AlmacenXTiendaBL oAlmacenBL = new AlmacenXTiendaBL(idCliente);
                AlmacenXTienda_DatosInicialesBE lobe = oAlmacenBL.ListarDatosCambioCliente(usuario, idCliente);

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
        public async Task<IHttpActionResult> Guardar(AlmacenXTiendaBE obe)
        {
            try
            {
                AlmacenXTiendaBL oAlmacenBL = new AlmacenXTiendaBL(obe.IdCliente);
                bool rpta = false;
                rpta = oAlmacenBL.Guardar(obe);

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
        public async Task<IHttpActionResult> Actualizar(AlmacenXTiendaBE obe)
        {
            try
            {
                AlmacenXTiendaBL oAlmacenBL = new AlmacenXTiendaBL(obe.IdCliente);
                bool rpta = false;
                rpta = oAlmacenBL.Actualizar(obe);

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
        public async Task<IHttpActionResult> Eliminar(int Id, int IdCliente,  string UsrModificador)
        {
            try
            {
                AlmacenXTiendaBL oAlmacenBL = new AlmacenXTiendaBL(IdCliente);
                AlmacenXTiendaBE obe = new AlmacenXTiendaBE();
                obe.Id = Id;
                obe.UsrModificador = UsrModificador;
                bool rpta = false;
                rpta = oAlmacenBL.Eliminar(obe);

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