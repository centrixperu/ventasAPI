using Entidades.Almacen.CodigoBarras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Almacen.CodigoBarras
{
    public class CodigoBarrasDA
    {
        public List<CodigoBarrasBE> ListarDatosIniciales(SqlConnection cnBD, string usuario)
        {
            List<CodigoBarrasBE> lobe = new List<CodigoBarrasBE>();
            CodigoBarrasBE obe = new CodigoBarrasBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Almacen_CodigoBarras_Lista]", cnBD))
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
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_Selec = drd.GetOrdinal("Selec");

                        lobe = new List<CodigoBarrasBE>();
                        while (drd.Read())
                        {
                            obe = new CodigoBarrasBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Nombre = drd.GetString(pos_Nombre);
                            obe.Cantidad = drd.GetInt32(pos_Cantidad);
                            obe.Selec = drd.GetBoolean(pos_Selec);
                            lobe.Add(obe);
                        }
                    }
                }
            }
            return lobe;
        }

    }
}
