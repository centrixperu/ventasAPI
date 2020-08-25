

using AccesoDatos.Maestros;
using AccesoDatos.ReporteCaja;
using Entidades.Almacen.AsignarAlmacen;
using Entidades.ReporteCaja;
using Entidades.Utils;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Logica.ReporteCaja
{
    public class ReporteCajaBL
    {

        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        ReporteCajaDA oReporteCajaDA;
        MaestrosDA oMaestrosDA;

        public ReporteCajaBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oReporteCajaDA = new ReporteCajaDA();
            oMaestrosDA = new MaestrosDA();
        }

        public CajaBE ReporteCaja(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            List<ListaComboBE> lobeTienda = new List<ListaComboBE>();
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                lobeTienda = oMaestrosDA.ComboTienda(conR, usuario, idCliente, -1);
            }

            CajaBE obe = new CajaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteCajaDA.ReporteCajaDia(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isMes)
                {
                    obe = oReporteCajaDA.ReporteCajaMes(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteCajaDA.ReporteCajaAnio(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                /*else if (isRango)
                {
                    obe = oReporteCajaDA.ReporteCajaRango(con, usuario, idCliente, fechaInicio, fechaFin, lobeTienda);
                }*/
            }

            return obe;
        }

        public CajaBE ListarDatosIniciales(string usuario, int idCliente, List<ListaComboBE> loTienda)
        {
            CajaBE obe = new CajaBE();

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                obe = oReporteCajaDA.ListarDatosIniciales(con, usuario, idCliente, loTienda);
            }
            return obe;
        }

        public RespuestaBE Guardar(CajaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oReporteCajaDA.Guardar(con, sqltrans, obe);
                if (rpta.codigo>0)
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

        public List<AsignarAlmacen_ProductoBE> ProductosCaja(string usuario, int idCliente, int idTienda, string busqueda)
        {
            List<AsignarAlmacen_ProductoBE> obe = new List<AsignarAlmacen_ProductoBE>();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                obe = oReporteCajaDA.ProductosCaja(con, usuario, idCliente, idTienda, busqueda);
            }

            return obe;
        }
    }
}
