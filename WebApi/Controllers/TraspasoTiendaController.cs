

using Entidades.Traspaso;
using Entidades.Utils;
using Logica.Traspaso;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Traspaso")]
    public class TraspasoTiendaController : ApiController
    {

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente)
        {
            try
            {
                TraspasoBL oTraspasoBL = new TraspasoBL(idCliente);
                Traspaso_DatosInicialesBE lobe = oTraspasoBL.ListarDatosIniciales(usuario, idCliente);

                if (lobe != null && lobe.loTienda.Count>1)
                {
                    return Ok(Models.Util.GetBodyResponse(200, lobe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron Tiendas registradas."));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("ProductosTienda")]
        [HttpGet]
        public IHttpActionResult GetProductosTienda(string usuario, int idCliente, int idTienda)
        { 
            try
            {
                TraspasoBL oTraspasoBL = new TraspasoBL(idCliente);
                Traspaso_DatosInicialesBE lobe = oTraspasoBL.ListarProductosTienda(usuario, idCliente, idTienda);

                if (lobe != null && lobe.loProducto.Count > 0)
                {
                    return Ok(Models.Util.GetBodyResponse(200, lobe));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron Productos en Tienda seleccionada."));
                }
            }
            catch (Exception ex)
            {
                /*LogSA.GrabarLogError("SOL TR", user, "GetListarOrdOtrs", ex);*/
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        [Route("Traspasar")]
        [HttpPost]
        public async Task<IHttpActionResult> Traspasar(Traspaso_DatosInicialesBE obe)
        {
            try
            {
                TraspasoBL oTraspasoBL = new TraspasoBL(obe.IdCliente);
                RespuestaBE rpta = new RespuestaBE();
                rpta = oTraspasoBL.Traspasar(obe);

                if (rpta.codigo==1)
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
                //LogSA.GrabarLogError("SOL TR", model.user, "EditarTareas", ex);
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

    }
}