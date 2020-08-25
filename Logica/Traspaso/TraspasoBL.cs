using AccesoDatos.Maestros;
using AccesoDatos.Traspaso;
using Entidades.Almacen.AsignarAlmacen;
using Entidades.Traspaso;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Traspaso
{
    public class TraspasoBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        TraspasoDA oTraspasoDA;
        MaestrosDA oMaestrosDA;

        public TraspasoBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oTraspasoDA = new TraspasoDA();
            oMaestrosDA = new MaestrosDA();
        }

        public Traspaso_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            Traspaso_DatosInicialesBE obe = new Traspaso_DatosInicialesBE();
            List<ListaComboDetallado> loTienda = new List<ListaComboDetallado>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                //loTienda = oMaestrosDA.ComboTienda(con, usuario, idCliente, -1);
                loTienda = oMaestrosDA.Tienda(con, usuario);
            }

            obe.loTienda = loTienda;

            return obe;
        }

        public Traspaso_DatosInicialesBE ListarProductosTienda(string usuario, int idCliente, int idTienda)
        {
            Traspaso_DatosInicialesBE obe = new Traspaso_DatosInicialesBE();
            List<AsignarAlmacen_ProductoBE> loProducto = new List<AsignarAlmacen_ProductoBE>();

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                loProducto = oMaestrosDA.ListaProductoXTiendaEnStock(con, usuario, idCliente, idTienda);
            }

            obe.loProducto = loProducto;

            return obe;
        }

        public RespuestaBE Traspasar(Traspaso_DatosInicialesBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oTraspasoDA.Traspasar(con, sqltrans, obe);
                if (rpta.codigo==1)
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
