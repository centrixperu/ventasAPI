using AccesoDatos.DashBoard;
using Entidades.DashBoard;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DashBoard
{
    public class DashBoardBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        DashBoardDA oDashBoardDA;

        public DashBoardBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oDashBoardDA = new DashBoardDA();
        }

        public DashBoard_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            DashBoard_DatosInicialesBE obe = new DashBoard_DatosInicialesBE();

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                obe = oDashBoardDA.ListarDatosIniciales(con, usuario);
            }
            return obe;
        }
    }
}
