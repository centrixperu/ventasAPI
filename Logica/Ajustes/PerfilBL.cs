using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Ajustes
{
    public class PerfilBL
    {
        //string strCnx;
        string strCnxRule;
        //string CnxCliente = "";
        PerfilDA oPerfilDA;
        MaestrosDA oMaestrosDA;

        public PerfilBL(int idCliente)
        {
            //CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            //strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oPerfilDA = new PerfilDA();
            oMaestrosDA = new MaestrosDA();
        }

        public Perfil_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            Perfil_DatosInicialesBE obe = new Perfil_DatosInicialesBE();
            List<PerfilBE> lobe = new List<PerfilBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();
            List<ListaComboBE> loModulos = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loCliente = oMaestrosDA.Cliente(con, usuario, idCliente);
                lobe = oPerfilDA.ListarDatosIniciales(con, usuario);
                loModulos = oMaestrosDA.ListaModulos(con, usuario, idCliente);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;
            obe.loModulos = loModulos;

            return obe;
        }

        public Perfil_DatosInicialesBE ListarDatosCambioCliente(string usuario, int idCliente)
        {
            Perfil_DatosInicialesBE obe = new Perfil_DatosInicialesBE();
            List<ListaComboBE> loModulos = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loModulos = oMaestrosDA.ListaModulos(con, usuario, idCliente);
            }

            obe.loModulos = loModulos;

            return obe;
        }

        public bool Guardar(PerfilBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oPerfilDA.Guardar(con, sqltrans, obe);
                if (rpta)
                {
                    sqltrans.Commit();
                }
                else
                {
                    sqltrans.Rollback();
                }
            }
            return rpta;
        }

        public bool Actualizar(PerfilBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oPerfilDA.Actualizar(con, sqltrans, obe);
                if (rpta)
                {
                    sqltrans.Commit();
                }
                else
                {
                    sqltrans.Rollback();
                }
            }
            return rpta;
        }

        public bool Eliminar(PerfilBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oPerfilDA.Eliminar(con, sqltrans, obe);
                if (rpta)
                {
                    sqltrans.Commit();
                }
                else
                {
                    sqltrans.Rollback();
                }
            }
            return rpta;
        }

    }
}
