using Entidades.Ajustes.Producto_GrupoMedico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Ajustes
{
    public class ProductoGrupoMedicoDA
    {
        public List<ProductoGrupoMedicoBE> ListarDatosIniciales(SqlConnection cnBD, string usuario)
        {
            List<ProductoGrupoMedicoBE> lobe = new List<ProductoGrupoMedicoBE>();
            ProductoGrupoMedicoBE obe = new ProductoGrupoMedicoBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ProductoGrupoMedico_Lista]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Nombre = drd.GetOrdinal("Nombre");
                        int pos_IdCliente = drd.GetOrdinal("IdCliente");
                        int pos_DesCliente = drd.GetOrdinal("DesCliente");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FchModificacion = drd.GetOrdinal("FchModificacion");

                        lobe = new List<ProductoGrupoMedicoBE>();
                        while (drd.Read())
                        {
                            obe = new ProductoGrupoMedicoBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Nombre = drd.GetString(pos_Nombre);
                            obe.IdCliente = drd.GetInt32(pos_IdCliente);
                            obe.DesCliente = drd.GetString(pos_DesCliente);
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

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, ProductoGrupoMedicoBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ProductoGrupoMedico_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@DesAlmacen", SqlDbType.VarChar, 150).Value = obe.Nombre;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 150).Value = obe.DesCliente;
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

        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, ProductoGrupoMedicoBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ProductoGrupoMedico_Actualizar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@DesAlmacen", SqlDbType.VarChar, 150).Value = obe.Nombre;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@DesCliente", SqlDbType.VarChar, 150).Value = obe.DesCliente;
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

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, ProductoGrupoMedicoBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ProductoGrupoMedico_Eliminar]", cnBD))
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
