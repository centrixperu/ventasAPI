

using Entidades.Maestro;
using Entidades.Utils;
using Logica.Maestro;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Maestro")]
    public class DatosMaestroController : ApiController
    {

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DNIRUC")]
        [HttpGet]
        public IHttpActionResult GetConsultaDNIRUC(string usuario, int idCliente, string nroDoc, string tipoDoc)
        {
            try
            {
                ConsultaDocumentoBL oConsultaDocumentoBL = new ConsultaDocumentoBL(idCliente);
                ConsultaDocumentoBE obe = oConsultaDocumentoBL.ConsultarDNIRUC(usuario, idCliente, nroDoc, tipoDoc);

                if (obe.nombre_o_razon_social!=null)
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
        [Route("ClienteVenta")]
        [HttpGet]
        public IHttpActionResult GetConsultaClienteVenta(string usuario, int idCliente, string desCliente)
        {
            try
            {
                ConsultaDocumentoBL oConsultaDocumentoBL = new ConsultaDocumentoBL(idCliente);
                List<ListaComboTextBE> lobe = oConsultaDocumentoBL.ConsultarClienteVenta(usuario, idCliente, desCliente);

                if (lobe.Count>0)
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

    }
}