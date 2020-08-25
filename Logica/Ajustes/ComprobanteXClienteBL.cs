using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes;
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
    public class ComprobanteXClienteBL
    {
        //string strCnx;
        string strCnxRule;
        //string CnxCliente = "";
        ComprobanteXClienteDA oComprobanteXClienteDA;
        MaestrosDA oMaestrosDA;

        public ComprobanteXClienteBL()//int idCliente)
        {
            //CnxCliente = ConfigurationManager.AppSettings[idCliente].ToString();
            //strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oComprobanteXClienteDA = new ComprobanteXClienteDA();
            oMaestrosDA = new MaestrosDA();
        }

        public ComprobanteXCliente_DatosInicialesBE ListarDatosIniciales(string usuario)//, int idCliente)
        {
            ComprobanteXCliente_DatosInicialesBE obe = new ComprobanteXCliente_DatosInicialesBE();
            List<ComprobanteXClienteBE> lobe = new List<ComprobanteXClienteBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();
            List<ListaComboTextBE> loComprobante = new List<ListaComboTextBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loCliente = oMaestrosDA.Cliente(con, usuario, 0);
                loComprobante = oMaestrosDA.Comprobante(con, usuario);//, idCliente);
                lobe = oComprobanteXClienteDA.ListarDatosIniciales(con, usuario);//, idCliente);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;
            obe.loTipoDocVenta = loComprobante;

            return obe;
        }

        public bool Guardar(ComprobanteXClienteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oComprobanteXClienteDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(ComprobanteXClienteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oComprobanteXClienteDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(ComprobanteXClienteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oComprobanteXClienteDA.Eliminar(con, sqltrans, obe);
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
