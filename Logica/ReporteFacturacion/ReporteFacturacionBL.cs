using AccesoDatos.Maestros;
using AccesoDatos.ReporteFacturacion;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ReporteFacturacion
{
    public class ReporteFacturacionBL
    {

        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        ReporteFacturacionDA oReporteFacturacionDA;
        MaestrosDA oMaestrosDA;

        public ReporteFacturacionBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oReporteFacturacionDA = new ReporteFacturacionDA();
            oMaestrosDA = new MaestrosDA();
        }

        public List<ListaComboBE> ComprobanteTienda(string usuario, int idCliente, int idTienda)
        {
            List<ListaComboBE> obe = new List<ListaComboBE>();
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                obe = oMaestrosDA.ComboComprobanteTienda(con, usuario, idCliente, idTienda);
            }

            return obe;
        }

    }
}
