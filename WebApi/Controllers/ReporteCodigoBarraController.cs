

using CrystalDecisions.CrystalReports.Engine;
using Entidades.ReporteCodigoBarra;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ReporteCodigoBarra")]
    public class ReporteCodigoBarraController : ApiController
    {
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("ReporteDocumento")]
        [HttpGet]
        public HttpResponseMessage GetReporteDocumento(string lst)//List<CodigoBarraBE> lstReporteCodigoBarras)
        {
            try
            {
                List<CodigoBarraBE> lstReporteCodigoBarras = new List<CodigoBarraBE>();
                List<CodigoBarraBE> lstReporteCodigoBarrasF = new List<CodigoBarraBE>();
                CodigoBarraBE obj = new CodigoBarraBE();
                string[] cab = lst.Split('|');
                for(int i = 0; i < cab.Length; i += 1)
                {
                    string[] det = cab[i].Split(',');
                    if(det.Length>0)
                    {
                        obj = new CodigoBarraBE();
                        obj.IdProducto = det[0];
                        obj.NombreProducto = det[1];
                        obj.CodigoBarras = det[0];
                        obj.BarCodeImage = ReturnBarCode(obj.CodigoBarras);
                        obj.Habilitado = true;
                        obj.Cantidad = Convert.ToInt32(det[2]);
                    }
                    lstReporteCodigoBarras.Add(obj);
                }
                
                //Llenar objeto con cantidad de codigos de barra
                foreach (CodigoBarraBE item in lstReporteCodigoBarras)
                {
                    if (item.Habilitado)
                    {
                        int length = item.Cantidad;
                        for (int i = 0; i < length; i++)
                        {
                            item.BarCodeImage = ReturnBarCode(item.CodigoBarras);
                            lstReporteCodigoBarrasF.Add(item);
                        }
                    }
                }

                if (lstReporteCodigoBarrasF.Count > 0)
                {
                    //Inicio de reporte
                    ReportDocument rd = new ReportDocument();
                    rd.Load(Path.Combine(HttpContext.Current.Server.MapPath("~/Reportes/ReporteCodigoBarra"), "Rpt_CodigoBarras.rpt"));
                    rd.SetDataSource(lstReporteCodigoBarrasF);

                    byte[] byteArray = null;
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        byteArray = br.ReadBytes((int)stream.Length);
                    }

                    rd.Close();
                    rd.Dispose();

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(byteArray);
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    string nombre = "ReporteBarras" + "_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf";
                    response.Content.Headers.ContentDisposition.FileName = nombre; 

                    return response;

                } else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
                //return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }
        private byte[] ReturnBarCode(string text)
        {
            byte[] Array;
            System.Drawing.Image imgBarCode = Common.HelperBarCode.Code128Rendering.MakeBarcodeImage(text, 2, true);
            ImageConverter converter = new ImageConverter();
            Array = (byte[])converter.ConvertTo(imgBarCode, typeof(byte[]));
            return Array;
        }
    }
}
