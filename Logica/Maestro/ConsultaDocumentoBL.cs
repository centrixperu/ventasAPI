using AccesoDatos.Maestros;
using Entidades.Maestro;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Maestro
{
    public class ConsultaDocumentoBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        //ConsultaDocumentoDA oConsultaDocumentoDA;
        MaestrosDA oMaestrosDA;

        public ConsultaDocumentoBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            //oConsultaDocumentoDA = new ConsultaDocumentoDA();
            oMaestrosDA = new MaestrosDA();
        }

        public ConsultaDocumentoBE ConsultarDNIRUC(string usuario, int idCliente, string nroDoc, string tipoDoc)
        {
            ConsultaDocumentoBE obe = new ConsultaDocumentoBE();
            obe.sNroDocumento = nroDoc;
            string strURLDNI = ConfigurationManager.AppSettings["URLConsultaDNI"].ToString();
            string strURLRUC = ConfigurationManager.AppSettings["URLConsultaRUC"].ToString();
            string strURLConsultaDocumento = ConfigurationManager.AppSettings["URLConsultaDocumento"].ToString();
            string strEstructuraMovil = beSerialize.SerializeObject<ConsultaDocumentoBE>(obe);

            if(tipoDoc=="DNI" || tipoDoc == "RUC")
            {
                string strURL = (tipoDoc == "DNI" ? strURLDNI : strURLRUC) + nroDoc;

                using (HttpClient oCli = new HttpClient())
                {
                    oCli.BaseAddress = new Uri(strURLConsultaDocumento);
                    //var requestcontent = new StringContent(strEstructuraMovil, Encoding.UTF8, "application/json");
                    var response = oCli.GetAsync(strURL).Result;
                    if (response != null)
                    {
                        string strResponse = response.Content.ReadAsStringAsync().Result;
                        obe = beSerialize.DeserializeObject<ConsultaDocumentoBE>(strResponse);
                    }
                }
            }          

            return obe;
        }

        public List<ListaComboTextBE> ConsultarClienteVenta(string usuario, int idCliente, string desCliente)
        {
            List<ListaComboTextBE> loCliente = new List<ListaComboTextBE>();

            using (SqlConnection conR = new SqlConnection(strCnx))
            {
                conR.Open();
                loCliente = oMaestrosDA.ConsultarClienteVenta(conR, usuario, idCliente, desCliente);
            }

            return loCliente;
        }

    }
}
