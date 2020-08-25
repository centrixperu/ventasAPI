using Entidades.Ajustes;
using Entidades.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Ajustes
{
    public class PerfilDA
    {

        public List<PerfilBE> ListarDatosIniciales(SqlConnection cnBD, string Usuario)
        {
            List<PerfilBE> lobe = new List<PerfilBE>();
            PerfilBE obe = new PerfilBE();
            ListaComboBE obem = new ListaComboBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Perfil_Lista]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = Usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Nombre = drd.GetOrdinal("Nombre");
                        int pos_IdCliente = drd.GetOrdinal("IdCliente");
                        int pos_Cliente = drd.GetOrdinal("Cliente");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FchModificacion = drd.GetOrdinal("FchModificacion");

                        lobe = new List<PerfilBE>();
                        while (drd.Read())
                        {
                            obe = new PerfilBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Nombre = drd.GetString(pos_Nombre);
                            obe.IdCliente = drd.GetInt32(pos_IdCliente);
                            obe.DesCliente = drd.GetString(pos_Cliente);
                            obe.Estado = drd.GetBoolean(pos_Estado);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.UsrModificador = drd.GetString(pos_UsrModificador);
                            obe.FchModificacion = drd.GetString(pos_FchModificacion);
                            obe.loModulos = new List<ListaComboBE>();
                            lobe.Add(obe);
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("IdMenu");
                        int pos_Nombre = drd.GetOrdinal("Menu");
                        int pos_IdPerfil = drd.GetOrdinal("IdPerfil");
                        int pos_IdCliente = drd.GetOrdinal("IdCliente");

                        while (drd.Read())
                        {
                            obem = new ListaComboBE();
                            int idPerfil = drd.GetInt32(pos_IdPerfil);
                            int idCliente = drd.GetInt32(pos_IdCliente);
                            obem.codigo = drd.GetInt32(pos_Id);
                            obem.descripcion = drd.GetString(pos_Nombre);

                            int index = lobe.FindIndex(det => det.Id == idPerfil && det.IdCliente == idCliente);
                            if(index != -1)
                            {
                                lobe[index].loModulos.Add(obem);
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
            dataT.Columns.Add(new DataColumn("Id"));
            dataT.Columns.Add(new DataColumn("Modulo"));

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

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, PerfilBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Perfil_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 150).Value = obe.Nombre;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 150).Value = obe.DesCliente;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@loModulos", SqlDbType.Structured).Value = CrearEstructura(obe.loModulos);

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

        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, PerfilBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Perfil_Actualizar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 150).Value = obe.Nombre;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 150).Value = obe.DesCliente;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@loModulos", SqlDbType.Structured).Value = CrearEstructura(obe.loModulos);

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

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, PerfilBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Perfil_Eliminar]", cnBD))
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
