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
    public class UsuarioDA
    {
        public List<UsuarioBE> ListarDatosIniciales(SqlConnection cnBD, string usuario)
        {
            List<UsuarioBE> lobe = new List<UsuarioBE>();
            UsuarioBE obe = new UsuarioBE();
            ListaComboBE obeT = new ListaComboBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Usuario_Lista]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_UsuarioSesion = drd.GetOrdinal("UsuarioSesion");
                        int pos_Nombre = drd.GetOrdinal("Nombre");
                        int pos_ApePat = drd.GetOrdinal("ApePat");
                        int pos_ApeMat = drd.GetOrdinal("ApeMat");
                        int pos_DNI = drd.GetOrdinal("DNI");
                        int pos_Sexo = drd.GetOrdinal("Sexo");
                        int pos_Celular = drd.GetOrdinal("Celular");
                        int pos_Correo = drd.GetOrdinal("Correo");
                        int pos_IdCliente = drd.GetOrdinal("IdCliente");
                        int pos_Cliente = drd.GetOrdinal("Cliente");
                        int pos_IdPerfil = drd.GetOrdinal("IdPerfil");
                        int pos_Perfil = drd.GetOrdinal("Perfil");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FchModificacion = drd.GetOrdinal("FchModificacion");
                        int pos_URLFoto = drd.GetOrdinal("URLFoto");
                        #endregion columnas
                        lobe = new List<UsuarioBE>();
                        while (drd.Read())
                        {
                            #region variables
                            obe = new UsuarioBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.UsuarioSesion = drd.GetString(pos_UsuarioSesion);
                            obe.IdCliente = drd.GetInt32(pos_IdCliente);
                            obe.DesCliente = drd.GetString(pos_Cliente);
                            obe.IdPerfil = drd.GetInt32(pos_IdPerfil);
                            obe.DesPerfil = drd.GetString(pos_Perfil);
                            obe.Nombre = drd.GetString(pos_Nombre);
                            obe.ApePat = drd.GetString(pos_ApePat);
                            obe.ApeMat = drd.GetString(pos_ApeMat);
                            obe.DNI = drd.GetString(pos_DNI);
                            obe.Sexo = drd.GetString(pos_Sexo);
                            obe.Correo = drd.GetString(pos_Correo);
                            obe.Celular = drd.GetString(pos_Celular);
                            obe.Estado = drd.GetBoolean(pos_Estado);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.UsrModificador = drd.GetString(pos_UsrModificador);
                            obe.FchModificacion = drd.GetString(pos_FchModificacion);
                            obe.URLFoto = drd.GetString(pos_URLFoto);
                            obe.loTienda = new List<ListaComboBE>();
                            lobe.Add(obe);
                            #endregion variables
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_IdUsuario = drd.GetOrdinal("IdUsuario");
                        #endregion columnas
                        while (drd.Read())
                        {
                            obeT = new ListaComboBE();
                            int idUsuario = drd.GetInt32(pos_IdUsuario);
                            obeT.codigo = drd.GetInt32(pos_IdTienda);
                            int index = lobe.FindIndex(det => det.Id == idUsuario);
                            if (index != -1)
                            {
                                lobe[index].loTienda.Add(obeT);
                            }
                        }
                    }
                }
            }
            return lobe;
        }

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
                    object[] RowValues = { lobe[i].codigo, "" };
                    dRow = dataT.Rows.Add(RowValues);
                }
            }
            dataT.AcceptChanges();
            return dataT;
        }

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, UsuarioBE obe, out int idCliente)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Usuario_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 150).Value = obe.DesCliente;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obe.IdPerfil;
                cmd.Parameters.Add("@DesPerfil", SqlDbType.VarChar, 150).Value = obe.DesPerfil;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 150).Value = obe.Nombre;
                cmd.Parameters.Add("@ApePat", SqlDbType.VarChar, 150).Value = obe.ApePat;
                cmd.Parameters.Add("@ApeMat", SqlDbType.VarChar, 150).Value = obe.ApeMat;
                cmd.Parameters.Add("@DNI", SqlDbType.VarChar, 9).Value = obe.DNI;
                cmd.Parameters.Add("@Sexo", SqlDbType.VarChar, 20).Value = obe.Sexo;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 150).Value = obe.Correo;
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 9).Value = obe.Celular;
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 150).Value = obe.Clave;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@UsuarioSesion", SqlDbType.VarChar, 50).Value = obe.UsuarioSesion;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(obe.loTienda);

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

        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, UsuarioBE obe, out int idCliente)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Usuario_Actualizar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 150).Value = obe.DesCliente;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obe.IdPerfil;
                cmd.Parameters.Add("@DesPerfil", SqlDbType.VarChar, 150).Value = obe.DesPerfil;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 150).Value = obe.Nombre;
                cmd.Parameters.Add("@ApePat", SqlDbType.VarChar, 150).Value = obe.ApePat;
                cmd.Parameters.Add("@ApeMat", SqlDbType.VarChar, 150).Value = obe.ApeMat;
                cmd.Parameters.Add("@DNI", SqlDbType.VarChar, 9).Value = obe.DNI;
                cmd.Parameters.Add("@Sexo", SqlDbType.VarChar, 20).Value = obe.Sexo;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 150).Value = obe.Correo;
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 9).Value = obe.Celular;
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 150).Value = obe.Clave;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@UsuarioSesion", SqlDbType.VarChar, 50).Value = obe.UsuarioSesion;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructura(obe.loTienda);

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

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, UsuarioBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Usuario_Eliminar]", cnBD))
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

        public bool GuardarURLLogo(SqlConnection cnBD, SqlTransaction trx, string ruta, int id, string usuario)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Usuario_GuardarURLLogo]", cnBD))
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
    }
}
