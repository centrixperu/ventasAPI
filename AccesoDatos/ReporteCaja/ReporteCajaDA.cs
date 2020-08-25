using Entidades.Almacen.AsignarAlmacen;
using Entidades.DashBoard;
using Entidades.ReporteCaja;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.ReporteCaja
{
    public class ReporteCajaDA
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

        public CajaBE ReporteCajaDia(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //LISTADO
            List<ReporteCajaBE> listado = new List<ReporteCajaBE>();
            ReporteCajaBE obe = new ReporteCajaBE();
            //LISTADO - COLUMNAS
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //INGRESOS
            List<DashBoardBE> loGraficoIngreso = new List<DashBoardBE>();
            DashBoardBE obeGraficoIngreso = new DashBoardBE();
            //EGRESOS
            List<DashBoardBE> loGraficoEgreso = new List<DashBoardBE>();
            DashBoardBE obeGraficoEgreso = new DashBoardBE();

            CajaBE lobe = new CajaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCaja_Dia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    lobe = new CajaBE();
                    loGraficoIngreso = new List<DashBoardBE>();
                    loGraficoEgreso = new List<DashBoardBE>();


                    if (drd.HasRows)
                    {
                        int pos_CajaAnterior = drd.GetOrdinal("CajaAnterior");
                        while (drd.Read())
                        { 
                            lobe.CajaAnterior = drd.GetDecimal(pos_CajaAnterior);
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_Clase = drd.GetOrdinal("Clase");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        //int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_Tipo = drd.GetOrdinal("Tipo");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteCajaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteCajaBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.Clase = drd.GetString(pos_Clase);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.Descripcion = drd.GetString(pos_Descripcion);
                            obe.Cantidad = drd.GetInt32(pos_Cantidad);
                            obe.Precio = drd.GetDecimal(pos_Precio);
                            //obe.PrecioCosto = drd.GetDecimal(pos_PrecioCosto);
                            obe.Tipo = drd.GetString(pos_Tipo);
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
                    //GRAFICOS
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoDia = new List<DashBoardBE>();
                        obeGraficoIngreso = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetDecimal(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoIngreso.serie = serie;
                        obeGraficoIngreso.label = label;
                        loGraficoIngreso.Add(obeGraficoIngreso);
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoSemana = new List<DashBoardBE>();
                        obeGraficoEgreso = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetDecimal(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoEgreso.serie = serie;
                        obeGraficoEgreso.label = label;
                        loGraficoEgreso.Add(obeGraficoEgreso);
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;
            lobe.loGraficoIngreso = loGraficoIngreso;
            lobe.loGraficoEgreso = loGraficoEgreso;

            return lobe;
        }

        public CajaBE ReporteCajaMes(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //LISTADO
            List<ReporteCajaBE> listado = new List<ReporteCajaBE>();
            ReporteCajaBE obe = new ReporteCajaBE();
            //LISTADO - COLUMNAS
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //INGRESOS
            List<DashBoardBE> loGraficoIngreso = new List<DashBoardBE>();
            DashBoardBE obeGraficoIngreso = new DashBoardBE();
            //EGRESOS
            List<DashBoardBE> loGraficoEgreso = new List<DashBoardBE>();
            DashBoardBE obeGraficoEgreso = new DashBoardBE();

            CajaBE lobe = new CajaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCaja_Mes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    lobe = new CajaBE();
                    loGraficoIngreso = new List<DashBoardBE>();
                    loGraficoEgreso = new List<DashBoardBE>();


                    if (drd.HasRows)
                    {
                        int pos_CajaAnterior = drd.GetOrdinal("CajaAnterior");
                        while (drd.Read())
                        {
                            lobe.CajaAnterior = drd.GetDecimal(pos_CajaAnterior);
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_Clase = drd.GetOrdinal("Clase");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        //int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_Tipo = drd.GetOrdinal("Tipo");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteCajaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteCajaBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.Clase = drd.GetString(pos_Clase);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.Descripcion = drd.GetString(pos_Descripcion);
                            obe.Cantidad = drd.GetInt32(pos_Cantidad);
                            obe.Precio = drd.GetDecimal(pos_Precio);
                            //obe.PrecioCosto = drd.GetDecimal(pos_PrecioCosto);
                            obe.Tipo = drd.GetString(pos_Tipo);
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
                    //GRAFICOS
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoDia = new List<DashBoardBE>();
                        obeGraficoIngreso = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetDecimal(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoIngreso.serie = serie;
                        obeGraficoIngreso.label = label;
                        loGraficoIngreso.Add(obeGraficoIngreso);
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoSemana = new List<DashBoardBE>();
                        obeGraficoEgreso = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetDecimal(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoEgreso.serie = serie;
                        obeGraficoEgreso.label = label;
                        loGraficoEgreso.Add(obeGraficoEgreso);
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;
            lobe.loGraficoIngreso = loGraficoIngreso;
            lobe.loGraficoEgreso = loGraficoEgreso;

            return lobe;
        }

        public CajaBE ReporteCajaAnio(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //LISTADO
            List<ReporteCajaBE> listado = new List<ReporteCajaBE>();
            ReporteCajaBE obe = new ReporteCajaBE();
            //LISTADO - COLUMNAS
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //INGRESOS
            List<DashBoardBE> loGraficoIngreso = new List<DashBoardBE>();
            DashBoardBE obeGraficoIngreso = new DashBoardBE();
            //EGRESOS
            List<DashBoardBE> loGraficoEgreso = new List<DashBoardBE>();
            DashBoardBE obeGraficoEgreso = new DashBoardBE();

            CajaBE lobe = new CajaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_ReporteCaja_Anio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    lobe = new CajaBE();
                    loGraficoIngreso = new List<DashBoardBE>();
                    loGraficoEgreso = new List<DashBoardBE>();


                    if (drd.HasRows)
                    {
                        int pos_CajaAnterior = drd.GetOrdinal("CajaAnterior");
                        while (drd.Read())
                        {
                            lobe.CajaAnterior = drd.GetDecimal(pos_CajaAnterior);
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_Clase = drd.GetOrdinal("Clase");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        //int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_Tipo = drd.GetOrdinal("Tipo");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteCajaBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteCajaBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.Clase = drd.GetString(pos_Clase);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.Descripcion = drd.GetString(pos_Descripcion);
                            obe.Cantidad = drd.GetInt32(pos_Cantidad);
                            obe.Precio = drd.GetDecimal(pos_Precio);
                            //obe.PrecioCosto = drd.GetDecimal(pos_PrecioCosto);
                            obe.Tipo = drd.GetString(pos_Tipo);
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
                    //GRAFICOS
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoDia = new List<DashBoardBE>();
                        obeGraficoIngreso = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetDecimal(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoIngreso.serie = serie;
                        obeGraficoIngreso.label = label;
                        loGraficoIngreso.Add(obeGraficoIngreso);
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoSemana = new List<DashBoardBE>();
                        obeGraficoEgreso = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetDecimal(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoEgreso.serie = serie;
                        obeGraficoEgreso.label = label;
                        loGraficoEgreso.Add(obeGraficoEgreso);
                    }
                }
            }
            lobe.listado = listado;
            lobe.loColumns = loColumns;
            lobe.loGraficoIngreso = loGraficoIngreso;
            lobe.loGraficoEgreso = loGraficoEgreso;

            return lobe;
        }


        public CajaBE ListarDatosIniciales(SqlConnection cnBD, string usuario, int idCliente, List<ListaComboBE> loTienda)
        {
            List<DashBoardBE> loGraficoIngresos = new List<DashBoardBE>();
            DashBoardBE obeGraficoIngresos = new DashBoardBE();
            List<DashBoardBE> loGraficoEgresos = new List<DashBoardBE>();
            DashBoardBE obeGraficoEgresos = new DashBoardBE();

            CajaBE obe = new CajaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_FlujoCaja_DatosIniciales]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    obe = new CajaBE();
                    loGraficoIngresos = new List<DashBoardBE>();
                    loGraficoEgresos = new List<DashBoardBE>();

                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoDia = new List<DashBoardBE>();
                        obeGraficoIngresos = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetDecimal(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoIngresos.serie = serie;
                        obeGraficoIngresos.label = label;
                        loGraficoIngresos.Add(obeGraficoIngresos);
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoSemana = new List<DashBoardBE>();
                        obeGraficoEgresos = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetDecimal(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoEgresos.serie = serie;
                        obeGraficoEgresos.label = label;
                        loGraficoEgresos.Add(obeGraficoEgresos);
                    }
                    
                    obe.loGraficoIngreso = loGraficoIngresos;
                    obe.loGraficoEgreso = loGraficoEgresos;

                    //obe.listado = loGraficoMes;
                    //obe.loColumns = loGraficoMes;
                }
            }
            return obe;
        }

        public RespuestaBE Guardar(SqlConnection cnBD, SqlTransaction trx, CajaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_FlujoCaja_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = obe.IdTienda;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = obe.Usuario;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = obe.Descripcion;
                cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = obe.Precio;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = obe.Cantidad;
                cmd.Parameters.Add("@CodProducto", SqlDbType.Int).Value = obe.CodProducto;
                cmd.Parameters.Add("@Tipo", SqlDbType.VarChar,1).Value = obe.Tipo;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        while (drd.Read())
                        {
                            rpta = new RespuestaBE();
                            rpta.codigo = drd.GetInt32(pos_Codigo);
                            rpta.descripcion = drd.GetString(pos_Descripcion);
                        }
                    }
                }
            }
            return rpta;
        }

        public List<AsignarAlmacen_ProductoBE> ProductosCaja(SqlConnection cnBD, string usuario, int idCliente, int idTienda, string busqueda)
        {
            List<AsignarAlmacen_ProductoBE> lobe = null;
            AsignarAlmacen_ProductoBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Caja_ListaProducto]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = idTienda;
                cmd.Parameters.Add("@busqueda", SqlDbType.VarChar, 250).Value = busqueda;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Nombre = drd.GetOrdinal("NombreProducto");
                        int pos_Stock = drd.GetOrdinal("Stock");
                        int pos_DesTipo = drd.GetOrdinal("DesTipo");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");

                        lobe = new List<AsignarAlmacen_ProductoBE>();
                        while (drd.Read())
                        {
                            obe = new AsignarAlmacen_ProductoBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Nombre = drd.GetString(pos_Nombre);
                            obe.Stock = drd.GetInt32(pos_Stock);
                            obe.desTipo = drd.GetString(pos_DesTipo);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }
    }
}
