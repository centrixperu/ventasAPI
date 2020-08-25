using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes.Producto_TipoPresentacion;
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
    public class ProductoTipoPresentacionBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        ProductoTipoPresentacionDA oProductoTipoPresentacionDA;
        MaestrosDA oMaestrosDA;

        public ProductoTipoPresentacionBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oProductoTipoPresentacionDA = new ProductoTipoPresentacionDA();
            oMaestrosDA = new MaestrosDA();
        }

        public ProductoTipoPresentacion_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            ProductoTipoPresentacion_DatosInicialesBE obe = new ProductoTipoPresentacion_DatosInicialesBE();
            List<ProductoTipoPresentacionBE> lobe = new List<ProductoTipoPresentacionBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loCliente = oMaestrosDA.Cliente(con, usuario, idCliente);
                lobe = oProductoTipoPresentacionDA.ListarDatosIniciales(con, usuario);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;

            return obe;
        }

        public bool Guardar(ProductoTipoPresentacionBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oProductoTipoPresentacionDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(ProductoTipoPresentacionBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oProductoTipoPresentacionDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(ProductoTipoPresentacionBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oProductoTipoPresentacionDA.Eliminar(con, sqltrans, obe);
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
