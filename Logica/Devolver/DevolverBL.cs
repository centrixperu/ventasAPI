using AccesoDatos.Devolver;
using AccesoDatos.Maestros;
using Entidades.Almacen.AsignarAlmacen;
using Entidades.Devolver;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Devolver
{
    public class DevolverBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        DevolverDA oDevolverDA;
        MaestrosDA oMaestrosDA;

        public DevolverBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oDevolverDA = new DevolverDA();
            oMaestrosDA = new MaestrosDA();
        }

        public Devolver_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            Devolver_DatosInicialesBE obe = new Devolver_DatosInicialesBE();
            List<ListaComboBE> loTienda = new List<ListaComboBE>();
            List<ListaComboBE> loAlmacen = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loTienda = oMaestrosDA.ComboTienda(con, usuario, idCliente, -1);
                loAlmacen = oMaestrosDA.ComboAlmacen(con, usuario, idCliente);
            }

            obe.loTienda = loTienda;
            obe.loAlmacen = loAlmacen;

            return obe;
        }

        public Devolver_DatosInicialesBE ListarProductosTienda(string usuario, int idCliente, int idTienda)
        {
            Devolver_DatosInicialesBE obe = new Devolver_DatosInicialesBE();
            List<AsignarAlmacen_ProductoBE> loProducto = new List<AsignarAlmacen_ProductoBE>();

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                loProducto = oMaestrosDA.ListaProductoXTiendaEnStock(con, usuario, idCliente, idTienda);
            }

            obe.loProducto = loProducto;

            return obe;
        }

        public RespuestaBE Devolver(Devolver_DatosInicialesBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oDevolverDA.Devolver(con, sqltrans, obe);
                if (rpta.codigo == 1)
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
