

using Entidades.Almacen.AsignarAlmacen;
using Entidades.Utils;
using Logica.Almacen.AsignarAlmacen;
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
    [RoutePrefix("api/AsignarAlmacen")]
    public class AsignarAlmacenController : ApiController
    {

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente)
        {
            try
            {
                AsignarAlmacenBL oAsignarAlmacenBL = new AsignarAlmacenBL(idCliente);
                AsignarAlmacen_DatosInicialesBE lobe = oAsignarAlmacenBL.ListarDatosIniciales(usuario, idCliente);

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
        [Route("Tienda")]
        [HttpGet]
        public IHttpActionResult GetTienda(string usuario, int idCliente, int idAlmacen)
        {
            try
            {
                AsignarAlmacenBL oAsignarAlmacenBL = new AsignarAlmacenBL(idCliente);
                List<ListaComboBE> lobe = oAsignarAlmacenBL.ListarTienda(usuario, idCliente, idAlmacen);

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
        [Route("ProductosTienda")]
        [HttpGet]
        public IHttpActionResult GetProductosTienda(string usuario, int idCliente, int idAlmacen, int idTienda)
        {
            try
            {
                AsignarAlmacenBL oAsignarAlmacenBL = new AsignarAlmacenBL(idCliente);
                List<AsignarAlmacen_ProductoBE> lobe = oAsignarAlmacenBL.ListarProductosTienda(usuario, idCliente, idAlmacen, idTienda);

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
        [Route("ProductosAlmacen")]
        [HttpGet]
        public IHttpActionResult GetProductosAlmacen(string usuario, int idCliente, int idAlmacen)
        {
            try
            {
                AsignarAlmacenBL oAsignarAlmacenBL = new AsignarAlmacenBL(idCliente);
                List<AsignarAlmacen_ProductoBE> lobe = oAsignarAlmacenBL.ListarProductosAlmacen(usuario, idCliente, idAlmacen);

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
        public async Task<IHttpActionResult> Guardar(AsignarAlmacenBE obe)
        {
            try
            {
                bool rpta = false;
                AsignarAlmacenBL oAsignarAlmacenBL = new AsignarAlmacenBL(obe.IdCliente);
                rpta = oAsignarAlmacenBL.Guardar(obe);

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

        [Route("GuardarTienda")]
        [HttpPost]
        public async Task<IHttpActionResult> GuardarTienda(AsignarAlmacenBE obe)
        {
            try
            {
                bool rpta = false;
                AsignarAlmacenBL oAsignarAlmacenBL = new AsignarAlmacenBL(obe.IdCliente);
                rpta = oAsignarAlmacenBL.GuardarTienda(obe);

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
        /*
        [Route("Actualizar")]
        [HttpPost]
        public async Task<IHttpActionResult> Actualizar(AsignarAlmacenBE obe)
        {
            try
            {
                bool rpta = false;
                AsignarAlmacenBL oAsignarAlmacenBL = new AsignarAlmacenBL(obe.IdCliente);
                rpta = oAsignarAlmacenBL.Actualizar(obe);

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
        public async Task<IHttpActionResult> Eliminar(int Id, string UsrModificador)
        {
            try
            {
                AsignarAlmacenBE obe = new AsignarAlmacenBE();
                obe.Id = Id;
                obe.UsrModificador = UsrModificador;
                bool rpta = false;
                AsignarAlmacenBL oAsignarAlmacenBL = new AsignarAlmacenBL(obe.IdCliente);
                rpta = oAsignarAlmacenBL.Eliminar(obe);

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
        */
    }
}