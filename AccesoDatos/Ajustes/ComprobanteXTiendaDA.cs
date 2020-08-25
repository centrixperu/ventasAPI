using Entidades.Ajustes;
using Entidades.Ajustes.AlmacenXTienda;
using Entidades.Ajustes.ComprobanteXTienda;
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
    public class ComprobanteXTiendaDA
    {
        public List<ComprobanteXTiendaBE> ListarDatosIniciales(SqlConnection cnBD, string usuario,
                                        out List<ReporteColumnas> loColumns, out List<ComprobanteXTiendaExportBE> loExport)
        {
            List<ComprobanteXTiendaBE> lobe = new List<ComprobanteXTiendaBE>();
            ComprobanteXTiendaBE obe = new ComprobanteXTiendaBE();

            loExport = new List<ComprobanteXTiendaExportBE>();
            ComprobanteXTiendaExportBE obeX = new ComprobanteXTiendaExportBE();
            //listado - columnas
            loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ComprobanteXTienda_Lista]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_IdComprobante = drd.GetOrdinal("IdComprobante");
                        int pos_NomComprobante = drd.GetOrdinal("NomComprobante");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_IdCliente = drd.GetOrdinal("IdCliente");
                        int pos_DesCliente = drd.GetOrdinal("DesCliente");
                        int pos_Serie = drd.GetOrdinal("Serie");
                        int pos_Correlativo = drd.GetOrdinal("Correlativo");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FchModificacion = drd.GetOrdinal("FchModificacion");

                        lobe = new List<ComprobanteXTiendaBE>();
                        loExport = new List<ComprobanteXTiendaExportBE>();
                        while (drd.Read())
                        {
                            obe = new ComprobanteXTiendaBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.IdComprobante = drd.GetInt32(pos_IdComprobante);
                            obe.NomComprobante = drd.GetString(pos_NomComprobante);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.IdCliente = drd.GetInt32(pos_IdCliente);
                            obe.DesCliente = drd.GetString(pos_DesCliente);
                            obe.Serie = drd.GetString(pos_Serie);
                            obe.Correlativo = drd.GetInt32(pos_Correlativo);
                            obe.Estado = drd.GetBoolean(pos_Estado);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.UsrModificador = drd.GetString(pos_UsrModificador);
                            obe.FchModificacion = drd.GetString(pos_FchModificacion);
                            lobe.Add(obe);

                            obeX = new ComprobanteXTiendaExportBE();
                            obeX.IdComprobante = drd.GetInt32(pos_IdComprobante);
                            obeX.NomComprobante = drd.GetString(pos_NomComprobante);
                            obeX.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeX.DesTienda = drd.GetString(pos_DesTienda);
                            obeX.Serie = drd.GetString(pos_Serie);
                            obeX.Correlativo = drd.GetInt32(pos_Correlativo);
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

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, ComprobanteXTiendaBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ComprobanteXTienda_Guardar]", cnBD))
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

        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, ComprobanteXTiendaBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ComprobanteXTienda_Actualizar]", cnBD))
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

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, ComprobanteXTiendaBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ComprobanteXTienda_Eliminar]", cnBD))
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
