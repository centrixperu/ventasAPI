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
    public class EmisorBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        EmisorDA oEmisorDA;
        MaestrosDA oMaestrosDA;

        public EmisorBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oEmisorDA = new EmisorDA();
            oMaestrosDA = new MaestrosDA();
        }

        public Emisor_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            Emisor_DatosInicialesBE lobe = new Emisor_DatosInicialesBE();

            List<ListaComboTextBE> obeDepartamento = new List<ListaComboTextBE>();
            List<ListaComboTextBE> obeProvincia = new List<ListaComboTextBE>();
            List<ListaComboTextBE> obeDistrito = new List<ListaComboTextBE>();
            List<ListaComboBE> obeCliente = new List<ListaComboBE>();
            List<EmisorBE> obeListado = new List<EmisorBE>();
            List<ListaComboDetallado> obeTienda = new List<ListaComboDetallado>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                obeDepartamento = oMaestrosDA.Departamento(con, usuario);
                obeProvincia = oMaestrosDA.Provincia(con, usuario, "0");
                obeDistrito = oMaestrosDA.Distrito(con, usuario, "0", "0");
                obeCliente = oMaestrosDA.Cliente(con, usuario, idCliente);
                obeListado = oEmisorDA.Listar(con, usuario, idCliente);
                obeTienda = oMaestrosDA.Tienda(con, usuario);
            }
            
            lobe.loListado = obeListado;
            lobe.loTienda = obeTienda;
            lobe.loDepartamento = obeDepartamento;
            lobe.loProvincia = obeProvincia;
            lobe.loDistrito = obeDistrito;
            lobe.loCliente = obeCliente;

            return lobe;
        }

        public List<ListaComboTextBE> ListarProvincia(string usuario, string codigo)
        {
            List<ListaComboTextBE> obe = new List<ListaComboTextBE>();
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                obe = oMaestrosDA.Provincia(con, usuario, codigo);
            }
            return obe;
        }
        public List<ListaComboTextBE> ListarDistrito(string usuario, string idDepartamento, string codigo)
        {
            List<ListaComboTextBE> obe = new List<ListaComboTextBE>();
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                obe = oMaestrosDA.Distrito(con, usuario, idDepartamento, codigo);
            }
            return obe;
        }

        public bool Guardar(EmisorBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oEmisorDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(EmisorBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oEmisorDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(EmisorBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oEmisorDA.Eliminar(con, sqltrans, obe);
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
