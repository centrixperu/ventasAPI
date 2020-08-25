

using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes;
using Entidades.Ajustes.Talla;
using Entidades.Utils;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Logica.Ajustes
{
    public class TallaBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        TallaDA oTallaDA;
        MaestrosDA oMaestrosDA;

        public TallaBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oTallaDA = new TallaDA();
            oMaestrosDA = new MaestrosDA();
        }

        public Talla_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            Talla_DatosInicialesBE obe = new Talla_DatosInicialesBE();
            List<TallaBE> lobe = new List<TallaBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();

            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            List<TallaExportBE> loExport = new List<TallaExportBE>();

            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                loCliente = oMaestrosDA.Cliente(conR, usuario, idCliente);
            }

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                lobe = oTallaDA.ListarDatosIniciales(con, usuario, out loColumns, out loExport);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;

            obe.loColumns = loColumns;
            obe.loExport = loExport;

            return obe;
        }

        public bool Guardar(TallaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oTallaDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(TallaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oTallaDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(TallaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oTallaDA.Eliminar(con, sqltrans, obe);
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
