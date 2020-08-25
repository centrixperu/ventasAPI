using Common;
using Entidades.DTOIntercambio;
using Entidades.DTOModelos;
//using Entidades.EntityFAE;
using Entidades.Venta;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logica.FacturacionElectronica
{
    public class FacturacionElectronicaBL : ResponseFacturacionElectronica
    {
        EDEDocumentoElectronico objEDEDocumentoElectronico;
        EDEContribuyente objEDEContribuyente;
        EDECompania objEDECompania;
        EDEDetalleDocumento objEDEDetalledocumento;
        EDEDatoAdicional objEDEDatoAdicional;
        EDEDiscrepancia objEDEDiscrepancia;
        EDEDocumentoRelacionado objEDEDocumentoRelacionado;
        EDELeyenda objEDELeyenda;
        EDEEnviarDocumentoResponse objEDERespuesta;
        EDEResumenDiarioNuevo objEDEResumenDiarioNuevo;
        EDEGrupoResumenNuevo objEDEGrupoResumenNuevo;
        EDEEnviarDocumentoResponse objEDEEnviarDocumentoResponse;
        List<EDEDatoAdicional> lstEDEDatoAdicional;
        List<EDEDiscrepancia> lstEDEDiscrepancia;
        List<EDEDocumentoRelacionado> lstEDEDocumentoRelacionado;
        List<EDEDetalleDocumento> listEDEDetalledocumento;
        List<EDEGrupoResumenNuevo> lstEDEGrupoResumenNuevo;
        List<EDELeyenda> lstEDELeyenda;
        List<VentaDetalleBE> lstFAEDet = new List<VentaDetalleBE>();
        #region Estructuras
        public EDEDocumentoElectronico GenerarEstructuraBoletaFactura(VentaBE objEFAECab)
        {
            objEDEDocumentoElectronico = new EDEDocumentoElectronico();
            objEDEDocumentoElectronico.CodigoBienOServicio = string.Empty;//HARDCODE
            objEDEDocumentoElectronico.CodigoMedioPago = string.Empty;//HARDCODE
            objEDEDocumentoElectronico.CuentaBancoNacion = string.Empty;//HARDCODE
            objEDEDatoAdicional = new EDEDatoAdicional();
            lstEDEDatoAdicional = new List<EDEDatoAdicional>();
            objEDEDocumentoElectronico.DatoAdicionales = lstEDEDatoAdicional;
            objEDEDocumentoElectronico.DescuentoGlobal = 0;//HARDCODE
            objEDEDiscrepancia = new EDEDiscrepancia();
            lstEDEDiscrepancia = new List<EDEDiscrepancia>();
            objEDEDocumentoElectronico.Discrepancias = lstEDEDiscrepancia;
            objEDEDocumentoElectronico.DocAnticipo = string.Empty;//HARDCODE
            //Inicio rellenar datos de emisor
            objEDECompania = new EDECompania
            {
                CodigoAnexo = objEFAECab.c_codigo_anexo,//HARDCODE
                NombreComercial = objEFAECab.c_emisor_nombre_comercial,
                NombreLegal = objEFAECab.c_emisor_nombre_legal,
                NroDocumento = objEFAECab.c_emisor_numero_documento,
                TipoDocumento = objEFAECab.c_emisor_tipo_documento,//0 doc trib. no. dom. sin ruc
                                                                   //1 doc nacional de identidad
                                                                   //4 carnet de extranjeria
                                                                   //6 registro unico de contribuyente
                                                                   //7 pasaporte
                                                                   //A ced. diplomatica de identidad
            };
            objEDEDocumentoElectronico.Emisor = objEDECompania;
            //Fin rellenar datos de emisor
            objEDEDocumentoElectronico.Exoneradas = 0;//HARDCODE
            objEDEDocumentoElectronico.FechaEmision = objEFAECab.c_fecha_emision;
            objEDEDocumentoElectronico.FechaVencimiento = string.Empty;//HARDCODE
            objEDEDocumentoElectronico.Gratuitas = objEFAECab.n_gratuitas;
            objEDEDocumentoElectronico.Gravadas = objEFAECab.n_gravadas;
            objEDEDocumentoElectronico.HoraEmision = DateTime.Now.ToString("HH:mm:ss");//HARDCODE
            objEDEDocumentoElectronico.IdDocumento = objEFAECab.c_id_documento;
            objEDEDocumentoElectronico.Inafectas = objEFAECab.n_inafectas;
            //Inicio Cargar detalle de venta
            listEDEDetalledocumento = new List<EDEDetalleDocumento>();
            lstFAEDet = objEFAECab.loDetalle;
            foreach (VentaDetalleBE objFAEDet in lstFAEDet)
            {
                objEDEDetalledocumento = new EDEDetalleDocumento();
                objEDEDetalledocumento.Cantidad = objFAEDet.n_cantidad;
                objEDEDetalledocumento.CodigoItem = objFAEDet.c_id_documento;
                objEDEDetalledocumento.CodigoProductoSunat = string.Empty;//HARDCODE
                objEDEDatoAdicional = new EDEDatoAdicional();
                lstEDEDatoAdicional = new List<EDEDatoAdicional>();
                objEDEDetalledocumento.DatosAdcionales = lstEDEDatoAdicional;
                objEDEDetalledocumento.Descripcion = objFAEDet.c_decripcion;
                objEDEDetalledocumento.Descuento = objFAEDet.n_descuento;
                objEDEDetalledocumento.Id = objFAEDet.n_id_detalle;
                objEDEDetalledocumento.Impuesto = objFAEDet.n_impuesto;
                objEDEDetalledocumento.ImpuestoSelectivo = objFAEDet.n_impuesto_selectivo;
                objEDEDetalledocumento.OtroImpuesto = objFAEDet.n_otro_impuesto;
                objEDEDetalledocumento.PlacaVehiculo = string.Empty;//HARCODE
                objEDEDetalledocumento.PrecioReferencial = objFAEDet.n_precio_referencial;
                objEDEDetalledocumento.PrecioUnitario = objFAEDet.n_precio_unitario;
                objEDEDetalledocumento.TasaImpuestoSelectivo = 0;//HARDCODE
                objEDEDetalledocumento.TipoImpuesto = objFAEDet.n_tipo_impuesto;//10 Gravado Operacion Onerosa
                                                                                //11 Gravado Retiro por Premio
                                                                                //12 Gravado Retiro por Donacion
                                                                                //13 Gravado Retiro
                                                                                //14 Gravado Retiro por publicidad
                                                                                //15 Gravado Bonificaciones
                                                                                //16 Gravado Retiro por entrega a trabaja
                                                                                //17 Gravado IVAP
                                                                                //20 Exonerado Operacion Onerosa
                                                                                //21 Exonerado Transferencia Gratuita
                                                                                //30 Inafecto Operacion Onerosa
                                                                                //31 Inafecto Retiro por Bonificacion
                                                                                //32 Inafecto Retiro
                                                                                //33 Inafecto Retiro por Muestras Medicas
                                                                                //34 Inafecto Retiro por Convenito Colectivo
                                                                                //35 Inafecto Retiro por Premio
                                                                                //36 Inafecto Retiro por Publicidad
                                                                                //40 Esportacion
                objEDEDetalledocumento.TipoPrecio = objFAEDet.c_tipo_precio;//01 Precio unitario (incluye el IGV)
                                                                            //02 Valor referencial unitario en operaciones no onerosas
                objEDEDetalledocumento.TotalVenta = objFAEDet.n_total_venta;
                objEDEDetalledocumento.UnidadMedida = objFAEDet.n_unidad_medida;//NIU
                                                                                //KG
                                                                                //ONZ
                                                                                //LTR
                listEDEDetalledocumento.Add(objEDEDetalledocumento);
            }
            objEDEDocumentoElectronico.Items = listEDEDetalledocumento;
            //Fin Cargar detalle de venta
            objEDELeyenda = new EDELeyenda();
            lstEDELeyenda = new List<EDELeyenda>();
            objEDEDocumentoElectronico.Leyendas = lstEDELeyenda;
            objEDEDocumentoElectronico.Moneda = objEFAECab.c_moneda;
            objEDEDocumentoElectronico.MonedaAnticipo = string.Empty;//HARDCODE
            objEDEDocumentoElectronico.MontoAnticipo = 0;//HARDCODE
            objEDEDocumentoElectronico.MontoDetraccion = objEFAECab.n_monto_detraccion;
            objEDEDocumentoElectronico.MontoEnLetras = objEFAECab.n_monto_letras;
            objEDEDocumentoElectronico.MontoPercepcion = objEFAECab.n_monto_percepcion;
            objEDEDocumentoRelacionado = new EDEDocumentoRelacionado();
            lstEDEDocumentoRelacionado = new List<EDEDocumentoRelacionado>();
            objEDEDocumentoElectronico.OtrosDocumentosRelacionados = lstEDEDocumentoRelacionado;
            //Inicio rellenar datos de receptor
            objEDECompania = new EDECompania
            {
                CodigoAnexo = string.Empty,//HARDCODE
                NombreComercial = objEFAECab.c_receptor_nombre_legal,
                NombreLegal = objEFAECab.c_receptor_nombre_legal,
                NroDocumento = objEFAECab.c_receptor_numero_documento,
                TipoDocumento = objEFAECab.c_receptor_tipo_documento,//0 doc trib. no. dom. sin ruc
                                                                     //1 doc nacional de identidad
                                                                     //4 carnet de extranjeria
                                                                     //6 registro unico de contribuyente
                                                                     //7 pasaporte
                                                                     //A ced. diplomatica de identidad

            };
            objEDEDocumentoElectronico.Receptor = objEDECompania;
            //Fin rellenar datos de receptor
            objEDEDocumentoRelacionado = new EDEDocumentoRelacionado();
            lstEDEDocumentoRelacionado = new List<EDEDocumentoRelacionado>();
            objEDEDocumentoElectronico.Relacionados = lstEDEDocumentoRelacionado;
            objEDEDocumentoElectronico.TasaDetraccion = 0;//HARDCODE
            objEDEDocumentoElectronico.TipoDocAnticipo = string.Empty;//HARDCODE
            objEDEDocumentoElectronico.TipoDocumento = objEFAECab.c_tipo_documento;//01 Factura
                                                                                 //03 Boleta de Venta
                                                                                 //07 Nota de credito
                                                                                 //08 Nota de debito
            objEDEDocumentoElectronico.TipoOperacion = objEFAECab.c_tipo_operacion; //HARDCODE
            objEDEDocumentoElectronico.TotalIgv = objEFAECab.n_total_igv;
            objEDEDocumentoElectronico.TotalIsc = objEFAECab.n_total_isc;
            objEDEDocumentoElectronico.TotalOtrosTributos = objEFAECab.n_total_otros_tributos;
            objEDEDocumentoElectronico.TotalVenta = objEFAECab.n_total_venta;

            objEDEDocumentoElectronico.RUC = objEFAECab.RUC;//"20512588868";
            objEDEDocumentoElectronico.UsuarioSOL = objEFAECab.UsuarioSOL;//"MODDATOS";
            objEDEDocumentoElectronico.ClaveSOL = objEFAECab.ClaveSOL;//"MODDATOS";
            objEDEDocumentoElectronico.URLCertificado = objEFAECab.URLCertificado;//"MODDATOS";
            objEDEDocumentoElectronico.ClaveDigital = objEFAECab.ClaveDigital;//"MODDATOS";
            return objEDEDocumentoElectronico;
        }
        public EDEDocumentoElectronico GenerarEstructuraNotaCredito(VentaBE objEFAECab)
        {
            objEDEDocumentoElectronico = new EDEDocumentoElectronico();
            objEDEDocumentoElectronico.CodigoBienOServicio = string.Empty;//HARDCODE
            objEDEDocumentoElectronico.CodigoMedioPago = string.Empty;//HARDCODE
            objEDEDocumentoElectronico.CuentaBancoNacion = string.Empty;//HARDCODE
            objEDEDatoAdicional = new EDEDatoAdicional();
            lstEDEDatoAdicional = new List<EDEDatoAdicional>();
            objEDEDocumentoElectronico.DatoAdicionales = lstEDEDatoAdicional;
            objEDEDocumentoElectronico.DescuentoGlobal = 0;//HARDCODE
            objEDEDiscrepancia = new EDEDiscrepancia();
            lstEDEDiscrepancia = new List<EDEDiscrepancia>();
            objEDEDiscrepancia.Descripcion = objEFAECab.c_tipo_documento == "01" ? "Anulacion total de la factura" : "Anulacion total de la boleta";
            objEDEDiscrepancia.NroReferencia = objEFAECab.c_id_documento;//NUMERO DE FACTURA IMPORTANTE <<<<<<<<<<<<<<<<<<<----------------
            objEDEDiscrepancia.Tipo = "01";//01 Anulacion de la operacion
                                           //02 Anulacion por erroe en el ruc
                                           //03 Correccion por error en descripcion
                                           //04 Descuento global
                                           //05 Descuento por item
                                           //06 Devolucion total
                                           //07 Devolucion parcial
                                           //08 Bonificacion
                                           //09 Disminucion en el valor
            lstEDEDiscrepancia.Add(objEDEDiscrepancia);
            objEDEDocumentoElectronico.Discrepancias = lstEDEDiscrepancia;
            objEDEDocumentoElectronico.DocAnticipo = string.Empty;//HARDCODE
            //Inicio rellenar datos de emisor
            objEDECompania = new EDECompania
            {
                CodigoAnexo = objEFAECab.c_codigo_anexo,//HARDCODE
                NombreComercial = objEFAECab.c_emisor_nombre_comercial,
                NombreLegal = objEFAECab.c_emisor_nombre_legal,
                NroDocumento = objEFAECab.c_emisor_numero_documento,
                TipoDocumento = objEFAECab.c_emisor_tipo_documento,//0 doc trib. no. dom. sin ruc
                                                                   //1 doc nacional de identidad
                                                                   //4 carnet de extranjeria
                                                                   //6 registro unico de contribuyente
                                                                   //7 pasaporte
                                                                   //A ced. diplomatica de identidad
            };
            objEDEDocumentoElectronico.Emisor = objEDECompania;
            //Fin rellenar datos de emisor
            objEDEDocumentoElectronico.Exoneradas = 0;//HARDCODE
            objEDEDocumentoElectronico.FechaEmision = objEFAECab.c_fecha_emision;
            objEDEDocumentoElectronico.FechaVencimiento = string.Empty;//HARDCODE
            objEDEDocumentoElectronico.Gratuitas = objEFAECab.n_gratuitas;
            objEDEDocumentoElectronico.Gravadas = objEFAECab.n_gravadas;
            objEDEDocumentoElectronico.HoraEmision = DateTime.Now.ToString("HH:mm:ss");//HARDCODE
            objEDEDocumentoElectronico.IdDocumento = objEFAECab.c_id_documentoNC;//NOTA CREDITO IMPORTANTE <<<<<<<<<<<<<<<<<<<----------------
            objEDEDocumentoElectronico.Inafectas = objEFAECab.n_inafectas;
            //Inicio Cargar detalle de venta
            listEDEDetalledocumento = new List<EDEDetalleDocumento>();
            lstFAEDet = objEFAECab.loDetalle;
            foreach (VentaDetalleBE objFAEDet in lstFAEDet)
            {
                objEDEDetalledocumento = new EDEDetalleDocumento();
                objEDEDetalledocumento.Cantidad = objFAEDet.n_cantidad;
                objEDEDetalledocumento.CodigoItem = objFAEDet.c_id_documento;
                objEDEDetalledocumento.CodigoProductoSunat = string.Empty;//HARDCODE
                objEDEDatoAdicional = new EDEDatoAdicional();
                lstEDEDatoAdicional = new List<EDEDatoAdicional>();
                objEDEDetalledocumento.DatosAdcionales = lstEDEDatoAdicional;
                objEDEDetalledocumento.Descripcion = objFAEDet.c_decripcion;
                objEDEDetalledocumento.Descuento = objFAEDet.n_descuento;
                objEDEDetalledocumento.Id = objFAEDet.n_id_detalle;
                objEDEDetalledocumento.Impuesto = objFAEDet.n_impuesto;
                objEDEDetalledocumento.ImpuestoSelectivo = objFAEDet.n_impuesto_selectivo;
                objEDEDetalledocumento.OtroImpuesto = objFAEDet.n_otro_impuesto;
                objEDEDetalledocumento.PlacaVehiculo = string.Empty;//HARCODE
                objEDEDetalledocumento.PrecioReferencial = objFAEDet.n_precio_referencial;
                objEDEDetalledocumento.PrecioUnitario = objFAEDet.n_precio_unitario;
                objEDEDetalledocumento.TasaImpuestoSelectivo = 0;//HARDCODE
                objEDEDetalledocumento.TipoImpuesto = objFAEDet.n_tipo_impuesto;//10 Gravado Operacion Onerosa
                                                                                //11 Gravado Retiro por Premio
                                                                                //12 Gravado Retiro por Donacion
                                                                                //13 Gravado Retiro
                                                                                //14 Gravado Retiro por publicidad
                                                                                //15 Gravado Bonificaciones
                                                                                //16 Gravado Retiro por entrega a trabaja
                                                                                //17 Gravado IVAP
                                                                                //20 Exonerado Operacion Onerosa
                                                                                //21 Exonerado Transferencia Gratuita
                                                                                //30 Inafecto Operacion Onerosa
                                                                                //31 Inafecto Retiro por Bonificacion
                                                                                //32 Inafecto Retiro
                                                                                //33 Inafecto Retiro por Muestras Medicas
                                                                                //34 Inafecto Retiro por Convenito Colectivo
                                                                                //35 Inafecto Retiro por Premio
                                                                                //36 Inafecto Retiro por Publicidad
                                                                                //40 Esportacion
                objEDEDetalledocumento.TipoPrecio = objFAEDet.c_tipo_precio;//01 Precio unitario (incluye el IGV)
                                                                            //02 Valor referencial unitario en operaciones no onerosas
                objEDEDetalledocumento.TotalVenta = objFAEDet.n_total_venta;
                objEDEDetalledocumento.UnidadMedida = objFAEDet.n_unidad_medida;//NIU
                                                                                //KG
                                                                                //ONZ
                                                                                //LTR
                listEDEDetalledocumento.Add(objEDEDetalledocumento);
            }
            objEDEDocumentoElectronico.Items = listEDEDetalledocumento;
            //Fin Cargar detalle de venta
            objEDELeyenda = new EDELeyenda();
            lstEDELeyenda = new List<EDELeyenda>();
            objEDEDocumentoElectronico.Leyendas = lstEDELeyenda;
            objEDEDocumentoElectronico.Moneda = objEFAECab.c_moneda;
            objEDEDocumentoElectronico.MonedaAnticipo = string.Empty;//HARDCODE
            objEDEDocumentoElectronico.MontoAnticipo = 0;//HARDCODE
            objEDEDocumentoElectronico.MontoDetraccion = objEFAECab.n_monto_detraccion;
            objEDEDocumentoElectronico.MontoEnLetras = objEFAECab.n_monto_letras;
            objEDEDocumentoElectronico.MontoPercepcion = objEFAECab.n_monto_percepcion;
            objEDEDocumentoRelacionado = new EDEDocumentoRelacionado();
            lstEDEDocumentoRelacionado = new List<EDEDocumentoRelacionado>();
            objEDEDocumentoElectronico.OtrosDocumentosRelacionados = lstEDEDocumentoRelacionado;
            //Inicio rellenar datos de receptor
            objEDECompania = new EDECompania
            {
                CodigoAnexo = string.Empty,//HARDCODE
                NombreComercial = objEFAECab.c_receptor_nombre_legal,
                NombreLegal = objEFAECab.c_receptor_nombre_legal,
                NroDocumento = objEFAECab.c_receptor_numero_documento,
                TipoDocumento = objEFAECab.c_receptor_tipo_documento,//0 doc trib. no. dom. sin ruc
                                                                     //1 doc nacional de identidad
                                                                     //4 carnet de extranjeria
                                                                     //6 registro unico de contribuyente
                                                                     //7 pasaporte
                                                                     //A ced. diplomatica de identidad

            };
            objEDEDocumentoElectronico.Receptor = objEDECompania;
            //Fin rellenar datos de receptor
            objEDEDocumentoRelacionado = new EDEDocumentoRelacionado();
            lstEDEDocumentoRelacionado = new List<EDEDocumentoRelacionado>();
            objEDEDocumentoRelacionado.NroDocumento = objEFAECab.c_id_documento;//NUMERO DE FACTURA O BOLETA IMPORTANTE <<<<<<<<<<<<<<<<<<<----------------
            objEDEDocumentoRelacionado.TipoDocumento = objEFAECab.c_tipo_documento;//TIPO DE DOCUMENTO FACTURA O BOLETA IMPORTANTE <<<<<<<<<<<<<<<<<<<----------------
            objEDEDocumentoElectronico.Relacionados = lstEDEDocumentoRelacionado;
            objEDEDocumentoElectronico.TasaDetraccion = 0;//HARDCODE
            objEDEDocumentoElectronico.TipoDocAnticipo = string.Empty;//HARDCODE
            objEDEDocumentoElectronico.TipoDocumento = objEFAECab.c_tipo_documentoNC;//TIPO DE DOCUMENTO NOTA CREDITO IMPORTANTE <<<<<<<<<<<<<<<<<<<----------------
                                                                                   //01 Factura
                                                                                   //03 Boleta de Venta
                                                                                   //07 Nota de credito
                                                                                   //08 Nota de debito
            objEDEDocumentoElectronico.TipoOperacion = objEFAECab.c_tipo_operacion; //HARDCODE
            objEDEDocumentoElectronico.TotalIgv = objEFAECab.n_total_igv;
            objEDEDocumentoElectronico.TotalIsc = objEFAECab.n_total_isc;
            objEDEDocumentoElectronico.TotalOtrosTributos = objEFAECab.n_total_otros_tributos;
            objEDEDocumentoElectronico.TotalVenta = objEFAECab.n_total_venta;

            objEDEDocumentoElectronico.RUC = objEFAECab.RUC;//"20512588868";
            objEDEDocumentoElectronico.UsuarioSOL = objEFAECab.UsuarioSOL;//"MODDATOS";
            objEDEDocumentoElectronico.ClaveSOL = objEFAECab.ClaveSOL;//"MODDATOS";
            objEDEDocumentoElectronico.URLCertificado = objEFAECab.URLCertificado;//"MODDATOS";
            objEDEDocumentoElectronico.ClaveDigital = objEFAECab.ClaveDigital;//"MODDATOS";
            return objEDEDocumentoElectronico;
        }
        public EDEComunicacionBaja GenerarEstructuraComunicacionBaja(List<VentaBE> lstEFAECab, DateTime itemFecha)
        {
            objEDECompania = new EDECompania
            {
                CodigoAnexo = lstEFAECab.FirstOrDefault().c_codigo_anexo,//HARDCODE
                NombreComercial = lstEFAECab.FirstOrDefault().c_emisor_nombre_comercial,
                NombreLegal = lstEFAECab.FirstOrDefault().c_emisor_nombre_legal,
                NroDocumento = lstEFAECab.FirstOrDefault().c_emisor_numero_documento,
                TipoDocumento = lstEFAECab.FirstOrDefault().c_emisor_tipo_documento,
                                                                //0 doc trib. no. dom. sin ruc
                                                                //1 doc nacional de identidad
                                                                //4 carnet de extranjeria
                                                                //6 registro unico de contribuyente
                                                                //7 pasaporte
                                                                //A ced. diplomatica de identidad
            };
            var documentoBaja = new EDEComunicacionBaja
            {
                IdDocumento = $"RA-{itemFecha:yyyyMMdd}-001",
                FechaEmision = itemFecha.ToString("yyyy-MM-dd"),
                FechaReferencia = itemFecha.AddDays(-1).ToString("yyyy-MM-dd"),
                Emisor = objEDECompania,
                Bajas = new List<EDEDocumentoBaja>()
            };
            int indexCab = 1;
            string Serie = string.Empty;
            string Correlativo = string.Empty;
            foreach (var itemCabecera in lstEFAECab)
            {
                string[] ArrayNumeroComprobante = itemCabecera.c_id_documento.Split('-');
                Serie = ArrayNumeroComprobante[0];
                Correlativo = ArrayNumeroComprobante[1];
                documentoBaja.Bajas.Add(new EDEDocumentoBaja
                {
                    Id = indexCab,
                    Correlativo = Correlativo,
                    MotivoBaja = "Anulación por error en el documento",
                    Serie = Serie,
                    TipoDocumento = "01"//01 Factura
                                        //03 Boleta de Venta
                                        //07 Nota de credito
                                        //08 Nota de debito
                });
                indexCab++;
            }
            return documentoBaja;
        }
        #endregion

        #region Procesar
        public EDEEnviarDocumentoResponse ProcesarBoletaFactura(EDEDocumentoElectronico objEDocumentoElectronico)
        {
            EDECommonRequest objEDECommonRequest = new EDECommonRequest();
            objEDECommonRequest.NombreMetodoProcesoAPI = "api/GenerarFactura";
            objEDECommonRequest.NombreMetodoEnvioAPI = "api/EnviarDocumento";
            objEDECommonRequest.TipoDocumento = objEDocumentoElectronico.TipoDocumento;
            objEDECommonRequest.NombreCarpetaSinFirmar = "XML_Sin_Firmar_Factura";
            objEDECommonRequest.NombreCarpetaFirmado = "XML_Firmado_Factura";
            objEDECommonRequest.NombreCarpeaCDR = "CDR_Response_Factura";
            //REEMPLAZAR AQUI
            objEDECommonRequest.RUC = objEDocumentoElectronico.RUC;// "20512588868";
            objEDECommonRequest.UsuarioSOL = objEDocumentoElectronico.UsuarioSOL;//"MODDATOS";
            objEDECommonRequest.ClaveSOL = objEDocumentoElectronico.ClaveSOL;//"MODDATOS";

            byte[] fileBytes;
            string someUrl = objEDocumentoElectronico.URLCertificado;//"http://files.centrixperu.com/cliente_1/certificado_digital/certificado.pfx";
            using (var webClient = new WebClient())
            {
                fileBytes = webClient.DownloadData(someUrl);
            }
            objEDECommonRequest.URLCertificado = Convert.ToBase64String(fileBytes);
            objEDECommonRequest.ClaveDigital = objEDocumentoElectronico.ClaveDigital;//"Linsoft3233";
            return ProcesarFAE<EDEDocumentoElectronico>(objEDocumentoElectronico, objEDECommonRequest, objEDocumentoElectronico.IdDocumento);
        }
        public EDEEnviarDocumentoResponse ProcesarNotaCredito(EDEDocumentoElectronico objEDocumentoElectronico)
        {
            EDECommonRequest objEDECommonRequest = new EDECommonRequest();
            objEDECommonRequest.NombreMetodoProcesoAPI = "api/GenerarNotaCredito";
            objEDECommonRequest.NombreMetodoEnvioAPI = "api/EnviarDocumento";
            objEDECommonRequest.TipoDocumento = objEDocumentoElectronico.TipoDocumento;
            objEDECommonRequest.NombreCarpetaSinFirmar = "XML_Sin_Firmar_NotaCredito";
            objEDECommonRequest.NombreCarpetaFirmado = "XML_Firmado_NotaCredito";
            objEDECommonRequest.NombreCarpeaCDR = "CDR_Response_NotaCredito";
            //REEMPLAZAR AQUI
            objEDECommonRequest.RUC = objEDocumentoElectronico.RUC;// "20512588868";
            objEDECommonRequest.UsuarioSOL = objEDocumentoElectronico.UsuarioSOL;//"MODDATOS";
            objEDECommonRequest.ClaveSOL = objEDocumentoElectronico.ClaveSOL;//"MODDATOS";

            byte[] fileBytes;
            string someUrl = objEDocumentoElectronico.URLCertificado;//"http://files.centrixperu.com/cliente_1/certificado_digital/certificado.pfx";
            using (var webClient = new WebClient())
            {
                fileBytes = webClient.DownloadData(someUrl);
            }
            objEDECommonRequest.URLCertificado = Convert.ToBase64String(fileBytes);
            objEDECommonRequest.ClaveDigital = objEDocumentoElectronico.ClaveDigital;//"Linsoft3233";
            return ProcesarFAE<EDEDocumentoElectronico>(objEDocumentoElectronico, objEDECommonRequest, objEDocumentoElectronico.IdDocumento);
        }
        public EDEEnviarDocumentoResponse ProcesarComunicacionBaja(EDEComunicacionBaja objEComunicacionBaja, EDEDocumentoElectronico objEDocumentoElectronico)
        {
            EDECommonRequest objEDECommonRequest = new EDECommonRequest();
            objEDECommonRequest.NombreMetodoProcesoAPI = "api/GenerarComunicacionBaja";
            objEDECommonRequest.NombreMetodoEnvioAPI = "api/EnviarDocumento";
            objEDECommonRequest.TipoDocumento = "CB";//CB
            objEDECommonRequest.NombreCarpetaSinFirmar = "XML_Sin_Firmar_ComunicacionBaja";
            objEDECommonRequest.NombreCarpetaFirmado = "XML_Firmado_ComunicacionBaja";
            objEDECommonRequest.NombreCarpeaCDR = "CDR_Response_ComunicacionBaja";
            //REEMPLAZAR AQUI
            objEDECommonRequest.RUC = objEDocumentoElectronico.RUC;// "20512588868";
            objEDECommonRequest.UsuarioSOL = objEDocumentoElectronico.UsuarioSOL;//"MODDATOS";
            objEDECommonRequest.ClaveSOL = objEDocumentoElectronico.ClaveSOL;//"MODDATOS";

            byte[] fileBytes;
            string someUrl = objEDocumentoElectronico.URLCertificado;//"http://files.centrixperu.com/cliente_1/certificado_digital/certificado.pfx";
            using (var webClient = new WebClient())
            {
                fileBytes = webClient.DownloadData(someUrl);
            }
            objEDECommonRequest.URLCertificado = Convert.ToBase64String(fileBytes);
            objEDECommonRequest.ClaveDigital = objEDocumentoElectronico.ClaveDigital;//"Linsoft3233";
            return ProcesarFAE<EDEComunicacionBaja>(objEComunicacionBaja, objEDECommonRequest, objEComunicacionBaja.IdDocumento);
        }
        #endregion

        #region Metodos
        private EDEEnviarDocumentoResponse ProcesarFAE<T>(T objFAE, EDECommonRequest objEDECommonRequest, string IdDocumento)
        {
            objEDERespuesta = new EDEEnviarDocumentoResponse();
            //Generacion de XML
            var respuestaGenerarXMLRequest = RequestApiService<T, EDEDocumentoResponse>(objEDECommonRequest.NombreMetodoProcesoAPI, objFAE);
            if (respuestaGenerarXMLRequest.Exito)
            {
                //Guardar XML
                WriteResponsePackage(objEDECommonRequest.IdCliente.ToString(), objEDECommonRequest.IdTienda.ToString(),
                    objEDECommonRequest.NombreCarpetaSinFirmar, $"{IdDocumento}.xml",   
                    respuestaGenerarXMLRequest.TramaXmlSinFirma);

                //Firmar el documento XML
                var firmadoRequest = new EDEFirmadoRequest
                {
                    TramaXmlSinFirma = respuestaGenerarXMLRequest.TramaXmlSinFirma,
                    CertificadoDigital = objEDECommonRequest.URLCertificado,
                    PasswordCertificado = objEDECommonRequest.ClaveDigital,
                    UnSoloNodoExtension = objEDECommonRequest.TipoDocumento == "RC" ? true : false
                };
                var respuestaFirmarXML = RequestApiService<EDEFirmadoRequest, EDEFirmadoResponse>("api/Firmar", firmadoRequest);
                if (respuestaFirmarXML.Exito)
                {
                    objEDERespuesta.Pila = respuestaFirmarXML.ResumenFirma;

                    //Guardar XML Firmado
                    WriteResponsePackage(objEDECommonRequest.IdCliente.ToString(), objEDECommonRequest.IdTienda.ToString(),
                        objEDECommonRequest.NombreCarpetaFirmado, $"{IdDocumento}.xml",
                        respuestaFirmarXML.TramaXmlFirmado);

                    //Enviar XML firmado a SUNAT
                    EDEEnviarDocumentoRequest enviarDocumentoRequest;
                    //Uso de discriminante para comunicacion de baja
                    if (objEDECommonRequest.TipoDocumento != "CB")
                    {
                        enviarDocumentoRequest = new EDEEnviarDocumentoRequest
                        {
                            Ruc = objEDECommonRequest.RUC,
                            UsuarioSol = objEDECommonRequest.UsuarioSOL,
                            ClaveSol = objEDECommonRequest.ClaveSOL,
                            EndPointUrl = ConfigurationManager.AppSettings["EndPointBoletaSUNAT"].ToString(),
                            IdDocumento = IdDocumento,
                            TipoDocumento = objEDECommonRequest.TipoDocumento,
                            TramaXmlFirmado = respuestaFirmarXML.TramaXmlFirmado
                        };
                    }
                    else
                    {
                        enviarDocumentoRequest = new EDEEnviarDocumentoRequest
                        {
                            Ruc = objEDECommonRequest.RUC,
                            UsuarioSol = objEDECommonRequest.UsuarioSOL,
                            ClaveSol = objEDECommonRequest.ClaveSOL,
                            EndPointUrl = ConfigurationManager.AppSettings["EndPointBoletaSUNAT"].ToString(),
                            IdDocumento = IdDocumento,
                            TramaXmlFirmado = respuestaFirmarXML.TramaXmlFirmado
                        };
                    }
                    EDEEnviarDocumentoResponse respuestaEnvio = RequestApiService<EDEEnviarDocumentoRequest, EDEEnviarDocumentoResponse>(objEDECommonRequest.NombreMetodoEnvioAPI, enviarDocumentoRequest);
                    if (respuestaEnvio.Exito)
                    {
                        //Guardar CDR 
                        WriteResponsePackage(objEDECommonRequest.IdCliente.ToString(), objEDECommonRequest.IdTienda.ToString(),
                            objEDECommonRequest.NombreCarpeaCDR, $"{IdDocumento}.zip",
                            respuestaEnvio.TramaZipCdr != null ? respuestaEnvio.TramaZipCdr : string.Empty);
                        objEDERespuesta.TramaZipCdr = respuestaEnvio.TramaZipCdr;
                        objEDERespuesta.MensajeRespuesta = respuestaEnvio.MensajeRespuesta != null ? respuestaEnvio.MensajeRespuesta : string.Format("Correcto {0}", respuestaEnvio.NombreArchivo);
                        objEDERespuesta.Exito = true;
                    }
                    else
                    {
                        objEDERespuesta.Exito = false;
                        objEDERespuesta.CodigoRespuesta = respuestaEnvio.CodigoRespuesta;
                        objEDERespuesta.MensajeError = respuestaEnvio.MensajeError;
                    }
                }
                else
                {
                    objEDERespuesta.Exito = false;
                    objEDERespuesta.MensajeError = respuestaFirmarXML.MensajeError;
                }
            }
            else
            {
                objEDERespuesta.Exito = false;
                objEDERespuesta.MensajeError = respuestaGenerarXMLRequest.MensajeError;
            }
            return objEDERespuesta;
        }

        public void WriteResponsePackage(string Customer, string Store, string FolderName, string FileName, string Package)
        {

            //Almacenar localmente el documento
            //Obtener la ruta actual del directorio
            var fileCurrentPath = AppDomain.CurrentDomain.BaseDirectory;
            //Navegar sobre la ruta de los arhivos
            FileInfo fileInfo = new FileInfo(fileCurrentPath);
            DirectoryInfo parentDir = fileInfo.Directory.Parent;
            string parentDirName = parentDir.FullName;
            string filepath = Path.Combine(parentDirName, "files");
            ValidateFolderExists(filepath);
            //Nombre documento SUNAT
            filepath = Path.Combine(filepath, "DOC_SUNAT");
            //Crear la carpeta del cliente
            filepath = Path.Combine(filepath, string.Format("cliente_{0}", Customer));
            ValidateFolderExists(filepath);
            //Crear la carpeta del tienda
            filepath = Path.Combine(filepath, string.Format("tienda_{0}", Store));
            ValidateFolderExists(filepath);
            //Crear la carpeta nombre de folder facturacion electronica
            filepath = Path.Combine(filepath, FolderName);
            ValidateFolderExists(filepath);
            //Crear la carpeta nombre de archivo facturacion electronica
            filepath = Path.Combine(filepath, FileName);
            File.WriteAllBytes(filepath, Convert.FromBase64String(Package));
            /////////////////////////////////////////////////////////
            //////Almacenar localmente el documento
            ////string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Client);
            ////FilePath = Path.Combine(FilePath, OperativeUnity);
            ////FilePath = Path.Combine(FilePath, FolderName);
            ////if (!Directory.Exists(FilePath))
            ////{
            ////    Directory.CreateDirectory(FilePath);
            ////}
            ////FilePath = Path.Combine(FilePath, FileName);
            ////File.WriteAllBytes(FilePath, Convert.FromBase64String(Package));
        }
        private void ValidateFolderExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        #endregion
    }
}
