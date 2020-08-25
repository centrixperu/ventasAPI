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
    public class ModuloXClienteBL
    {
        //string strCnx;
        string strCnxRule;
        //string CnxCliente = "";
        ModuloXClienteDA oModuloXClienteDA;
        MaestrosDA oMaestrosDA;

        public ModuloXClienteBL(int idCliente)
        {
            //CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            //strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oModuloXClienteDA = new ModuloXClienteDA();
            oMaestrosDA = new MaestrosDA();
        }

        public ModuloXCliente_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            ModuloXCliente_DatosInicialesBE obe = new ModuloXCliente_DatosInicialesBE();
            List<ModuloXClienteBE> lobe = new List<ModuloXClienteBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();
            List<ListaComboBE> loModulos = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loCliente = oMaestrosDA.Cliente(con, usuario, idCliente);
                lobe = oModuloXClienteDA.ListarDatosIniciales(con, usuario);
                loModulos = oMaestrosDA.ListaModulos(con, usuario, idCliente, 1);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;
            obe.loModulos = loModulos;

            return obe;
        }

        public ModuloXCliente_DatosInicialesBE ListarDatosCambioCliente(string usuario, int idCliente)
        {
            ModuloXCliente_DatosInicialesBE obe = new ModuloXCliente_DatosInicialesBE();
            List<ListaComboBE> loModulos = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loModulos = oMaestrosDA.ListaModulos(con, usuario, idCliente);
            }

            obe.loModulos = loModulos;

            return obe;
        }

        public bool Guardar(ModuloXClienteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oModuloXClienteDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(ModuloXClienteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oModuloXClienteDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(ModuloXClienteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oModuloXClienteDA.Eliminar(con, sqltrans, obe);
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
