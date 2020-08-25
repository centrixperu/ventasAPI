using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes;
using Entidades.Ajustes.Tienda;
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
    public class TiendaBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        TiendaDA oTiendaDA;
        MaestrosDA oClienteDA;

        public TiendaBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oTiendaDA = new TiendaDA();
            oClienteDA = new MaestrosDA();
        }

        public Tienda_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            Tienda_DatosInicialesBE obe = new Tienda_DatosInicialesBE();
            List<TiendaBE> lobe = new List<TiendaBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            List<TiendaExportBE> loExport = new List<TiendaExportBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loCliente = oClienteDA.Cliente(con, usuario, idCliente);
                lobe = oTiendaDA.ListarDatosIniciales(con, usuario, out loExport, out loColumns);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;
            obe.loExport = loExport;
            obe.loColumns = loColumns;
            
            return obe;
        }

        public bool Guardar(TiendaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oTiendaDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(TiendaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oTiendaDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(TiendaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oTiendaDA.Eliminar(con, sqltrans, obe);
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
