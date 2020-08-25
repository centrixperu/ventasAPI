

using Entidades.Ajustes.Producto_GrupoMedico;
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
    [RoutePrefix("api/ProdGrupoMedico")]
    public class ProductoGrupoMedicoController : ApiController
    {
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente)
        {
            try
            {
                ProductoGrupoMedicoBL oProductoGrupoMedicoBL = new ProductoGrupoMedicoBL(idCliente);
                ProductoGrupoMedico_DatosInicialesBE lobe = oProductoGrupoMedicoBL.ListarDatosIniciales(usuario, idCliente);

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
        public async Task<IHttpActionResult> Guardar(ProductoGrupoMedicoBE obe)
        {
            try
            {
                ProductoGrupoMedicoBL oProductoGrupoMedicoBL = new ProductoGrupoMedicoBL(obe.IdCliente);
                bool rpta = false;
                rpta = oProductoGrupoMedicoBL.Guardar(obe);

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
        public async Task<IHttpActionResult> Actualizar(ProductoGrupoMedicoBE obe)
        {
            try
            {
                ProductoGrupoMedicoBL oProductoGrupoMedicoBL = new ProductoGrupoMedicoBL(obe.IdCliente);
                bool rpta = false;
                rpta = oProductoGrupoMedicoBL.Actualizar(obe);

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
                ProductoGrupoMedicoBL oProductoGrupoMedicoBL = new ProductoGrupoMedicoBL(IdCliente);
                ProductoGrupoMedicoBE obe = new ProductoGrupoMedicoBE();
                obe.Id = Id;
                obe.UsrModificador = UsrModificador;
                bool rpta = false;
                rpta = oProductoGrupoMedicoBL.Eliminar(obe);

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