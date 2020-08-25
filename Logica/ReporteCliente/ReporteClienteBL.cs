

using AccesoDatos.Maestros;
using AccesoDatos.ReporteCliente;
using Entidades.ReporteCliente;
using Entidades.ReporteCliente.KardexPrecio;
using Entidades.ReporteCliente.KardexProducto;
using Entidades.ReporteCliente.VentaPrecio;
using Entidades.ReporteCliente.VentaProducto;
using Entidades.Utils;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Logica.ReporteCliente
{
    public class ReporteClienteBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        ReporteClienteDA oReporteClienteDA;
        MaestrosDA oMaestrosDA;

        public ReporteClienteBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oReporteClienteDA = new ReporteClienteDA();
            oMaestrosDA = new MaestrosDA();
        }

        public GuiaBE VerGuia(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            List<ListaComboBE> lobeTienda = new List<ListaComboBE>();
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                lobeTienda = oMaestrosDA.ComboTienda(conR, usuario, idCliente, -1);
            }

            GuiaBE obe = new GuiaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteDA.VerGuiaDia(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteDA.VerGuiaMes(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteDA.VerGuiaAnio(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteDA.VerGuiaRango(con, usuario, idCliente, fechaInicio, fechaFin, lobeTienda);
                }
            }

            return obe;
        }

        public VentaProductoBE VentaProducto(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            List<ListaComboBE> lobeTienda = new List<ListaComboBE>();
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                lobeTienda = oMaestrosDA.ComboTienda(conR, usuario, idCliente, -1);
            }

            VentaProductoBE obe = new VentaProductoBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteDA.VentaProductoDia(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteDA.VentaProductoMes(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteDA.VentaProductoAnio(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteDA.VentaProductoRango(con, usuario, idCliente, fechaInicio, fechaFin, lobeTienda);
                }
            }

            return obe;
        }

        public VentaPrecioBE VentaPrecio(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            List<ListaComboBE> lobeTienda = new List<ListaComboBE>();
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                lobeTienda = oMaestrosDA.ComboTienda(conR, usuario, idCliente, -1);
            }

            VentaPrecioBE obe = new VentaPrecioBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteDA.VentaPrecioDia(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteDA.VentaPrecioMes(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteDA.VentaPrecioAnio(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteDA.VentaPrecioRango(con, usuario, idCliente, fechaInicio, fechaFin, lobeTienda);
                }
            }

            return obe;
        }

        public KardexProductoBE KardexProducto(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            List<ListaComboBE> lobeTienda = new List<ListaComboBE>();
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                lobeTienda = oMaestrosDA.ComboTienda(conR, usuario, idCliente, -1);
            }

            KardexProductoBE obe = new KardexProductoBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteDA.KardexProductoDia(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteDA.KardexProductoMes(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteDA.KardexProductoAnio(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteDA.KardexProductoRango(con, usuario, idCliente, fechaInicio, fechaFin, lobeTienda);
                }
            }

            return obe;
        }

        public KardexPrecioBE KardexPrecio(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            List<ListaComboBE> lobeTienda = new List<ListaComboBE>();
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                lobeTienda = oMaestrosDA.ComboTienda(conR, usuario, idCliente, -1);
            }

            KardexPrecioBE obe = new KardexPrecioBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteDA.KardexPrecioDia(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteDA.KardexPrecioMes(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteDA.KardexPrecioAnio(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteDA.KardexPrecioRango(con, usuario, idCliente, fechaInicio, fechaFin, lobeTienda);
                }
            }

            return obe;
        }
    }
}
