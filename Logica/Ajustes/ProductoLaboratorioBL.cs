using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes.Producto_Laboratorio;
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
    public class ProductoLaboratorioBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        ProductoLaboratorioDA oProductoLaboratorioDA;
        MaestrosDA oMaestrosDA;

        public ProductoLaboratorioBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oProductoLaboratorioDA = new ProductoLaboratorioDA();
            oMaestrosDA = new MaestrosDA();
        }

        public ProductoLaboratorio_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            ProductoLaboratorio_DatosInicialesBE obe = new ProductoLaboratorio_DatosInicialesBE();
            List<ProductoLaboratorioBE> lobe = new List<ProductoLaboratorioBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loCliente = oMaestrosDA.Cliente(con, usuario, idCliente);
                lobe = oProductoLaboratorioDA.ListarDatosIniciales(con, usuario);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;

            return obe;
        }

        public bool Guardar(ProductoLaboratorioBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oProductoLaboratorioDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(ProductoLaboratorioBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oProductoLaboratorioDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(ProductoLaboratorioBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oProductoLaboratorioDA.Eliminar(con, sqltrans, obe);
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
