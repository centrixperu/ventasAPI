using CrystalDecisions.CrystalReports.Engine;
using Entidades.ArchivosAdjuntos;
using Entidades.ReporteCodigoBarra;
using Entidades.Venta;
//using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
//using System.Web.Http.Cors;

namespace Logica.ArchivosAdjuntos
{
    public class ImprimirComprobanteBL
    {
        string strCnxRule;

        public ImprimirComprobanteBL()
        {
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
        }

        public string ImprimirVenta(VentaBE obe)//List<CodigoBarraBE> lstReporteCodigoBarras)
        {
            try
            {
                //List<CodigoBarraBE> lstReporteCodigoBarrasF = new List<CodigoBarraBE>();
                List<ImprimirComprobanteBE> lobj = new List<ImprimirComprobanteBE>();
                ImprimirComprobanteBE obj = new ImprimirComprobanteBE();

                if (obe != null)
                {
                    if (obe.loDetalle.Count > 0)
                    {
                        for (var i = 0; i < obe.loDetalle.Count; i += 1)
                        {
                            obj = new ImprimirComprobanteBE();
                            obj.NombreComercial = obe.c_emisor_nombre_comercial;
                            obj.NombreLegal = obe.c_emisor_nombre_legal;
                            obj.RUC = obe.c_emisor_numero_documento;
                            obj.Direccion = obe.c_emisor_direccion;
                            obj.DireccionL1 = obe.c_emisor_urbanizacion;
                            obj.DireccionL2 = obe.c_emisor_distrito.Substring(3);
                            obj.DireccionL3 = obe.c_emisor_provincia.Substring(3);
                            obj.DireccionL4 = obe.c_emisor_departamento.Substring(3);
                            obj.DireccionL5 = obe.c_emisor_direccion;
                            obj.NombreComprobante = obe.c_tipo_documento_nombre;
                            obj.NumeroComprobante = obe.c_id_documento;
                            obj.FechaEmision = DateTime.Now.ToString("dd/MM/yyyy"); // obe.c_fecha_emision;
                            //obj.HoraEmision = obe.XXXXXX;
                            obj.CodigoProducto = Convert.ToString(obe.loDetalle[i].c_id_producto);
                            obj.DescripcionProducto = Convert.ToString(obe.loDetalle[i].c_decripcion);
                            obj.Cantidad = Convert.ToString(obe.loDetalle[i].n_cantidad);
                            obj.Preciounitario = Convert.ToString(obe.loDetalle[i].n_precio_unitario);
                            obj.Subtotal = Convert.ToString(obe.loDetalle[i].n_total_venta);
                            obj.OperacionGravada = Convert.ToString(obe.n_total_venta - obe.n_total_igv);
                            obj.IGV = Convert.ToString(obe.n_total_igv);
                            obj.Total = Convert.ToString(obe.n_total_venta);
                            //obj.PiePagina = obe.XXXXXX;
                            //obj.PiePagina1 = obe.XXXXXX;
                            //obj.PiePagina2 = obe.XXXXXX;
                            //obj.PiePagina3 = obe.XXXXXX;
                            //obj.PiePagina4 = obe.XXXXXX;
                            //obj.PiePagina5 = obe.XXXXXX;
                            //obj.PiePaginaL1 = obe.XXXXXX;
                            //obj.PiePaginaL2 = obe.XXXXXX;
                            //obj.PiePaginaL3 = obe.XXXXXX;
                            //obj.PiePaginaL4 = obe.XXXXXX;
                            //obj.PiePaginaL5 = obe.XXXXXX;
                            obj.NumeroNotaVenta = obe.c_id_documentoNV;
                            //obj.Tienda = obe.XXXXXX;
                            //obj.Vendedor = obe.XXXXXX;
                            obj.NroDocumentoReceptor = obe.c_receptor_numero_documento;
                            obj.NombreLegalReceptor = obe.c_receptor_nombre_legal;
                            obj.DireccionRecepctor = obe.c_receptor_direccion;
                            //obj.NroGuiaRemision = obe.XXXXXX;
                            lobj.Add(obj);
                        }
                    }
                }
                if (lobj.Count > 0)
                {
                    //Inicio de reporte
                    ReportDocument rd = new ReportDocument();
                    if(obe.t_impresion == "A4")
                    {
                        rd.Load(Path.Combine(HttpContext.Current.Server.MapPath("~/Reportes/Gmail"), "Rpt_KRL_ComprobanteFactura.rpt"));
                    }
                    else
                    {
                        rd.Load(Path.Combine(HttpContext.Current.Server.MapPath("~/Reportes/Gmail"), "Rpt_Chelita_ComprobanteFactura.rpt"));
                    }                    
                    rd.SetDataSource(lobj);

                    byte[] byteArray = null;
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        byteArray = br.ReadBytes((int)stream.Length);
                    }

                    rd.Close();
                    rd.Dispose();

                    return Convert.ToBase64String(byteArray);
                }
                else
                {
                    return ""; // new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                //return new HttpResponseMessage(HttpStatusCode.BadRequest);
                return "";// Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }


    }
}
