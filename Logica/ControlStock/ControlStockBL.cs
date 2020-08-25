

using AccesoDatos.ControlStock;
using Entidades.ControlStock;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Logica.ControlStock
{
    public class ControlStockBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        ControlStockDA oControlStockDA;
        //MaestrosDA oMaestrosDA;
        //ArchivosAdjuntosBL oArchivosAdjuntosBL;

        public ControlStockBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oControlStockDA = new ControlStockDA();
            //oMaestrosDA = new MaestrosDA();
            //oArchivosAdjuntosBL = new ArchivosAdjuntosBL();
        }
        public ControlStockGBE ListarProductos(string usuario, int idCliente, int idAlmacen, int idTienda)
        {
            ControlStockGBE loProducto = new ControlStockGBE();

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                loProducto = oControlStockDA.ListaProductoXTienda(con, usuario, idCliente, idAlmacen, idTienda);
            }

            return loProducto;
        }

        public bool Guardar(ControlStockGBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oControlStockDA.Guardar(con, sqltrans, obe);
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
