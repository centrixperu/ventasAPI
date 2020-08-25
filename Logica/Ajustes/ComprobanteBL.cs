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
    public class ComprobanteBL
    {
        //string strCnx;
        string strCnxRule;
        //string CnxCliente = "";
        ComprobanteDA oComprobanteDA;
        MaestrosDA oMaestrosDA;

        public ComprobanteBL()//int idCliente)
        {
            //CnxCliente = ConfigurationManager.AppSettings[idCliente].ToString();
            //strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oComprobanteDA = new ComprobanteDA();
            oMaestrosDA = new MaestrosDA();
        }

        public Comprobante_DatosInicialesBE ListarDatosIniciales(string usuario)//, int idCliente)
        {
            Comprobante_DatosInicialesBE obe = new Comprobante_DatosInicialesBE();
            List<ComprobanteBE> lobe = new List<ComprobanteBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();
            List<ListaComboTextBE> loTipoDocIden = new List<ListaComboTextBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                //loCliente = oMaestrosDA.Cliente(con, usuario, idCliente);
                loTipoDocIden = oMaestrosDA.TipoDocumentoIdentidad(con, usuario);//, idCliente);
                lobe = oComprobanteDA.ListarDatosIniciales(con, usuario);//, idCliente);
            }

            obe.loListado = lobe;
            //obe.loCliente = loCliente;
            obe.loTipoDocIden = loTipoDocIden;

            return obe;
        }

        public bool Guardar(ComprobanteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oComprobanteDA.Guardar(con, sqltrans, obe);
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

        public bool Actualizar(ComprobanteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oComprobanteDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(ComprobanteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oComprobanteDA.Eliminar(con, sqltrans, obe);
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
