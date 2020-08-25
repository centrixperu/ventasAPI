using Entidades.ControlStock;
using Entidades.ControlStockReporte;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.ControlStock
{
    public class ControlStockDA
    {
        public ControlStockGBE ListaProductoXTienda(SqlConnection cnBD, string usuario, int idCliente, int idAlmacen, int idTienda)
        {
            ControlStockGBE obeCS = new ControlStockGBE();

            List<ControlStockBE> lobe = new List<ControlStockBE>();
            ControlStockBE obe = new ControlStockBE();

            List<ControlStockBEReporte> lobeR = new List<ControlStockBEReporte>();
            ControlStockBEReporte obeR = new ControlStockBEReporte();

            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ControlStock_Productos]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = idAlmacen;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_IdProductoAlmacen = drd.GetOrdinal("IdProductoAlmacen");
                        int pos_IdAlmacen = drd.GetOrdinal("IdAlmacen");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_CodProducto = drd.GetOrdinal("CodProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_idProductoBase = drd.GetOrdinal("idProductoBase");
                        int pos_StockTotal = drd.GetOrdinal("StockTotal");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_PrecioBlister = drd.GetOrdinal("PrecioBlister");
                        int pos_IdTipo = drd.GetOrdinal("IdTipo");
                        int pos_DesTipo = drd.GetOrdinal("DesTipo");
                        int pos_CodProdLaboratorio = drd.GetOrdinal("CodProdLaboratorio");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_CodProdTipoPresentacion = drd.GetOrdinal("CodProdTipoPresentacion");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");
                        int pos_RegistroSanitario = drd.GetOrdinal("RegistroSanitario");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_CantidadCaja = drd.GetOrdinal("CantidadCaja");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_FecVencimiento = drd.GetOrdinal("FecVencimiento");
                        int pos_DetalleStock = drd.GetOrdinal("DetalleStock");
                        int pos_StockN = drd.GetOrdinal("StockN");
                        int pos_PrecioN = drd.GetOrdinal("PrecioN");
                        int pos_PrecioBlisterN = drd.GetOrdinal("PrecioBlisterN");
                        int pos_RecetaMedica = drd.GetOrdinal("RecetaMedica");
                        int pos_Val1 = drd.GetOrdinal("Val1");
                        int pos_Val2 = drd.GetOrdinal("Val2");
                        int pos_Val3 = drd.GetOrdinal("Val3");

                        lobe = new List<ControlStockBE>();
                        while (drd.Read())
                        {
                            obe = new ControlStockBE();
                            obe.IdProductoAlmacen = drd.GetInt64(pos_IdProductoAlmacen);
                            obe.IdAlmacen = drd.GetInt32(pos_IdAlmacen);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            obe.CodProducto = drd.GetString(pos_CodProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.idProductoBase = drd.GetInt32(pos_idProductoBase);
                            obe.StockTotal = drd.GetInt32(pos_StockTotal);
                            obe.Stock = drd.GetInt32(pos_Stock);
                            obe.Precio = drd.GetDecimal(pos_Precio);
                            obe.PrecioBlister = drd.GetDecimal(pos_PrecioBlister);
                            obe.IdTipo = drd.GetInt32(pos_IdTipo);
                            obe.DesTipo = drd.GetString(pos_DesTipo);
                            obe.CodProdLaboratorio = drd.GetString(pos_CodProdLaboratorio);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.CodProdTipoPresentacion = drd.GetString(pos_CodProdTipoPresentacion);
                            obe.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);
                            obe.RegistroSanitario = drd.GetString(pos_RegistroSanitario);
                            obe.Cantidad = drd.GetInt32(pos_Cantidad);
                            obe.CantidadCaja = drd.GetInt32(pos_CantidadCaja);
                            obe.PrecioCosto = drd.GetDecimal(pos_PrecioCosto);
                            obe.FecVencimiento = drd.GetString(pos_FecVencimiento);
                            obe.DetalleStock = drd.GetString(pos_DetalleStock);
                            obe.StockN = drd.GetInt32(pos_StockN);
                            obe.PrecioN = drd.GetDecimal(pos_PrecioN);
                            obe.PrecioBlisterN = drd.GetDecimal(pos_PrecioBlisterN);
                            obe.RecetaMedica = drd.GetString(pos_RecetaMedica);
                            obe.Val1 = drd.GetBoolean(pos_Val1);
                            obe.Val2 = drd.GetBoolean(pos_Val2);
                            obe.Val3 = drd.GetBoolean(pos_Val3);
                            lobe.Add(obe);
                        }
                        obeCS.listado = lobe;
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        int pos_IdProductoAlmacen = drd.GetOrdinal("IdProductoAlmacen");
                        int pos_IdAlmacen = drd.GetOrdinal("IdAlmacen");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_CodProducto = drd.GetOrdinal("CodProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_StockTotal = drd.GetOrdinal("StockTotal");
                        int pos_IdTipo = drd.GetOrdinal("IdTipo");
                        int pos_DesTipo = drd.GetOrdinal("DesTipo");
                        int pos_CodProdLaboratorio = drd.GetOrdinal("CodProdLaboratorio");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_CodProdTipoPresentacion = drd.GetOrdinal("CodProdTipoPresentacion");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");
                        int pos_RegistroSanitario = drd.GetOrdinal("RegistroSanitario");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_PrecioBlister = drd.GetOrdinal("PrecioBlister");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_FecVencimiento = drd.GetOrdinal("FecVencimiento");

                        lobeR = new List<ControlStockBEReporte>();
                        while (drd.Read())
                        {
                            obeR = new ControlStockBEReporte();
                            obeR.IdProductoAlmacen = drd.GetInt64(pos_IdProductoAlmacen);
                            obeR.IdAlmacen = drd.GetInt32(pos_IdAlmacen);
                            obeR.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeR.IdProducto = drd.GetInt32(pos_IdProducto);
                            obeR.CodProducto = drd.GetString(pos_CodProducto);
                            obeR.NombreProducto = drd.GetString(pos_NombreProducto);
                            obeR.StockTotal = drd.GetInt32(pos_StockTotal);
                            obeR.IdTipo = drd.GetInt32(pos_IdTipo);
                            obeR.DesTipo = drd.GetString(pos_DesTipo);
                            obeR.CodProdLaboratorio = drd.GetString(pos_CodProdLaboratorio);
                            obeR.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obeR.CodProdTipoPresentacion = drd.GetString(pos_CodProdTipoPresentacion);
                            obeR.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);
                            obeR.RegistroSanitario = drd.GetString(pos_RegistroSanitario);
                            obeR.Precio = drd.GetDecimal(pos_Precio);
                            obeR.PrecioBlister = drd.GetDecimal(pos_PrecioBlister);
                            obeR.PrecioCosto = drd.GetDecimal(pos_PrecioCosto);
                            obeR.FecVencimiento = drd.GetString(pos_FecVencimiento);
                            lobeR.Add(obeR);
                        }
                        obeCS.listadoReporte = lobeR;
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region ColumnasLista - columnas
                        int pos_field = drd.GetOrdinal("field");
                        int pos_header = drd.GetOrdinal("header");
                        int pos_width = drd.GetOrdinal("width");
                        #endregion ColumnasLista - columnas
                        loColumns = new List<ReporteColumnas>();
                        while (drd.Read())
                        {
                            #region ColumnasLista - campos
                            obeColumns = new ReporteColumnas();
                            obeColumns.field = drd.GetString(pos_field);
                            obeColumns.header = drd.GetString(pos_header);
                            obeColumns.width = drd.GetInt32(pos_width);
                            loColumns.Add(obeColumns);
                            #endregion ColumnasLista - campos
                        }
                        obeCS.columnas = loColumns;
                    }
                }
            }
            return obeCS;
        }

        private DataTable CrearEstructura(List<ControlStockBE> lobe)
        {
            DataTable dataT = new DataTable();
            DataRow dRow;
            dataT.Columns.Add(new DataColumn("IdProductoAlmacen"));
            dataT.Columns.Add(new DataColumn("IdAlmacen"));
            dataT.Columns.Add(new DataColumn("IdTienda"));
            dataT.Columns.Add(new DataColumn("IdProducto"));
            dataT.Columns.Add(new DataColumn("CodProducto"));
            dataT.Columns.Add(new DataColumn("NombreProducto"));
            dataT.Columns.Add(new DataColumn("Stock"));
            dataT.Columns.Add(new DataColumn("Precio"));
            dataT.Columns.Add(new DataColumn("PrecioBlister"));
            dataT.Columns.Add(new DataColumn("IdTipo"));
            dataT.Columns.Add(new DataColumn("DesTipo"));
            dataT.Columns.Add(new DataColumn("CodProdLaboratorio"));
            dataT.Columns.Add(new DataColumn("DesProdLaboratorio"));
            dataT.Columns.Add(new DataColumn("CodProdTipoPresentacion"));
            dataT.Columns.Add(new DataColumn("DesProdTipoPresentacion"));
            dataT.Columns.Add(new DataColumn("RegistroSanitario"));
            dataT.Columns.Add(new DataColumn("Cantidad"));
            dataT.Columns.Add(new DataColumn("CantidadCaja"));
            dataT.Columns.Add(new DataColumn("PrecioCosto"));
            dataT.Columns.Add(new DataColumn("FecVencimiento"));
            dataT.Columns.Add(new DataColumn("DetalleStock"));
            dataT.Columns.Add(new DataColumn("StockN"));
            dataT.Columns.Add(new DataColumn("RecetaMedica"));
            dataT.Columns.Add(new DataColumn("PrecioN"));
            dataT.Columns.Add(new DataColumn("PrecioBlisterN"));

            if (lobe != null && lobe.Count > 0)
            {
                for (int i = 0; i < lobe.Count; i++)
                {
                    object[] RowValues = { lobe[i].IdProductoAlmacen, lobe[i].IdAlmacen, lobe[i].IdTienda, lobe[i].IdProducto,
                                            lobe[i].CodProducto, lobe[i].NombreProducto, lobe[i].Stock, lobe[i].Precio, lobe[i].PrecioBlister,
                                            lobe[i].IdTipo, lobe[i].DesTipo, lobe[i].CodProdLaboratorio, lobe[i].DesProdLaboratorio,
                                            lobe[i].CodProdTipoPresentacion, lobe[i].DesProdTipoPresentacion, lobe[i].RegistroSanitario,
                                            lobe[i].Cantidad, lobe[i].CantidadCaja, lobe[i].PrecioCosto, lobe[i].FecVencimiento, 
                                            lobe[i].DetalleStock, lobe[i].StockN, lobe[i].RecetaMedica, lobe[i].PrecioN, lobe[i].PrecioBlisterN};
                    dRow = dataT.Rows.Add(RowValues);
                }
            }
            dataT.AcceptChanges();
            return dataT;
        }

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, ControlStockGBE obe)
        {
            bool rpta = false;
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ControlStock_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@lolistado", SqlDbType.Structured).Value = CrearEstructura(obe.listado);
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.usuario;

                int counterMarker = 0;
                object objRes = cmd.ExecuteScalar();
                int.TryParse(objRes.ToString(), out counterMarker);
                if (counterMarker > 0)
                {
                    rpta = true;
                }
                else
                {
                    rpta = false;
                }
            }
            return rpta;
        }

    }
}
