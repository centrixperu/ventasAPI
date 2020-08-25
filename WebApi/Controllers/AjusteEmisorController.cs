using Entidades.Ajustes;
using Entidades.Utils;
using Logica.Ajustes;
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
    [RoutePrefix("api/AjusteEmisor")]
    public class AjusteEmisorController : ApiController
    {

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente)
        {
            try
            {
                EmisorBL oEmisorBL = new EmisorBL(idCliente);
                Emisor_DatosInicialesBE obe = oEmisorBL.ListarDatosIniciales(usuario, idCliente);

                if (obe != null && (obe.loListado != null || obe.loTienda != null || obe.loDepartamento != null ||
                                    obe.loProvincia != null || obe.loDistrito != null))
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

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Provincia")]
        [HttpGet]
        public IHttpActionResult GetProvincia(string usuario, string codigo)
        {
            try
            {
                EmisorBL oEmisorBL = new EmisorBL(0);
                List<ListaComboTextBE> obe = oEmisorBL.ListarProvincia(usuario, codigo);

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

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Distrito")]
        [HttpGet]
        public IHttpActionResult GetDistrito(string usuario, string idDepartamento, string codigo)
        {
            try
            {
                EmisorBL oEmisorBL = new EmisorBL(0);
                List<ListaComboTextBE> obe = oEmisorBL.ListarDistrito(usuario, idDepartamento, codigo);

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

        [Route("Guardar")]
        [HttpPost]
        public async Task<IHttpActionResult> Guardar(EmisorBE obe)
        {
            try
            {
                EmisorBL oEmisorBL = new EmisorBL(obe.IdCliente);
                bool rpta = false;
                rpta = oEmisorBL.Guardar(obe);

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
        public async Task<IHttpActionResult> Actualizar(EmisorBE obe)
        {
            try
            {
                EmisorBL oEmisorBL = new EmisorBL(obe.IdCliente);
                bool rpta = false;
                rpta = oEmisorBL.Actualizar(obe);

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
                EmisorBL oEmisorBL = new EmisorBL(IdCliente);
                EmisorBE obe = new EmisorBE();
                obe.Id = Id;
                obe.UsrModificador = UsrModificador;
                bool rpta = false;
                rpta = oEmisorBL.Eliminar(obe);

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