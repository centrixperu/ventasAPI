using Entidades.ControlStock;
using Logica.ControlStock;
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
    [RoutePrefix("api/ControlStock")]
    public class ControlStockController : ApiController
    {
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Productos")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente, int idAlmacen, int idTienda)
        {
            try
            {
                ControlStockBL oControlStockBL = new ControlStockBL(idCliente);
                ControlStockGBE obe = oControlStockBL.ListarProductos(usuario, idCliente, idAlmacen, idTienda);

                if (obe != null && obe.listado.Count > 0)
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

        [Route("Actualizar")]
        [HttpPost]
        public async Task<IHttpActionResult> Guardar(ControlStockGBE obe)
        {
            try
            {
                bool rpta = false;
                ControlStockBL oControlStockBL = new ControlStockBL(obe.idCliente);
                rpta = oControlStockBL.Guardar(obe);

                if (rpta)
                {
                    return Ok(Models.Util.GetBodyResponse(200, "OK"));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "Ocurrió un error al guardar información"));
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
