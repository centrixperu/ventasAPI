

using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes;
using Entidades.Ajustes.Color;
using Entidades.Utils;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Logica.Ajustes
{
    public class ColorBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        ColorDA oColorDA;
        MaestrosDA oMaestrosDA;

        public ColorBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oColorDA = new ColorDA();
            oMaestrosDA = new MaestrosDA();
        }

        public Color_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            Color_DatosInicialesBE obe = new Color_DatosInicialesBE();
            List<ColorBE> lobe = new List<ColorBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();

            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            List<ColorExportBE> loExport = new List<ColorExportBE>();

            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                loCliente = oMaestrosDA.Cliente(conR, usuario, idCliente);
            }

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                lobe = oColorDA.ListarDatosIniciales(con, usuario, out loColumns, out loExport);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;

            obe.loColumns = loColumns;
            obe.loExport = loExport;

            return obe;
        }

        public bool Guardar(ColorBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oColorDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(ColorBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oColorDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(ColorBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oColorDA.Eliminar(con, sqltrans, obe);
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
