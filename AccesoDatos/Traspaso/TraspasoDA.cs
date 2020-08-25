﻿using Entidades.Almacen.AsignarAlmacen;
using Entidades.Traspaso;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Traspaso
{
    public class TraspasoDA
    {

        private DataTable CrearEstructura(List<AsignarAlmacen_ProductoBE> lobe)
        {
            DataTable dataT = new DataTable();
            DataRow dRow;
            dataT.Columns.Add(new DataColumn("Id"));
            dataT.Columns.Add(new DataColumn("Nombre"));
            dataT.Columns.Add(new DataColumn("Cantidad"));
            dataT.Columns.Add(new DataColumn("CantidadTienda"));
            dataT.Columns.Add(new DataColumn("Precio"));
            dataT.Columns.Add(new DataColumn("OldPrecio"));
            dataT.Columns.Add(new DataColumn("CantidadCaja"));
            dataT.Columns.Add(new DataColumn("PrecioCosto"));
            dataT.Columns.Add(new DataColumn("IdTipo"));
            dataT.Columns.Add(new DataColumn("FecVencimiento"));
            dataT.Columns.Add(new DataColumn("DireccionCosto"));
            dataT.Columns.Add(new DataColumn("Ubicacion"));
            dataT.Columns.Add(new DataColumn("Lote"));

            if (lobe != null && lobe.Count > 0)
            {
                for (int i = 0; i < lobe.Count; i++)
                {
                    object[] RowValues = { lobe[i].Id, lobe[i].Nombre, lobe[i].Cantidad,
                                            lobe[i].CantidadTienda, lobe[i].Precio, lobe[i].OldPrecio,
                                            lobe[i].CantidadCaja, lobe[i].PrecioCosto, lobe[i].idTipo,
                                            Convert.ToDateTime(lobe[i].FecVencimiento).ToString("yyyy-MM-dd HH:mm:ss"),
                                            lobe[i].DireccionCosto, lobe[i].Ubicacion, lobe[i].Lote};
                    dRow = dataT.Rows.Add(RowValues);
                }
            }
            dataT.AcceptChanges();
            return dataT;
        }

        public RespuestaBE Traspasar(SqlConnection cnBD, SqlTransaction trx, Traspaso_DatosInicialesBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_TraspasoTienda_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@IdTiendaOrigen", SqlDbType.Int).Value = obe.IdTiendaOrigen;
                cmd.Parameters.Add("@DesTiendaOrigen", SqlDbType.VarChar, 150).Value = obe.DesTiendaOrigen;
                cmd.Parameters.Add("@IdTiendaDestino", SqlDbType.Int).Value = obe.IdTiendaDestino;
                cmd.Parameters.Add("@DesTiendaDestino", SqlDbType.VarChar,150).Value = obe.DesTiendaDestino;
                cmd.Parameters.Add("@GuiaEntrada", SqlDbType.VarChar, 20).Value = obe.GuiaEntrada;
                cmd.Parameters.Add("@GuiaSalida", SqlDbType.VarChar, 20).Value = obe.GuiaSalida;
                cmd.Parameters.Add("@FechaGuia", SqlDbType.DateTime).Value = obe.FechaGuia;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@loProducto", SqlDbType.Structured).Value = CrearEstructura(obe.loProducto);

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

    }
}