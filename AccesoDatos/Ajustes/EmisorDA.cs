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
    public class EmisorDA
    {

        public List<EmisorBE> Listar(SqlConnection cnBD, string usuario, int idCliente)
        {
            List<EmisorBE> lobe = new List<EmisorBE>();
            EmisorBE obe = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Emisor_Listar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("desTienda");
                        int pos_IdCliente = drd.GetOrdinal("IdCliente");
                        int pos_DesCliente = drd.GetOrdinal("DesCliente");
                        int pos_CodSurcursal = drd.GetOrdinal("CodSucursal");
                        int pos_SerieBoleta = drd.GetOrdinal("SerieBoleta");
                        int pos_SerieFactura = drd.GetOrdinal("SerieFactura");
                        int pos_NomComercial = drd.GetOrdinal("NombreComercial");
                        int pos_NomLegal = drd.GetOrdinal("NombreLegal");
                        int pos_RUC = drd.GetOrdinal("RUC");
                        int pos_Direccion = drd.GetOrdinal("Direccion");
                        int pos_Urbanizacion = drd.GetOrdinal("Urbanizacion");
                        int pos_IdDepartamento = drd.GetOrdinal("IdDepartamento");
                        int pos_Departamento = drd.GetOrdinal("Departamento");
                        int pos_IdProvincia = drd.GetOrdinal("IdProvincia");
                        int pos_Provincia = drd.GetOrdinal("Provincia");
                        int pos_IdDistrito = drd.GetOrdinal("IdDistrito");
                        int pos_Distrito = drd.GetOrdinal("Distrito");
                        int pos_Ubigeo = drd.GetOrdinal("Ubigeo");
                        int pos_UsuarioSOL = drd.GetOrdinal("UsuarioSOL");
                        int pos_ClaveSOL = drd.GetOrdinal("ClaveSOL");
                        int pos_Detraccion = drd.GetOrdinal("Detraccion");
                        int pos_IGV = drd.GetOrdinal("IGV");
                        int pos_ISC = drd.GetOrdinal("ISC");
                        int pos_Estatus = drd.GetOrdinal("Estado");
                        int pos_UsrCreador = drd.GetOrdinal("UsrCreador");
                        int pos_FechaCreacion = drd.GetOrdinal("FchCreacion");
                        int pos_UsrModificador = drd.GetOrdinal("UsrModificador");
                        int pos_FechaModificacion = drd.GetOrdinal("FchModificacion");
                        int pos_impresion = drd.GetOrdinal("impresion");

                        lobe = new List<EmisorBE>();
                        while (drd.Read())
                        {
                            obe = new EmisorBE();
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.desTienda = drd.GetString(pos_DesTienda);
                            obe.IdCliente = drd.GetInt32(pos_IdCliente);
                            obe.desCliente = drd.GetString(pos_DesCliente);
                            obe.codSurcursal = drd.GetString(pos_CodSurcursal);
                            obe.serieBoleta = drd.GetString(pos_SerieBoleta);
                            obe.serieFactura = drd.GetString(pos_SerieFactura);
                            obe.nomComercial = drd.GetString(pos_NomComercial);
                            obe.nomLegal = drd.GetString(pos_NomLegal);
                            obe.ruc = drd.GetString(pos_RUC);
                            obe.direccion = drd.GetString(pos_Direccion);
                            obe.urbanizacion = drd.GetString(pos_Urbanizacion);
                            obe.IdDepartamento = drd.GetString(pos_IdDepartamento);
                            obe.desDepartamento = drd.GetString(pos_Departamento);
                            obe.IdProvincia = drd.GetString(pos_IdProvincia);
                            obe.desProvincia = drd.GetString(pos_Provincia);
                            obe.IdDistrito = drd.GetString(pos_IdDistrito);
                            obe.desDistrito = drd.GetString(pos_Distrito);
                            obe.ubigeo = drd.GetString(pos_Ubigeo);
                            obe.usuarioSOL = drd.GetString(pos_UsuarioSOL);
                            obe.claveSOL = drd.GetString(pos_ClaveSOL);
                            obe.detraccion = drd.GetDecimal(pos_Detraccion);
                            obe.igv = drd.GetDecimal(pos_IGV);
                            obe.isc = drd.GetDecimal(pos_ISC);
                            obe.activo = drd.GetBoolean(pos_Estatus);
                            obe.UsrCreador = drd.GetString(pos_UsrCreador);
                            obe.FchCreacion = drd.GetString(pos_FechaCreacion);
                            obe.UsrModificador = drd.GetString(pos_UsrModificador);
                            obe.FchModificacion = drd.GetString(pos_FechaModificacion);
                            obe.impresion = drd.GetString(pos_impresion);
                            lobe.Add(obe);
                        }
                    }
                }
            }

            return lobe;
        }

        public bool Guardar(SqlConnection cnBD, SqlTransaction trx, EmisorBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Emisor_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = obe.IdTienda;
                cmd.Parameters.Add("@desTienda", SqlDbType.VarChar, 50).Value = obe.desTienda;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@desCliente", SqlDbType.VarChar, 200).Value = obe.desCliente;
                cmd.Parameters.Add("@codSurcursal", SqlDbType.VarChar, 5).Value = obe.codSurcursal;
                cmd.Parameters.Add("@serieBoleta", SqlDbType.VarChar, 5).Value = obe.serieBoleta;
                cmd.Parameters.Add("@serieFactura", SqlDbType.VarChar, 5).Value = obe.serieFactura;
                cmd.Parameters.Add("@nomComercial", SqlDbType.VarChar, 250).Value = obe.nomComercial;
                cmd.Parameters.Add("@nomLegal", SqlDbType.VarChar, 250).Value = obe.nomLegal;
                cmd.Parameters.Add("@ruc", SqlDbType.VarChar, 11).Value = obe.ruc;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 250).Value = obe.direccion;
                cmd.Parameters.Add("@urbanizacion", SqlDbType.VarChar, 150).Value = obe.urbanizacion;
                cmd.Parameters.Add("@IdDepartamento", SqlDbType.VarChar, 3).Value = obe.IdDepartamento;
                cmd.Parameters.Add("@desDepartamento", SqlDbType.VarChar, 150).Value = obe.desDepartamento;
                cmd.Parameters.Add("@IdProvincia", SqlDbType.VarChar, 3).Value = obe.IdProvincia;
                cmd.Parameters.Add("@desProvincia", SqlDbType.VarChar, 150).Value = obe.desProvincia;
                cmd.Parameters.Add("@IdDistrito", SqlDbType.VarChar, 3).Value = obe.IdDistrito;
                cmd.Parameters.Add("@desDistrito", SqlDbType.VarChar, 150).Value = obe.desDistrito;
                cmd.Parameters.Add("@ubigeo", SqlDbType.VarChar, 7).Value = obe.ubigeo;
                cmd.Parameters.Add("@usuarioSOL", SqlDbType.VarChar, 250).Value = obe.usuarioSOL;
                cmd.Parameters.Add("@claveSOL", SqlDbType.VarChar, 250).Value = obe.claveSOL;
                cmd.Parameters.Add("@detraccion", SqlDbType.Decimal).Value = obe.detraccion;
                cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = obe.igv;
                cmd.Parameters.Add("@isc", SqlDbType.Decimal).Value = obe.isc;
                cmd.Parameters.Add("@activo", SqlDbType.Bit).Value = obe.activo;
                cmd.Parameters.Add("@impresion", SqlDbType.VarChar, 10).Value = obe.impresion;
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

        public bool Actualizar(SqlConnection cnBD, SqlTransaction trx, EmisorBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Emisor_Actualizar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obe.Id;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = obe.IdTienda;
                cmd.Parameters.Add("@desTienda", SqlDbType.VarChar, 50).Value = obe.desTienda;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@desCliente", SqlDbType.VarChar, 200).Value = obe.desCliente;
                cmd.Parameters.Add("@codSurcursal", SqlDbType.VarChar, 5).Value = obe.codSurcursal;
                cmd.Parameters.Add("@serieBoleta", SqlDbType.VarChar, 5).Value = obe.serieBoleta;
                cmd.Parameters.Add("@serieFactura", SqlDbType.VarChar, 5).Value = obe.serieFactura;
                cmd.Parameters.Add("@nomComercial", SqlDbType.VarChar, 250).Value = obe.nomComercial;
                cmd.Parameters.Add("@nomLegal", SqlDbType.VarChar, 250).Value = obe.nomLegal;
                cmd.Parameters.Add("@ruc", SqlDbType.VarChar, 11).Value = obe.ruc;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 250).Value = obe.direccion;
                cmd.Parameters.Add("@urbanizacion", SqlDbType.VarChar, 150).Value = obe.urbanizacion;
                cmd.Parameters.Add("@IdDepartamento", SqlDbType.VarChar, 3).Value = obe.IdDepartamento;
                cmd.Parameters.Add("@desDepartamento", SqlDbType.VarChar, 150).Value = obe.desDepartamento;
                cmd.Parameters.Add("@IdProvincia", SqlDbType.VarChar, 3).Value = obe.IdProvincia;
                cmd.Parameters.Add("@desProvincia", SqlDbType.VarChar, 150).Value = obe.desProvincia;
                cmd.Parameters.Add("@IdDistrito", SqlDbType.VarChar, 3).Value = obe.IdDistrito;
                cmd.Parameters.Add("@desDistrito", SqlDbType.VarChar, 150).Value = obe.desDistrito;
                cmd.Parameters.Add("@ubigeo", SqlDbType.VarChar, 7).Value = obe.ubigeo;
                cmd.Parameters.Add("@usuarioSOL", SqlDbType.VarChar, 250).Value = obe.usuarioSOL;
                cmd.Parameters.Add("@claveSOL", SqlDbType.VarChar, 250).Value = obe.claveSOL;
                cmd.Parameters.Add("@detraccion", SqlDbType.Decimal).Value = obe.detraccion;
                cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = obe.igv;
                cmd.Parameters.Add("@isc", SqlDbType.Decimal).Value = obe.isc;
                cmd.Parameters.Add("@activo", SqlDbType.Bit).Value = obe.activo;
                cmd.Parameters.Add("@impresion", SqlDbType.VarChar, 10).Value = obe.impresion;
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

        public bool Eliminar(SqlConnection cnBD, SqlTransaction trx, EmisorBE obe)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Ajustes_Emisor_Eliminar]", cnBD))
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
