using Common;
using Entidades.AdministrarProducto;
using Entidades.Utils;
using Logica.ArchivosAdjuntos;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/AdministrarArchivo")]
    public class AdministrarArchivoController : ApiController
    {
        ArchivosAdjuntosBL oArchivosAdjuntosBL = new ArchivosAdjuntosBL();

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("GuardarArchivo")]
        [HttpPost]
        public IHttpActionResult PostGuardarArchivo(string Customer)
        {
            try
            {
                var httpContext = HttpContext.Current;
                bool FlagIsImage = false;
                string TypeFile = string.Empty;
                string fileName = string.Empty;
                if (httpContext.Request.Files.Count > 0)
                {
                    for (int i = 0; i < httpContext.Request.Files.Count; i++)
                    {
                        HttpPostedFile httpPostedFile = httpContext.Request.Files[i];
                        if (httpPostedFile != null)
                        {
                            //Obtener la extension del archivo
                            string extension = System.IO.Path.GetExtension(httpPostedFile.FileName);
                            //Obtener la ruta actual del directorio
                            var fileCurrentPath = AppDomain.CurrentDomain.BaseDirectory;
                            //Navegar sobre la ruta de los arhivos
                            FileInfo fileInfo = new FileInfo(fileCurrentPath);
                            DirectoryInfo parentDir = fileInfo.Directory.Parent;
                            string parentDirName = parentDir.FullName;
                            string filepath = Path.Combine(parentDirName, "files");
                            //Crear la carpeta del cliente
                            Customer = string.Format("cliente_{0}", Customer);
                            filepath = Path.Combine(filepath, Customer);
                            //Validar extensiones para crear carpetas segun tipo de archivo
                            ValidateFolderExists(filepath);
                            if (extension.ToLower() == ".jpg" ||
                                extension.ToLower() == ".jpeg" ||
                                extension.ToLower() == ".pjpeg" ||
                                extension.ToLower() == ".png" ||
                                extension.ToLower() == ".x-png" ||
                                extension.ToLower() == ".tif" ||
                                extension.ToLower() == ".bmp" ||
                                extension.ToLower() == ".psd" ||
                                extension.ToLower() == ".gif")
                            {
                                FlagIsImage = true;
                                TypeFile = "images";
                            }
                            else if (extension.ToLower() == ".doc" ||
                                extension.ToLower() == ".docx" ||
                                extension.ToLower() == ".docm")
                            {
                                TypeFile = "word";
                            }
                            else if (extension.ToLower() == ".xls" ||
                                extension.ToLower() == ".xlsx" ||
                                extension.ToLower() == ".xlsm")
                            {
                                TypeFile = "excel";
                            }
                            else if (extension.ToLower() == ".pdf")
                            {
                                TypeFile = "pdf";
                            }
                            else if (extension.ToLower() == ".xml")
                            {
                                TypeFile = "xml";
                            }
                            else if (extension.ToLower() == ".zip" ||
                                extension.ToLower() == ".rar" ||
                                extension.ToLower() == ".tar")
                            {
                                TypeFile = "zip";
                            }
                            else if (extension.ToLower() == ".pfx")
                            {
                                TypeFile = "certificado_digital";
                            }
                            else
                            {
                                TypeFile = "otros";
                            }
                            filepath = Path.Combine(filepath, TypeFile);
                            ValidateFolderExists(filepath);
                            //Crear el nombre de archivo
                            fileName = Guid.NewGuid().ToString() + extension.ToLower();
                            //Ruta completa para guardar el arhivo
                            filepath = Path.Combine(filepath, fileName);
                            //Guardar el archivo
                            if (FlagIsImage)
                            {
                                using (var image = System.Drawing.Image.FromStream(httpPostedFile.InputStream))
                                using (var newImage = ScaleImage(image, Common.Constants.Redimension.heigh, Common.Constants.Redimension.width))
                                {
                                    newImage.Save(filepath);
                                }
                            }
                            else
                            {
                                httpPostedFile.SaveAs(filepath);
                            }
                        }
                    }
                    //Crear ruta de respuesta
                    string PathRespose = string.Format(ConfigurationManager.AppSettings["ResponseFile"] + "{0}/{1}/{2}", Customer, TypeFile, fileName);
                    return Ok(Models.Util.GetBodyResponse(200, PathRespose));
                }
                else
                {
                    return Ok(Models.Util.GetBodyResponse(300, "No se adjunto ningun archivo."));
                }
            }
            catch (Exception ex)
            {
                HelperLog.PutLineError(ex.Message);
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }
        private void ValidateFolderExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }


        [Route("GuardarArchivoVue")]
        public async Task<IHttpActionResult> PostGuardarArchivoVUE(List<ListaArchivosAdjuntos> model)
        {
            try
            {

                string msj = "";
                bool rpta = false;
                rpta = oArchivosAdjuntosBL.GuardarArchivoVUE(model, out msj);
                if (rpta)
                {
                    return Ok(Models.Util.GetBodyResponse(200, msj));
                }else
                {
                    return Ok(Models.Util.GetBodyResponse(300, msj));
                }

            }
            catch (Exception ex)
            {
                HelperLog.PutLineError(ex.Message);
                return Ok(Models.Util.GetBodyResponse(400, ex.Message));
            }
        }
    }
}
