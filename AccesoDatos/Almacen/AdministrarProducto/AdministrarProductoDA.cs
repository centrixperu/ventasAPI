using Entidades.AdministrarProducto;
using Entidades.Almacen.AdministrarProducto;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.AdministrarProducto
{
    public class AdministrarProductoDA
    {

        public List<AdministrarProductoBE> ListaProducto(SqlConnection cnBD, string usuario,
                                        out List<ReporteColumnas> loColumns, out List<AdministrarProductoExportBE> loExport)
        {
            List<AdministrarProductoBE> lobe = new List<AdministrarProductoBE>();
            AdministrarProductoBE obe = new AdministrarProductoBE();

            ListaArchivosAdjuntos obeArch = null;

            loExport = new List<AdministrarProductoExportBE>();
            AdministrarProductoExportBE obeX = new AdministrarProductoExportBE();
            //listado - columnas
            loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_AdministrarProducto_Listado]", cnBD))
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
                        int pos_CodProducto = drd.GetOrdinal("CodProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_IdTalla = drd.GetOrdinal("IdTalla");
                        int pos_DesTalla = drd.GetOrdinal("DesTalla");
                        int pos_IdColor = drd.GetOrdinal("IdColor");
                        int pos_DesColor = drd.GetOrdinal("DesColor");
                        int pos_IdTipo = drd.GetOrdinal("IdTipo");
                        int pos_DesTipo = drd.GetOrdinal("DesTipo");
                        int pos_IdUnidad = drd.GetOrdinal("IdUnidad");
                        int pos_DesUnidad = drd.GetOrdinal("DesUnidad");
                        int pos_IdSegmento = drd.GetOrdinal("IdSegmento");
                        int pos_IdFamilia = drd.GetOrdinal("IdFamilia");
                        int pos_IdClase = drd.GetOrdinal("IdClase");
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_CodUNSPSC = drd.GetOrdinal("CodUNSPSC");
                        int pos_Estatus = drd.GetOrdinal("Estatus");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FechaCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FechaModificacion = drd.GetOrdinal("FchModificacion");
                        int pos_IdProductoBase = drd.GetOrdinal("IdProductoBase");
                        int pos_NombreProductoBase = drd.GetOrdinal("NombreProductoBase");
                        //int pos_isFecVencimiento = drd.GetOrdinal("isFecVencimiento");
                        int pos_IdProdLaboratorio = drd.GetOrdinal("IdProdLaboratorio");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_IdProdGrupo = drd.GetOrdinal("IdProdGrupo");
                        int pos_DesProdGrupo = drd.GetOrdinal("DesProdGrupo");
                        int pos_IdProdTipoPresentacion = drd.GetOrdinal("IdProdTipoPresentacion");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");
                        int pos_DesNombreGenerico = drd.GetOrdinal("DesNombreGenerico");
                        int pos_DesTipoProducto = drd.GetOrdinal("DesTipoProducto");
                        int pos_DesComposicion = drd.GetOrdinal("DesComposicion");
                        int pos_DesIndicaciones = drd.GetOrdinal("DesIndicaciones");
                        int pos_DesContraIndicaciones = drd.GetOrdinal("DesContraIndicaciones");
                        int pos_RecetaMedica = drd.GetOrdinal("RecetaMedica");
                        int pos_isGenerico = drd.GetOrdinal("isGenerico");
                        int pos_RegSanitario = drd.GetOrdinal("RegSanitario");
                        #endregion parametros
                        lobe = new List<AdministrarProductoBE>();
                        loExport = new List<AdministrarProductoExportBE>();
                        while (drd.Read())
                        {
                            #region variables
                            obe = new AdministrarProductoBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.CodProducto = drd.GetString(pos_CodProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.Descripcion = drd.GetString(pos_Descripcion);
                            obe.IdTalla = drd.GetInt32(pos_IdTalla);
                            
                            obe.IdColor = drd.GetInt32(pos_IdColor);
                            
                            obe.IdTipo = drd.GetInt32(pos_IdTipo);
                            
                            obe.IdUnidad = drd.GetString(pos_IdUnidad);
                            
                            obe.IdSegmento = drd.GetString(pos_IdSegmento);
                            obe.IdFamilia = drd.GetString(pos_IdFamilia);
                            obe.IdClase = drd.GetString(pos_IdClase);
                            obe.IdProducto = drd.GetString(pos_IdProducto);
                            obe.CodUNSPSC = drd.GetString(pos_CodUNSPSC);
                            obe.Estatus = drd.GetBoolean(pos_Estatus);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FechaCreacion);
                            obe.UsrModificador = drd.GetString(pos_UsrModificador);
                            obe.FchModificacion = drd.GetString(pos_FechaModificacion);
                            obe.IdProductoBase = drd.GetInt32(pos_IdProductoBase);
                            obe.NombreProductoBase = drd.GetString(pos_NombreProductoBase);
                            //obe.isFechaVencimiento = drd.GetBoolean(pos_isFecVencimiento);
                            obe.IdProdLaboratorio = drd.GetInt32(pos_IdProdLaboratorio);
                            
                            obe.IdProdGrupo = drd.GetInt32(pos_IdProdGrupo);
                            
                            obe.IdProdTipoPresentacion = drd.GetInt32(pos_IdProdTipoPresentacion);
                            
                            obe.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obe.DesTipoProducto = drd.GetString(pos_DesTipoProducto);
                            obe.DesComposicion = drd.GetString(pos_DesComposicion);
                            obe.DesIndicaciones = drd.GetString(pos_DesIndicaciones);
                            obe.DesContraIndicaciones = drd.GetString(pos_DesContraIndicaciones);
                            obe.RecetaMedica = drd.GetString(pos_RecetaMedica);
                            obe.isGenerico = drd.GetString(pos_isGenerico);
                            obe.RegSanitario = drd.GetString(pos_RegSanitario);
                            obe.loarchivos = new List<ListaArchivosAdjuntos>();
                            lobe.Add(obe);
                            #endregion variables

                            obeX = new AdministrarProductoExportBE();
                            obeX.CodProducto = drd.GetString(pos_CodProducto);
                            obeX.CodUNSPSC = drd.GetString(pos_CodUNSPSC);
                            obeX.NombreProducto = drd.GetString(pos_NombreProducto);
                            obeX.Descripcion = drd.GetString(pos_Descripcion);
                            //obeX.IdUnidad = drd.GetString(pos_IdUnidad);
                            //obe.DesUnidad = drd.GetString(pos_DesUnidad);
                            obeX.DesUnidad = drd.GetString(pos_IdUnidad) + " - " + drd.GetString(pos_DesUnidad); //"";
                            //obeX.IdTalla = drd.GetInt32(pos_IdTalla);
                            //obe.DesTalla = drd.GetString(pos_DesTalla);
                            obeX.DesTalla = drd.GetInt32(pos_IdTalla).ToString() + " - " + drd.GetString(pos_DesTalla); //"";
                            //obeX.IdColor = drd.GetInt32(pos_IdColor);
                            //obe.DesColor = drd.GetString(pos_DesColor);
                            obeX.DesColor = drd.GetInt32(pos_IdColor).ToString() + " - " + drd.GetString(pos_DesColor); //"";
                            //obeX.IdTipo = drd.GetInt32(pos_IdTipo);
                            //obe.DesTipo = drd.GetString(pos_DesTipo);
                            obeX.DesTipo = drd.GetInt32(pos_IdTipo).ToString() + " - " + drd.GetString(pos_DesTipo); // "";
                            //---
                            obeX.DesProdLaboratorio = drd.GetInt32(pos_IdProdLaboratorio).ToString() + " - " + drd.GetString(pos_DesProdLaboratorio);
                            //obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);

                            obeX.DesProdGrupo = drd.GetInt32(pos_IdProdGrupo).ToString() + " - " + drd.GetString(pos_DesProdGrupo);
                            //obe.DesProdGrupo = drd.GetString(pos_DesProdGrupo);

                            obeX.DesProdTipoPresentacion = drd.GetInt32(pos_IdProdTipoPresentacion).ToString() + " - " + drd.GetString(pos_DesProdTipoPresentacion);
                            //obe.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);

                            obeX.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obeX.isGenerico = drd.GetString(pos_isGenerico);
                            obeX.RegSanitario = drd.GetString(pos_RegSanitario);
                            obeX.DesTipoProducto = drd.GetString(pos_DesTipoProducto);
                            obeX.DesComposicion = drd.GetString(pos_DesComposicion);
                            obeX.DesIndicaciones = drd.GetString(pos_DesIndicaciones);
                            obeX.DesContraIndicaciones = drd.GetString(pos_DesContraIndicaciones);
                            obeX.RecetaMedica = drd.GetString(pos_RecetaMedica);
                            //---
                            obeX.Estatus = drd.GetBoolean(pos_Estatus) ? "Activo" : "Inactivo";
                            obeX.UsrCreador = drd.GetString(pos_UsrCreador);
                            obeX.FchCreacion = drd.GetString(pos_FechaCreacion);
                            obeX.UsrModificador = drd.GetString(pos_UsrModificador);
                            obeX.FchModificacion = drd.GetString(pos_FechaModificacion);
                            loExport.Add(obeX);
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_URLProducto = drd.GetOrdinal("URLProducto");

                        while (drd.Read())
                        {
                            obeArch = new ListaArchivosAdjuntos();
                            int idProducto = drd.GetInt32(pos_IdProducto);
                            obeArch.Id = drd.GetInt32(pos_Id);
                            obeArch.URL = drd.GetString(pos_URLProducto);
                            int index = lobe.FindIndex(det => det.Id == idProducto);
                            if (index != -1)
                            {
                                lobe[index].loarchivos.Add(obeArch);
                            }
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

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, AdministrarProductoBE obe, out int id, out string msjError)
        {
            bool rpta = false;
            msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_AdministrarProducto_Guardar]", cnBD))
            {
                #region parametros
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@CodProducto", SqlDbType.VarChar, 50).Value = obe.CodProducto;
                cmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar, 250).Value = obe.NombreProducto;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = obe.Descripcion;
                cmd.Parameters.Add("@IdTalla", SqlDbType.Int).Value = obe.IdTalla;
                cmd.Parameters.Add("@DesTalla", SqlDbType.VarChar, 20).Value = obe.DesTalla;
                cmd.Parameters.Add("@IdColor", SqlDbType.Int).Value = obe.IdColor;
                cmd.Parameters.Add("@DesColor", SqlDbType.VarChar, 50).Value = obe.DesColor;
                cmd.Parameters.Add("@IdTipo", SqlDbType.Int).Value = obe.IdTipo;
                cmd.Parameters.Add("@DesTipo", SqlDbType.VarChar, 50).Value = obe.DesTipo;
                cmd.Parameters.Add("@idProductoBase", SqlDbType.Int).Value = obe.IdProductoBase;
                //cmd.Parameters.Add("@isFechaVencimiento", SqlDbType.Bit).Value = obe.isFechaVencimiento;
                cmd.Parameters.Add("@IdUnidad", SqlDbType.VarChar, 5).Value = obe.IdUnidad;
                cmd.Parameters.Add("@DesUnidad", SqlDbType.VarChar, 200).Value = obe.DesUnidad;
                cmd.Parameters.Add("@IdSegmento", SqlDbType.VarChar, 3).Value = obe.IdSegmento;
                cmd.Parameters.Add("@DesSegmento", SqlDbType.VarChar, 200).Value = obe.DesSegmento;
                cmd.Parameters.Add("@IdFamilia", SqlDbType.VarChar, 3).Value = obe.IdFamilia;
                cmd.Parameters.Add("@DesFamilia", SqlDbType.VarChar, 200).Value = obe.DesFamilia;
                cmd.Parameters.Add("@IdClase", SqlDbType.VarChar, 3).Value = obe.IdClase;
                cmd.Parameters.Add("@DesClase", SqlDbType.VarChar, 200).Value = obe.DesClase;
                cmd.Parameters.Add("@IdProducto", SqlDbType.VarChar, 3).Value = obe.IdProducto;
                cmd.Parameters.Add("@DesProducto", SqlDbType.VarChar, 200).Value = obe.DesProducto;
                cmd.Parameters.Add("@CodUNSPSC", SqlDbType.VarChar, 20).Value = obe.CodUNSPSC;
                cmd.Parameters.Add("@Estatus", SqlDbType.Bit).Value = obe.Estatus;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;

                cmd.Parameters.Add("@IdProdLaboratorio", SqlDbType.Int).Value = obe.IdProdLaboratorio;
                cmd.Parameters.Add("@CodProdLaboratorio", SqlDbType.VarChar, 10).Value = obe.CodProdLaboratorio;
                cmd.Parameters.Add("@DesProdLaboratorio", SqlDbType.VarChar, 150).Value = obe.DesProdLaboratorio;
                cmd.Parameters.Add("@IdProdGrupo", SqlDbType.Int).Value = obe.IdProdGrupo;
                cmd.Parameters.Add("@DesProdGrupo", SqlDbType.VarChar, 150).Value = obe.DesProdGrupo;
                cmd.Parameters.Add("@IdProdTipoPresentacion", SqlDbType.Int).Value = obe.IdProdTipoPresentacion;
                cmd.Parameters.Add("@CodProdTipoPresentacion", SqlDbType.VarChar, 150).Value = obe.CodProdTipoPresentacion;
                cmd.Parameters.Add("@DesProdTipoPresentacion", SqlDbType.VarChar, 150).Value = obe.DesProdTipoPresentacion;
                cmd.Parameters.Add("@DesNombreGenerico", SqlDbType.VarChar, 150).Value = obe.DesNombreGenerico;
                cmd.Parameters.Add("@DesTipoProducto", SqlDbType.VarChar, 150).Value = obe.DesTipoProducto;
                cmd.Parameters.Add("@DesComposicion", SqlDbType.VarChar, 800).Value = obe.DesComposicion;
                cmd.Parameters.Add("@DesIndicaciones", SqlDbType.VarChar, 800).Value = obe.DesIndicaciones;
                cmd.Parameters.Add("@DesContraIndicaciones", SqlDbType.VarChar, 800).Value = obe.DesContraIndicaciones;
                cmd.Parameters.Add("@RecetaMedica", SqlDbType.VarChar, 2).Value = obe.RecetaMedica;
                cmd.Parameters.Add("@isGenerico", SqlDbType.VarChar, 2).Value = obe.isGenerico;
                cmd.Parameters.Add("@RegSanitario", SqlDbType.VarChar, 50).Value = obe.RegSanitario;
                #endregion parametros

                int counterMarker = 0;
                object objRes = cmd.ExecuteScalar();
                int.TryParse(objRes.ToString(), out counterMarker);
                if (counterMarker > 0)
                {
                    id = counterMarker;
                    rpta = true;
                }
                else
                {
                    id = 0;
                    msjError = objRes.ToString();
                    rpta = false;
                }
            }
            return rpta;
        }

        public bool GuardarURL(SqlConnection cnBD, SqlTransaction trx, string ruta, int id, string usuario)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_AdministrarProducto_GuardarURL]", cnBD))
            {
                #region parametros
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Ruta", SqlDbType.VarChar, 250).Value = ruta;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                #endregion parametros

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

        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, AdministrarProductoBE obe, out int id, out string msjError)
        {
            bool rpta = false;
            msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_AdministrarProducto_Actualizar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@CodProducto", SqlDbType.VarChar, 50).Value = obe.CodProducto;
                cmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar, 250).Value = obe.NombreProducto;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = obe.Descripcion;
                cmd.Parameters.Add("@IdTalla", SqlDbType.Int).Value = obe.IdTalla;
                cmd.Parameters.Add("@DesTalla", SqlDbType.VarChar, 20).Value = obe.DesTalla;
                cmd.Parameters.Add("@IdColor", SqlDbType.Int).Value = obe.IdColor;
                cmd.Parameters.Add("@DesColor", SqlDbType.VarChar, 50).Value = obe.DesColor;
                cmd.Parameters.Add("@IdTipo", SqlDbType.Int).Value = obe.IdTipo;
                cmd.Parameters.Add("@DesTipo", SqlDbType.VarChar, 50).Value = obe.DesTipo;
                cmd.Parameters.Add("@idProductoBase", SqlDbType.Int).Value = obe.IdProductoBase;
                //cmd.Parameters.Add("@isFechaVencimiento", SqlDbType.Bit).Value = obe.isFechaVencimiento;
                cmd.Parameters.Add("@IdUnidad", SqlDbType.VarChar, 5).Value = obe.IdUnidad;
                cmd.Parameters.Add("@DesUnidad", SqlDbType.VarChar, 200).Value = obe.DesUnidad;
                cmd.Parameters.Add("@IdSegmento", SqlDbType.VarChar, 3).Value = obe.IdSegmento;
                cmd.Parameters.Add("@DesSegmento", SqlDbType.VarChar, 200).Value = obe.DesSegmento;
                cmd.Parameters.Add("@IdFamilia", SqlDbType.VarChar, 3).Value = obe.IdFamilia;
                cmd.Parameters.Add("@DesFamilia", SqlDbType.VarChar, 200).Value = obe.DesFamilia;
                cmd.Parameters.Add("@IdClase", SqlDbType.VarChar, 3).Value = obe.IdClase;
                cmd.Parameters.Add("@DesClase", SqlDbType.VarChar, 200).Value = obe.DesClase;
                cmd.Parameters.Add("@IdProducto", SqlDbType.VarChar, 3).Value = obe.IdProducto;
                cmd.Parameters.Add("@DesProducto", SqlDbType.VarChar, 200).Value = obe.DesProducto;
                cmd.Parameters.Add("@CodUNSPSC", SqlDbType.VarChar, 20).Value = obe.CodUNSPSC;
                cmd.Parameters.Add("@Estatus", SqlDbType.Bit).Value = obe.Estatus;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;

                cmd.Parameters.Add("@IdProdLaboratorio", SqlDbType.Int).Value = obe.IdProdLaboratorio;
                cmd.Parameters.Add("@CodProdLaboratorio", SqlDbType.VarChar, 10).Value = obe.CodProdLaboratorio;
                cmd.Parameters.Add("@DesProdLaboratorio", SqlDbType.VarChar, 150).Value = obe.DesProdLaboratorio;
                cmd.Parameters.Add("@IdProdGrupo", SqlDbType.Int).Value = obe.IdProdGrupo;
                cmd.Parameters.Add("@DesProdGrupo", SqlDbType.VarChar, 150).Value = obe.DesProdGrupo;
                cmd.Parameters.Add("@IdProdTipoPresentacion", SqlDbType.Int).Value = obe.IdProdTipoPresentacion;
                cmd.Parameters.Add("@CodProdTipoPresentacion", SqlDbType.VarChar, 150).Value = obe.CodProdTipoPresentacion;
                cmd.Parameters.Add("@DesProdTipoPresentacion", SqlDbType.VarChar, 150).Value = obe.DesProdTipoPresentacion;
                cmd.Parameters.Add("@DesNombreGenerico", SqlDbType.VarChar, 150).Value = obe.DesNombreGenerico;
                cmd.Parameters.Add("@DesTipoProducto", SqlDbType.VarChar, 150).Value = obe.DesTipoProducto;
                cmd.Parameters.Add("@DesComposicion", SqlDbType.VarChar, 800).Value = obe.DesComposicion;
                cmd.Parameters.Add("@DesIndicaciones", SqlDbType.VarChar, 800).Value = obe.DesIndicaciones;
                cmd.Parameters.Add("@DesContraIndicaciones", SqlDbType.VarChar, 800).Value = obe.DesContraIndicaciones;
                cmd.Parameters.Add("@RecetaMedica", SqlDbType.VarChar, 2).Value = obe.RecetaMedica;
                cmd.Parameters.Add("@isGenerico", SqlDbType.VarChar, 2).Value = obe.isGenerico;

                int counterMarker = 0;
                object objRes = cmd.ExecuteScalar();
                int.TryParse(objRes.ToString(), out counterMarker);
                if (counterMarker > 0)
                {
                    id = counterMarker;
                    rpta = true;
                }
                else
                {
                    id = 0;
                    msjError = objRes.ToString();
                    rpta = false;
                }
            }
            return rpta;
        }

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, AdministrarProductoBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_AdministrarProducto_Eliminar]", cnBD))
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

        public bool EliminarAdjunto(SqlConnection cnBD, SqlTransaction trx, int Id, string URL, int IdProducto, string UsrModificador)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_AdministrarProducto_EliminarURL]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@URL", SqlDbType.VarChar, 250).Value = URL;
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = IdProducto;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = UsrModificador;

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
