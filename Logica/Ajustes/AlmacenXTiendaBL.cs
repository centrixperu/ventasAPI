using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes;
using Entidades.Ajustes.AlmacenXTienda;
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
    public class AlmacenXTiendaBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        AlmacenXTiendaDA oAlmacenXTiendaDA;
        MaestrosDA oMaestrosDA;

        public AlmacenXTiendaBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oAlmacenXTiendaDA = new AlmacenXTiendaDA();
            oMaestrosDA = new MaestrosDA();
        }

        public AlmacenXTienda_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            AlmacenXTienda_DatosInicialesBE obe = new AlmacenXTienda_DatosInicialesBE();
            List<AlmacenXTiendaBE> lobe = new List<AlmacenXTiendaBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();
            List<ListaComboBE> loTienda = new List<ListaComboBE>();
            List<ListaComboBE> loAlmacen = new List<ListaComboBE>();

            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            List<AlmacenXTiendaExportBE> loExport = new List<AlmacenXTiendaExportBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loCliente = oMaestrosDA.Cliente(con, usuario, idCliente);
                lobe = oAlmacenXTiendaDA.ListarDatosIniciales(con, usuario, out loColumns, out loExport);
                loTienda = oMaestrosDA.ComboTienda(con, usuario, idCliente,-1);
                loAlmacen = oMaestrosDA.ComboAlmacen(con, usuario, idCliente);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;
            obe.loTienda = loTienda;
            obe.loAlmacen = loAlmacen;

            obe.loColumns = loColumns;
            obe.loExport = loExport;

            return obe;
        }

        public AlmacenXTienda_DatosInicialesBE ListarDatosCambioCliente(string usuario, int idCliente)
        {
            AlmacenXTienda_DatosInicialesBE obe = new AlmacenXTienda_DatosInicialesBE();
            List<ListaComboBE> loTienda = new List<ListaComboBE>();
            List<ListaComboBE> loAlmacen = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loTienda = oMaestrosDA.ComboTienda(con, usuario, idCliente,-1);
                loAlmacen = oMaestrosDA.ComboAlmacen(con, usuario, idCliente);
            }

            obe.loTienda = loTienda;
            obe.loAlmacen = loAlmacen;

            return obe;
        }

        public bool Guardar(AlmacenXTiendaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAlmacenXTiendaDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(AlmacenXTiendaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAlmacenXTiendaDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(AlmacenXTiendaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAlmacenXTiendaDA.Eliminar(con, sqltrans, obe);
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
