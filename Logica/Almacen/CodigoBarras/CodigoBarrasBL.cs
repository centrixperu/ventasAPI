using AccesoDatos.Almacen.CodigoBarras;
using AccesoDatos.Maestros;
using Entidades.Almacen.CodigoBarras;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Almacen.CodigoBarras
{
    public class CodigoBarrasBL
    {
        string strCnx;
        string CnxCliente = "";
        string strCnxRule;
        CodigoBarrasDA oCodigoBarrasDA;
        MaestrosDA oMaestrosDA;

        public CodigoBarrasBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oCodigoBarrasDA = new CodigoBarrasDA();
            oMaestrosDA = new MaestrosDA();
        }

        public CodigoBarras_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            CodigoBarras_DatosInicialesBE obe = new CodigoBarras_DatosInicialesBE();
            List<CodigoBarrasBE> lobe = new List<CodigoBarrasBE>();

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                lobe = oCodigoBarrasDA.ListarDatosIniciales(con, usuario);
            }

            obe.loListado = lobe;

            return obe;
        }

    }
}
