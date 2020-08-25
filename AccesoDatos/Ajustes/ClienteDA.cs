using Entidades.Ajustes;
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
    public class ClienteDA
    {

        public List<ClienteBE> ListarDatosIniciales(SqlConnection cnBD, string Usuario)
        {
            List<ClienteBE> lobe = new List<ClienteBE>();
            ClienteBE obe = new ClienteBE();
            ListaArchivosAdjuntos obeArch = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Cliente_Lista]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = Usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region parametros
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_DesCliente = drd.GetOrdinal("DesCliente");
                        int pos_RUC = drd.GetOrdinal("RUC");
                        int pos_DNI = drd.GetOrdinal("DNI");
                        int pos_NombreLegal = drd.GetOrdinal("NombreLegal");
                        int pos_NombreComercial = drd.GetOrdinal("NombreComercial");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_isFactOnline = drd.GetOrdinal("isFactOnline");
                        int pos_isFactProg = drd.GetOrdinal("isFactProg");
                        int pos_isFactProgHour = drd.GetOrdinal("isFactProgHour");
                        int pos_isTipoProducto = drd.GetOrdinal("isTipoProducto");
                        int pos_isCostoProduccion = drd.GetOrdinal("isCostoProduccion");
                        int pos_isFechaVenProd = drd.GetOrdinal("isFechaVenProd");
                        int pos_isPrecioConIGV = drd.GetOrdinal("isPrecioConIGV");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FchModificacion = drd.GetOrdinal("FchModificacion");
                        int pos_UsuarioSOL = drd.GetOrdinal("UsuarioSOL");
                        int pos_ClaveSOL = drd.GetOrdinal("ClaveSOL");
                        int pos_ClaveDigital = drd.GetOrdinal("ClaveDigital");
                        int pos_URLCertificado = drd.GetOrdinal("URLCertificado");
                        int pos_URLLogo = drd.GetOrdinal("URLLogo");
                        //RUBRO MEDICO
                        int pos_isLaboratorio = drd.GetOrdinal("isLaboratorio");
                        int pos_isNombreGenerico = drd.GetOrdinal("isNombreGenerico");
                        int pos_isGrupoMedico = drd.GetOrdinal("isGrupoMedico");
                        int pos_isTipoMedico = drd.GetOrdinal("isTipoMedico");
                        int pos_isTipoPresentacion = drd.GetOrdinal("isTipoPresentacion");
                        int pos_isComposicion = drd.GetOrdinal("isComposicion");
                        int pos_isContraIndicaciones = drd.GetOrdinal("isContraIndicaciones");
                        int pos_isUbicacion = drd.GetOrdinal("isUbicacion");
                        int pos_isLote = drd.GetOrdinal("isLote");
                        int pos_isRecetaMedica = drd.GetOrdinal("isRecetaMedica");
                        #endregion parametros
                        lobe = new List<ClienteBE>();
                        while (drd.Read())
                        {
                            #region variables
                            obe = new ClienteBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.DesCliente = drd.GetString(pos_DesCliente);
                            obe.RUC = drd.GetString(pos_RUC);
                            obe.DNI = drd.GetString(pos_DNI);
                            obe.NombreLegal = drd.GetString(pos_NombreLegal);
                            obe.NombreComercial = drd.GetString(pos_NombreComercial);
                            obe.Estado = drd.GetBoolean(pos_Estado);
                            obe.isFactOnline = drd.GetBoolean(pos_isFactOnline);
                            obe.isFactProg = drd.GetBoolean(pos_isFactProg);
                            obe.isFactProgHour = drd.GetString(pos_isFactProgHour);
                            obe.isTipoProducto = drd.GetBoolean(pos_isTipoProducto);
                            obe.isCostoProduccion = drd.GetBoolean(pos_isCostoProduccion);
                            obe.isFechaVenProd = drd.GetBoolean(pos_isFechaVenProd);
                            obe.isPrecioConIGV = drd.GetInt32(pos_isPrecioConIGV);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.UsrModificador = drd.GetString(pos_UsrModificador);
                            obe.FchModificacion = drd.GetString(pos_FchModificacion);
                            obe.UsuarioSOL = drd.GetString(pos_UsuarioSOL);
                            obe.ClaveSOL = drd.GetString(pos_ClaveSOL);
                            obe.ClaveDigital = drd.GetString(pos_ClaveDigital);
                            obe.URLCertificado = drd.GetString(pos_URLCertificado);
                            obe.URLLogo = drd.GetString(pos_URLLogo);
                            obe.loarchivos = new List<ListaArchivosAdjuntos>();
                            //---- RUBRO MEDICO
                            obe.isLaboratorio = drd.GetBoolean(pos_isLaboratorio);
                            obe.isNombreGenerico = drd.GetBoolean(pos_isNombreGenerico);
                            obe.isGrupoMedico = drd.GetBoolean(pos_isGrupoMedico);
                            obe.isTipoMedico = drd.GetBoolean(pos_isTipoMedico);
                            obe.isTipoPresentacion = drd.GetBoolean(pos_isTipoPresentacion);
                            obe.isComposicion = drd.GetBoolean(pos_isComposicion);
                            obe.isContraIndicaciones = drd.GetBoolean(pos_isContraIndicaciones);
                            obe.isUbicacion = drd.GetBoolean(pos_isUbicacion);
                            obe.isLote = drd.GetBoolean(pos_isLote);
                            obe.isRecetaMedica = drd.GetBoolean(pos_isRecetaMedica);
                            #endregion variables
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, ClienteBE obe, out int idCliente)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Cliente_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 150).Value = obe.DesCliente;
                cmd.Parameters.Add("@TipoDoc", SqlDbType.VarChar, 2).Value = obe.TipoDoc;
                cmd.Parameters.Add("@RUC", SqlDbType.VarChar, 11).Value = obe.RUC;
                cmd.Parameters.Add("@DNI", SqlDbType.VarChar,8).Value = obe.DNI;
                cmd.Parameters.Add("@NombreLegal", SqlDbType.VarChar,150).Value = obe.NombreLegal;
                cmd.Parameters.Add("@NombreComercial", SqlDbType.VarChar,150).Value = obe.NombreComercial;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@isFactOnline", SqlDbType.Bit).Value = obe.isFactOnline;
                cmd.Parameters.Add("@isFactProg", SqlDbType.Bit).Value = obe.isFactProg;
                cmd.Parameters.Add("@isFactProgHour", SqlDbType.VarChar, 5).Value = obe.isFactProgHour;
                cmd.Parameters.Add("@isTipoProducto", SqlDbType.Bit).Value = obe.isTipoProducto;
                cmd.Parameters.Add("@isCostoProduccion", SqlDbType.Bit).Value = obe.isCostoProduccion;
                cmd.Parameters.Add("@isFechaVenProd", SqlDbType.Bit).Value = obe.isFechaVenProd;
                cmd.Parameters.Add("@isPrecioConIGV", SqlDbType.Int).Value = obe.isPrecioConIGV;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@UsuarioSOL", SqlDbType.VarChar, 150).Value = obe.UsuarioSOL;
                cmd.Parameters.Add("@ClaveSOL", SqlDbType.VarChar, 150).Value = obe.ClaveSOL;
                cmd.Parameters.Add("@ClaveDigital", SqlDbType.VarChar, 150).Value = obe.ClaveDigital;
                cmd.Parameters.Add("@URLCertificado", SqlDbType.VarChar, 250).Value = obe.URLCertificado;
                // RUBRO MEDICO
                cmd.Parameters.Add("@isLaboratorio", SqlDbType.Bit).Value = obe.isLaboratorio;
                cmd.Parameters.Add("@isNombreGenerico", SqlDbType.Bit).Value = obe.isNombreGenerico;
                cmd.Parameters.Add("@isGrupoMedico", SqlDbType.Bit).Value = obe.isGrupoMedico;
                cmd.Parameters.Add("@isTipoMedico", SqlDbType.Bit).Value = obe.isTipoMedico;
                cmd.Parameters.Add("@isTipoPresentacion", SqlDbType.Bit).Value = obe.isTipoPresentacion;
                cmd.Parameters.Add("@isComposicion", SqlDbType.Bit).Value = obe.isComposicion;
                cmd.Parameters.Add("@isContraIndicaciones", SqlDbType.Bit).Value = obe.isContraIndicaciones;
                cmd.Parameters.Add("@isUbicacion", SqlDbType.Bit).Value = obe.isUbicacion;
                cmd.Parameters.Add("@isLote", SqlDbType.Bit).Value = obe.isLote;
                cmd.Parameters.Add("@isRecetaMedica", SqlDbType.Bit).Value = obe.isRecetaMedica;
                // 
                int counterMarker = 0;
                object objRes = cmd.ExecuteScalar();
                int.TryParse(objRes.ToString(), out counterMarker);
                if (counterMarker > 0)
                {
                    idCliente = counterMarker;
                    rpta = true;
                }
                else
                {
                    msjError = objRes.ToString();
                    idCliente = 0;
                    rpta = false;
                }
            }
            return rpta;
        }

        public bool GuardarURL(SqlConnection cnBD, SqlTransaction trx, string ruta, int id, string usuario)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Cliente_GuardarURL]", cnBD))
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

        public bool GuardarURLLogo(SqlConnection cnBD, SqlTransaction trx, string ruta, int id, string usuario)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Cliente_GuardarURLLogo]", cnBD))
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

        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, ClienteBE obe, out int idCliente)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Cliente_Actualizar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 150).Value = obe.DesCliente;
                cmd.Parameters.Add("@TipoDoc", SqlDbType.VarChar, 2).Value = obe.TipoDoc;
                cmd.Parameters.Add("@RUC", SqlDbType.VarChar, 11).Value = obe.RUC;
                cmd.Parameters.Add("@DNI", SqlDbType.VarChar, 8).Value = obe.DNI;
                cmd.Parameters.Add("@NombreLegal", SqlDbType.VarChar, 150).Value = obe.NombreLegal;
                cmd.Parameters.Add("@NombreComercial", SqlDbType.VarChar, 150).Value = obe.NombreComercial;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@isFactOnline", SqlDbType.Bit).Value = obe.isFactOnline;
                cmd.Parameters.Add("@isFactProg", SqlDbType.Bit).Value = obe.isFactProg;
                cmd.Parameters.Add("@isFactProgHour", SqlDbType.VarChar, 5).Value = obe.isFactProgHour;
                cmd.Parameters.Add("@isTipoProducto", SqlDbType.Bit).Value = obe.isTipoProducto;
                cmd.Parameters.Add("@isCostoProduccion", SqlDbType.Bit).Value = obe.isCostoProduccion;
                cmd.Parameters.Add("@isFechaVenProd", SqlDbType.Bit).Value = obe.isFechaVenProd;
                cmd.Parameters.Add("@isPrecioConIGV", SqlDbType.Int).Value = obe.isPrecioConIGV;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@UsuarioSOL", SqlDbType.VarChar, 150).Value = obe.UsuarioSOL;
                cmd.Parameters.Add("@ClaveSOL", SqlDbType.VarChar, 150).Value = obe.ClaveSOL;
                cmd.Parameters.Add("@ClaveDigital", SqlDbType.VarChar, 150).Value = obe.ClaveDigital;
                cmd.Parameters.Add("@URLCertificado", SqlDbType.VarChar, 250).Value = obe.URLCertificado;
                // RUBRO MEDICO
                cmd.Parameters.Add("@isLaboratorio", SqlDbType.Bit).Value = obe.isLaboratorio;
                cmd.Parameters.Add("@isNombreGenerico", SqlDbType.Bit).Value = obe.isNombreGenerico;
                cmd.Parameters.Add("@isGrupoMedico", SqlDbType.Bit).Value = obe.isGrupoMedico;
                cmd.Parameters.Add("@isTipoMedico", SqlDbType.Bit).Value = obe.isTipoMedico;
                cmd.Parameters.Add("@isTipoPresentacion", SqlDbType.Bit).Value = obe.isTipoPresentacion;
                cmd.Parameters.Add("@isComposicion", SqlDbType.Bit).Value = obe.isComposicion;
                cmd.Parameters.Add("@isContraIndicaciones", SqlDbType.Bit).Value = obe.isContraIndicaciones;
                cmd.Parameters.Add("@isUbicacion", SqlDbType.Bit).Value = obe.isUbicacion;
                cmd.Parameters.Add("@isLote", SqlDbType.Bit).Value = obe.isLote;
                cmd.Parameters.Add("@isRecetaMedica", SqlDbType.Bit).Value = obe.isRecetaMedica;
                // 

                int counterMarker = 0;
                object objRes = cmd.ExecuteScalar();
                int.TryParse(objRes.ToString(), out counterMarker);
                if (counterMarker > 0 || obe.Id==0)
                {
                    idCliente = counterMarker;
                    rpta = true;
                }
                else
                {
                    msjError = objRes.ToString();
                    idCliente = 0;
                    rpta = false;
                }
            }
            return rpta;
        }

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, ClienteBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Cliente_Eliminar]", cnBD))
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

        public bool EliminarLogo(SqlConnection cnBD, SqlTransaction trx, ClienteBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Cliente_EliminarLogo]", cnBD))
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
