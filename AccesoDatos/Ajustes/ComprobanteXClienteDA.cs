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
    public class ComprobanteXClienteDA
    {
        public List<ComprobanteXClienteBE> ListarDatosIniciales(SqlConnection cnBD, string usuario)//, int idCliente)
        {
            List<ComprobanteXClienteBE> lobe = new List<ComprobanteXClienteBE>();
            ComprobanteXClienteBE obe = new ComprobanteXClienteBE();
            ListaComboTextBE obeC = new ListaComboTextBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ComprobanteXCliente_Lista]", cnBD))
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
                        int pos_IdCliente = drd.GetOrdinal("IdCliente");
                        int pos_ClienteDes = drd.GetOrdinal("ClienteDes");
                        int pos_CodigoSUNAT = drd.GetOrdinal("CodigoSUNAT");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FchCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FchModificacion = drd.GetOrdinal("FchModificacion");

                        lobe = new List<ComprobanteXClienteBE>();
                        while (drd.Read())
                        {
                            obe = new ComprobanteXClienteBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.IdCliente = drd.GetInt32(pos_IdCliente);
                            obe.DesCliente = drd.GetString(pos_ClienteDes);
                            obe.Comprobantes = "";
                            obe.Estado = drd.GetBoolean(pos_Estado);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FchCreacion);
                            obe.UsrModificador = drd.GetString(pos_UsrModificador);
                            obe.FchModificacion = drd.GetString(pos_FchModificacion);
                            obe.loComprobante = new List<ListaComboTextBE>();

                            obeC = new ListaComboTextBE();
                            obeC.codigo = drd.GetString(pos_CodigoSUNAT); 
                            obeC.descripcion = drd.GetString(pos_Descripcion);

                            int index = lobe.FindIndex(det => det.IdCliente == obe.IdCliente);
                            if (index != -1)
                            {
                                lobe[index].Comprobantes = lobe[index].Comprobantes + "[" + obeC.codigo + " - " + obeC.descripcion + "]";
                                lobe[index].loComprobante.Add(obeC);
                            }
                            else
                            {
                                obe.Comprobantes = obe.Comprobantes + "[" + obeC.codigo + " - " + obeC.descripcion + "]";
                                obe.loComprobante.Add(obeC);
                                lobe.Add(obe);
                            }
                            
                        }
                    }
                }
            }
            return lobe;
        }


        private DataTable CrearEstructura(List<ListaComboTextBE> lobe)
        {
            DataTable dataT = new DataTable();
            DataRow dRow;
            dataT.Columns.Add(new DataColumn("codigo"));
            dataT.Columns.Add(new DataColumn("descripcion"));

            if (lobe != null && lobe.Count > 0)
            {
                for (int i = 0; i < lobe.Count; i++)
                {
                    object[] RowValues = { lobe[i].codigo, lobe[i].descripcion};
                    dRow = dataT.Rows.Add(RowValues);
                }
            }
            dataT.AcceptChanges();
            return dataT;
        }

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, ComprobanteXClienteBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ComprobanteXCliente_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@loComprobante", SqlDbType.Structured).Value = CrearEstructura(obe.loComprobante);

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

        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, ComprobanteXClienteBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ComprobanteXCliente_Actualizar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = obe.Estado;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@loComprobante", SqlDbType.Structured).Value = CrearEstructura(obe.loComprobante);

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

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, ComprobanteXClienteBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_ComprobanteXCliente_Eliminar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
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
