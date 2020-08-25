using Entidades.Almacen.AsignarAlmacen;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Almacen.AsignarAlmacen
{
    public class AsignarAlmacenDA
    {
        public List<AsignarAlmacenBE> ListarDatosIniciales(SqlConnection cnBD, string usuario, List<ListaComboBE> loAlmacen)
        {
            List<AsignarAlmacenBE> lobe = new List<AsignarAlmacenBE>();
            AsignarAlmacenBE obe = new AsignarAlmacenBE();

            List<AsignarAlmacen_ProductoBE> lobeP = new List<AsignarAlmacen_ProductoBE>();
            AsignarAlmacen_ProductoBE obeP = new AsignarAlmacen_ProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Almacen_AsignarAlmacen_Lista]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region parametros
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_IdAlmacen = drd.GetOrdinal("IdAlmacen");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FchModificacion = drd.GetOrdinal("FchModificacion");
                        #endregion parametros
                        lobe = new List<AsignarAlmacenBE>();
                        while (drd.Read())
                        {
                            #region variables
                            obe = new AsignarAlmacenBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.IdAlmacen = drd.GetInt32(pos_IdAlmacen);
                            obe.Nombre = "";
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.UsrModificador = drd.GetString(pos_UsrModificador);
                            obe.FchModificacion = drd.GetString(pos_FchModificacion);
                            obe.loProducto = new List<AsignarAlmacen_ProductoBE>();

                            int index = loAlmacen.FindIndex(det => det.codigo == obe.IdAlmacen);
                            if (index != -1)
                            {
                                obe.Nombre = loAlmacen[index].descripcion;
                                lobe.Add(obe);
                            }
                            //lobe.Add(obe);
                            #endregion variables
                        }
                    }
                    /*drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region parametros
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Nombre = drd.GetOrdinal("Nombre");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_IdTipo = drd.GetOrdinal("IdTipo");
                        int pos_CantidadCaja = drd.GetOrdinal("CantidadCaja");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_Selec = drd.GetOrdinal("Selec");
                        int pos_IdAlmacen = drd.GetOrdinal("IdAlmacen");
                        int pos_CantidadTienda = drd.GetOrdinal("CantidadTienda");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_isBase = drd.GetOrdinal("isBase");
                        #endregion parametros
                        while (drd.Read())
                        {
                            #region variables
                            obeP = new AsignarAlmacen_ProductoBE();
                            int idAlmacen = drd.GetInt32(pos_IdAlmacen);
                            obeP.Id = drd.GetInt32(pos_Id);
                            obeP.Nombre = drd.GetString(pos_Nombre);
                            obeP.Cantidad = drd.GetInt32(pos_Cantidad);
                            obeP.CantidadTienda = drd.GetInt32(pos_CantidadTienda);
                            obeP.Precio = drd.GetDecimal(pos_Precio);
                            obeP.OldPrecio = drd.GetDecimal(pos_Precio);
                            obeP.Selec = drd.GetBoolean(pos_Selec);
                            obeP.PrecioCosto = drd.GetDecimal(pos_PrecioCosto);
                            obeP.idTipo = drd.GetInt32(pos_IdTipo);
                            obeP.CantidadCaja = drd.GetInt32(pos_CantidadCaja);
                            obeP.loTipoProducto = new List<ListaComboBE>();

                            obeP.isTipoBase = drd.GetBoolean(pos_isBase);
                            obeP.isTipoProducto = false;
                            obeP.isFechaVenProd = false;
                            obeP.isCostoProduccion = false;
                            #endregion variables
                            int index = lobe.FindIndex(det => det.IdAlmacen == idAlmacen);
                            if (index != -1)
                            {
                                lobe[index].loProducto.Add(obeP);
                            }
                        }
                    }*/
                }
            }
            return lobe;
        }

        public List<AsignarAlmacen_ProductoBE> ListarProductosAlmacenTienda(SqlConnection cnBD, string usuario, int idAlmacen, int idTienda)
        {
            List<AsignarAlmacen_ProductoBE> lobe = new List<AsignarAlmacen_ProductoBE>();
            AsignarAlmacen_ProductoBE obe = new AsignarAlmacen_ProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Almacen_AsignarAlmacen_ProductosTienda]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = idAlmacen;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region parametros
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Nombre = drd.GetOrdinal("Nombre");
                        int pos_CodProducto = drd.GetOrdinal("CodProducto");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_IdTipo = drd.GetOrdinal("IdTipo");
                        int pos_CantidadCaja = drd.GetOrdinal("CantidadCaja");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_Selec = drd.GetOrdinal("Selec");
                        int pos_IdAlmacen = drd.GetOrdinal("IdAlmacen");
                        int pos_CantidadTienda = drd.GetOrdinal("CantidadTienda");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        //int pos_PrecioBlister = drd.GetOrdinal("PrecioBlister");
                        int pos_PrecioBase = drd.GetOrdinal("PrecioBase");
                        int pos_isBase = drd.GetOrdinal("isBase");
                        int pos_Ubicacion = drd.GetOrdinal("Ubicacion");
                        int pos_Lote = drd.GetOrdinal("Lote");
                        #endregion parametros
                        while (drd.Read())
                        {
                            #region variables
                            obe = new AsignarAlmacen_ProductoBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Nombre = drd.GetString(pos_Nombre);
                            obe.CodProducto = drd.GetString(pos_CodProducto);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.Cantidad = drd.GetInt32(pos_Cantidad);
                            obe.Stock = drd.GetInt32(pos_Stock);
                            obe.CantidadTienda = drd.GetInt32(pos_CantidadTienda);
                            obe.Precio = drd.GetDecimal(pos_Precio);
                            //obe.PrecioBlister = drd.GetDecimal(pos_PrecioBlister);
                            obe.OldPrecio = drd.GetDecimal(pos_Precio);
                            //obe.OldPrecioBlister = drd.GetDecimal(pos_PrecioBlister);
                            obe.PrecioBase = drd.GetDecimal(pos_PrecioBase);
                            obe.Selec = drd.GetBoolean(pos_Selec);
                            obe.PrecioCosto = drd.GetDecimal(pos_PrecioCosto);
                            obe.idTipo = drd.GetInt32(pos_IdTipo);
                            obe.CantidadCaja = drd.GetInt32(pos_CantidadCaja);
                            obe.loTipoProducto = new List<ListaComboBE>();
                            obe.FecVencimiento = new DateTime(1900, 1, 1, 0, 0, 0, 0).ToString();
                            obe.isTipoBase = drd.GetBoolean(pos_isBase);
                            obe.isTipoProducto = false;
                            obe.isFechaVenProd = false;
                            obe.isCostoProduccion = false;
                            obe.isUbicacion = false;
                            obe.Ubicacion = drd.GetString(pos_Ubicacion);
                            obe.Lote = drd.GetString(pos_Lote);
                            #endregion variables
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        private DataTable CrearEstructura(List<AsignarAlmacen_ProductoBE> lobe)
        {
            DataTable dataT = new DataTable();
            DataRow dRow;
            dataT.Columns.Add(new DataColumn("Id"));
            dataT.Columns.Add(new DataColumn("Nombre"));
            dataT.Columns.Add(new DataColumn("Cantidad"));
            dataT.Columns.Add(new DataColumn("CantidadTienda"));
            dataT.Columns.Add(new DataColumn("Precio"));
            dataT.Columns.Add(new DataColumn("PrecioBlister"));
            dataT.Columns.Add(new DataColumn("OldPrecio"));
            dataT.Columns.Add(new DataColumn("OldPrecioBlister"));
            dataT.Columns.Add(new DataColumn("CantidadCaja"));
            dataT.Columns.Add(new DataColumn("PrecioCosto"));
            dataT.Columns.Add(new DataColumn("IdTipo"));
            dataT.Columns.Add(new DataColumn("FecVencimiento"));
            dataT.Columns.Add(new DataColumn("DireccionCosto"));
            dataT.Columns.Add(new DataColumn("Ubicacion"));
            dataT.Columns.Add(new DataColumn("Lote"));
            dataT.Columns.Add(new DataColumn("RegistroSanitario"));

            if (lobe != null && lobe.Count > 0)
            {
                for (int i = 0; i < lobe.Count; i++)
                {
                    object[] RowValues = { lobe[i].Id, lobe[i].Nombre, lobe[i].Cantidad,
                                            lobe[i].CantidadTienda, lobe[i].Precio, lobe[i].PrecioBlister, lobe[i].OldPrecio,
                                            lobe[i].OldPrecioBlister, lobe[i].CantidadCaja, lobe[i].PrecioCosto, lobe[i].idTipo,
                                            Convert.ToDateTime(lobe[i].FecVencimiento).ToString("yyyy-MM-dd HH:mm:ss"),
                                            lobe[i].DireccionCosto, lobe[i].Ubicacion, lobe[i].Lote, lobe[i].RegistroSanitario};
                    dRow = dataT.Rows.Add(RowValues);
                }
            }
            dataT.AcceptChanges();
            return dataT;
        }

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, AsignarAlmacenBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Almacen_AsignarAlmacen_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = obe.IdAlmacen;
                cmd.Parameters.Add("@BoletaCompra", SqlDbType.VarChar, 20).Value = obe.BoletaCompra;
                cmd.Parameters.Add("@RazonCompra", SqlDbType.VarChar,250).Value = obe.RazonCompra;
                cmd.Parameters.Add("@RucCompra", SqlDbType.VarChar,11).Value = obe.RucCompra;
                cmd.Parameters.Add("@DireccionCompra", SqlDbType.VarChar,250).Value = obe.DireccionCompra;
                cmd.Parameters.Add("@loProducto", SqlDbType.Structured).Value = CrearEstructura(obe.loProducto);
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;

                int counterMarker = 0;
                object objRes = cmd.ExecuteScalar();
                int.TryParse(objRes.ToString(), out counterMarker);
                if (counterMarker > 0)
                {
                    rpta = true;
                }
                else
                {
                    msjError = objRes.ToString();
                    rpta = false;
                }
            }
            return rpta;
        }

        public bool GuardarTienda(SqlConnection cnBD, SqlTransaction trx, AsignarAlmacenBE obe)
        {
            bool rpta = false;
            string msjError = "Productos no tienen Stock en Almacén:\n";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Almacen_AsignarAlmacen_GuardarTienda]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = obe.IdAlmacen;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = obe.IdTienda;
                cmd.Parameters.Add("@NroGuia", SqlDbType.VarChar, 50).Value = obe.NroGuia;
                cmd.Parameters.Add("@FechaGuia", SqlDbType.DateTime).Value = obe.FechaGuia;
                cmd.Parameters.Add("@isCostoProduccion", SqlDbType.Bit).Value = obe.isCostoProduccion;
                cmd.Parameters.Add("@loProducto", SqlDbType.Structured).Value = CrearEstructura(obe.loProducto);
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region parametros
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_CantidadTienda = drd.GetOrdinal("CantidadTienda");
                        int pos_IdProductoAlmacen = drd.GetOrdinal("IdProductoAlmacen");
                        int pos_Nombre = drd.GetOrdinal("Nombre");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        #endregion parametros
                        while (drd.Read())
                        {
                            int Codigo = drd.GetInt32(pos_Codigo);
                            if (Codigo == 1)
                            {
                                rpta = true;
                            }
                            else
                            {
                                msjError = "Nombre: " + drd.GetString(pos_Nombre) + " - Precio Unitario: " + drd.GetDecimal(pos_PrecioCosto) + "\n";
                                rpta = false;
                            }
                        }
                    }
                }
            }
            return rpta;
        }
        /*
        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, AsignarAlmacenBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Almacen_AsignarAlmacen_Actualizar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@IdComprobante", SqlDbType.Int).Value = obe.IdComprobante;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = obe.IdTienda;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 150).Value = obe.DesCliente;
                cmd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = obe.Correlativo;
                cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 5).Value = obe.Serie;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;

                int counterMarker = 0;
                object objRes = cmd.ExecuteScalar();
                int.TryParse(objRes.ToString(), out counterMarker);
                if (counterMarker > 0)
                {
                    rpta = true;
                }
                else
                {
                    msjError = objRes.ToString();
                    rpta = false;
                }
            }
            return rpta;
        }

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, AsignarAlmacenBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Almacen_AsignarAlmacen_Eliminar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrModificador;

                int counterMarker = 0;
                object objRes = cmd.ExecuteScalar();
                int.TryParse(objRes.ToString(), out counterMarker);
                if (counterMarker > 0)
                {
                    rpta = true;
                }
                else
                {
                    msjError = objRes.ToString();
                    rpta = false;
                }
            }
            return rpta;
        }
        */
    }
}
