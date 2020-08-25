using Entidades.DTOIntercambio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ResponseFacturacionElectronica
    {
        EDEPaqueteResponse objEDEPaqueteRequest;
        public T2 RequestApiService<T1, T2>(string UrlAPI, T1 SenderObject) where T2 : EDERespuestaComun
        {
            var Proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlOpenInvoicePeruApi"]) };
            var Response = Proxy.PostAsJsonAsync(UrlAPI, SenderObject).Result;
            var ResposeAPI = Response.Content.ReadAsAsync<T2>().Result;
            return ResposeAPI;
        }
        public void WriteResponsePackage(string Client, string OperativeUnity, string FolderName, string FileName, string Package)
        {
            //Almacenar localmente el documento
            string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Client);
            FilePath = Path.Combine(FilePath, OperativeUnity);
            FilePath = Path.Combine(FilePath, FolderName);
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            FilePath = Path.Combine(FilePath, FileName);
            File.WriteAllBytes(FilePath, Convert.FromBase64String(Package));
        }
    }
}
