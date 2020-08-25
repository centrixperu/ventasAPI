using AccesoDatos.Maestros;
using AccesoDatos.ReporteClienteTienda;
using Entidades.ReporteClienteTienda;
using Entidades.ReporteClienteTienda.GuiasTienda;
using Entidades.ReporteClienteTienda.KardexPrecioTienda;
using Entidades.ReporteClienteTienda.KardexProductoTienda;
using Entidades.ReporteClienteTienda.RegistroVentaTienda;
using Entidades.ReporteClienteTienda.VentaPrecioTienda;
using Entidades.ReporteClienteTienda.VentaProductoTienda;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ReporteClienteTienda
{
    public class ReporteClienteTiendaBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        ReporteClienteTiendaDA oReporteClienteTiendaDA;
        MaestrosDA oMaestrosDA;

        public ReporteClienteTiendaBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oReporteClienteTiendaDA = new ReporteClienteTiendaDA();
            oMaestrosDA = new MaestrosDA();
        }

        public ReporteClienteTienda_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            ReporteClienteTienda_DatosInicialesBE obe = new ReporteClienteTienda_DatosInicialesBE();
            List<ListaComboBE> loTienda = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loTienda = oMaestrosDA.ComboTienda(con, usuario, idCliente, -1);
            }

            obe.loTienda = loTienda;

            return obe;
        }

        public ReporteClienteTienda_DatosInicialesBE ListarAlmacen(string usuario, int idCliente)
        {
            ReporteClienteTienda_DatosInicialesBE obe = new ReporteClienteTienda_DatosInicialesBE();
            List<ListaComboBE> loAlmacen = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loAlmacen = oMaestrosDA.ComboAlmacen(con, usuario, idCliente);
            }

            obe.loAlmacen = loAlmacen;

            return obe;
        }

        public GuiaTiendaBE VerGuiaTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            GuiaTiendaBE obe = new GuiaTiendaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteTiendaDA.VerGuiaTiendaDia(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteTiendaDA.VerGuiaTiendaMes(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteTiendaDA.VerGuiaTiendaAnio(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteTiendaDA.VerGuiaTiendaRango(con, usuario, idCliente, fechaInicio, fechaFin, idTienda, desTienda);
                }
            }

            return obe;
        }

        public VentaProductoTiendaBE VentaProductoTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            VentaProductoTiendaBE obe = new VentaProductoTiendaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteTiendaDA.VentaProductoTiendaDia(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteTiendaDA.VentaProductoTiendaMes(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteTiendaDA.VentaProductoTiendaAnio(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteTiendaDA.VentaProductoTiendaRango(con, usuario, idCliente, fechaInicio, fechaFin, idTienda, desTienda);
                }
            }

            return obe;
        }

        public VentaPrecioTiendaBE VentaPrecioTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            VentaPrecioTiendaBE obe = new VentaPrecioTiendaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteTiendaDA.VentaPrecioTiendaDia(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteTiendaDA.VentaPrecioTiendaMes(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteTiendaDA.VentaPrecioTiendaAnio(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteTiendaDA.VentaPrecioTiendaRango(con, usuario, idCliente, fechaInicio, fechaFin, idTienda, desTienda);
                }
            }

            return obe;
        }

        public KardexProductoTiendaBE KardexProductoTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            KardexProductoTiendaBE obe = new KardexProductoTiendaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteTiendaDA.KardexProductoTiendaDia(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteTiendaDA.KardexProductoTiendaMes(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteTiendaDA.KardexProductoTiendaAnio(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteTiendaDA.KardexProductoTiendaRango(con, usuario, idCliente, fechaInicio, fechaFin, idTienda, desTienda);
                }
            }

            return obe;
        }

        public KardexPrecioTiendaBE KardexPrecioTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            KardexPrecioTiendaBE obe = new KardexPrecioTiendaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteTiendaDA.KardexPrecioTiendaDia(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteTiendaDA.KardexPrecioTiendaMes(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteTiendaDA.KardexPrecioTiendaAnio(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteTiendaDA.KardexPrecioTiendaRango(con, usuario, idCliente, fechaInicio, fechaFin, idTienda, desTienda);
                }
            }

            return obe;
        }

        public VentaTiendaBE RegistroVentasTienda(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            VentaTiendaBE obe = new VentaTiendaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oReporteClienteTiendaDA.RegistroVentasTiendaDia(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isMes)
                {
                    obe = oReporteClienteTiendaDA.RegistroVentasTiendaMes(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isAnio)
                {
                    obe = oReporteClienteTiendaDA.RegistroVentasTiendaAnio(con, usuario, idCliente, fechaInicio, idTienda, desTienda);
                }
                else if (isRango)
                {
                    obe = oReporteClienteTiendaDA.RegistroVentasTiendaRango(con, usuario, idCliente, fechaInicio, fechaFin, idTienda, desTienda);
                }
            }

            return obe;
        }

    }
}
