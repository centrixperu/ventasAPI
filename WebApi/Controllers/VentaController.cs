

using Entidades.DTOModelos;
using Entidades.Utils;
using Entidades.Venta;
using Logica.Venta;
using Logica.FacturacionElectronica;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Entidades.DTOIntercambio;
using Entidades.Venta.RegistroVenta;
using Common;
using Logica.ArchivosAdjuntos;
using Entidades.Venta.ListadoVenta;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Venta")]
    public class VentaController : ApiController
    {
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("DatosIniciales")]
        [HttpGet]
        public IHttpActionResult GetDatosIniciales(string usuario, int idCliente)
        {
            try
            {
                VentaBL oVentaBL = new VentaBL(idCliente);
                Venta_DatosInicialesBE obe = oVentaBL.ListarDatosIniciales(usuario, idCliente);

                if (obe != null && (obe.loTienda != null && obe.loTienda.Count > 1) && (obe.loEmisor != null && obe.loEmisor.Count >= 1))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else if (obe.loTienda == null || (obe.loTienda != null && obe.loTienda.Count == 1))
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se registraron Tiendas."));
                }
                else if (obe.loEmisor == null || (obe.loEmisor != null && obe.loEmisor.Count == 0))
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontró datos de Emisor Electrónico y/o Certificado Digital."));
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
        [Route("Comprobantes")]
        [HttpGet]
        public IHttpActionResult GetComprobantes(string usuario, int idCliente, int idTienda)
        {
            try
            {
                VentaBL oVentaBL = new VentaBL(idCliente);
                Venta_DatosInicialesBE obe = oVentaBL.ListarComprobantes(usuario, idCliente, idTienda);

                if (obe != null && (obe.loComprobante != null && obe.loComprobante.Count > 1))
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else if (obe.loComprobante == null || (obe.loComprobante != null && obe.loComprobante.Count == 1))
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontró Tipo de Documento para la Tienda seleccionada."));
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

        [Route("Productos")]
        [HttpPost]
        public async Task<IHttpActionResult> Productos(VentaBE obj)
        {
            try
            {
                VentaBL oVentaBL = new VentaBL(obj.IdCliente);
                Venta_DatosInicialesBE obe = oVentaBL.ListarProductos(obj.UsrCreador, obj.IdCliente, obj.IdTienda);

                if (obe != null && (obe.loProducto != null && obe.loProducto.Count > 0) && (obe.loTipoProducto != null && obe.loTipoProducto.Count > 0)) 
                {
                    return Ok(Models.Util.GetBodyResponse(200, obe));
                }
                else if (obe.loProducto == null || (obe.loProducto != null && obe.loProducto.Count == 0))
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron Productos registrados en la Tienda seleccionada."));
                }
                else if (obe.loTipoProducto == null || (obe.loTipoProducto != null && obe.loTipoProducto.Count == 0))
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se encontraron Tipos de Productos registrados en la Tienda seleccionada."));
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
        [Route("ListarImagenProducto")]
        [HttpGet]
        public IHttpActionResult GetListarImagenProducto(string usuario, int idCliente, int idProducto)
        {
            try
            {
                VentaBL oVentaBL = new VentaBL(idCliente);
                List<ListaArchivosAdjuntos> obe = oVentaBL.ListarImagenProducto(usuario, idProducto);

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
        [Route("Anular")]
        [HttpGet]
        public IHttpActionResult GetAnular(string usuario, int idCliente, int idVenta)
        {
            EDEComunicacionBaja objEDEComunicacionBajaResponse;
            EDEDocumentoElectronico objEDEDocumentoElectronico;
            EDEEnviarDocumentoResponse objEDERespuesta;
            FacturacionElectronicaBL oFacturaElectronicaBL = new FacturacionElectronicaBL();
            try
            {
                VentaBL oVentaBL = new VentaBL(idCliente);
                RespuestaBE rpta = new RespuestaBE();
                VentaBE obe = new VentaBE();
                rpta = oVentaBL.Anular(usuario, idCliente, idVenta, out obe);

                if (rpta.codigo == 1 & rpta.isFactOnline)
                {
                    DateTime fecha = DateTime.Now;
                    List<VentaBE> lobe = new List<VentaBE>();
                    lobe.Add(obe);
                    //Generar Estructura Comunicación de Baja
                    objEDEComunicacionBajaResponse = new EDEComunicacionBaja();
                    objEDEDocumentoElectronico = new EDEDocumentoElectronico();
                    objEDEComunicacionBajaResponse = oFacturaElectronicaBL.GenerarEstructuraComunicacionBaja(lobe, fecha);
                    //Procesar Comunicación de Baja
                    HelperLog.PutLine("Inicio proceso Facturacion Electronica Comunicación de Baja");
                    objEDEDocumentoElectronico.RUC = obe.RUC;
                    objEDEDocumentoElectronico.UsuarioSOL = obe.UsuarioSOL;
                    objEDEDocumentoElectronico.ClaveSOL = obe.ClaveSOL;
                    objEDEDocumentoElectronico.URLCertificado = obe.URLCertificado;
                    objEDEDocumentoElectronico.ClaveDigital = obe.ClaveDigital;
                    objEDERespuesta = oFacturaElectronicaBL.ProcesarComunicacionBaja(objEDEComunicacionBajaResponse, objEDEDocumentoElectronico);
                    string msg = "";
                    if (objEDERespuesta.Exito)
                    {
                        msg = "Se envío a SUNAT Correctamente.";
                        if (objEDERespuesta.Procesado)
                        {

                            HelperLog.PutLine(string.Format("Se han actualizado el registro."));
                        }
                        else
                        {
                            HelperLog.PutLine(string.Format("No existen registros para actualizar."));
                        }
                    }
                    else
                    {
                        msg = "Ocurrío un error al enviar a SUNAT.";
                        HelperLog.PutLineError(string.Format(string.Format("Se ha generado el siguiente error: {0}", objEDERespuesta.MensajeError)));
                    }
                    //Actualizar respuesta
                    //ActualizarRespuesta(objEDERespuesta);
                    return Ok(Models.Util.GetBodyResponse(200, rpta.descripcion + " " + msg));
                }
                else if (rpta.codigo == 1) //FACTURA - BOLETA (SIN FACTURACION ELECTRONICA)
                {
                    return Ok(Models.Util.GetBodyResponse(200, rpta.descripcion));
                }
                else if (rpta.codigo == 2) //NOTA DE VENTA
                {
                    return Ok(Models.Util.GetBodyResponse(200, rpta.descripcion));
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
        [Route("AnularNC")]
        [HttpGet]
        public IHttpActionResult GetAnularNC(string usuario, int idCliente, int idVenta)
        {
            EDEDocumentoElectronico objEDEDocumentoElectronicoResponse;
            EDEEnviarDocumentoResponse objEDERespuesta;
            FacturacionElectronicaBL oFacturaElectronicaBL = new FacturacionElectronicaBL();
            try
            {
                VentaBL oVentaBL = new VentaBL(idCliente);
                RespuestaBE rpta = new RespuestaBE();
                VentaBE obe = new VentaBE();
                rpta = oVentaBL.AnularNC(usuario, idCliente, idVenta, out obe);

                if (rpta.codigo == 1 & rpta.isFactOnline)
                {
                    //Generar Estructura Nota de Crédito
                    objEDEDocumentoElectronicoResponse = new EDEDocumentoElectronico();
                    objEDEDocumentoElectronicoResponse = oFacturaElectronicaBL.GenerarEstructuraNotaCredito(obe);
                    //Procesar Nota de Crédito
                    HelperLog.PutLine("Inicio proceso Facturacion Electronica Nota de Crédito");
                    objEDERespuesta = oFacturaElectronicaBL.ProcesarNotaCredito(objEDEDocumentoElectronicoResponse);
                    string msg = "";
                    if (objEDERespuesta.Exito)
                    {
                        msg = "Se envío a SUNAT Correctamente.";
                        if (objEDERespuesta.Procesado)
                        {

                            HelperLog.PutLine(string.Format("Se han actualizado el registro."));
                        }
                        else
                        {
                            HelperLog.PutLine(string.Format("No existen registros para actualizar."));
                        }
                    }
                    else
                    {
                        msg = "Ocurrío un error al enviar a SUNAT.";
                        HelperLog.PutLineError(string.Format(string.Format("Se ha generado el siguiente error: {0}", objEDERespuesta.MensajeError)));
                    }
                    //Actualizar respuesta
                    ActualizarRespuesta(objEDERespuesta);
                    return Ok(Models.Util.GetBodyResponse(200, rpta.descripcion + " " + msg));
                }
                else if (rpta.codigo == 1)
                {
                    return Ok(Models.Util.GetBodyResponse(200, rpta.descripcion));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "Ocurrío un error inesperado."));
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
        public async Task<IHttpActionResult> Guardar(VentaBE obe)
        {
            try
            {
                VentaBL oVentaBL = new VentaBL(obe.IdCliente);
                RespuestaBE rpta = new RespuestaBE();
                if (obe.Acuenta)
                {
                    rpta = oVentaBL.GuardarACuenta(obe);
                    if (rpta.codigo == 1 || rpta.codigo == 2)
                    {
                        return Ok(Models.Util.GetBodyResponseF(210, rpta.descripcion, ""));
                    }
                    else {
                        return Ok(Models.Util.GetBodyResponseF(300, rpta.descripcion, ""));
                    }
                }
                else
                {
                    rpta = oVentaBL.Guardar(obe);

                    if (rpta.codigo == 2 & rpta.isFactOnline)
                    {
                        EDEDocumentoElectronico objEDEDocumentoElectronicoResponse;
                        EDEEnviarDocumentoResponse objEDERespuesta;
                        FacturacionElectronicaBL oFacturaElectronicaBL = new FacturacionElectronicaBL();
                        //Generar Estructura Facturacion electronica
                        objEDEDocumentoElectronicoResponse = new EDEDocumentoElectronico();
                        objEDEDocumentoElectronicoResponse = oFacturaElectronicaBL.GenerarEstructuraBoletaFactura(obe);
                        //Procesar Facturacion electronica
                        HelperLog.PutLine("Inicio proceso Facturacion Electronica Boletas y Facturas");
                        objEDERespuesta = oFacturaElectronicaBL.ProcesarBoletaFactura(objEDEDocumentoElectronicoResponse);
                        string msg = "";
                        string byteArchivo = "";
                        if (objEDERespuesta.Exito)
                        {
                            ImprimirComprobanteBL oImprimirComprobanteBL = new ImprimirComprobanteBL();
                            byteArchivo = oImprimirComprobanteBL.ImprimirVenta(obe);
                            msg = "Se envío a SUNAT Correctamente.";
                            if (objEDERespuesta.Procesado)
                            {

                                HelperLog.PutLine(string.Format("Se han actualizado el registro."));
                            }
                            else
                            {
                                HelperLog.PutLine(string.Format("No existen registros para actualizar."));
                            }
                        }
                        else
                        {
                            msg = "Ocurrío un error al enviar a SUNAT.";
                            HelperLog.PutLineError(string.Format(string.Format("Se ha generado el siguiente error: {0}", objEDERespuesta.MensajeError)));
                        }
                        //Actualizar Respuesta
                        ActualizarRespuesta(objEDERespuesta);
                        return Ok(Models.Util.GetBodyResponseF(200, rpta.descripcion + " " + msg, byteArchivo));
                    }
                    else if (rpta.codigo == 1)
                    {
                        string byteArchivo = "";
                        ImprimirComprobanteBL oImprimirComprobanteBL = new ImprimirComprobanteBL();
                        byteArchivo = oImprimirComprobanteBL.ImprimirVenta(obe);
                        return Ok(Models.Util.GetBodyResponseF(200, rpta.descripcion, byteArchivo));
                    }
                    else if (rpta.codigo == 2)
                    {
                        string byteArchivo = "";
                        ImprimirComprobanteBL oImprimirComprobanteBL = new ImprimirComprobanteBL();
                        byteArchivo = oImprimirComprobanteBL.ImprimirVenta(obe);
                        return Ok(Models.Util.GetBodyResponseF(200, rpta.descripcion, byteArchivo));
                    }
                    else
                    {
                        return Ok(Models.Util.GetBodyResponse(300, rpta.descripcion));
                    }
                }                
            }
            catch (Exception ex)
            {
                //LogSA.GrabarLogError("SOL TR", model.user, "EditarTareas", ex);
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }

        private void ActualizarRespuesta(EDEEnviarDocumentoResponse objEDERespuesta)
        {
            //objEDetalleVentaRespuesta = new EDetalleVenta();
            //lstEDetalleVentaRespuesta = new List<EDetalleVenta>();
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegistroVentas")]
        [HttpGet]
        public IHttpActionResult GetRegistroVentas(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            try
            {
                VentaBL oVentaBL = new VentaBL(idCliente);
                RegistroVentaBE obe = oVentaBL.RegistroVentas(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin);

                if (obe != null && (obe.listado != null && obe.listado.Count > 0))
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
        [Route("VerDetalleVenta")]
        [HttpGet]
        public IHttpActionResult GetVerDetalleVenta(string usuario, int idCliente, int idVenta)
        {
            try
            {
                VentaBL oVentaBL = new VentaBL(idCliente);
                RegistroVentaBE obe = oVentaBL.VerDetalleVenta(usuario, idCliente, idVenta);

                if (obe != null && (obe.listadoDetalle != null && obe.listadoDetalle.Count > 0))
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
        [Route("ListadoVentas")]
        [HttpGet]
        public IHttpActionResult GetListadoVentas(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            try
            {
                VentaBL oVentaBL = new VentaBL(idCliente);
                ListadoVentaBE obe = oVentaBL.ListadoVentas(usuario, idCliente, isDia, isMes, isAnio, isRango, fechaInicio, fechaFin);

                if (obe != null && (obe.listado != null && obe.listado.Count > 0))
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
        [Route("ListadoVentasACuenta")]
        [HttpGet]
        public IHttpActionResult GetListadoVentasACuenta(string usuario, int idCliente, string desCliente)
        {
            try
            {
                if (desCliente == null) { desCliente = ""; }
                VentaBL oVentaBL = new VentaBL(idCliente);
                ListadoVentaBE obe = oVentaBL.ListadoVentasACuenta(usuario, idCliente, desCliente);

                if (obe != null && (obe.listado != null && obe.listado.Count > 0))
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

        [Route("VentaACuenta")]
        [HttpPost]
        public async Task<IHttpActionResult> VentaACuenta(VentaBE obe)
        {
            try
            {
                VentaBL oVentaBL = new VentaBL(obe.IdCliente);
                RespuestaBE rpta = new RespuestaBE();
                rpta = oVentaBL.VentaACuenta(obe);

                if (rpta.codigo == 2 & rpta.isFactOnline)
                {
                    EDEDocumentoElectronico objEDEDocumentoElectronicoResponse;
                    EDEEnviarDocumentoResponse objEDERespuesta;
                    FacturacionElectronicaBL oFacturaElectronicaBL = new FacturacionElectronicaBL();
                    //Generar Estructura Facturacion electronica
                    objEDEDocumentoElectronicoResponse = new EDEDocumentoElectronico();
                    objEDEDocumentoElectronicoResponse = oFacturaElectronicaBL.GenerarEstructuraBoletaFactura(obe);
                    //Procesar Facturacion electronica
                    HelperLog.PutLine("Inicio proceso Facturacion Electronica Boletas y Facturas");
                    objEDERespuesta = oFacturaElectronicaBL.ProcesarBoletaFactura(objEDEDocumentoElectronicoResponse);
                    string msg = "";
                    string byteArchivo = "";
                    if (objEDERespuesta.Exito)
                    {
                        ImprimirComprobanteBL oImprimirComprobanteBL = new ImprimirComprobanteBL();
                        byteArchivo = oImprimirComprobanteBL.ImprimirVenta(obe);
                        msg = "Se envío a SUNAT Correctamente.";
                        if (objEDERespuesta.Procesado)
                        {

                            HelperLog.PutLine(string.Format("Se han actualizado el registro."));
                        }
                        else
                        {
                            HelperLog.PutLine(string.Format("No existen registros para actualizar."));
                        }
                    }
                    else
                    {
                        msg = "Ocurrío un error al enviar a SUNAT.";
                        HelperLog.PutLineError(string.Format(string.Format("Se ha generado el siguiente error: {0}", objEDERespuesta.MensajeError)));
                    }
                    //Actualizar Respuesta
                    ActualizarRespuesta(objEDERespuesta);
                    return Ok(Models.Util.GetBodyResponseF(200, rpta.descripcion + " " + msg, byteArchivo));
                }
                else if (rpta.codigo == 1)
                {
                    string byteArchivo = "";
                    //ImprimirComprobanteBL oImprimirComprobanteBL = new ImprimirComprobanteBL();
                    //byteArchivo = oImprimirComprobanteBL.ImprimirVenta(obe);
                    return Ok(Models.Util.GetBodyResponseF(200, rpta.descripcion, byteArchivo));
                }
                else if (rpta.codigo == 2)
                {
                    string byteArchivo = "";
                    //ImprimirComprobanteBL oImprimirComprobanteBL = new ImprimirComprobanteBL();
                    //byteArchivo = oImprimirComprobanteBL.ImprimirVenta(obe);
                    return Ok(Models.Util.GetBodyResponseF(200, rpta.descripcion, byteArchivo));
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