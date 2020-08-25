using Entidades.Ajustes;
using Entidades.Almacen.AsignarAlmacen;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Maestros
{
    public class MaestrosDA
    {
        // bd rules
        public List<ListaComboTextBE> UnidadMedida(SqlConnection cnBD, string usuario)
        {
            List<ListaComboTextBE> lobe = null;
            ListaComboTextBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_UnidadMedida]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboTextBE> Segmento(SqlConnection cnBD, string usuario)
        {
            List<ListaComboTextBE> lobe = null;
            ListaComboTextBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_SegmentoProducto]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboTextBE> Familia(SqlConnection cnBD, string usuario, string IdSegmento = "")
        {
            List<ListaComboTextBE> lobe = null;
            ListaComboTextBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_FamiliaProducto]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@IdSegmento", SqlDbType.VarChar, 4).Value = IdSegmento;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboTextBE> Clase(SqlConnection cnBD, string usuario, string IdSegmento = "", string IdFamilia = "")
        {
            List<ListaComboTextBE> lobe = null;
            ListaComboTextBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ClaseProducto]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@IdSegmento", SqlDbType.VarChar, 4).Value = IdSegmento;
                cmd.Parameters.Add("@IdFamilia", SqlDbType.VarChar, 4).Value = IdFamilia;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboTextBE> Producto(SqlConnection cnBD, string usuario, string IdSegmento = "", string IdFamilia = "", string IdClase = "")
        {
            List<ListaComboTextBE> lobe = null;
            ListaComboTextBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ProductoUNSPSC]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@IdSegmento", SqlDbType.VarChar, 4).Value = IdSegmento;
                cmd.Parameters.Add("@IdFamilia", SqlDbType.VarChar, 4).Value = IdFamilia;
                cmd.Parameters.Add("@IdClase", SqlDbType.VarChar, 4).Value = IdClase;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboTextBE> TipoDocumentoIdentidad(SqlConnection cnBD, string usuario)//, int idCliente)
        {
            List<ListaComboTextBE> lobe = null;
            ListaComboTextBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_TipoDocumentoIdentidad]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                //cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("codigo");
                        int pos_Descripcion = drd.GetOrdinal("descripcion");
                        int pos_DescripcionLarga = drd.GetOrdinal("descripcionLarga");

                        int pos_isDNI = drd.GetOrdinal("isDNI");
                        int pos_isRUC = drd.GetOrdinal("isRUC");
                        int pos_isNombre = drd.GetOrdinal("isNombre");
                        int pos_isDireccion = drd.GetOrdinal("isDireccion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            obe.descripcionLarga = drd.GetString(pos_DescripcionLarga);

                            obe.isDNI = drd.GetBoolean(pos_isDNI);
                            obe.isRUC = drd.GetBoolean(pos_isRUC);
                            obe.isNombre = drd.GetBoolean(pos_isNombre);
                            obe.isDireccion = drd.GetBoolean(pos_isDireccion);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaComboBE> Cliente(SqlConnection cnBD, string usuario, int idCliente)
        {
            List<ListaComboBE> lobe = null;
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_Cliente]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("codigo");
                        int pos_Descripcion = drd.GetOrdinal("descripcion");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public ClienteBE DatosCliente(SqlConnection cnBD, string usuario, int idCliente)
        {
            //List<ListaComboBE> lobe = null;
            ClienteBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ListaCliente]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("codigo");
                        int pos_Descripcion = drd.GetOrdinal("descripcion");
                        int pos_isTipoProducto = drd.GetOrdinal("isTipoProducto");
                        int pos_isCostoProduccion = drd.GetOrdinal("isCostoProduccion");
                        int pos_isFechaVenProd = drd.GetOrdinal("isFechaVenProd");

                        //lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ClienteBE();
                            obe.Id = drd.GetInt32(pos_Codigo);
                            obe.DesCliente = drd.GetString(pos_Descripcion);
                            obe.isTipoProducto = drd.GetBoolean(pos_isTipoProducto);
                            obe.isCostoProduccion = drd.GetBoolean(pos_isCostoProduccion);
                            obe.isFechaVenProd = drd.GetBoolean(pos_isFechaVenProd);
                            //lobe.Add(obe);
                        }
                    }
                }
            }
            return obe;
        }

        public List<ListaComboTextBE> Comprobante(SqlConnection cnBD, string usuario)
        {
            List<ListaComboTextBE> lobe = null;
            ListaComboTextBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_Comprobante]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }
        
        public List<ListaComboBE> ComboAlmacen(SqlConnection cnBD, string usuario, int idCliente)
        {
            List<ListaComboBE> lobe = new List<ListaComboBE>();
            ListaComboBE obe = new ListaComboBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ComboAlmacen]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaComboBE> ComboTienda(SqlConnection cnBD, string usuario, int idCliente, int idAlmacen)
        {
            List<ListaComboBE> lobe = new List<ListaComboBE>();
            ListaComboBE obe = new ListaComboBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ComboTienda]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = idAlmacen;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_TipoPrecio = drd.GetOrdinal("TipoPrecio");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            obe.isTipoPrecio = drd.GetInt32(pos_TipoPrecio);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaComboBE> ComboComprobante(SqlConnection cnBD, string usuario, int idCliente)
        {
            List<ListaComboBE> lobe = null;
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ComboComprobante]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        //int pos_isBase = drd.GetOrdinal("isBase");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            //obe.isBase = drd.GetInt32(pos_isBase);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaComboBE> ComboComprobanteTienda(SqlConnection cnBD, string usuario, int idCliente, int idTienda)
        {
            List<ListaComboBE> lobe = null;
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ComboComprobanteTienda]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_isTipoDocDefecto = drd.GetOrdinal("isTipoDocDefecto");
                        //--------------------------------------------------
                        int pos_CodigoSUNAT = drd.GetOrdinal("CodigoSUNAT");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            obe.isTipoDocDefecto = drd.GetString(pos_isTipoDocDefecto);
                            obe.codigoSUNAT = drd.GetString(pos_CodigoSUNAT);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaComboBE> ComboPerfil(SqlConnection cnBD, string usuario, int idCliente)
        {
            List<ListaComboBE> lobe = null;
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ComboPerfil]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaComboBE> ListaModulos(SqlConnection cnBD, string usuario, int idCliente, int isTodo = 0)
        {
            List<ListaComboBE> lobe = new List<ListaComboBE>();
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ListaModulo]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@isTodo", SqlDbType.Int).Value = isTodo;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_IdModuloPadre = drd.GetOrdinal("IdModuloPadre");
                        int pos_DesModuloPadre = drd.GetOrdinal("DesModuloPadre");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            obe.menuPadre = drd.GetString(pos_IdModuloPadre) + " - " + drd.GetString(pos_DesModuloPadre);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaComboTextBE> Departamento(SqlConnection cnBD, string usuario)
        {
            List<ListaComboTextBE> lobe = null;
            ListaComboTextBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_Departamento]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboTextBE> Provincia(SqlConnection cnBD, string usuario, string IdDepartamento = "0")
        {
            List<ListaComboTextBE> lobe = null;
            ListaComboTextBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_Provincia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@IdDepartamento", SqlDbType.VarChar, 3).Value = IdDepartamento;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboTextBE> Distrito(SqlConnection cnBD, string usuario, string IdDepartamento = "0", string IdProvincia = "0")
        {
            List<ListaComboTextBE> lobe = null;
            ListaComboTextBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_Distrito]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@IdDepartamento", SqlDbType.VarChar, 3).Value = IdDepartamento;
                cmd.Parameters.Add("@IdProvincia", SqlDbType.VarChar, 3).Value = IdProvincia;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboDetallado> Tienda(SqlConnection cnBD, string usuario)
        {
            List<ListaComboDetallado> lobe = null;
            ListaComboDetallado obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ListarTienda]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_Direccion = drd.GetOrdinal("Direccion");
                        int pos_Urbanizacion = drd.GetOrdinal("Urbanizacion");
                        int pos_NombreComercial = drd.GetOrdinal("NombreComercial");
                        int pos_NombreLegal = drd.GetOrdinal("NombreLegal");

                        lobe = new List<ListaComboDetallado>();
                        while (drd.Read())
                        {
                            obe = new ListaComboDetallado();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            obe.direccion = drd.GetString(pos_Direccion);
                            obe.urbanizacion = drd.GetString(pos_Urbanizacion);
                            obe.NombreComercial = drd.GetString(pos_NombreComercial);
                            obe.NombreLegal = drd.GetString(pos_NombreLegal);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<EmisorBE> ListaEmisor(SqlConnection cnBD, string usuario, int idCliente)
        {
            List<EmisorBE> lobe = null;
            EmisorBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ListaEmisor]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_IdCliente = drd.GetOrdinal("IdCliente");
                        int pos_DesCliente = drd.GetOrdinal("DesCliente");
                        int pos_CodSucursal = drd.GetOrdinal("CodSucursal");
                        int pos_NombreComercial = drd.GetOrdinal("NombreComercial");
                        int pos_NombreLegal = drd.GetOrdinal("NombreLegal");
                        int pos_RUC = drd.GetOrdinal("RUC");
                        int pos_TipoDoc = drd.GetOrdinal("TipoDoc");
                        int pos_Direccion = drd.GetOrdinal("Direccion");
                        int pos_Urbanizacion = drd.GetOrdinal("Urbanizacion");
                        int pos_IdDepartamento = drd.GetOrdinal("IdDepartamento");
                        int pos_Departamento = drd.GetOrdinal("Departamento");
                        int pos_IdProvincia = drd.GetOrdinal("IdProvincia");
                        int pos_Provincia = drd.GetOrdinal("Provincia");
                        int pos_IdDistrito = drd.GetOrdinal("IdDistrito");
                        int pos_Distrito = drd.GetOrdinal("Distrito");
                        int pos_Ubigeo = drd.GetOrdinal("Ubigeo");
                        int pos_Detraccion = drd.GetOrdinal("Detraccion");
                        int pos_IGV = drd.GetOrdinal("IGV");
                        int pos_ISC = drd.GetOrdinal("ISC");
                        int pos_ClaveDigital = drd.GetOrdinal("ClaveDigital");
                        int pos_URLCertificado = drd.GetOrdinal("URLCertificado");

                        lobe = new List<EmisorBE>();
                        while (drd.Read())
                        {
                            obe = new EmisorBE();
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.desTienda = drd.GetString(pos_DesTienda);
                            obe.IdCliente = drd.GetInt32(pos_IdCliente);
                            obe.desCliente = drd.GetString(pos_DesCliente);
                            obe.codSurcursal = drd.GetString(pos_CodSucursal);
                            obe.nomComercial = drd.GetString(pos_NombreComercial);
                            obe.nomLegal = drd.GetString(pos_NombreLegal);
                            obe.ruc = drd.GetString(pos_RUC);
                            obe.tipodoc = drd.GetString(pos_TipoDoc);
                            obe.direccion = drd.GetString(pos_Direccion);
                            obe.urbanizacion = drd.GetString(pos_Urbanizacion);
                            obe.IdDepartamento = drd.GetString(pos_IdDepartamento);
                            obe.desDepartamento = drd.GetString(pos_Departamento);
                            obe.IdProvincia = drd.GetString(pos_IdProvincia);
                            obe.desProvincia = drd.GetString(pos_Provincia);
                            obe.IdDistrito = drd.GetString(pos_IdDistrito);
                            obe.desDistrito = drd.GetString(pos_Distrito);
                            obe.ubigeo = drd.GetString(pos_Ubigeo);
                            obe.detraccion = drd.GetDecimal(pos_Detraccion);
                            obe.igv = drd.GetDecimal(pos_IGV);
                            obe.isc = drd.GetDecimal(pos_ISC);
                            var claveD = drd.GetString(pos_Ubigeo);
                            var URLCert = drd.GetString(pos_URLCertificado);
                            if (claveD != "" && URLCert!="")
                            {
                                lobe.Add(obe);
                            }                            
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaComboBE> Producto_TipoPresentacion(SqlConnection cnBD, string usuario, int idCliente)
        {
            List<ListaComboBE> lobe = null;
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ProductoTipoPresentacion]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_CodCorto = drd.GetOrdinal("CodCorto");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.codcorto = drd.GetString(pos_CodCorto);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboBE> Producto_GrupoMedico(SqlConnection cnBD, string usuario, int idCliente)
        {
            List<ListaComboBE> lobe = null;
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ProductoGrupoMedico]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboBE> Producto_Laboratorio(SqlConnection cnBD, string usuario, int idCliente)
        {
            List<ListaComboBE> lobe = null;
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ProductoLaboratorio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_CodCorto = drd.GetOrdinal("CodCorto");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.codcorto = drd.GetString(pos_CodCorto);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }
        //bd client
        public List<AsignarAlmacen_ProductoBE> ListaProducto(SqlConnection cnBD, string usuario, int tipo = -1, int idAlmacen = 0, string busqueda = "")
        {
            List<AsignarAlmacen_ProductoBE> lobe = null;
            AsignarAlmacen_ProductoBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ListaProducto]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = tipo;
                cmd.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = idAlmacen;
                cmd.Parameters.Add("@busqueda", SqlDbType.VarChar,250).Value = busqueda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_CodProducto = drd.GetOrdinal("CodProducto");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_Nombre = drd.GetOrdinal("Nombre");
                        int pos_Selec = drd.GetOrdinal("Selec");

                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_CantidadTienda = drd.GetOrdinal("CantidadTienda");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_IdTipo = drd.GetOrdinal("IdTipo");
                        int pos_isBase = drd.GetOrdinal("isBase");
                        int pos_RegistroSanitario = drd.GetOrdinal("RegistroSanitario");
                        //int pos_isFechaVencimiento = drd.GetOrdinal("isFecVencimiento");

                        lobe = new List<AsignarAlmacen_ProductoBE>();
                        while (drd.Read())
                        {
                            obe = new AsignarAlmacen_ProductoBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.CodProducto = drd.GetString(pos_CodProducto);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.Nombre = drd.GetString(pos_Nombre);
                            obe.Cantidad = 0;
                            obe.CantidadCaja = 0;
                            obe.PrecioCosto = 0;
                            obe.Selec = drd.GetBoolean(pos_Selec);
                            obe.Stock = drd.GetInt32(pos_Stock);

                            obe.CantidadTienda = drd.GetInt32(pos_CantidadTienda);
                            obe.Precio = drd.GetDecimal(pos_Precio);
                            obe.OldPrecio = drd.GetDecimal(pos_Precio);
                            obe.loTipoProducto = new List<ListaComboBE>();
                            obe.idTipo = drd.GetInt32(pos_IdTipo);
                            obe.isTipoBase = drd.GetBoolean(pos_isBase);
                            obe.FecVencimiento = "";
                            obe.isTipoProducto = false;
                            obe.isFechaVenProd = false;
                            obe.isCostoProduccion = false;
                            obe.DireccionCosto = "";
                            obe.Ubicacion = "";
                            obe.Lote = "";
                            obe.RegistroSanitario = drd.GetString(pos_RegistroSanitario);
                            //obe.isFechaVencimiento = drd.GetBoolean(pos_isFechaVencimiento);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        //LISTA PRODUCTOS POR TIENDA
        public List<AsignarAlmacen_ProductoBE> ListaProductoXTienda(SqlConnection cnBD, string usuario, int idCliente, int idTienda)
        {
            List<AsignarAlmacen_ProductoBE> lobe = null;
            AsignarAlmacen_ProductoBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ListaProductoXTienda]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@idTienda", SqlDbType.Int).Value = idTienda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_CodProducto = drd.GetOrdinal("CodProducto");
                        int pos_Nombre = drd.GetOrdinal("Nombre");
                        int pos_Selec = drd.GetOrdinal("Selec");

                        int pos_CantidadTienda = drd.GetOrdinal("CantidadTienda");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_idProductoBase = drd.GetOrdinal("idProductoBase");
                        int pos_CantidadCaja = drd.GetOrdinal("CantidadCaja");
                        int pos_IdTipo = drd.GetOrdinal("IdTipo");
                        int pos_DesTipo = drd.GetOrdinal("DesTipo");

                        int pos_IdUnidad = drd.GetOrdinal("IdUnidad");
                        int pos_DesUnidad = drd.GetOrdinal("DesUnidad");
                        int pos_CodUNSPSC = drd.GetOrdinal("CodUNSPSC");
                        int pos_FecVencimiento = drd.GetOrdinal("FecVencimiento");
                        int pos_isXVencer = drd.GetOrdinal("isXVencer");
                        int pos_isAddStock = drd.GetOrdinal("isAddStock");
                        int pos_Color = drd.GetOrdinal("Color");
                        int pos_Talla = drd.GetOrdinal("Talla");
                        //int pos_isFecVencimiento = drd.GetOrdinal("isFecVencimiento");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_IdProductoAlmacen = drd.GetOrdinal("IdProductoAlmacen");

                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_CodProdLaboratorio = drd.GetOrdinal("CodProdLaboratorio");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_DesProdGrupo = drd.GetOrdinal("DesProdGrupo");
                        int pos_CodProdTipoPresentacion = drd.GetOrdinal("CodProdTipoPresentacion");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");
                        int pos_DesNombreGenerico = drd.GetOrdinal("DesNombreGenerico");
                        int pos_DesTipoProducto = drd.GetOrdinal("DesTipoProducto");
                        int pos_DesComposicion = drd.GetOrdinal("DesComposicion");
                        int pos_DesIndicaciones = drd.GetOrdinal("DesIndicaciones");
                        int pos_DesContraIndicaciones = drd.GetOrdinal("DesContraIndicaciones");
                        int pos_RecetaMedica = drd.GetOrdinal("RecetaMedica");
                        int pos_isGenerico = drd.GetOrdinal("isGenerico");
                        int pos_StockTotal = drd.GetOrdinal("StockTotal");
                        int pos_Val1 = drd.GetOrdinal("Val1");
                        int pos_Val2 = drd.GetOrdinal("Val2");
                        int pos_Val3 = drd.GetOrdinal("Val3");

                        lobe = new List<AsignarAlmacen_ProductoBE>();
                        while (drd.Read())
                        {
                            obe = new AsignarAlmacen_ProductoBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.CodProducto = drd.GetString(pos_CodProducto);
                            obe.Nombre = drd.GetString(pos_Nombre);
                            obe.Cantidad = 0;
                            obe.Selec = drd.GetBoolean(pos_Selec);

                            obe.CantidadTienda = drd.GetInt32(pos_CantidadTienda);
                            obe.Precio = drd.GetDecimal(pos_Precio);
                            obe.OldPrecio = drd.GetDecimal(pos_Precio);
                            obe.idProductoBase = drd.GetInt32(pos_idProductoBase);
                            obe.CantidadCaja = drd.GetInt32(pos_CantidadCaja);
                            obe.idTipo = drd.GetInt32(pos_IdTipo);
                            obe.desTipo = drd.GetString(pos_DesTipo);

                            obe.idUnidad = drd.GetString(pos_IdUnidad);
                            obe.desUnidad = drd.GetString(pos_DesUnidad);
                            obe.codUNSPSC = drd.GetString(pos_CodUNSPSC);
                            obe.FecVencimiento = drd.GetString(pos_FecVencimiento);
                            obe.isXVencer = drd.GetBoolean(pos_isXVencer);
                            obe.isAddStock = drd.GetBoolean(pos_isAddStock);
                            obe.Color = drd.GetString(pos_Color);
                            obe.Talla = drd.GetString(pos_Talla);
                            //obe.isFechaVencimiento = drd.GetBoolean(pos_isFecVencimiento);
                            obe.PrecioCosto = drd.GetDecimal(pos_PrecioCosto);
                            obe.IdProductoAlmacen = drd.GetInt32(pos_IdProductoAlmacen);
                            obe.isTipoProducto = false;
                            obe.isFechaVenProd = false;
                            obe.isCostoProduccion = false;
                            obe.Descripcion = drd.GetString(pos_Descripcion);
                            obe.CodProdLaboratorio = drd.GetString(pos_CodProdLaboratorio);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.DesProdGrupo = drd.GetString(pos_DesProdGrupo);
                            obe.CodProdTipoPresentacion = drd.GetString(pos_CodProdTipoPresentacion);
                            obe.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);
                            obe.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obe.DesTipoProducto = drd.GetString(pos_DesTipoProducto);
                            obe.DesComposicion = drd.GetString(pos_DesComposicion);
                            obe.DesIndicaciones = drd.GetString(pos_DesIndicaciones);
                            obe.DesContraIndicaciones = drd.GetString(pos_DesContraIndicaciones);
                            obe.RecetaMedica = drd.GetString(pos_RecetaMedica);
                            obe.isGenerico = drd.GetString(pos_isGenerico);
                            //-----
                            obe.Val1 = drd.GetBoolean(pos_Val1);
                            obe.Val2 = drd.GetBoolean(pos_Val2);
                            obe.Val3 = drd.GetBoolean(pos_Val3);
                            obe.StockTotal = drd.GetInt32(pos_StockTotal);

                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }
        //LISTA TIPOS DE PRODUCTOS POR TIENDA
        public List<AsignarAlmacen_ProductoBE> ListaTipoProductoXTienda(SqlConnection cnBD, string usuario, int idCliente, int idTienda)
        {
            List<AsignarAlmacen_ProductoBE> lobe = null;
            AsignarAlmacen_ProductoBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ListaTipoProductoXTienda]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@idTienda", SqlDbType.Int).Value = idTienda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Nombre = drd.GetOrdinal("Nombre");

                        lobe = new List<AsignarAlmacen_ProductoBE>();
                        while (drd.Read())
                        {
                            obe = new AsignarAlmacen_ProductoBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Nombre = drd.GetString(pos_Nombre);

                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<AsignarAlmacen_ProductoBE> ListaProductoXTiendaEnStock(SqlConnection cnBD, string usuario, int idCliente, int idTienda)
        {
            List<AsignarAlmacen_ProductoBE> lobe = new List<AsignarAlmacen_ProductoBE>();
            AsignarAlmacen_ProductoBE obe = new AsignarAlmacen_ProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ListaProductoXTiendaEnStock]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@idTienda", SqlDbType.Int).Value = idTienda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Nombre = drd.GetOrdinal("Nombre");
                        int pos_Selec = drd.GetOrdinal("Selec");

                        int pos_CantidadTienda = drd.GetOrdinal("CantidadTienda");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_idProductoBase = drd.GetOrdinal("idProductoBase");
                        int pos_CantidadCaja = drd.GetOrdinal("CantidadCaja");
                        int pos_IdTipo = drd.GetOrdinal("IdTipo");

                        int pos_IdUnidad = drd.GetOrdinal("IdUnidad");
                        int pos_DesUnidad = drd.GetOrdinal("DesUnidad");
                        int pos_CodUNSPSC = drd.GetOrdinal("CodUNSPSC");
                        int pos_FecVencimiento = drd.GetOrdinal("FecVencimiento");
                        int pos_isXVencer = drd.GetOrdinal("isXVencer");
                        int pos_isAddStock = drd.GetOrdinal("isAddStock");
                        int pos_Color = drd.GetOrdinal("Color");
                        int pos_Talla = drd.GetOrdinal("Talla");
                        //int pos_isFecVencimiento = drd.GetOrdinal("isFecVencimiento");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_IdProductoAlmacen = drd.GetOrdinal("IdProductoAlmacen");

                        lobe = new List<AsignarAlmacen_ProductoBE>();
                        while (drd.Read())
                        {
                            obe = new AsignarAlmacen_ProductoBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Nombre = drd.GetString(pos_Nombre);
                            obe.Cantidad = 0;
                            obe.Selec = drd.GetBoolean(pos_Selec);

                            obe.CantidadTienda = drd.GetInt32(pos_CantidadTienda);
                            obe.Precio = drd.GetDecimal(pos_Precio);
                            obe.OldPrecio = drd.GetDecimal(pos_Precio);
                            obe.idProductoBase = drd.GetInt32(pos_idProductoBase);
                            obe.CantidadCaja = drd.GetInt32(pos_CantidadCaja);
                            obe.idTipo = drd.GetInt32(pos_IdTipo);
                            obe.idUnidad = drd.GetString(pos_IdUnidad);
                            obe.desUnidad = drd.GetString(pos_DesUnidad);
                            obe.codUNSPSC = drd.GetString(pos_CodUNSPSC);
                            obe.FecVencimiento = drd.GetString(pos_FecVencimiento);
                            obe.isXVencer = drd.GetBoolean(pos_isXVencer);
                            obe.isAddStock = drd.GetBoolean(pos_isAddStock);
                            obe.Color = drd.GetString(pos_Color);
                            obe.Talla = drd.GetString(pos_Talla);
                            //obe.isFechaVencimiento = drd.GetBoolean(pos_isFecVencimiento);
                            obe.PrecioCosto = drd.GetDecimal(pos_PrecioCosto);
                            obe.IdProductoAlmacen = drd.GetInt32(pos_IdProductoAlmacen);
                            obe.isTipoProducto = false;
                            obe.isFechaVenProd = false;
                            obe.isCostoProduccion = false;
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaComboBE> ComboTipoProducto(SqlConnection cnBD, string usuario, int idCliente)
        {
            List<ListaComboBE> lobe = null;
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ComboTipoProducto]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("codigo");
                        int pos_Descripcion = drd.GetOrdinal("descripcion");
                        int pos_isTipoParent = drd.GetOrdinal("isTipoParent");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            obe.isTipoParent = drd.GetInt32(pos_isTipoParent);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaArchivosAdjuntos> ListarImagenProducto(SqlConnection cnBD, string usuario, int idProducto)
        {
            List<ListaArchivosAdjuntos> lobe = null;
            ListaArchivosAdjuntos obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_ListaImagenProducto]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_URLProducto = drd.GetOrdinal("URLProducto");
                        // COLUMNAS DETALLE
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_DesNombreGenerico = drd.GetOrdinal("DesNombreGenerico");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_DesProdGrupo = drd.GetOrdinal("DesProdGrupo");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");
                        int pos_DesTipoProducto = drd.GetOrdinal("DesTipoProducto");
                        int pos_DesComposicion = drd.GetOrdinal("DesComposicion");
                        int pos_DesIndicaciones = drd.GetOrdinal("DesIndicaciones");
                        int pos_DesContraIndicaciones = drd.GetOrdinal("DesContraIndicaciones");

                        lobe = new List<ListaArchivosAdjuntos>();
                        while (drd.Read())
                        {
                            obe = new ListaArchivosAdjuntos();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.URL = drd.GetString(pos_URLProducto);
                            //DETALLE
                            obe.Descripcion = drd.GetString(pos_Descripcion);
                            obe.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.DesProdGrupo = drd.GetString(pos_DesProdGrupo);
                            obe.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);
                            obe.DesTipoProducto = drd.GetString(pos_DesTipoProducto);
                            obe.DesComposicion = drd.GetString(pos_DesComposicion);
                            obe.DesIndicaciones = drd.GetString(pos_DesIndicaciones);
                            obe.DesContraIndicaciones = drd.GetString(pos_DesContraIndicaciones);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public List<ListaComboBE> Talla(SqlConnection cnBD, string usuario)
        {
            List<ListaComboBE> lobe = null;
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_Talla]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public List<ListaComboBE> Color(SqlConnection cnBD, string usuario)
        {
            List<ListaComboBE> lobe = null;
            ListaComboBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_Color]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        lobe = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboBE();
                            obe.codigo = drd.GetInt32(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        //BUSQUEDA DE CLIENTE
        public List<ListaComboTextBE> ConsultarClienteVenta(SqlConnection cnBD, string usuario, int idCliente, string desCliente)
        {
            List<ListaComboTextBE> lobe = new List<ListaComboTextBE>();
            ListaComboTextBE obe = new ListaComboTextBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Maestro_BusquedaClienteVenta]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar,150).Value = desCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("codigo");
                        int pos_Descripcion = drd.GetOrdinal("descripcion");

                        lobe = new List<ListaComboTextBE>();
                        while (drd.Read())
                        {
                            obe = new ListaComboTextBE();
                            obe.codigo = drd.GetString(pos_Codigo);
                            obe.descripcion = drd.GetString(pos_Descripcion);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }
    }
}
