using Entidades.ReporteClienteTienda.GuiasTienda;
using Entidades.ReporteClienteTienda.KardexPrecioTienda;
using Entidades.ReporteClienteTienda.KardexProductoTienda;
using Entidades.ReporteClienteTienda.RegistroVentaTienda;
using Entidades.ReporteClienteTienda.VentaPrecioTienda;
using Entidades.ReporteClienteTienda.VentaProductoTienda;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.ReporteClienteTienda
{
    public class ReporteClienteTiendaDA
    {

        public GuiaTiendaBE VerGuiaTiendaDia(SqlConnection cnBD, string usuario, int idCliente, 
                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteGuiaTiendaBE> listado = new List<ReporteGuiaTiendaBE>();
            ReporteGuiaTiendaBE obe = new ReporteGuiaTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //listado detalle
            List<ReporteGuiaTienda_DetalleBE> listadoDetalle = new List<ReporteGuiaTienda_DetalleBE>();
            ReporteGuiaTienda_DetalleBE obeDet = new ReporteGuiaTienda_DetalleBE();
            //listado detalle - columnas
            List<ReporteColumnas> loColumnsDetalle = new List<ReporteColumnas>();
            ReporteColumnas obeColumnsDetalle = new ReporteColumnas();
            //bjeto
            GuiaTiendaBE lobe = new GuiaTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_GuiaTiendaDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar,150).Value = desTienda;

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
                        listado = new List<ReporteGuiaTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteGuiaTiendaBE();
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
                        listadoDetalle = new List<ReporteGuiaTienda_DetalleBE>();
                        while (drd.Read())
                        {
                            obeDet = new ReporteGuiaTienda_DetalleBE();
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

        public GuiaTiendaBE VerGuiaTiendaMes(SqlConnection cnBD, string usuario, int idCliente, 
                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteGuiaTiendaBE> listado = new List<ReporteGuiaTiendaBE>();
            ReporteGuiaTiendaBE obe = new ReporteGuiaTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //listado detalle
            List<ReporteGuiaTienda_DetalleBE> listadoDetalle = new List<ReporteGuiaTienda_DetalleBE>();
            ReporteGuiaTienda_DetalleBE obeDet = new ReporteGuiaTienda_DetalleBE();
            //listado detalle - columnas
            List<ReporteColumnas> loColumnsDetalle = new List<ReporteColumnas>();
            ReporteColumnas obeColumnsDetalle = new ReporteColumnas();
            //bjeto
            GuiaTiendaBE lobe = new GuiaTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_GuiaTiendaMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteGuiaTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteGuiaTiendaBE();
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
                        listadoDetalle = new List<ReporteGuiaTienda_DetalleBE>();
                        while (drd.Read())
                        {
                            obeDet = new ReporteGuiaTienda_DetalleBE();
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

        public GuiaTiendaBE VerGuiaTiendaAnio(SqlConnection cnBD, string usuario, int idCliente, 
                                                    string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteGuiaTiendaBE> listado = new List<ReporteGuiaTiendaBE>();
            ReporteGuiaTiendaBE obe = new ReporteGuiaTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //listado detalle
            List<ReporteGuiaTienda_DetalleBE> listadoDetalle = new List<ReporteGuiaTienda_DetalleBE>();
            ReporteGuiaTienda_DetalleBE obeDet = new ReporteGuiaTienda_DetalleBE();
            //listado detalle - columnas
            List<ReporteColumnas> loColumnsDetalle = new List<ReporteColumnas>();
            ReporteColumnas obeColumnsDetalle = new ReporteColumnas();
            //bjeto
            GuiaTiendaBE lobe = new GuiaTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_GuiaTiendaAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteGuiaTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteGuiaTiendaBE();
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
                        listadoDetalle = new List<ReporteGuiaTienda_DetalleBE>();
                        while (drd.Read())
                        {
                            obeDet = new ReporteGuiaTienda_DetalleBE();
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

        public GuiaTiendaBE VerGuiaTiendaRango(SqlConnection cnBD, string usuario, int idCliente, 
                                                    string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            //listado
            List<ReporteGuiaTiendaBE> listado = new List<ReporteGuiaTiendaBE>();
            ReporteGuiaTiendaBE obe = new ReporteGuiaTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //listado detalle
            List<ReporteGuiaTienda_DetalleBE> listadoDetalle = new List<ReporteGuiaTienda_DetalleBE>();
            ReporteGuiaTienda_DetalleBE obeDet = new ReporteGuiaTienda_DetalleBE();
            //listado detalle - columnas
            List<ReporteColumnas> loColumnsDetalle = new List<ReporteColumnas>();
            ReporteColumnas obeColumnsDetalle = new ReporteColumnas();
            //bjeto
            GuiaTiendaBE lobe = new GuiaTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_GuiaTiendaRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteGuiaTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteGuiaTiendaBE();
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
                        listadoDetalle = new List<ReporteGuiaTienda_DetalleBE>();
                        while (drd.Read())
                        {
                            obeDet = new ReporteGuiaTienda_DetalleBE();
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

        public VentaProductoTiendaBE VentaProductoTiendaDia(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaProductoTiendaBE> listado = new List<ReporteVentaProductoTiendaBE>();
            ReporteVentaProductoTiendaBE obe = new ReporteVentaProductoTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaProductoTiendaBE lobe = new VentaProductoTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaProductoTiendaDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteVentaProductoTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaProductoTiendaBE();
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

        public VentaProductoTiendaBE VentaProductoTiendaMes(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaProductoTiendaBE> listado = new List<ReporteVentaProductoTiendaBE>();
            ReporteVentaProductoTiendaBE obe = new ReporteVentaProductoTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaProductoTiendaBE lobe = new VentaProductoTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaProductoTiendaMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteVentaProductoTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaProductoTiendaBE();
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

        public VentaProductoTiendaBE VentaProductoTiendaAnio(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaProductoTiendaBE> listado = new List<ReporteVentaProductoTiendaBE>();
            ReporteVentaProductoTiendaBE obe = new ReporteVentaProductoTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaProductoTiendaBE lobe = new VentaProductoTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaProductoTiendaAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteVentaProductoTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaProductoTiendaBE();
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

        public VentaProductoTiendaBE VentaProductoTiendaRango(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaProductoTiendaBE> listado = new List<ReporteVentaProductoTiendaBE>();
            ReporteVentaProductoTiendaBE obe = new ReporteVentaProductoTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaProductoTiendaBE lobe = new VentaProductoTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaProductoTiendaRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteVentaProductoTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaProductoTiendaBE();
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

        public VentaPrecioTiendaBE VentaPrecioTiendaDia(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaPrecioTiendaBE> listado = new List<ReporteVentaPrecioTiendaBE>();
            ReporteVentaPrecioTiendaBE obe = new ReporteVentaPrecioTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaPrecioTiendaBE lobe = new VentaPrecioTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaPrecioTiendaDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteVentaPrecioTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaPrecioTiendaBE();
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

        public VentaPrecioTiendaBE VentaPrecioTiendaMes(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaPrecioTiendaBE> listado = new List<ReporteVentaPrecioTiendaBE>();
            ReporteVentaPrecioTiendaBE obe = new ReporteVentaPrecioTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaPrecioTiendaBE lobe = new VentaPrecioTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaPrecioTiendaMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteVentaPrecioTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaPrecioTiendaBE();
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

        public VentaPrecioTiendaBE VentaPrecioTiendaAnio(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaPrecioTiendaBE> listado = new List<ReporteVentaPrecioTiendaBE>();
            ReporteVentaPrecioTiendaBE obe = new ReporteVentaPrecioTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaPrecioTiendaBE lobe = new VentaPrecioTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaPrecioTiendaAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteVentaPrecioTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaPrecioTiendaBE();
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

        public VentaPrecioTiendaBE VentaPrecioTiendaRango(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaPrecioTiendaBE> listado = new List<ReporteVentaPrecioTiendaBE>();
            ReporteVentaPrecioTiendaBE obe = new ReporteVentaPrecioTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaPrecioTiendaBE lobe = new VentaPrecioTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_VentaProductoTiendaRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteVentaPrecioTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaPrecioTiendaBE();
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

        public KardexProductoTiendaBE KardexProductoTiendaDia(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteKardexProductoTiendaBE> listado = new List<ReporteKardexProductoTiendaBE>();
            ReporteKardexProductoTiendaBE obe = new ReporteKardexProductoTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexProductoTiendaBE lobe = new KardexProductoTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexProductoTiendaDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteKardexProductoTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexProductoTiendaBE();
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

        public KardexProductoTiendaBE KardexProductoTiendaMes(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteKardexProductoTiendaBE> listado = new List<ReporteKardexProductoTiendaBE>();
            ReporteKardexProductoTiendaBE obe = new ReporteKardexProductoTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexProductoTiendaBE lobe = new KardexProductoTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexProductoTiendaMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteKardexProductoTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexProductoTiendaBE();
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

        public KardexProductoTiendaBE KardexProductoTiendaAnio(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteKardexProductoTiendaBE> listado = new List<ReporteKardexProductoTiendaBE>();
            ReporteKardexProductoTiendaBE obe = new ReporteKardexProductoTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexProductoTiendaBE lobe = new KardexProductoTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexProductoTiendaAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteKardexProductoTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexProductoTiendaBE();
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

        public KardexProductoTiendaBE KardexProductoTiendaRango(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            //listado
            List<ReporteKardexProductoTiendaBE> listado = new List<ReporteKardexProductoTiendaBE>();
            ReporteKardexProductoTiendaBE obe = new ReporteKardexProductoTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexProductoTiendaBE lobe = new KardexProductoTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexProductoTiendaRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteKardexProductoTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexProductoTiendaBE();
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

        public KardexPrecioTiendaBE KardexPrecioTiendaDia(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteKardexPrecioTiendaBE> listado = new List<ReporteKardexPrecioTiendaBE>();
            ReporteKardexPrecioTiendaBE obe = new ReporteKardexPrecioTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexPrecioTiendaBE lobe = new KardexPrecioTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexPrecioTiendaDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteKardexPrecioTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexPrecioTiendaBE();
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

        public KardexPrecioTiendaBE KardexPrecioTiendaMes(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteKardexPrecioTiendaBE> listado = new List<ReporteKardexPrecioTiendaBE>();
            ReporteKardexPrecioTiendaBE obe = new ReporteKardexPrecioTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexPrecioTiendaBE lobe = new KardexPrecioTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexPrecioTiendaMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteKardexPrecioTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexPrecioTiendaBE();
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

        public KardexPrecioTiendaBE KardexPrecioTiendaAnio(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteKardexPrecioTiendaBE> listado = new List<ReporteKardexPrecioTiendaBE>();
            ReporteKardexPrecioTiendaBE obe = new ReporteKardexPrecioTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexPrecioTiendaBE lobe = new KardexPrecioTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexPrecioTiendaAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteKardexPrecioTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexPrecioTiendaBE();
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

        public KardexPrecioTiendaBE KardexPrecioTiendaRango(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            //listado
            List<ReporteKardexPrecioTiendaBE> listado = new List<ReporteKardexPrecioTiendaBE>();
            ReporteKardexPrecioTiendaBE obe = new ReporteKardexPrecioTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            KardexPrecioTiendaBE lobe = new KardexPrecioTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCliente_KardexPrecioTiendaRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

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
                        listado = new List<ReporteKardexPrecioTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteKardexPrecioTiendaBE();
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

        public VentaTiendaBE RegistroVentasTiendaDia(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaTiendaBE> listado = new List<ReporteVentaTiendaBE>();
            ReporteVentaTiendaBE obe = new ReporteVentaTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaTiendaBE lobe = new VentaTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_RegistroVentasTiendaDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Fecha = drd.GetOrdinal("Fecha");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_NotaVenta = drd.GetOrdinal("NotaVenta");
                        int pos_BoletaVenta = drd.GetOrdinal("BoletaVenta");
                        int pos_FacturaVenta = drd.GetOrdinal("FacturaVenta");
                        int pos_NotaCreditoVenta = drd.GetOrdinal("NotaCreditoVenta");
                        int pos_NotaDebitoVenta = drd.GetOrdinal("NotaDebitoVenta");
                        int pos_TotalSinIGV = drd.GetOrdinal("TotalSinIGV");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_EstadoFABO = drd.GetOrdinal("EstadoFABO");
                        int pos_EstadoResumen = drd.GetOrdinal("EstadoResumen");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaTiendaBE();
                            #region Lista - campos
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Fecha = drd.GetString(pos_Fecha);
                            obe.Estado = drd.GetString(pos_Estado);
                            obe.NotaVenta = drd.GetString(pos_NotaVenta);
                            obe.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obe.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obe.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obe.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obe.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obe.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
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
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public VentaTiendaBE RegistroVentasTiendaMes(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaTiendaBE> listado = new List<ReporteVentaTiendaBE>();
            ReporteVentaTiendaBE obe = new ReporteVentaTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaTiendaBE lobe = new VentaTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_RegistroVentasTiendaMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Fecha = drd.GetOrdinal("Fecha");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_NotaVenta = drd.GetOrdinal("NotaVenta");
                        int pos_BoletaVenta = drd.GetOrdinal("BoletaVenta");
                        int pos_FacturaVenta = drd.GetOrdinal("FacturaVenta");
                        int pos_NotaCreditoVenta = drd.GetOrdinal("NotaCreditoVenta");
                        int pos_NotaDebitoVenta = drd.GetOrdinal("NotaDebitoVenta");
                        int pos_TotalSinIGV = drd.GetOrdinal("TotalSinIGV");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_EstadoFABO = drd.GetOrdinal("EstadoFABO");
                        int pos_EstadoResumen = drd.GetOrdinal("EstadoResumen");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaTiendaBE();
                            #region Lista - campos
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Fecha = drd.GetString(pos_Fecha);
                            obe.Estado = drd.GetString(pos_Estado);
                            obe.NotaVenta = drd.GetString(pos_NotaVenta);
                            obe.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obe.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obe.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obe.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obe.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obe.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
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
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public VentaTiendaBE RegistroVentasTiendaAnio(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaTiendaBE> listado = new List<ReporteVentaTiendaBE>();
            ReporteVentaTiendaBE obe = new ReporteVentaTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaTiendaBE lobe = new VentaTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_RegistroVentasTiendaAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Fecha = drd.GetOrdinal("Fecha");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_NotaVenta = drd.GetOrdinal("NotaVenta");
                        int pos_BoletaVenta = drd.GetOrdinal("BoletaVenta");
                        int pos_FacturaVenta = drd.GetOrdinal("FacturaVenta");
                        int pos_NotaCreditoVenta = drd.GetOrdinal("NotaCreditoVenta");
                        int pos_NotaDebitoVenta = drd.GetOrdinal("NotaDebitoVenta");
                        int pos_TotalSinIGV = drd.GetOrdinal("TotalSinIGV");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_EstadoFABO = drd.GetOrdinal("EstadoFABO");
                        int pos_EstadoResumen = drd.GetOrdinal("EstadoResumen");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaTiendaBE();
                            #region Lista - campos
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Fecha = drd.GetString(pos_Fecha);
                            obe.Estado = drd.GetString(pos_Estado);
                            obe.NotaVenta = drd.GetString(pos_NotaVenta);
                            obe.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obe.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obe.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obe.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obe.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obe.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
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
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public VentaTiendaBE RegistroVentasTiendaRango(SqlConnection cnBD, string usuario, int idCliente, 
                                                            string fechaInicio, string fechaFin, int idTienda, string desTienda)
        {
            //listado
            List<ReporteVentaTiendaBE> listado = new List<ReporteVentaTiendaBE>();
            ReporteVentaTiendaBE obe = new ReporteVentaTiendaBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            VentaTiendaBE lobe = new VentaTiendaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_RegistroVentasTiendaRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@DesTienda", SqlDbType.VarChar, 150).Value = desTienda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Fecha = drd.GetOrdinal("Fecha");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_NotaVenta = drd.GetOrdinal("NotaVenta");
                        int pos_BoletaVenta = drd.GetOrdinal("BoletaVenta");
                        int pos_FacturaVenta = drd.GetOrdinal("FacturaVenta");
                        int pos_NotaCreditoVenta = drd.GetOrdinal("NotaCreditoVenta");
                        int pos_NotaDebitoVenta = drd.GetOrdinal("NotaDebitoVenta");
                        int pos_TotalSinIGV = drd.GetOrdinal("TotalSinIGV");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_EstadoFABO = drd.GetOrdinal("EstadoFABO");
                        int pos_EstadoResumen = drd.GetOrdinal("EstadoResumen");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_FechaFinReporte = drd.GetOrdinal("FechaFinReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteVentaTiendaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteVentaTiendaBE();
                            #region Lista - campos
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Fecha = drd.GetString(pos_Fecha);
                            obe.Estado = drd.GetString(pos_Estado);
                            obe.NotaVenta = drd.GetString(pos_NotaVenta);
                            obe.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obe.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obe.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obe.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obe.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obe.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
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
