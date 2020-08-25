
using Entidades.AdministrarProducto;
using Entidades.Almacen.AsignarAlmacen;
using Entidades.Utils;
using Logica.AdministrarProducto;
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
    [RoutePrefix("api/AdministrarProducto")]
    public class AdministrarProductoController : ApiController
    {

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente)
        {
            try
            {
                AdministrarProductoBL oAdministrarProductoBL = new AdministrarProductoBL(idCliente);
                AdministrarProducto_DatosInicialesBE obe = oAdministrarProductoBL.ListarDatosIniciales(usuario, idCliente);

                if (obe != null && (obe.loUnidadMedida != null || obe.loSegmentos != null || obe.loFamilia != null ||
                                    obe.loClase != null || obe.loProducto != null || obe.loTalla != null ||
                                    obe.loColor != null || obe.loTipoProducto != null || obe.loLista != null))
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
        [Route("ListarProductos")]
        [HttpGet]
        public IHttpActionResult GetListarProductos(string usuario, int idCliente, string busqueda)
        {
            try
            {
                AdministrarProductoBL oAdministrarProductoBL = new AdministrarProductoBL(idCliente);
                List<AsignarAlmacen_ProductoBE> obe = oAdministrarProductoBL.ListarProductos(usuario, idCliente, busqueda);

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
        [Route("Familia")]
        [HttpGet]
        public IHttpActionResult GetFamilia(string usuario, string codigo)
        {
            try
            {
                AdministrarProductoBL oAdministrarProductoBL = new AdministrarProductoBL(0);
                List<ListaComboTextBE> obe = oAdministrarProductoBL.ListarFamilia(usuario, codigo);

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
        [Route("Clase")]
        [HttpGet]
        public IHttpActionResult GetClase(string usuario, string idsegmento, string codigo)
        {
            try
            {
                AdministrarProductoBL oAdministrarProductoBL = new AdministrarProductoBL(0);
                List<ListaComboTextBE> obe = oAdministrarProductoBL.ListarClase(usuario, idsegmento, codigo);

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
        [Route("Producto")]
        [HttpGet]
        public IHttpActionResult GetProducto(string usuario, string idsegmento, string idfamilia, string codigo)
        {
            try
            {
                AdministrarProductoBL oAdministrarProductoBL = new AdministrarProductoBL(0);
                List<ListaComboTextBE> obe = oAdministrarProductoBL.ListarProducto(usuario, idsegmento, idfamilia, codigo);

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
        public async Task<IHttpActionResult> Guardar(AdministrarProductoBE obe)
        {
            try
            {
                bool rpta = false;
                bool rpta2 = false;
                string msjError = "";
                AdministrarProductoBL oAdministrarProductoBL = new AdministrarProductoBL(obe.IdCliente);
                rpta = oAdministrarProductoBL.Guardar(obe, out rpta2, out msjError);

                if (rpta)
                {
                    if (rpta2)
                    {
                        return Ok(Models.Util.GetBodyResponse(200, "OK"));
                    }
                    else
                    {
                        return Ok(Models.Util.GetBodyResponse(210, "Se grabó Datos de Producto. Ocurrió un error al guardar Imagen."));
                    }
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, msjError));
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
        public async Task<IHttpActionResult> Actualizar(AdministrarProductoBE obe)
        {
            try
            {
                bool rpta = false;
                bool rpta2 = false;
                string msjError = "";
                AdministrarProductoBL oAdministrarProductoBL = new AdministrarProductoBL(obe.IdCliente);
                rpta = oAdministrarProductoBL.Actualizar(obe, out rpta2, out msjError);

                if (rpta)
                {
                    if (rpta2)
                    {
                        return Ok(Models.Util.GetBodyResponse(200, "OK"));
                    }
                    else
                    {
                        return Ok(Models.Util.GetBodyResponse(210, "Se actualizó Datos de Producto. Ocurrió un error al guardar Imagen."));
                    }
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, msjError));
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
        public async Task<IHttpActionResult> Eliminar(int Id, string UsrModificador, int IdCliente)
        {
            try
            {
                AdministrarProductoBL oAdministrarProductoBL = new AdministrarProductoBL(IdCliente);
                AdministrarProductoBE obe = new AdministrarProductoBE();
                obe.Id = Id;
                obe.UsrModificador = UsrModificador;
                bool rpta = false;
                rpta = oAdministrarProductoBL.Eliminar(obe);

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

        [Route("EliminarAdjunto")]
        [HttpGet]
        public async Task<IHttpActionResult> EliminarAdjunto(int Id, string URL, int IdProducto, string Usuario, int IdCliente)
        {
            try
            {
                bool rpta = false;
                AdministrarProductoBL oAdministrarProductoBL = new AdministrarProductoBL(IdCliente);
                rpta = oAdministrarProductoBL.EliminarAdjunto(Id, URL, IdProducto, Usuario);

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