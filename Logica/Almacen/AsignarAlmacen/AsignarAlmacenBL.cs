using AccesoDatos.Almacen.AsignarAlmacen;
using AccesoDatos.Maestros;
using Entidades.Ajustes;
using Entidades.Almacen.AsignarAlmacen;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Almacen.AsignarAlmacen
{
    public class AsignarAlmacenBL
    {
        string strCnx;
        string CnxCliente = "";
        string strCnxRule;
        AsignarAlmacenDA oAsignarAlmacenDA;
        MaestrosDA oMaestrosDA;

        public AsignarAlmacenBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oAsignarAlmacenDA = new AsignarAlmacenDA();
            oMaestrosDA = new MaestrosDA();
        }

        public AsignarAlmacen_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            AsignarAlmacen_DatosInicialesBE obe = new AsignarAlmacen_DatosInicialesBE();
            List<AsignarAlmacenBE> lobe = new List<AsignarAlmacenBE>();
            List<ListaComboBE> loAlmacen = new List<ListaComboBE>();
            ClienteBE loCliente = new ClienteBE();
            List<AsignarAlmacen_ProductoBE> lobeProducto = new List<AsignarAlmacen_ProductoBE>();
            List<ListaComboBE> lobeTipoProducto = new List<ListaComboBE>();

            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                loAlmacen = oMaestrosDA.ComboAlmacen(conR, usuario, idCliente);
                loCliente = oMaestrosDA.DatosCliente(conR, usuario, idCliente);
            }
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                lobe = oAsignarAlmacenDA.ListarDatosIniciales(con, usuario, loAlmacen);
                lobeProducto = oMaestrosDA.ListaProducto(con, usuario);
                lobeTipoProducto = oMaestrosDA.ComboTipoProducto(con, usuario, idCliente);
            }

            /*if (lobe != null && lobe.Count > 0)
            {
                for (int i = 0; i < lobe.Count; i += 1)
                {
                    for (int j = 0; j < lobe[i].loProducto.Count; j += 1)
                    {
                        lobe[i].loProducto[j].loTipoProducto = lobeTipoProducto;
                        lobe[i].loProducto[j].isTipoProducto = loCliente.isTipoProducto;
                        lobe[i].loProducto[j].isFechaVenProd = loCliente.isFechaVenProd;
                        lobe[i].loProducto[j].isCostoProduccion = loCliente.isCostoProduccion;
                    }
                }                
            }*/

            /*if (lobeProducto != null && lobeProducto.Count > 0)
            {
                for (int j = 0; j < lobeProducto.Count; j += 1)
                {
                    lobeProducto[j].loTipoProducto = lobeTipoProducto;
                    lobeProducto[j].isTipoProducto = loCliente.isTipoProducto;
                    lobeProducto[j].isFechaVenProd = loCliente.isFechaVenProd;
                    lobeProducto[j].isCostoProduccion = loCliente.isCostoProduccion;
                }
            }*/

            obe.loListado = lobe;
            obe.loAlmacen = loAlmacen;
            //obe.loProducto = lobeProducto;

            return obe;
        }

        public List<ListaComboBE> ListarTienda(string usuario, int idCliente, int idAlmacen)
        {
            List<ListaComboBE> obe = new List<ListaComboBE>();

            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                obe = oMaestrosDA.ComboTienda(conR, usuario, idCliente, idAlmacen);
            }

            return obe;
        }

        public List<AsignarAlmacen_ProductoBE> ListarProductosTienda(string usuario, int idCliente, int idAlmacen, int idTienda)
        {
            List<AsignarAlmacen_ProductoBE> obe = new List<AsignarAlmacen_ProductoBE>();
            ClienteBE loCliente = new ClienteBE();
            List<ListaComboBE> lobeTipoProducto = new List<ListaComboBE>();

            //using (SqlConnection conR = new SqlConnection(strCnxRule))
            //{
            //    conR.Open();
            //    loCliente = oMaestrosDA.DatosCliente(conR, usuario, idCliente);
            //}

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                obe = oAsignarAlmacenDA.ListarProductosAlmacenTienda(con, usuario, idAlmacen, idTienda);
                lobeTipoProducto = oMaestrosDA.ComboTipoProducto(con, usuario, idCliente);
            }

            if (obe != null && obe.Count > 0)
            {
                for (int j = 0; j < obe.Count; j += 1)
                {
                    obe[j].loTipoProducto = lobeTipoProducto;
                    //obe[j].isTipoProducto = loCliente.isTipoProducto;
                    //obe[j].isFechaVenProd = loCliente.isFechaVenProd;
                    //obe[j].isCostoProduccion = loCliente.isCostoProduccion;
                }
            }

            return obe;
        }

        public List<AsignarAlmacen_ProductoBE> ListarProductosAlmacen(string usuario, int idCliente, int idAlmacen)
        {
            List<AsignarAlmacen_ProductoBE> lobeProducto = new List<AsignarAlmacen_ProductoBE>();
            ClienteBE loCliente = new ClienteBE();
            List<ListaComboBE> lobeTipoProducto = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                lobeProducto = oMaestrosDA.ListaProducto(con, usuario, -1, idAlmacen);
                lobeTipoProducto = oMaestrosDA.ComboTipoProducto(con, usuario, idCliente);
            }

            if (lobeProducto != null && lobeProducto.Count > 0)
            {
                for (int j = 0; j < lobeProducto.Count; j += 1)
                {
                    lobeProducto[j].loTipoProducto = lobeTipoProducto;
                }
            }

            return lobeProducto;
        }

        public bool Guardar(AsignarAlmacenBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAsignarAlmacenDA.Guardar(con, sqltrans, obe);
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

        public bool GuardarTienda(AsignarAlmacenBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAsignarAlmacenDA.GuardarTienda(con, sqltrans, obe);
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
        /*
        public bool Actualizar(AsignarAlmacenBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAsignarAlmacenDA.Actualizar(con, sqltrans, obe);
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

        public bool Eliminar(AsignarAlmacenBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAsignarAlmacenDA.Eliminar(con, sqltrans, obe);
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
        */
    }
}
