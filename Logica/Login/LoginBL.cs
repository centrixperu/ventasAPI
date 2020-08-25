using AccesoDatos.Login;
using Entidades.Login;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Login
{
    public class LoginBL
    {
        //string strCnx;
        string strCnxRule;
        LoginDA oLoginDA;

        public LoginBL()
        {
            //strCnx = ConfigurationManager.ConnectionStrings["cnxChelita"].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oLoginDA = new LoginDA();
        }

        public LoginBE IniciarSesion(LoginBE be)
        {
            LoginBE obe = new LoginBE();
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                obe = oLoginDA.IniciarSesion(con, be);
            }
            return obe;
        }


    }
}
