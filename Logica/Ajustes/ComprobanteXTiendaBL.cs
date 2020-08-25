using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes;
using Entidades.Ajustes.ComprobanteXTienda;
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
    public class ComprobanteXTiendaBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        ComprobanteXTiendaDA oComprobanteXTiendaDA;
        MaestrosDA oMaestrosDA;

        public ComprobanteXTiendaBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oComprobanteXTiendaDA = new ComprobanteXTiendaDA();
            oMaestrosDA = new MaestrosDA();
        }

        public ComprobanteXTienda_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            ComprobanteXTienda_DatosInicialesBE obe = new ComprobanteXTienda_DatosInicialesBE();
            List<ComprobanteXTiendaBE> lobe = new List<ComprobanteXTiendaBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();
            List<ListaComboBE> loTienda = new List<ListaComboBE>();
            List<ListaComboBE> loComprobante = new List<ListaComboBE>();
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            List<ComprobanteXTiendaExportBE> loExport = new List<ComprobanteXTiendaExportBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loCliente = oMaestrosDA.Cliente(con, usuario, idCliente);
                lobe = oComprobanteXTiendaDA.ListarDatosIniciales(con, usuario, out loColumns, out loExport);
                loTienda = oMaestrosDA.ComboTienda(con, usuario, idCliente,-1);
                loComprobante = oMaestrosDA.ComboComprobante(con, usuario, idCliente);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;
            obe.loTienda = loTienda;
            obe.loComprobante = loComprobante;

            obe.loColumns = loColumns;
            obe.loExport = loExport;
            return obe;
        }

        public ComprobanteXTienda_DatosInicialesBE ListarDatosCambioCliente(string usuario, int idCliente)
        {
            ComprobanteXTienda_DatosInicialesBE obe = new ComprobanteXTienda_DatosInicialesBE();
            List<ListaComboBE> loTienda = new List<ListaComboBE>();
            List<ListaComboBE> loComprobante = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loTienda = oMaestrosDA.ComboTienda(con, usuario, idCliente,-1);
                loComprobante = oMaestrosDA.ComboComprobante(con, usuario, idCliente);
            }

            obe.loTienda = loTienda;
            obe.loComprobante = loComprobante;

            return obe;
        }

        public bool Guardar(ComprobanteXTiendaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oComprobanteXTiendaDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(ComprobanteXTiendaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oComprobanteXTiendaDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(ComprobanteXTiendaBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oComprobanteXTiendaDA.Eliminar(con, sqltrans, obe);
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
