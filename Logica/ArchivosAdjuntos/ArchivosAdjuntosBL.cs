using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ArchivosAdjuntos
{
    public class ArchivosAdjuntosBL
    {
        //string strCnx;
        string strCnxRule;
        //AdministrarProductoDA oAdministrarProductoDA;

        public ArchivosAdjuntosBL()
        {
            //strCnx = ConfigurationManager.ConnectionStrings["cnxChelita"].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            //oAdministrarProductoDA = new AdministrarProductoDA();
        }

        public bool GuardarArchivoVUE(List<ListaArchivosAdjuntos> model, out string msj)
        {
            bool rpta = false;
            msj = "";
            bool FlagIsImage = false;
            string TypeFile = string.Empty;
            string fileName = string.Empty;

            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    //Obtener la extension del archivo
                    string extension = System.IO.Path.GetExtension(model[i].DatosAdjuntosName);
                    //Obtener la ruta actual del directorio
                    var fileCurrentPath = AppDomain.CurrentDomain.BaseDirectory;
                    //Navegar sobre la ruta de los arhivos
                    FileInfo fileInfo = new FileInfo(fileCurrentPath);
                    DirectoryInfo parentDir = fileInfo.Directory.Parent;
                    string parentDirName = parentDir.FullName;
                    string filepath = Path.Combine(parentDirName, "files");
                    //Crear la carpeta del cliente
                    filepath = Path.Combine(filepath, string.Format("cliente_{0}", model[i].NombreCarpeta));
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
                    byte[] byteArray;
                    if (FlagIsImage)
                    {
                        byteArray = Convert.FromBase64String(model[i].DatosAdjuntos);
                        MemoryStream ms = new MemoryStream(byteArray, 0, byteArray.Length);
                        ms.Write(byteArray, 0, byteArray.Length);


                        using (var image = System.Drawing.Image.FromStream(ms))
                        using (var newImage = ScaleImage(image, Common.Constants.Redimension.heigh, Common.Constants.Redimension.width))
                        {
                            newImage.Save(filepath);
                        }
                    }
                    else
                    {
                        using (FileStream stream = System.IO.File.Create(filepath))
                        {
                            if (model[i].DatosAdjuntos != null)
                            {
                                byteArray = Convert.FromBase64String(model[i].DatosAdjuntos);
                            }
                            else
                            {
                                byteArray = Convert.FromBase64String("");
                            }
                            stream.Write(byteArray, 0, byteArray.Length);
                        }
                    }

                    if (msj == "")
                    {
                        msj = string.Format(ConfigurationManager.AppSettings["ResponseFile"] + "{0}/{1}/{2}", string.Format("cliente_{0}", model[i].NombreCarpeta), TypeFile, fileName);
                    }
                    else
                    {
                        msj = msj + '#' + string.Format(ConfigurationManager.AppSettings["ResponseFile"] + "{0}/{1}/{2}", string.Format("cliente_{0}", model[i].NombreCarpeta), TypeFile, fileName);
                    }
                }
                //Crear ruta de respuesta
                //string PathRespose = string.Format(ConfigurationManager.AppSettings["ResponseFile"] + "{0}/{1}/{2}", model[0].NombreCarpeta, TypeFile, fileName);
                //msj = string.Format(ConfigurationManager.AppSettings["ResponseFile"] + "{0}/{1}/{2}", model[0].NombreCarpeta, TypeFile, fileName);
                rpta = true;
            }
            else
            {
                msj = "No se adjunto ningun archivo.";
                rpta = false;
            }

            return rpta;
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
    }
}
