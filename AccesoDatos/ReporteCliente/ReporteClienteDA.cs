using Entidades.ReporteCliente;
using Entidades.ReporteCliente.Guias;
using Entidades.ReporteCliente.KardexPrecio;
using Entidades.ReporteCliente.KardexProducto;
using Entidades.ReporteCliente.VentaPrecio;
using Entidades.ReporteCliente.VentaProducto;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.ReporteCliente
{
    public class ReporteClienteDA
    {
        private DataTable CrearEstructura(List<ListaComboBE> lobe)
        {
            DataTable dataT = new DataTable();
            DataRow dRow;
            dataT.Columns.Add(new DataColumn("codigo"));
            dataT.Columns.Add(new DataColumn("descripcion"));

            if (lobe != null && lobe.Count > 0)
            {
                for (int i = 0; i < lobe.Count; i++)
                {
                    object[] RowValues = { lobe[i].codigo, lobe[i].descripcion };
                    dRow = dataT.Rows.Add(RowValues);
                }
            }
            dataT.AcceptChanges();
            return dataT;
        }

        public GuiaBE VerGuiaDia(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteGuiaBE> listado = new List<ReporteGuiaBE>();
            ReporteGuiaBE obe = new ReporteGuiaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //listado detalle
            List<ReporteGuia_DetalleBE> listadoDetalle = new List<ReporteGuia_DetalleBE>();
            ReporteGuia_DetalleBE obeDet = new ReporteGuia_DetalleBE();
            //listado detalle - columnas
            List<ReporteColumnas> loColumnsDetalle = new List<ReporteColumnas>();
            ReporteColumnas obeColumnsDetalle = new ReporteColumnas();
            //bjeto
            GuiaBE lobe = new GuiaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_GuiaDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_NroGuiaSalida = drd.GetOrdinal("NroGuiaSalida");
                        int pos_NroGuiaEntrada = drd.GetOrdinal("NroGuiaEntrada");
                        int pos_FchGuia = drd.GetOrdinal("FchGuia");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteGuiaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteGuiaBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.NroGuiaSalida = drd.GetString(pos_NroGuiaSalida);
                            obe.NroGuiaEntrada = drd.GetString(pos_NroGuiaEntrada);
                            obe.FchGuia = drd.GetString(pos_FchGuia);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region ListaDetalle - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_DesProducto = drd.GetOrdinal("DesProducto");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_CantidadCaja = drd.GetOrdinal("CantidadCaja");
                        int pos_NroGuia = drd.GetOrdinal("NroGuia");
                        int pos_TipoMovimiento = drd.GetOrdinal("TipoMovimiento");
                        #endregion ListaDetalle - columnas
                        listadoDetalle = new List<ReporteGuia_DetalleBE>();
                        while (drd.Read())
                        {
                            obeDet = new ReporteGuia_DetalleBE();
                            #region ListaDetalle - campos
                            obeDet.IdProducto = drd.GetInt32(pos_IdProducto);
                            obeDet.DesProducto = drd.GetString(pos_DesProducto);
                            obeDet.Cantidad = drd.GetInt32(pos_Cantidad);
                            obeDet.CantidadCaja = drd.GetInt32(pos_CantidadCaja);
                            obeDet.NroGuia = drd.GetString(pos_NroGuia);
                            obeDet.TipoMovimiento = drd.GetString(pos_TipoMovimiento);
                            listadoDetalle.Add(obeDet);
                            #endregion ListaDetalle - campos
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region ColumnasListaDetalle - columnas
                        int pos_field = drd.GetOrdinal("field");
                        int pos_header = drd.GetOrdinal("header");
                        int pos_width = drd.GetOrdinal("width");
                        #endregion ColumnasListaDetalle - columnas
                        loColumnsDetalle = new List<ReporteColumnas>();
                        while (drd.Read())
                        {
                            #region ColumnasListaDetalle - campos
                            obeColumnsDetalle = new ReporteColumnas();
                            obeColumnsDetalle.field = drd.GetString(pos_field);
                            obeColumnsDetalle.header = drd.GetString(pos_header);
                            obeColumnsDetalle.width = drd.GetInt32(pos_width);
                            loColumnsDetalle.Add(obeColumnsDetalle);
                            #endregion ColumnasListaDetalle - campos
                        }
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;
            lobe.listadoDetalle = listadoDetalle;
            lobe.loColumnsDetalle = loColumnsDetalle;

            return lobe;
        }

        public GuiaBE VerGuiaMes(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteGuiaBE> listado = new List<ReporteGuiaBE>();
            ReporteGuiaBE obe = new ReporteGuiaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //listado detalle
            List<ReporteGuia_DetalleBE> listadoDetalle = new List<ReporteGuia_DetalleBE>();
            ReporteGuia_DetalleBE obeDet = new ReporteGuia_DetalleBE();
            //listado detalle - columnas
            List<ReporteColumnas> loColumnsDetalle = new List<ReporteColumnas>();
            ReporteColumnas obeColumnsDetalle = new ReporteColumnas();
            //bjeto
            GuiaBE lobe = new GuiaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_GuiaMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_NroGuiaSalida = drd.GetOrdinal("NroGuiaSalida");
                        int pos_NroGuiaEntrada = drd.GetOrdinal("NroGuiaEntrada");
                        int pos_FchGuia = drd.GetOrdinal("FchGuia");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteGuiaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteGuiaBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.NroGuiaSalida = drd.GetString(pos_NroGuiaSalida);
                            obe.NroGuiaEntrada = drd.GetString(pos_NroGuiaEntrada);
                            obe.FchGuia = drd.GetString(pos_FchGuia);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region ListaDetalle - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_DesProducto = drd.GetOrdinal("DesProducto");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_CantidadCaja = drd.GetOrdinal("CantidadCaja");
                        int pos_NroGuia = drd.GetOrdinal("NroGuia");
                        int pos_TipoMovimiento = drd.GetOrdinal("TipoMovimiento");
                        #endregion ListaDetalle - columnas
                        listadoDetalle = new List<ReporteGuia_DetalleBE>();
                        while (drd.Read())
                        {
                            obeDet = new ReporteGuia_DetalleBE();
                            #region ListaDetalle - campos
                            obeDet.IdProducto = drd.GetInt32(pos_IdProducto);
                            obeDet.DesProducto = drd.GetString(pos_DesProducto);
                            obeDet.Cantidad = drd.GetInt32(pos_Cantidad);
                            obeDet.CantidadCaja = drd.GetInt32(pos_CantidadCaja);
                            obeDet.NroGuia = drd.GetString(pos_NroGuia);
                            obeDet.TipoMovimiento = drd.GetString(pos_TipoMovimiento);
                            listadoDetalle.Add(obeDet);
                            #endregion ListaDetalle - campos
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region ColumnasListaDetalle - columnas
                        int pos_field = drd.GetOrdinal("field");
                        int pos_header = drd.GetOrdinal("header");
                        int pos_width = drd.GetOrdinal("width");
                        #endregion ColumnasListaDetalle - columnas
                        loColumnsDetalle = new List<ReporteColumnas>();
                        while (drd.Read())
                        {
                            #region ColumnasListaDetalle - campos
                            obeColumnsDetalle = new ReporteColumnas();
                            obeColumnsDetalle.field = drd.GetString(pos_field);
                            obeColumnsDetalle.header = drd.GetString(pos_header);
                            obeColumnsDetalle.width = drd.GetInt32(pos_width);
                            loColumnsDetalle.Add(obeColumnsDetalle);
                            #endregion ColumnasListaDetalle - campos
                        }
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;
            lobe.listadoDetalle = listadoDetalle;
            lobe.loColumnsDetalle = loColumnsDetalle;

            return lobe;
        }

        public GuiaBE VerGuiaAnio(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteGuiaBE> listado = new List<ReporteGuiaBE>();
            ReporteGuiaBE obe = new ReporteGuiaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //listado detalle
            List<ReporteGuia_DetalleBE> listadoDetalle = new List<ReporteGuia_DetalleBE>();
            ReporteGuia_DetalleBE obeDet = new ReporteGuia_DetalleBE();
            //listado detalle - columnas
            List<ReporteColumnas> loColumnsDetalle = new List<ReporteColumnas>();
            ReporteColumnas obeColumnsDetalle = new ReporteColumnas();
            //bjeto
            GuiaBE lobe = new GuiaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_GuiaAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_NroGuiaSalida = drd.GetOrdinal("NroGuiaSalida");
                        int pos_NroGuiaEntrada = drd.GetOrdinal("NroGuiaEntrada");
                        int pos_FchGuia = drd.GetOrdinal("FchGuia");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteGuiaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteGuiaBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.NroGuiaSalida = drd.GetString(pos_NroGuiaSalida);
                            obe.NroGuiaEntrada = drd.GetString(pos_NroGuiaEntrada);
                            obe.FchGuia = drd.GetString(pos_FchGuia);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region ListaDetalle - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_DesProducto = drd.GetOrdinal("DesProducto");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_CantidadCaja = drd.GetOrdinal("CantidadCaja");
                        int pos_NroGuia = drd.GetOrdinal("NroGuia");
                        int pos_TipoMovimiento = drd.GetOrdinal("TipoMovimiento");
                        #endregion ListaDetalle - columnas
                        listadoDetalle = new List<ReporteGuia_DetalleBE>();
                        while (drd.Read())
                        {
                            obeDet = new ReporteGuia_DetalleBE();
                            #region ListaDetalle - campos
                            obeDet.IdProducto = drd.GetInt32(pos_IdProducto);
                            obeDet.DesProducto = drd.GetString(pos_DesProducto);
                            obeDet.Cantidad = drd.GetInt32(pos_Cantidad);
                            obeDet.CantidadCaja = drd.GetInt32(pos_CantidadCaja);
                            obeDet.NroGuia = drd.GetString(pos_NroGuia);
                            obeDet.TipoMovimiento = drd.GetString(pos_TipoMovimiento);
                            listadoDetalle.Add(obeDet);
                            #endregion ListaDetalle - campos
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region ColumnasListaDetalle - columnas
                        int pos_field = drd.GetOrdinal("field");
                        int pos_header = drd.GetOrdinal("header");
                        int pos_width = drd.GetOrdinal("width");
                        #endregion ColumnasListaDetalle - columnas
                        loColumnsDetalle = new List<ReporteColumnas>();
                        while (drd.Read())
                        {
                            #region ColumnasListaDetalle - campos
                            obeColumnsDetalle = new ReporteColumnas();
                            obeColumnsDetalle.field = drd.GetString(pos_field);
                            obeColumnsDetalle.header = drd.GetString(pos_header);
                            obeColumnsDetalle.width = drd.GetInt32(pos_width);
                            loColumnsDetalle.Add(obeColumnsDetalle);
                            #endregion ColumnasListaDetalle - campos
                        }
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;
            lobe.listadoDetalle = listadoDetalle;
            lobe.loColumnsDetalle = loColumnsDetalle;

            return lobe;
        }

        public GuiaBE VerGuiaRango(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, string fechaFin, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteGuiaBE> listado = new List<ReporteGuiaBE>();
            ReporteGuiaBE obe = new ReporteGuiaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //listado detalle
            List<ReporteGuia_DetalleBE> listadoDetalle = new List<ReporteGuia_DetalleBE>();
            ReporteGuia_DetalleBE obeDet = new ReporteGuia_DetalleBE();
            //listado detalle - columnas
            List<ReporteColumnas> loColumnsDetalle = new List<ReporteColumnas>();
            ReporteColumnas obeColumnsDetalle = new ReporteColumnas();
            //bjeto
            GuiaBE lobe = new GuiaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_GuiaRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_NroGuiaSalida = drd.GetOrdinal("NroGuiaSalida");
                        int pos_NroGuiaEntrada = drd.GetOrdinal("NroGuiaEntrada");
                        int pos_FchGuia = drd.GetOrdinal("FchGuia");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_FechaFinReporte = drd.GetOrdinal("FechaFinReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteGuiaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteGuiaBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.NroGuiaSalida = drd.GetString(pos_NroGuiaSalida);
                            obe.NroGuiaEntrada = drd.GetString(pos_NroGuiaEntrada);
                            obe.FchGuia = drd.GetString(pos_FchGuia);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.FechaFinReporte = drd.GetString(pos_FechaFinReporte);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                            obeColumns = new ReporteColumnas();
                            #region ColumnasLista - campos
                            obeColumns.field = drd.GetString(pos_field);
                            obeColumns.header = drd.GetString(pos_header);
                            obeColumns.width = drd.GetInt32(pos_width);
                            loColumns.Add(obeColumns);
                            #endregion ColumnasLista - campos
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region ListaDetalle - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_DesProducto = drd.GetOrdinal("DesProducto");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_CantidadCaja = drd.GetOrdinal("CantidadCaja");
                        int pos_NroGuia = drd.GetOrdinal("NroGuia");
                        int pos_TipoMovimiento = drd.GetOrdinal("TipoMovimiento");
                        #endregion ListaDetalle - columnas
                        listadoDetalle = new List<ReporteGuia_DetalleBE>();
                        while (drd.Read())
                        {
                            obeDet = new ReporteGuia_DetalleBE();
                            #region ListaDetalle - campos
                            obeDet.IdProducto = drd.GetInt32(pos_IdProducto);
                            obeDet.DesProducto = drd.GetString(pos_DesProducto);
                            obeDet.Cantidad = drd.GetInt32(pos_Cantidad);
                            obeDet.CantidadCaja = drd.GetInt32(pos_CantidadCaja);
                            obeDet.NroGuia = drd.GetString(pos_NroGuia);
                            obeDet.TipoMovimiento = drd.GetString(pos_TipoMovimiento);
                            listadoDetalle.Add(obeDet);
                            #endregion ListaDetalle - campos
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region ColumnasListaDetalle - columnas
                        int pos_field = drd.GetOrdinal("field");
                        int pos_header = drd.GetOrdinal("header");
                        int pos_width = drd.GetOrdinal("width");
                        #endregion ColumnasListaDetalle - columnas
                        loColumnsDetalle = new List<ReporteColumnas>();
                        while (drd.Read())
                        {
                            obeColumnsDetalle = new ReporteColumnas();
                            #region ColumnasListaDetalle - campos
                            obeColumnsDetalle.field = drd.GetString(pos_field);
                            obeColumnsDetalle.header = drd.GetString(pos_header);
                            obeColumnsDetalle.width = drd.GetInt32(pos_width);
                            loColumnsDetalle.Add(obeColumnsDetalle);
                            #endregion ColumnasListaDetalle - campos
                        }
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;
            lobe.listadoDetalle = listadoDetalle;
            lobe.loColumnsDetalle = loColumnsDetalle;

            return lobe;
        }

        public VentaProductoBE VentaProductoDia(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteVentaProductoBE> listado = new List<ReporteVentaProductoBE>();
            ReporteVentaProductoBE obe = new ReporteVentaProductoBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaProductoBE lobe = new VentaProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaProductoDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_VentaTienda = drd.GetOrdinal("VentaTienda");
                        int pos_AnulacionVentaTienda = drd.GetOrdinal("AnulacionVentaTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_DescuentoVentas = drd.GetOrdinal("DescuentoVentas");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_SumaTotalVenta = drd.GetOrdinal("SumaTotalVenta");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaProductoBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaProductoBE();
                            #region Lista - campos
                            obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.VentaTienda = drd.GetString(pos_VentaTienda);
                            obe.AnulacionVentaTienda = drd.GetString(pos_AnulacionVentaTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.DescuentoVentas = drd.GetString(pos_DescuentoVentas);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.SumaTotalVenta = drd.GetString(pos_SumaTotalVenta);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public VentaProductoBE VentaProductoMes(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteVentaProductoBE> listado = new List<ReporteVentaProductoBE>();
            ReporteVentaProductoBE obe = new ReporteVentaProductoBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaProductoBE lobe = new VentaProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaProductoMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_VentaTienda = drd.GetOrdinal("VentaTienda");
                        int pos_AnulacionVentaTienda = drd.GetOrdinal("AnulacionVentaTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_DescuentoVentas = drd.GetOrdinal("DescuentoVentas");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_SumaTotalVenta = drd.GetOrdinal("SumaTotalVenta");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaProductoBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaProductoBE();
                            #region Lista - campos
                            obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.VentaTienda = drd.GetString(pos_VentaTienda);
                            obe.AnulacionVentaTienda = drd.GetString(pos_AnulacionVentaTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.DescuentoVentas = drd.GetString(pos_DescuentoVentas);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.SumaTotalVenta = drd.GetString(pos_SumaTotalVenta);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                            obeColumns = new ReporteColumnas();
                            #region ColumnasLista - campos
                            obeColumns.field = drd.GetString(pos_field);
                            obeColumns.header = drd.GetString(pos_header);
                            obeColumns.width = drd.GetInt32(pos_width);
                            loColumns.Add(obeColumns);
                            #endregion ColumnasLista - campos
                        }
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public VentaProductoBE VentaProductoAnio(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteVentaProductoBE> listado = new List<ReporteVentaProductoBE>();
            ReporteVentaProductoBE obe = new ReporteVentaProductoBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaProductoBE lobe = new VentaProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaProductoAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_VentaTienda = drd.GetOrdinal("VentaTienda");
                        int pos_AnulacionVentaTienda = drd.GetOrdinal("AnulacionVentaTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        //int pos_FechaFinReporte = drd.GetOrdinal("FechaFinReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_DescuentoVentas = drd.GetOrdinal("DescuentoVentas");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_SumaTotalVenta = drd.GetOrdinal("SumaTotalVenta");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaProductoBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaProductoBE();
                            #region Lista - campos
                            obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.VentaTienda = drd.GetString(pos_VentaTienda);
                            obe.AnulacionVentaTienda = drd.GetString(pos_AnulacionVentaTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.DescuentoVentas = drd.GetString(pos_DescuentoVentas);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.SumaTotalVenta = drd.GetString(pos_SumaTotalVenta);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public VentaProductoBE VentaProductoRango(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, string fechaFin, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteVentaProductoBE> listado = new List<ReporteVentaProductoBE>();
            ReporteVentaProductoBE obe = new ReporteVentaProductoBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaProductoBE lobe = new VentaProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaProductoRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_VentaTienda = drd.GetOrdinal("VentaTienda");
                        int pos_AnulacionVentaTienda = drd.GetOrdinal("AnulacionVentaTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_FechaFinReporte = drd.GetOrdinal("FechaFinReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_DescuentoVentas = drd.GetOrdinal("DescuentoVentas");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_SumaTotalVenta = drd.GetOrdinal("SumaTotalVenta");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaProductoBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaProductoBE();
                            #region Lista - campos
                            obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.VentaTienda = drd.GetString(pos_VentaTienda);
                            obe.AnulacionVentaTienda = drd.GetString(pos_AnulacionVentaTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.FechaFinReporte = drd.GetString(pos_FechaFinReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.DescuentoVentas = drd.GetString(pos_DescuentoVentas);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.SumaTotalVenta = drd.GetString(pos_SumaTotalVenta);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public VentaPrecioBE VentaPrecioDia(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteVentaPrecioBE> listado = new List<ReporteVentaPrecioBE>();
            ReporteVentaPrecioBE obe = new ReporteVentaPrecioBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaPrecioBE lobe = new VentaPrecioBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaPrecioDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        //int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        //int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_VentaTienda = drd.GetOrdinal("VentaTienda");
                        int pos_AnulacionVentaTienda = drd.GetOrdinal("AnulacionVentaTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_DescuentoVentas = drd.GetOrdinal("DescuentoVentas");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_SumaTotalVenta = drd.GetOrdinal("SumaTotalVenta");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaPrecioBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaPrecioBE();
                            #region Lista - campos
                            //obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            //obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.VentaTienda = drd.GetString(pos_VentaTienda);
                            obe.AnulacionVentaTienda = drd.GetString(pos_AnulacionVentaTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.DescuentoVentas = drd.GetString(pos_DescuentoVentas);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.SumaTotalVenta = drd.GetString(pos_SumaTotalVenta);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public VentaPrecioBE VentaPrecioMes(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteVentaPrecioBE> listado = new List<ReporteVentaPrecioBE>();
            ReporteVentaPrecioBE obe = new ReporteVentaPrecioBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaPrecioBE lobe = new VentaPrecioBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaPrecioMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        //int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        //int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_VentaTienda = drd.GetOrdinal("VentaTienda");
                        int pos_AnulacionVentaTienda = drd.GetOrdinal("AnulacionVentaTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_DescuentoVentas = drd.GetOrdinal("DescuentoVentas");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_SumaTotalVenta = drd.GetOrdinal("SumaTotalVenta");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaPrecioBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaPrecioBE();
                            #region Lista - campos
                            //obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            //obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.VentaTienda = drd.GetString(pos_VentaTienda);
                            obe.AnulacionVentaTienda = drd.GetString(pos_AnulacionVentaTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.DescuentoVentas = drd.GetString(pos_DescuentoVentas);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.SumaTotalVenta = drd.GetString(pos_SumaTotalVenta);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public VentaPrecioBE VentaPrecioAnio(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteVentaPrecioBE> listado = new List<ReporteVentaPrecioBE>();
            ReporteVentaPrecioBE obe = new ReporteVentaPrecioBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaPrecioBE lobe = new VentaPrecioBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaPrecioAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        //int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        //int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_VentaTienda = drd.GetOrdinal("VentaTienda");
                        int pos_AnulacionVentaTienda = drd.GetOrdinal("AnulacionVentaTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_DescuentoVentas = drd.GetOrdinal("DescuentoVentas");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_SumaTotalVenta = drd.GetOrdinal("SumaTotalVenta");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaPrecioBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaPrecioBE();
                            #region Lista - campos
                            //obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            //obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.VentaTienda = drd.GetString(pos_VentaTienda);
                            obe.AnulacionVentaTienda = drd.GetString(pos_AnulacionVentaTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.DescuentoVentas = drd.GetString(pos_DescuentoVentas);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.SumaTotalVenta = drd.GetString(pos_SumaTotalVenta);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public VentaPrecioBE VentaPrecioRango(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, string fechaFin, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteVentaPrecioBE> listado = new List<ReporteVentaPrecioBE>();
            ReporteVentaPrecioBE obe = new ReporteVentaPrecioBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaPrecioBE lobe = new VentaPrecioBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaPrecioRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        //int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        //int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_VentaTienda = drd.GetOrdinal("VentaTienda");
                        int pos_AnulacionVentaTienda = drd.GetOrdinal("AnulacionVentaTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_FechaFinReporte = drd.GetOrdinal("FechaFinReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_DescuentoVentas = drd.GetOrdinal("DescuentoVentas");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_SumaTotalVenta = drd.GetOrdinal("SumaTotalVenta");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaPrecioBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaPrecioBE();
                            #region Lista - campos
                            //obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            //obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.VentaTienda = drd.GetString(pos_VentaTienda);
                            obe.AnulacionVentaTienda = drd.GetString(pos_AnulacionVentaTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.FechaFinReporte = drd.GetString(pos_FechaFinReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.DescuentoVentas = drd.GetString(pos_DescuentoVentas);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.SumaTotalVenta = drd.GetString(pos_SumaTotalVenta);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public KardexProductoBE KardexProductoDia(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteKardexProductoBE> listado = new List<ReporteKardexProductoBE>();
            ReporteKardexProductoBE obe = new ReporteKardexProductoBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexProductoBE lobe = new KardexProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexProductoDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_Entrada = drd.GetOrdinal("Entrada");
                        int pos_EntradaTraspaso = drd.GetOrdinal("EntradaTraspaso");
                        int pos_Salida = drd.GetOrdinal("Salida");
                        int pos_SalidaTraspaso = drd.GetOrdinal("SalidaTraspaso");
                        int pos_Anulacion = drd.GetOrdinal("Anulacion");
                        int pos_Venta = drd.GetOrdinal("Venta");
                        int pos_Total = drd.GetOrdinal("Total");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        #endregion Lista - columnas
                        listado = new List<ReporteKardexProductoBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexProductoBE();
                            #region Lista - campos
                            obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.Stock = drd.GetString(pos_Stock);
                            obe.Entrada = drd.GetString(pos_Entrada);
                            obe.EntradaTraspaso = drd.GetString(pos_EntradaTraspaso);
                            obe.Salida = drd.GetString(pos_Salida);
                            obe.SalidaTraspaso = drd.GetString(pos_SalidaTraspaso);
                            obe.Anulacion = drd.GetString(pos_Anulacion);
                            obe.Venta = drd.GetString(pos_Venta);
                            obe.Total = drd.GetString(pos_Total);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public KardexProductoBE KardexProductoMes(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteKardexProductoBE> listado = new List<ReporteKardexProductoBE>();
            ReporteKardexProductoBE obe = new ReporteKardexProductoBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexProductoBE lobe = new KardexProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexProductoMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_Entrada = drd.GetOrdinal("Entrada");
                        int pos_EntradaTraspaso = drd.GetOrdinal("EntradaTraspaso");
                        int pos_Salida = drd.GetOrdinal("Salida");
                        int pos_SalidaTraspaso = drd.GetOrdinal("SalidaTraspaso");
                        int pos_Anulacion = drd.GetOrdinal("Anulacion");
                        int pos_Venta = drd.GetOrdinal("Venta");
                        int pos_Total = drd.GetOrdinal("Total");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        #endregion Lista - columnas
                        listado = new List<ReporteKardexProductoBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexProductoBE();
                            #region Lista - campos
                            obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.Stock = drd.GetString(pos_Stock);
                            obe.Entrada = drd.GetString(pos_Entrada);
                            obe.EntradaTraspaso = drd.GetString(pos_EntradaTraspaso);
                            obe.Salida = drd.GetString(pos_Salida);
                            obe.SalidaTraspaso = drd.GetString(pos_SalidaTraspaso);
                            obe.Anulacion = drd.GetString(pos_Anulacion);
                            obe.Venta = drd.GetString(pos_Venta);
                            obe.Total = drd.GetString(pos_Total);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public KardexProductoBE KardexProductoAnio(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteKardexProductoBE> listado = new List<ReporteKardexProductoBE>();
            ReporteKardexProductoBE obe = new ReporteKardexProductoBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexProductoBE lobe = new KardexProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexProductoAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_Entrada = drd.GetOrdinal("Entrada");
                        int pos_EntradaTraspaso = drd.GetOrdinal("EntradaTraspaso");
                        int pos_Salida = drd.GetOrdinal("Salida");
                        int pos_SalidaTraspaso = drd.GetOrdinal("SalidaTraspaso");
                        int pos_Anulacion = drd.GetOrdinal("Anulacion");
                        int pos_Venta = drd.GetOrdinal("Venta");
                        int pos_Total = drd.GetOrdinal("Total");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        #endregion Lista - columnas
                        listado = new List<ReporteKardexProductoBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexProductoBE();
                            #region Lista - campos
                            obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.Stock = drd.GetString(pos_Stock);
                            obe.Entrada = drd.GetString(pos_Entrada);
                            obe.EntradaTraspaso = drd.GetString(pos_EntradaTraspaso);
                            obe.Salida = drd.GetString(pos_Salida);
                            obe.SalidaTraspaso = drd.GetString(pos_SalidaTraspaso);
                            obe.Anulacion = drd.GetString(pos_Anulacion);
                            obe.Venta = drd.GetString(pos_Venta);
                            obe.Total = drd.GetString(pos_Total);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public KardexProductoBE KardexProductoRango(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, string fechaFin, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteKardexProductoBE> listado = new List<ReporteKardexProductoBE>();
            ReporteKardexProductoBE obe = new ReporteKardexProductoBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexProductoBE lobe = new KardexProductoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexProductoRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_Entrada = drd.GetOrdinal("Entrada");
                        int pos_EntradaTraspaso = drd.GetOrdinal("EntradaTraspaso");
                        int pos_Salida = drd.GetOrdinal("Salida");
                        int pos_SalidaTraspaso = drd.GetOrdinal("SalidaTraspaso");
                        int pos_Anulacion = drd.GetOrdinal("Anulacion");
                        int pos_Venta = drd.GetOrdinal("Venta");
                        int pos_Total = drd.GetOrdinal("Total");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_FechaFinReporte = drd.GetOrdinal("FechaFinReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        #endregion Lista - columnas
                        listado = new List<ReporteKardexProductoBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexProductoBE();
                            #region Lista - campos
                            obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.Stock = drd.GetString(pos_Stock);
                            obe.Entrada = drd.GetString(pos_Entrada);
                            obe.EntradaTraspaso = drd.GetString(pos_EntradaTraspaso);
                            obe.Salida = drd.GetString(pos_Salida);
                            obe.SalidaTraspaso = drd.GetString(pos_SalidaTraspaso);
                            obe.Anulacion = drd.GetString(pos_Anulacion);
                            obe.Venta = drd.GetString(pos_Venta);
                            obe.Total = drd.GetString(pos_Total);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.FechaFinReporte = drd.GetString(pos_FechaFinReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public KardexPrecioBE KardexPrecioDia(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteKardexPrecioBE> listado = new List<ReporteKardexPrecioBE>();
            ReporteKardexPrecioBE obe = new ReporteKardexPrecioBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexPrecioBE lobe = new KardexPrecioBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexPrecioDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_Entrada = drd.GetOrdinal("Entrada");
                        int pos_EntradaTraspaso = drd.GetOrdinal("EntradaTraspaso");
                        int pos_Salida = drd.GetOrdinal("Salida");
                        int pos_SalidaTraspaso = drd.GetOrdinal("SalidaTraspaso");
                        int pos_Anulacion = drd.GetOrdinal("Anulacion");
                        int pos_Venta = drd.GetOrdinal("Venta");
                        int pos_Total = drd.GetOrdinal("Total");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        #endregion Lista - columnas
                        listado = new List<ReporteKardexPrecioBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexPrecioBE();
                            #region Lista - campos
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.Stock = drd.GetString(pos_Stock);
                            obe.Entrada = drd.GetString(pos_Entrada);
                            obe.EntradaTraspaso = drd.GetString(pos_EntradaTraspaso);
                            obe.Salida = drd.GetString(pos_Salida);
                            obe.SalidaTraspaso = drd.GetString(pos_SalidaTraspaso);
                            obe.Anulacion = drd.GetString(pos_Anulacion);
                            obe.Venta = drd.GetString(pos_Venta);
                            obe.Total = drd.GetString(pos_Total);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public KardexPrecioBE KardexPrecioMes(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteKardexPrecioBE> listado = new List<ReporteKardexPrecioBE>();
            ReporteKardexPrecioBE obe = new ReporteKardexPrecioBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexPrecioBE lobe = new KardexPrecioBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexPrecioMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_Entrada = drd.GetOrdinal("Entrada");
                        int pos_EntradaTraspaso = drd.GetOrdinal("EntradaTraspaso");
                        int pos_Salida = drd.GetOrdinal("Salida");
                        int pos_SalidaTraspaso = drd.GetOrdinal("SalidaTraspaso");
                        int pos_Anulacion = drd.GetOrdinal("Anulacion");
                        int pos_Venta = drd.GetOrdinal("Venta");
                        int pos_Total = drd.GetOrdinal("Total");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        #endregion Lista - columnas
                        listado = new List<ReporteKardexPrecioBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexPrecioBE();
                            #region Lista - campos
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.Stock = drd.GetString(pos_Stock);
                            obe.Entrada = drd.GetString(pos_Entrada);
                            obe.EntradaTraspaso = drd.GetString(pos_EntradaTraspaso);
                            obe.Salida = drd.GetString(pos_Salida);
                            obe.SalidaTraspaso = drd.GetString(pos_SalidaTraspaso);
                            obe.Anulacion = drd.GetString(pos_Anulacion);
                            obe.Venta = drd.GetString(pos_Venta);
                            obe.Total = drd.GetString(pos_Total);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public KardexPrecioBE KardexPrecioAnio(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteKardexPrecioBE> listado = new List<ReporteKardexPrecioBE>();
            ReporteKardexPrecioBE obe = new ReporteKardexPrecioBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexPrecioBE lobe = new KardexPrecioBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexPrecioAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_Entrada = drd.GetOrdinal("Entrada");
                        int pos_EntradaTraspaso = drd.GetOrdinal("EntradaTraspaso");
                        int pos_Salida = drd.GetOrdinal("Salida");
                        int pos_SalidaTraspaso = drd.GetOrdinal("SalidaTraspaso");
                        int pos_Anulacion = drd.GetOrdinal("Anulacion");
                        int pos_Venta = drd.GetOrdinal("Venta");
                        int pos_Total = drd.GetOrdinal("Total");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        #endregion Lista - columnas
                        listado = new List<ReporteKardexPrecioBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexPrecioBE();
                            #region Lista - campos
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.Stock = drd.GetString(pos_Stock);
                            obe.Entrada = drd.GetString(pos_Entrada);
                            obe.EntradaTraspaso = drd.GetString(pos_EntradaTraspaso);
                            obe.Salida = drd.GetString(pos_Salida);
                            obe.SalidaTraspaso = drd.GetString(pos_SalidaTraspaso);
                            obe.Anulacion = drd.GetString(pos_Anulacion);
                            obe.Venta = drd.GetString(pos_Venta);
                            obe.Total = drd.GetString(pos_Total);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public KardexPrecioBE KardexPrecioRango(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, string fechaFin, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteKardexPrecioBE> listado = new List<ReporteKardexPrecioBE>();
            ReporteKardexPrecioBE obe = new ReporteKardexPrecioBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexPrecioBE lobe = new KardexPrecioBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexPrecioRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_Entrada = drd.GetOrdinal("Entrada");
                        int pos_EntradaTraspaso = drd.GetOrdinal("EntradaTraspaso");
                        int pos_Salida = drd.GetOrdinal("Salida");
                        int pos_SalidaTraspaso = drd.GetOrdinal("SalidaTraspaso");
                        int pos_Anulacion = drd.GetOrdinal("Anulacion");
                        int pos_Venta = drd.GetOrdinal("Venta");
                        int pos_Total = drd.GetOrdinal("Total");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_FechaFinReporte = drd.GetOrdinal("FechaFinReporte");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        #endregion Lista - columnas
                        listado = new List<ReporteKardexPrecioBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexPrecioBE();
                            #region Lista - campos
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.Stock = drd.GetString(pos_Stock);
                            obe.Entrada = drd.GetString(pos_Entrada);
                            obe.EntradaTraspaso = drd.GetString(pos_EntradaTraspaso);
                            obe.Salida = drd.GetString(pos_Salida);
                            obe.SalidaTraspaso = drd.GetString(pos_SalidaTraspaso);
                            obe.Anulacion = drd.GetString(pos_Anulacion);
                            obe.Venta = drd.GetString(pos_Venta);
                            obe.Total = drd.GetString(pos_Total);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.FechaFinReporte = drd.GetString(pos_FechaFinReporte);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            listado.Add(obe);
                            #endregion Lista - campos
                        }
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
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }
    }
}
