using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes.Producto_GrupoMedico;
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
    public class ProductoGrupoMedicoBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        ProductoGrupoMedicoDA oProductoGrupoMedicoDA;
        MaestrosDA oMaestrosDA;

        public ProductoGrupoMedicoBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oProductoGrupoMedicoDA = new ProductoGrupoMedicoDA();
            oMaestrosDA = new MaestrosDA();
        }

        public ProductoGrupoMedico_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            ProductoGrupoMedico_DatosInicialesBE obe = new ProductoGrupoMedico_DatosInicialesBE();
            List<ProductoGrupoMedicoBE> lobe = new List<ProductoGrupoMedicoBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loCliente = oMaestrosDA.Cliente(con, usuario, idCliente);
                lobe = oProductoGrupoMedicoDA.ListarDatosIniciales(con, usuario);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;

            return obe;
        }

        public bool Guardar(ProductoGrupoMedicoBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oProductoGrupoMedicoDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(ProductoGrupoMedicoBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oProductoGrupoMedicoDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(ProductoGrupoMedicoBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oProductoGrupoMedicoDA.Eliminar(con, sqltrans, obe);
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
