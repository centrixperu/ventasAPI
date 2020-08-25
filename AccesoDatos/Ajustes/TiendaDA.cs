using Entidades.Ajustes;
using Entidades.Ajustes.Tienda;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Ajustes
{
    public class TiendaDA
    {
        public List<TiendaBE> ListarDatosIniciales(SqlConnection cnBD, string usuario, out List<TiendaExportBE> loExport, out List<ReporteColumnas> loColumns)
        {
            List<TiendaBE> lobe = new List<TiendaBE>();
            TiendaBE obe = new TiendaBE();

            loExport = new List<TiendaExportBE>();
            TiendaExportBE obeX = new TiendaExportBE();
            //listado - columnas
            loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Tienda_Lista]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Tienda = drd.GetOrdinal("Tienda");
                        int pos_Direccion = drd.GetOrdinal("Direccion");
                        int pos_Urbanizacion = drd.GetOrdinal("Urbanizacion");
                        int pos_IdCliente = drd.GetOrdinal("IdCliente");
                        int pos_NombreCliente = drd.GetOrdinal("NombreCliente");
                        int pos_isPrecioConIGV = drd.GetOrdinal("isPrecioConIGV");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FchModificacion = drd.GetOrdinal("FchModificacion");

                        lobe = new List<TiendaBE>();
                        loExport = new List<TiendaExportBE>();
                        while (drd.Read())
                        {
                            obe = new TiendaBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Tienda = drd.GetString(pos_Tienda);
                            obe.Direccion = drd.GetString(pos_Direccion);
                            obe.Urbanizacion = drd.GetString(pos_Urbanizacion);
                            obe.IdCliente = drd.GetInt32(pos_IdCliente);
                            obe.DesCliente = drd.GetString(pos_NombreCliente);
                            obe.isPrecioConIGV = drd.GetInt32(pos_isPrecioConIGV);
                            obe.Estado = drd.GetBoolean(pos_Estado);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.UsrModificador = drd.GetString(pos_UsrModificador);
                            obe.FchModificacion = drd.GetString(pos_FchModificacion);
                            lobe.Add(obe);

                            obeX = new TiendaExportBE();
                            obeX.Id = drd.GetInt32(pos_Id);
                            obeX.Tienda = drd.GetString(pos_Tienda);
                            obeX.Direccion = drd.GetString(pos_Direccion);
                            obeX.Urbanizacion = drd.GetString(pos_Urbanizacion);
                            obeX.Estado = drd.GetBoolean(pos_Estado) ? "Activo" : "Inactivo";
                            obeX.UsrCreador = drd.GetString(pos_UsrCreador);
                            obeX.FchCreacion = drd.GetString(pos_FchCreacion);
                            obeX.UsrModificador = drd.GetString(pos_UsrModificador);
                            obeX.FchModificacion = drd.GetString(pos_FchModificacion);
                            loExport.Add(obeX);
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
            return lobe;
        }

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, TiendaBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Tienda_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@Tienda", SqlDbType.VarChar, 50).Value = obe.Tienda;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = obe.Direccion;
                cmd.Parameters.Add("@Urbanizacion", SqlDbType.VarChar, 250).Value = obe.Urbanizacion;
                cmd.Parameters.Add("@isPrecioConIGV", SqlDbType.Int).Value = obe.isPrecioConIGV;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 50).Value = obe.DesCliente;
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

        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, TiendaBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Tienda_Actualizar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@Tienda", SqlDbType.VarChar, 50).Value = obe.Tienda;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = obe.Direccion;
                cmd.Parameters.Add("@Urbanizacion", SqlDbType.VarChar, 250).Value = obe.Urbanizacion;
                cmd.Parameters.Add("@isPrecioConIGV", SqlDbType.Int).Value = obe.isPrecioConIGV;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 50).Value = obe.DesCliente;
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

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, TiendaBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Tienda_Eliminar]", cnBD))
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

    }
}
