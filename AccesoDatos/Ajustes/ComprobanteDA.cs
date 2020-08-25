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
    public class ComprobanteDA
    {
        public List<ComprobanteBE> ListarDatosIniciales(SqlConnection cnBD, string usuario)//, int idCliente)
        {
            List<ComprobanteBE> lobe = new List<ComprobanteBE>();
            ComprobanteBE obe = new ComprobanteBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Comprobante_Lista]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                //cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_CodigoSUNAT = drd.GetOrdinal("CodigoSUNAT");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_CodDocDefecto = drd.GetOrdinal("CodDocDefecto");
                        int pos_DesDocDefecto = drd.GetOrdinal("DesDocDefecto");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FchModificacion = drd.GetOrdinal("FchModificacion");

                        lobe = new List<ComprobanteBE>();
                        while (drd.Read())
                        {
                            obe = new ComprobanteBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.CodigoSUNAT = drd.GetString(pos_CodigoSUNAT);
                            obe.Descripcion = drd.GetString(pos_Descripcion);
                            obe.CodDocDefecto = drd.GetString(pos_CodDocDefecto);
                            obe.DesDocDefecto = drd.GetString(pos_DesDocDefecto);
                            obe.Estado = drd.GetBoolean(pos_Estado);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.UsrModificador = drd.GetString(pos_UsrModificador);
                            obe.FchModificacion = drd.GetString(pos_FchModificacion);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, ComprobanteBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Comprobante_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@CodigoSUNAT", SqlDbType.VarChar, 4).Value = obe.CodigoSUNAT;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = obe.Descripcion;
                cmd.Parameters.Add("@TipoDocIdenDefecto", SqlDbType.VarChar, 4).Value = obe.CodDocDefecto;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
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

        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, ComprobanteBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Comprobante_Actualizar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@CodigoSUNAT", SqlDbType.VarChar, 4).Value = obe.CodigoSUNAT;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = obe.Descripcion;
                cmd.Parameters.Add("@TipoDocIdenDefecto", SqlDbType.VarChar, 4).Value = obe.CodDocDefecto;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
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

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, ComprobanteBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Comprobante_Eliminar]", cnBD))
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
