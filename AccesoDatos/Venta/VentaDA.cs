using Entidades.ReporteCliente;
using Entidades.Utils;
using Entidades.Venta;
using Entidades.Venta.ListadoVenta;
using Entidades.Venta.RegistroVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Venta
{
    public class VentaDA
    {
        private DataTable CrearEstructura(List<VentaDetalleBE> lobe, List<ListaCorrelativoVentaBE> obe)
        {
            DataTable dataT = new DataTable();
            DataRow dRow;
            dataT.Columns.Add(new DataColumn("n_id_detalle"));
            dataT.Columns.Add(new DataColumn("n_id_cabecera"));
            dataT.Columns.Add(new DataColumn("c_id_producto"));
            dataT.Columns.Add(new DataColumn("c_id_productoAlmacen"));
            dataT.Columns.Add(new DataColumn("c_id_tienda"));
            dataT.Columns.Add(new DataColumn("c_codigo_item"));
            dataT.Columns.Add(new DataColumn("c_decripcion"));
            dataT.Columns.Add(new DataColumn("c_tipo_precio"));
            dataT.Columns.Add(new DataColumn("n_precio_referencial"));
            dataT.Columns.Add(new DataColumn("n_precio_unitario"));
            dataT.Columns.Add(new DataColumn("n_descuento"));
            dataT.Columns.Add(new DataColumn("n_cantidad"));
            dataT.Columns.Add(new DataColumn("n_unidad_medida"));
            dataT.Columns.Add(new DataColumn("n_tipo_impuesto"));
            dataT.Columns.Add(new DataColumn("n_impuesto"));
            dataT.Columns.Add(new DataColumn("n_impuesto_selectivo"));
            dataT.Columns.Add(new DataColumn("n_otro_impuesto"));
            dataT.Columns.Add(new DataColumn("n_total_venta"));
            dataT.Columns.Add(new DataColumn("n_suma"));
            dataT.Columns.Add(new DataColumn("c_tipo_documento"));
            dataT.Columns.Add(new DataColumn("c_id_documento"));
            dataT.Columns.Add(new DataColumn("c_emisor_nombre_legal"));
            dataT.Columns.Add(new DataColumn("c_emisor_numero_documento"));

            if (lobe != null && lobe.Count > 0)
            {
                for (int i = 0; i < lobe.Count; i++)
                {
                    object[] RowValues = { lobe[i].n_id_detalle, lobe[i].n_id_cabecera, lobe[i].c_id_producto, lobe[i].c_id_productoAlmacen,
                                            lobe[i].c_id_tienda, lobe[i].c_codigo_item,
                                            lobe[i].c_decripcion, lobe[i].c_tipo_precio, lobe[i].n_precio_referencial,
                                            lobe[i].n_precio_unitario, lobe[i].n_descuento, lobe[i].n_cantidad,
                                            lobe[i].n_unidad_medida, lobe[i].n_tipo_impuesto, lobe[i].n_impuesto,
                                            lobe[i].n_impuesto_selectivo, lobe[i].n_otro_impuesto, lobe[i].n_total_venta,
                                            lobe[i].n_suma, lobe[i].c_tipo_documento, obe[0].Serie + '-' + obe[0].Correlativo,//lobe[i].c_id_documento,
                                            lobe[i].c_emisor_nombre_legal, lobe[i].c_emisor_numero_documento};
                    dRow = dataT.Rows.Add(RowValues);
                }
            }
            dataT.AcceptChanges();
            return dataT;
        }

        private DataTable CrearEstructuraNC(List<VentaDetalleBE> lobe)
        {
            DataTable dataT = new DataTable();
            DataRow dRow;
            dataT.Columns.Add(new DataColumn("n_id_detalle"));
            dataT.Columns.Add(new DataColumn("n_id_cabecera"));
            dataT.Columns.Add(new DataColumn("c_id_producto"));
            dataT.Columns.Add(new DataColumn("c_id_productoAlmacen"));
            dataT.Columns.Add(new DataColumn("c_id_tienda"));
            dataT.Columns.Add(new DataColumn("c_codigo_item"));
            dataT.Columns.Add(new DataColumn("c_decripcion"));
            dataT.Columns.Add(new DataColumn("c_tipo_precio"));
            dataT.Columns.Add(new DataColumn("n_precio_referencial"));
            dataT.Columns.Add(new DataColumn("n_precio_unitario"));
            dataT.Columns.Add(new DataColumn("n_descuento"));
            dataT.Columns.Add(new DataColumn("n_cantidad"));
            dataT.Columns.Add(new DataColumn("n_unidad_medida"));
            dataT.Columns.Add(new DataColumn("n_tipo_impuesto"));
            dataT.Columns.Add(new DataColumn("n_impuesto"));
            dataT.Columns.Add(new DataColumn("n_impuesto_selectivo"));
            dataT.Columns.Add(new DataColumn("n_otro_impuesto"));
            dataT.Columns.Add(new DataColumn("n_total_venta"));
            dataT.Columns.Add(new DataColumn("n_suma"));
            dataT.Columns.Add(new DataColumn("c_tipo_documento"));
            dataT.Columns.Add(new DataColumn("c_id_documento"));
            dataT.Columns.Add(new DataColumn("c_emisor_nombre_legal"));
            dataT.Columns.Add(new DataColumn("c_emisor_numero_documento"));

            if (lobe != null && lobe.Count > 0)
            {
                for (int i = 0; i < lobe.Count; i++)
                {
                    object[] RowValues = { lobe[i].n_id_detalle, lobe[i].n_id_cabecera, lobe[i].c_id_producto, lobe[i].c_id_productoAlmacen,
                                            lobe[i].c_id_tienda, lobe[i].c_codigo_item,
                                            lobe[i].c_decripcion, lobe[i].c_tipo_precio, lobe[i].n_precio_referencial,
                                            lobe[i].n_precio_unitario, lobe[i].n_descuento, lobe[i].n_cantidad,
                                            lobe[i].n_unidad_medida, lobe[i].n_tipo_impuesto, lobe[i].n_impuesto,
                                            lobe[i].n_impuesto_selectivo, lobe[i].n_otro_impuesto, lobe[i].n_total_venta,
                                            lobe[i].n_suma, lobe[i].c_tipo_documento, lobe[0].c_id_documento,
                                            lobe[i].c_emisor_nombre_legal, lobe[i].c_emisor_numero_documento};
                    dRow = dataT.Rows.Add(RowValues);
                }
            }
            dataT.AcceptChanges();
            return dataT;
        }

        public RespuestaBE Guardar(SqlConnection cnBD, SqlTransaction trx, VentaBE obe, List<ListaCorrelativoVentaBE> lobe, out int id)
        {
            RespuestaBE rpta = new RespuestaBE();
            id = 0;
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_Guardar]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@n_id_cabecera", SqlDbType.Int).Value = obe.n_id_cabecera;
                cmd.Parameters.Add("@c_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_tipo_documento;
                cmd.Parameters.Add("@c_tipo_documento_nombre", SqlDbType.VarChar,50).Value = obe.c_tipo_documento_nombre;
                cmd.Parameters.Add("@n_id_documento_parent", SqlDbType.Int).Value = obe.n_id_documento_parent;
                cmd.Parameters.Add("@c_tipo_operacion", SqlDbType.VarChar, 50).Value = obe.c_tipo_operacion;
                cmd.Parameters.Add("@n_exoneradas", SqlDbType.Decimal).Value = obe.n_exoneradas;
                cmd.Parameters.Add("@n_gratuitas", SqlDbType.Decimal).Value = obe.n_gratuitas;
                cmd.Parameters.Add("@n_gravadas", SqlDbType.Decimal).Value = obe.n_gravadas;
                cmd.Parameters.Add("@n_inafectas", SqlDbType.Decimal).Value = obe.n_inafectas;
                cmd.Parameters.Add("@c_fecha_emision", SqlDbType.VarChar, 50).Value = obe.c_fecha_emision;
                cmd.Parameters.Add("@c_id_documento", SqlDbType.VarChar, 50).Value = lobe[0].Serie + '-' + lobe[0].Correlativo;//obe.c_id_documento;
                cmd.Parameters.Add("@claveDigital", SqlDbType.VarChar, 250).Value = lobe[0].ClaveDigital;//obe.c_id_documento;
                cmd.Parameters.Add("@urlCertificado", SqlDbType.VarChar, 500).Value = lobe[0].URLCertificado;//obe.c_id_documento;
                cmd.Parameters.Add("@c_moneda", SqlDbType.VarChar, 50).Value = obe.c_moneda;
                cmd.Parameters.Add("@n_monto_detraccion", SqlDbType.Decimal).Value = obe.n_monto_detraccion;
                cmd.Parameters.Add("@n_monto_percepcion", SqlDbType.Decimal).Value = obe.n_monto_percepcion;
                cmd.Parameters.Add("@n_monto_letras", SqlDbType.VarChar, 500).Value = obe.n_monto_letras;
                cmd.Parameters.Add("@n_total_igv", SqlDbType.Decimal).Value = obe.n_total_igv;
                cmd.Parameters.Add("@n_total_isc", SqlDbType.Decimal).Value = obe.n_total_isc;
                cmd.Parameters.Add("@n_total_otros_tributos", SqlDbType.Decimal).Value = obe.n_total_otros_tributos;
                cmd.Parameters.Add("@n_total_venta", SqlDbType.Decimal).Value = obe.n_total_venta;
                cmd.Parameters.Add("@c_receptor_nombre_comercial", SqlDbType.VarChar, 500).Value = obe.c_receptor_nombre_comercial;
                cmd.Parameters.Add("@c_receptor_nombre_legal", SqlDbType.VarChar, 500).Value = obe.c_receptor_nombre_legal;
                cmd.Parameters.Add("@c_receptor_direccion", SqlDbType.VarChar, 500).Value = obe.c_receptor_direccion;
                cmd.Parameters.Add("@c_receptor_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_receptor_tipo_documento;
                cmd.Parameters.Add("@c_receptor_numero_documento", SqlDbType.VarChar, 50).Value = obe.c_receptor_numero_documento;
                cmd.Parameters.Add("@c_emisor_departamento", SqlDbType.VarChar, 50).Value = obe.c_emisor_departamento;
                cmd.Parameters.Add("@c_emisor_provincia", SqlDbType.VarChar, 50).Value = obe.c_emisor_provincia;
                cmd.Parameters.Add("@c_emisor_distrito", SqlDbType.VarChar, 50).Value = obe.c_emisor_distrito;
                cmd.Parameters.Add("@c_emisor_direccion", SqlDbType.VarChar, 500).Value = obe.c_emisor_direccion;
                cmd.Parameters.Add("@c_emisor_urbanizacion", SqlDbType.VarChar, 50).Value = obe.c_emisor_urbanizacion;
                cmd.Parameters.Add("@c_emisor_ubigeo", SqlDbType.VarChar, 50).Value = obe.c_emisor_ubigeo;
                cmd.Parameters.Add("@c_emisor_nombre_comercial", SqlDbType.VarChar, 500).Value = obe.c_emisor_nombre_comercial;
                cmd.Parameters.Add("@c_emisor_nombre_legal", SqlDbType.VarChar, 500).Value = obe.c_emisor_nombre_legal;
                cmd.Parameters.Add("@c_emisor_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_emisor_tipo_documento;
                cmd.Parameters.Add("@c_emisor_numero_documento", SqlDbType.VarChar, 50).Value = obe.c_emisor_numero_documento;
                cmd.Parameters.Add("@c_codigo_anexo", SqlDbType.VarChar, 20).Value = obe.c_codigo_anexo;
                cmd.Parameters.Add("@n_calculo_detraccion", SqlDbType.Decimal).Value = obe.n_calculo_detraccion;
                cmd.Parameters.Add("@n_calculo_igv", SqlDbType.Decimal).Value = obe.n_calculo_igv;
                cmd.Parameters.Add("@n_calculo_isc", SqlDbType.Decimal).Value = obe.n_calculo_isc;
                cmd.Parameters.Add("@loDetalle", SqlDbType.Structured).Value = CrearEstructura(obe.loDetalle, lobe);

                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@c_id_documentoNV", SqlDbType.VarChar, 50).Value = obe.c_id_documentoNV;
                cmd.Parameters.Add("@c_id_tienda", SqlDbType.Int).Value = obe.IdTienda;
                cmd.Parameters.Add("@ACuenta", SqlDbType.Bit).Value = obe.Acuenta;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("IdVenta");
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        while (drd.Read())
                        {
                            rpta = new RespuestaBE();
                            id = drd.GetInt32(pos_Id);
                            rpta.codigo = drd.GetInt32(pos_Codigo);
                            rpta.descripcion = drd.GetString(pos_Descripcion);
                        }
                    }
                }
            }
            return rpta;
        }

        private DataTable CrearEstructuraACuenta(List<VentaDetalleBE> lobe)
        {
            DataTable dataT = new DataTable();
            DataRow dRow;
            dataT.Columns.Add(new DataColumn("n_id_detalle"));
            dataT.Columns.Add(new DataColumn("n_id_cabecera"));
            dataT.Columns.Add(new DataColumn("c_id_producto"));
            dataT.Columns.Add(new DataColumn("c_id_productoAlmacen"));
            dataT.Columns.Add(new DataColumn("c_id_tienda"));
            dataT.Columns.Add(new DataColumn("c_codigo_item"));
            dataT.Columns.Add(new DataColumn("c_decripcion"));
            dataT.Columns.Add(new DataColumn("c_tipo_precio"));
            dataT.Columns.Add(new DataColumn("n_precio_referencial"));
            dataT.Columns.Add(new DataColumn("n_precio_unitario"));
            dataT.Columns.Add(new DataColumn("n_descuento"));
            dataT.Columns.Add(new DataColumn("n_cantidad"));
            dataT.Columns.Add(new DataColumn("n_unidad_medida"));
            dataT.Columns.Add(new DataColumn("n_tipo_impuesto"));
            dataT.Columns.Add(new DataColumn("n_impuesto"));
            dataT.Columns.Add(new DataColumn("n_impuesto_selectivo"));
            dataT.Columns.Add(new DataColumn("n_otro_impuesto"));
            dataT.Columns.Add(new DataColumn("n_total_venta"));
            dataT.Columns.Add(new DataColumn("n_suma"));
            dataT.Columns.Add(new DataColumn("c_tipo_documento"));
            dataT.Columns.Add(new DataColumn("c_id_documento"));
            dataT.Columns.Add(new DataColumn("c_emisor_nombre_legal"));
            dataT.Columns.Add(new DataColumn("c_emisor_numero_documento"));

            if (lobe != null && lobe.Count > 0)
            {
                for (int i = 0; i < lobe.Count; i++)
                {
                    object[] RowValues = { lobe[i].n_id_detalle, lobe[i].n_id_cabecera, lobe[i].c_id_producto, lobe[i].c_id_productoAlmacen,
                                            lobe[i].c_id_tienda, lobe[i].c_codigo_item,
                                            lobe[i].c_decripcion, lobe[i].c_tipo_precio, lobe[i].n_precio_referencial,
                                            lobe[i].n_precio_unitario, lobe[i].n_descuento, lobe[i].n_cantidad,
                                            lobe[i].n_unidad_medida, lobe[i].n_tipo_impuesto, lobe[i].n_impuesto,
                                            lobe[i].n_impuesto_selectivo, lobe[i].n_otro_impuesto, lobe[i].n_total_venta,
                                            lobe[i].n_suma, lobe[i].c_tipo_documento, "",
                                            lobe[i].c_emisor_nombre_legal, lobe[i].c_emisor_numero_documento};
                    dRow = dataT.Rows.Add(RowValues);
                }
            }
            dataT.AcceptChanges();
            return dataT;
        }
        public RespuestaBE GuardarACuenta(SqlConnection cnBD, SqlTransaction trx, VentaBE obe, out int id)
        {
            RespuestaBE rpta = new RespuestaBE();
            id = 0;
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_GuardarACuenta]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@n_id_cabecera", SqlDbType.Int).Value = obe.n_id_cabecera;
                cmd.Parameters.Add("@c_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_tipo_documento;
                cmd.Parameters.Add("@c_tipo_documento_nombre", SqlDbType.VarChar, 50).Value = obe.c_tipo_documento_nombre;
                cmd.Parameters.Add("@n_id_documento_parent", SqlDbType.Int).Value = obe.n_id_documento_parent;
                cmd.Parameters.Add("@c_tipo_operacion", SqlDbType.VarChar, 50).Value = obe.c_tipo_operacion;
                cmd.Parameters.Add("@n_exoneradas", SqlDbType.Decimal).Value = obe.n_exoneradas;
                cmd.Parameters.Add("@n_gratuitas", SqlDbType.Decimal).Value = obe.n_gratuitas;
                cmd.Parameters.Add("@n_gravadas", SqlDbType.Decimal).Value = obe.n_gravadas;
                cmd.Parameters.Add("@n_inafectas", SqlDbType.Decimal).Value = obe.n_inafectas;
                cmd.Parameters.Add("@c_fecha_emision", SqlDbType.VarChar, 50).Value = obe.c_fecha_emision;
                cmd.Parameters.Add("@c_id_documento", SqlDbType.VarChar, 50).Value = "";// lobe[0].Serie + '-' + lobe[0].Correlativo;//obe.c_id_documento;
                cmd.Parameters.Add("@claveDigital", SqlDbType.VarChar, 250).Value = "";// lobe[0].ClaveDigital;//obe.c_id_documento;
                cmd.Parameters.Add("@urlCertificado", SqlDbType.VarChar, 500).Value = "";// lobe[0].URLCertificado;//obe.c_id_documento;
                cmd.Parameters.Add("@c_moneda", SqlDbType.VarChar, 50).Value = obe.c_moneda;
                cmd.Parameters.Add("@n_monto_detraccion", SqlDbType.Decimal).Value = obe.n_monto_detraccion;
                cmd.Parameters.Add("@n_monto_percepcion", SqlDbType.Decimal).Value = obe.n_monto_percepcion;
                cmd.Parameters.Add("@n_monto_letras", SqlDbType.VarChar, 500).Value = obe.n_monto_letras;
                cmd.Parameters.Add("@n_total_igv", SqlDbType.Decimal).Value = obe.n_total_igv;
                cmd.Parameters.Add("@n_total_isc", SqlDbType.Decimal).Value = obe.n_total_isc;
                cmd.Parameters.Add("@n_total_otros_tributos", SqlDbType.Decimal).Value = obe.n_total_otros_tributos;
                cmd.Parameters.Add("@n_total_venta", SqlDbType.Decimal).Value = obe.n_total_venta;
                cmd.Parameters.Add("@c_receptor_nombre_comercial", SqlDbType.VarChar, 500).Value = obe.c_receptor_nombre_comercial;
                cmd.Parameters.Add("@c_receptor_nombre_legal", SqlDbType.VarChar, 500).Value = obe.c_receptor_nombre_legal;
                cmd.Parameters.Add("@c_receptor_direccion", SqlDbType.VarChar, 500).Value = obe.c_receptor_direccion;
                cmd.Parameters.Add("@c_receptor_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_receptor_tipo_documento;
                cmd.Parameters.Add("@c_receptor_numero_documento", SqlDbType.VarChar, 50).Value = obe.c_receptor_numero_documento;
                cmd.Parameters.Add("@c_emisor_departamento", SqlDbType.VarChar, 50).Value = obe.c_emisor_departamento;
                cmd.Parameters.Add("@c_emisor_provincia", SqlDbType.VarChar, 50).Value = obe.c_emisor_provincia;
                cmd.Parameters.Add("@c_emisor_distrito", SqlDbType.VarChar, 50).Value = obe.c_emisor_distrito;
                cmd.Parameters.Add("@c_emisor_direccion", SqlDbType.VarChar, 500).Value = obe.c_emisor_direccion;
                cmd.Parameters.Add("@c_emisor_urbanizacion", SqlDbType.VarChar, 50).Value = obe.c_emisor_urbanizacion;
                cmd.Parameters.Add("@c_emisor_ubigeo", SqlDbType.VarChar, 50).Value = obe.c_emisor_ubigeo;
                cmd.Parameters.Add("@c_emisor_nombre_comercial", SqlDbType.VarChar, 500).Value = obe.c_emisor_nombre_comercial;
                cmd.Parameters.Add("@c_emisor_nombre_legal", SqlDbType.VarChar, 500).Value = obe.c_emisor_nombre_legal;
                cmd.Parameters.Add("@c_emisor_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_emisor_tipo_documento;
                cmd.Parameters.Add("@c_emisor_numero_documento", SqlDbType.VarChar, 50).Value = obe.c_emisor_numero_documento;
                cmd.Parameters.Add("@c_codigo_anexo", SqlDbType.VarChar, 20).Value = obe.c_codigo_anexo;
                cmd.Parameters.Add("@n_calculo_detraccion", SqlDbType.Decimal).Value = obe.n_calculo_detraccion;
                cmd.Parameters.Add("@n_calculo_igv", SqlDbType.Decimal).Value = obe.n_calculo_igv;
                cmd.Parameters.Add("@n_calculo_isc", SqlDbType.Decimal).Value = obe.n_calculo_isc;
                cmd.Parameters.Add("@loDetalle", SqlDbType.Structured).Value = CrearEstructuraACuenta(obe.loDetalle);

                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@c_id_documentoNV", SqlDbType.VarChar, 50).Value = obe.c_id_documentoNV;
                cmd.Parameters.Add("@c_id_tienda", SqlDbType.Int).Value = obe.IdTienda;
                cmd.Parameters.Add("@ACuenta", SqlDbType.Bit).Value = obe.Acuenta;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("IdVenta");
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        while (drd.Read())
                        {
                            rpta = new RespuestaBE();
                            id = drd.GetInt32(pos_Id);
                            rpta.codigo = drd.GetInt32(pos_Codigo);
                            rpta.descripcion = drd.GetString(pos_Descripcion);
                        }
                    }
                }
            }
            return rpta;
        }

        public bool GuardarReceta(SqlConnection cnBD, SqlTransaction trx, string ruta, int id, string usuario)
        {
            bool rpta = false;
            string msjError = "";
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_GuardarReceta]", cnBD))
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

        public List<ListaCorrelativoVentaBE> TraerCorrelativo(SqlConnection cnBD, SqlTransaction trx, VentaBE obj)
        {
            List<ListaCorrelativoVentaBE> lobe = new List<ListaCorrelativoVentaBE>();
            ListaCorrelativoVentaBE obe = new ListaCorrelativoVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_TraerCorrelativo]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obj.IdCliente;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = obj.IdTienda;
                cmd.Parameters.Add("@IdTipoComprobante", SqlDbType.VarChar,4).Value = obj.c_tipo_documento;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obj.UsrCreador;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Serie = drd.GetOrdinal("Serie");
                        int pos_Correlativo = drd.GetOrdinal("Correlativo");
                        int pos_SerieNV = drd.GetOrdinal("SerieNV");
                        int pos_CorrelativoNV = drd.GetOrdinal("CorrelativoNV");
                        int pos_ClaveDigital = drd.GetOrdinal("ClaveDigital");
                        int pos_URLCertificado = drd.GetOrdinal("URLCertificado");
                        int pos_RUC = drd.GetOrdinal("RUC");
                        int pos_IsFact= drd.GetOrdinal("isFact");
                        int pos_UsuarioSOL = drd.GetOrdinal("UsuarioSOL");
                        int pos_ClaveSOL = drd.GetOrdinal("ClaveSOL");
                        int pos_impresion = drd.GetOrdinal("impresion");

                        lobe = new List<ListaCorrelativoVentaBE>();
                        while (drd.Read())
                        {
                            obe = new ListaCorrelativoVentaBE();
                            obe.Serie = drd.GetString(pos_Serie);
                            obe.Correlativo = drd.GetString(pos_Correlativo);
                            obe.SerieNV = drd.GetString(pos_SerieNV);
                            obe.CorrelativoNV = drd.GetString(pos_CorrelativoNV);
                            obe.ClaveDigital = drd.GetString(pos_ClaveDigital);
                            obe.URLCertificado = drd.GetString(pos_URLCertificado);
                            obe.RUC = drd.GetString(pos_RUC);
                            obe.isFact = drd.GetBoolean(pos_IsFact);
                            obe.UsuarioSOL = drd.GetString(pos_UsuarioSOL);
                            obe.ClaveSOL = drd.GetString(pos_ClaveSOL);
                            obe.impresion = drd.GetString(pos_impresion);
                            if (obe.ClaveDigital != "" && obe.URLCertificado != "" && obe.UsuarioSOL != "" && obe.ClaveSOL != "")
                            {
                                lobe.Add(obe);
                            }
                        }
                    }
                }
            }
            return lobe;
        }

        private DataTable CrearEstructuraTienda(List<ListaComboBE> lobe)
        {
            DataTable dataT = new DataTable();
            DataRow dRow;
            dataT.Columns.Add(new DataColumn("codigo"));
            dataT.Columns.Add(new DataColumn("descripcion"));

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

        public RespuestaBE VentaACuenta(SqlConnection cnBD, SqlTransaction trx, VentaBE obe, List<ListaCorrelativoVentaBE> lobe, out int id)
        {
            RespuestaBE rpta = new RespuestaBE();
            id = 0;
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_VentaACuenta]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                //cmd.Parameters.Add("@n_id_cabecera", SqlDbType.Int).Value = obe.n_id_cabecera;
                cmd.Parameters.Add("@c_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_tipo_documento;
                //cmd.Parameters.Add("@c_tipo_documento_nombre", SqlDbType.VarChar, 50).Value = obe.c_tipo_documento_nombre;
                //cmd.Parameters.Add("@n_id_documento_parent", SqlDbType.Int).Value = obe.n_id_documento_parent;
                //cmd.Parameters.Add("@c_tipo_operacion", SqlDbType.VarChar, 50).Value = obe.c_tipo_operacion;
                //cmd.Parameters.Add("@n_exoneradas", SqlDbType.Decimal).Value = obe.n_exoneradas;
                //cmd.Parameters.Add("@n_gratuitas", SqlDbType.Decimal).Value = obe.n_gratuitas;
                //cmd.Parameters.Add("@n_gravadas", SqlDbType.Decimal).Value = obe.n_gravadas;
                //cmd.Parameters.Add("@n_inafectas", SqlDbType.Decimal).Value = obe.n_inafectas;
                cmd.Parameters.Add("@c_fecha_emision", SqlDbType.VarChar, 50).Value = obe.c_fecha_emision;
                cmd.Parameters.Add("@c_id_documento", SqlDbType.VarChar, 50).Value = lobe[0].Serie + '-' + lobe[0].Correlativo;//obe.c_id_documento;
                cmd.Parameters.Add("@claveDigital", SqlDbType.VarChar, 250).Value = lobe[0].ClaveDigital;//obe.c_id_documento;
                cmd.Parameters.Add("@urlCertificado", SqlDbType.VarChar, 500).Value = lobe[0].URLCertificado;//obe.c_id_documento;
                //cmd.Parameters.Add("@c_moneda", SqlDbType.VarChar, 50).Value = obe.c_moneda;
                //cmd.Parameters.Add("@n_monto_detraccion", SqlDbType.Decimal).Value = obe.n_monto_detraccion;
                //cmd.Parameters.Add("@n_monto_percepcion", SqlDbType.Decimal).Value = obe.n_monto_percepcion;
                //cmd.Parameters.Add("@n_monto_letras", SqlDbType.VarChar, 500).Value = obe.n_monto_letras;
                //cmd.Parameters.Add("@n_total_igv", SqlDbType.Decimal).Value = obe.n_total_igv;
                //cmd.Parameters.Add("@n_total_isc", SqlDbType.Decimal).Value = obe.n_total_isc;
                //cmd.Parameters.Add("@n_total_otros_tributos", SqlDbType.Decimal).Value = obe.n_total_otros_tributos;
                //cmd.Parameters.Add("@n_total_venta", SqlDbType.Decimal).Value = obe.n_total_venta;
                //cmd.Parameters.Add("@c_receptor_nombre_comercial", SqlDbType.VarChar, 500).Value = obe.c_receptor_nombre_comercial;
                //cmd.Parameters.Add("@c_receptor_nombre_legal", SqlDbType.VarChar, 500).Value = obe.c_receptor_nombre_legal;
                //cmd.Parameters.Add("@c_receptor_direccion", SqlDbType.VarChar, 500).Value = obe.c_receptor_direccion;
                //cmd.Parameters.Add("@c_receptor_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_receptor_tipo_documento;
                //cmd.Parameters.Add("@c_receptor_numero_documento", SqlDbType.VarChar, 50).Value = obe.c_receptor_numero_documento;
                //cmd.Parameters.Add("@c_emisor_departamento", SqlDbType.VarChar, 50).Value = obe.c_emisor_departamento;
                //cmd.Parameters.Add("@c_emisor_provincia", SqlDbType.VarChar, 50).Value = obe.c_emisor_provincia;
                //cmd.Parameters.Add("@c_emisor_distrito", SqlDbType.VarChar, 50).Value = obe.c_emisor_distrito;
                //cmd.Parameters.Add("@c_emisor_direccion", SqlDbType.VarChar, 500).Value = obe.c_emisor_direccion;
                //cmd.Parameters.Add("@c_emisor_urbanizacion", SqlDbType.VarChar, 50).Value = obe.c_emisor_urbanizacion;
                //cmd.Parameters.Add("@c_emisor_ubigeo", SqlDbType.VarChar, 50).Value = obe.c_emisor_ubigeo;
                //cmd.Parameters.Add("@c_emisor_nombre_comercial", SqlDbType.VarChar, 500).Value = obe.c_emisor_nombre_comercial;
                //cmd.Parameters.Add("@c_emisor_nombre_legal", SqlDbType.VarChar, 500).Value = obe.c_emisor_nombre_legal;
                //cmd.Parameters.Add("@c_emisor_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_emisor_tipo_documento;
                //cmd.Parameters.Add("@c_emisor_numero_documento", SqlDbType.VarChar, 50).Value = obe.c_emisor_numero_documento;
                //cmd.Parameters.Add("@c_codigo_anexo", SqlDbType.VarChar, 20).Value = obe.c_codigo_anexo;
                //cmd.Parameters.Add("@n_calculo_detraccion", SqlDbType.Decimal).Value = obe.n_calculo_detraccion;
                //cmd.Parameters.Add("@n_calculo_igv", SqlDbType.Decimal).Value = obe.n_calculo_igv;
                //cmd.Parameters.Add("@n_calculo_isc", SqlDbType.Decimal).Value = obe.n_calculo_isc;
                cmd.Parameters.Add("@loDetalle", SqlDbType.Structured).Value = CrearEstructura(obe.loDetalle, lobe);

                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@c_id_documentoNV", SqlDbType.VarChar, 50).Value = obe.c_id_documentoNV;
                cmd.Parameters.Add("@c_id_tienda", SqlDbType.Int).Value = obe.IdTienda;
                cmd.Parameters.Add("@ACuenta", SqlDbType.Bit).Value = obe.Acuenta;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Id = drd.GetOrdinal("IdVenta");
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        while (drd.Read())
                        {
                            rpta = new RespuestaBE();
                            id = drd.GetInt32(pos_Id);
                            rpta.codigo = drd.GetInt32(pos_Codigo);
                            rpta.descripcion = drd.GetString(pos_Descripcion);
                        }
                    }
                }
            }
            return rpta;
        }
        //REGISTRO DE VENTAS
        public RegistroVentaBE RegistroVentasDia(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteRegistroVentaBE> listado = new List<ReporteRegistroVentaBE>();
            List<ReporteRegistroVentaExcelBE> listadoExcel = new List<ReporteRegistroVentaExcelBE>();
            ReporteRegistroVentaBE obe = new ReporteRegistroVentaBE();
            ReporteRegistroVentaExcelBE obeXLS = new ReporteRegistroVentaExcelBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            RegistroVentaBE lobe = new RegistroVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_RegistroVentasDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructuraTienda(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Fecha = drd.GetOrdinal("Fecha");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_NotaVenta = drd.GetOrdinal("NotaVenta");
                        int pos_BoletaVenta = drd.GetOrdinal("BoletaVenta");
                        int pos_FacturaVenta = drd.GetOrdinal("FacturaVenta");
                        int pos_NotaCreditoVenta = drd.GetOrdinal("NotaCreditoVenta");
                        int pos_NotaDebitoVenta = drd.GetOrdinal("NotaDebitoVenta");
                        int pos_TotalSinIGV = drd.GetOrdinal("TotalSinIGV");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_EstadoFABO = drd.GetOrdinal("EstadoFABO");
                        int pos_EstadoResumen = drd.GetOrdinal("EstadoResumen");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_isNC = drd.GetOrdinal("isNC");
                        int pos_isND = drd.GetOrdinal("isND");
                        int pos_isAnular = drd.GetOrdinal("isAnular");
                        #endregion Lista - columnas
                        listado = new List<ReporteRegistroVentaBE>();
                        listadoExcel = new List<ReporteRegistroVentaExcelBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteRegistroVentaBE();
                            obeXLS = new ReporteRegistroVentaExcelBE();
                            #region Lista - campos
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Fecha = drd.GetString(pos_Fecha);
                            obe.Estado = drd.GetString(pos_Estado);
                            obe.NotaVenta = drd.GetString(pos_NotaVenta);
                            obe.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obe.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obe.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obe.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obe.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obe.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.isNC = drd.GetBoolean(pos_isNC);
                            obe.isND = drd.GetBoolean(pos_isND);
                            obe.isAnular = drd.GetBoolean(pos_isAnular);

                            obeXLS.Id = drd.GetInt32(pos_Id);
                            obeXLS.Fecha = drd.GetString(pos_Fecha);
                            obeXLS.Estado = drd.GetString(pos_Estado);
                            obeXLS.NotaVenta = drd.GetString(pos_NotaVenta);
                            obeXLS.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obeXLS.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obeXLS.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obeXLS.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obeXLS.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obeXLS.TotalVenta = drd.GetString(pos_TotalVenta);
                            obeXLS.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obeXLS.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obeXLS.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeXLS.DesTienda = drd.GetString(pos_DesTienda);
                            obeXLS.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            listado.Add(obe);
                            listadoExcel.Add(obeXLS);
                            #endregion Lista - campos
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
            lobe.listado = listado;
            lobe.listadoExcel = listadoExcel;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public RegistroVentaBE RegistroVentasMes(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteRegistroVentaBE> listado = new List<ReporteRegistroVentaBE>();
            List<ReporteRegistroVentaExcelBE> listadoExcel = new List<ReporteRegistroVentaExcelBE>();
            ReporteRegistroVentaBE obe = new ReporteRegistroVentaBE();
            ReporteRegistroVentaExcelBE obeXLS = new ReporteRegistroVentaExcelBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            RegistroVentaBE lobe = new RegistroVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_RegistroVentasMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructuraTienda(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Fecha = drd.GetOrdinal("Fecha");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_NotaVenta = drd.GetOrdinal("NotaVenta");
                        int pos_BoletaVenta = drd.GetOrdinal("BoletaVenta");
                        int pos_FacturaVenta = drd.GetOrdinal("FacturaVenta");
                        int pos_NotaCreditoVenta = drd.GetOrdinal("NotaCreditoVenta");
                        int pos_NotaDebitoVenta = drd.GetOrdinal("NotaDebitoVenta");
                        int pos_TotalSinIGV = drd.GetOrdinal("TotalSinIGV");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_EstadoFABO = drd.GetOrdinal("EstadoFABO");
                        int pos_EstadoResumen = drd.GetOrdinal("EstadoResumen");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteRegistroVentaBE>();
                        listadoExcel = new List<ReporteRegistroVentaExcelBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteRegistroVentaBE();
                            obeXLS = new ReporteRegistroVentaExcelBE();
                            #region Lista - campos
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Fecha = drd.GetString(pos_Fecha);
                            obe.Estado = drd.GetString(pos_Estado);
                            obe.NotaVenta = drd.GetString(pos_NotaVenta);
                            obe.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obe.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obe.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obe.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obe.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obe.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            obeXLS.Id = drd.GetInt32(pos_Id);
                            obeXLS.Fecha = drd.GetString(pos_Fecha);
                            obeXLS.Estado = drd.GetString(pos_Estado);
                            obeXLS.NotaVenta = drd.GetString(pos_NotaVenta);
                            obeXLS.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obeXLS.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obeXLS.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obeXLS.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obeXLS.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obeXLS.TotalVenta = drd.GetString(pos_TotalVenta);
                            obeXLS.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obeXLS.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obeXLS.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeXLS.DesTienda = drd.GetString(pos_DesTienda);
                            obeXLS.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            listado.Add(obe);
                            listadoExcel.Add(obeXLS);
                            #endregion Lista - campos
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
            lobe.listado = listado;
            lobe.listadoExcel = listadoExcel;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public RegistroVentaBE RegistroVentasAnio(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteRegistroVentaBE> listado = new List<ReporteRegistroVentaBE>();
            List<ReporteRegistroVentaExcelBE> listadoExcel = new List<ReporteRegistroVentaExcelBE>();
            ReporteRegistroVentaBE obe = new ReporteRegistroVentaBE();
            ReporteRegistroVentaExcelBE obeXLS = new ReporteRegistroVentaExcelBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            RegistroVentaBE lobe = new RegistroVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_RegistroVentasAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructuraTienda(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Fecha = drd.GetOrdinal("Fecha");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_NotaVenta = drd.GetOrdinal("NotaVenta");
                        int pos_BoletaVenta = drd.GetOrdinal("BoletaVenta");
                        int pos_FacturaVenta = drd.GetOrdinal("FacturaVenta");
                        int pos_NotaCreditoVenta = drd.GetOrdinal("NotaCreditoVenta");
                        int pos_NotaDebitoVenta = drd.GetOrdinal("NotaDebitoVenta");
                        int pos_TotalSinIGV = drd.GetOrdinal("TotalSinIGV");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_EstadoFABO = drd.GetOrdinal("EstadoFABO");
                        int pos_EstadoResumen = drd.GetOrdinal("EstadoResumen");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteRegistroVentaBE>();
                        listadoExcel = new List<ReporteRegistroVentaExcelBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteRegistroVentaBE();
                            obeXLS = new ReporteRegistroVentaExcelBE();
                            #region Lista - campos
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Fecha = drd.GetString(pos_Fecha);
                            obe.Estado = drd.GetString(pos_Estado);
                            obe.NotaVenta = drd.GetString(pos_NotaVenta);
                            obe.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obe.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obe.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obe.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obe.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obe.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            obeXLS.Id = drd.GetInt32(pos_Id);
                            obeXLS.Fecha = drd.GetString(pos_Fecha);
                            obeXLS.Estado = drd.GetString(pos_Estado);
                            obeXLS.NotaVenta = drd.GetString(pos_NotaVenta);
                            obeXLS.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obeXLS.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obeXLS.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obeXLS.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obeXLS.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obeXLS.TotalVenta = drd.GetString(pos_TotalVenta);
                            obeXLS.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obeXLS.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obeXLS.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeXLS.DesTienda = drd.GetString(pos_DesTienda);
                            obeXLS.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            listado.Add(obe);
                            listadoExcel.Add(obeXLS);
                            #endregion Lista - campos
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
            lobe.listado = listado;
            lobe.listadoExcel = listadoExcel;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public RegistroVentaBE RegistroVentasRango(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, string fechaFin, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteRegistroVentaBE> listado = new List<ReporteRegistroVentaBE>();
            List<ReporteRegistroVentaExcelBE> listadoExcel = new List<ReporteRegistroVentaExcelBE>();
            ReporteRegistroVentaBE obe = new ReporteRegistroVentaBE();
            ReporteRegistroVentaExcelBE obeXLS = new ReporteRegistroVentaExcelBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            RegistroVentaBE lobe = new RegistroVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_RegistroVentasRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructuraTienda(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_Id = drd.GetOrdinal("Id");
                        int pos_Fecha = drd.GetOrdinal("Fecha");
                        int pos_Estado = drd.GetOrdinal("Estado");
                        int pos_NotaVenta = drd.GetOrdinal("NotaVenta");
                        int pos_BoletaVenta = drd.GetOrdinal("BoletaVenta");
                        int pos_FacturaVenta = drd.GetOrdinal("FacturaVenta");
                        int pos_NotaCreditoVenta = drd.GetOrdinal("NotaCreditoVenta");
                        int pos_NotaDebitoVenta = drd.GetOrdinal("NotaDebitoVenta");
                        int pos_TotalSinIGV = drd.GetOrdinal("TotalSinIGV");
                        int pos_TotalVenta = drd.GetOrdinal("TotalVenta");
                        int pos_EstadoFABO = drd.GetOrdinal("EstadoFABO");
                        int pos_EstadoResumen = drd.GetOrdinal("EstadoResumen");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_DesTienda = drd.GetOrdinal("DesTienda");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_FechaFinReporte = drd.GetOrdinal("FechaFinReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteRegistroVentaBE>();
                        listadoExcel = new List<ReporteRegistroVentaExcelBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteRegistroVentaBE();
                            obeXLS = new ReporteRegistroVentaExcelBE();
                            #region Lista - campos
                            obe.Id = drd.GetInt32(pos_Id);
                            obe.Fecha = drd.GetString(pos_Fecha);
                            obe.Estado = drd.GetString(pos_Estado);
                            obe.NotaVenta = drd.GetString(pos_NotaVenta);
                            obe.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obe.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obe.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obe.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obe.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obe.TotalVenta = drd.GetString(pos_TotalVenta);
                            obe.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obe.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.DesTienda = drd.GetString(pos_DesTienda);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.FechaFinReporte = drd.GetString(pos_FechaFinReporte);

                            obeXLS.Id = drd.GetInt32(pos_Id);
                            obeXLS.Fecha = drd.GetString(pos_Fecha);
                            obeXLS.Estado = drd.GetString(pos_Estado);
                            obeXLS.NotaVenta = drd.GetString(pos_NotaVenta);
                            obeXLS.BoletaVenta = drd.GetString(pos_BoletaVenta);
                            obeXLS.FacturaVenta = drd.GetString(pos_FacturaVenta);
                            obeXLS.NotaCreditoVenta = drd.GetString(pos_NotaCreditoVenta);
                            obeXLS.NotaDebitoVenta = drd.GetString(pos_NotaDebitoVenta);
                            obeXLS.TotalSinIGV = drd.GetString(pos_TotalSinIGV);
                            obeXLS.TotalVenta = drd.GetString(pos_TotalVenta);
                            obeXLS.EstadoFABO = drd.GetString(pos_EstadoFABO);
                            obeXLS.EstadoResumen = drd.GetString(pos_EstadoResumen);
                            obeXLS.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeXLS.DesTienda = drd.GetString(pos_DesTienda);
                            obeXLS.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obeXLS.FechaFinReporte = drd.GetString(pos_FechaFinReporte);

                            listado.Add(obe);
                            listadoExcel.Add(obeXLS);
                            #endregion Lista - campos
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
            lobe.listado = listado;
            lobe.listadoExcel = listadoExcel;
            lobe.loColumns = loColumns;

            return lobe;
        }

        //DETALLE DE VENTA
        public RegistroVentaBE VerDetalleVenta(SqlConnection cnBD, string usuario, int idCliente, int idVenta)
        {
            //listado
            List<RegistroVentaDetalleBE> listadoDetalle = new List<RegistroVentaDetalleBE>();
            RegistroVentaDetalleBE obe = new RegistroVentaDetalleBE();
            //Objeto
            RegistroVentaBE lobe = new RegistroVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_RegistroVentasDetalle]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_DesProducto = drd.GetOrdinal("DesProducto");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_PUnitario = drd.GetOrdinal("PUnitario");
                        int pos_Total = drd.GetOrdinal("Total");
                        int pos_SubTotal = drd.GetOrdinal("SubTotal");
                        int pos_NotaVenta = drd.GetOrdinal("NotaVenta");
                        int pos_NroDocumento = drd.GetOrdinal("NroDocumento");
                        int pos_Documento = drd.GetOrdinal("Documento");
                        #endregion Lista - columnas
                        listadoDetalle = new List<RegistroVentaDetalleBE>();
                        while (drd.Read())
                        {
                            obe = new RegistroVentaDetalleBE();
                            #region Lista - campos
                            obe.IdProducto = drd.GetInt32(pos_IdProducto);
                            obe.DesProducto = drd.GetString(pos_DesProducto);
                            obe.Cantidad = drd.GetInt32(pos_Cantidad);
                            obe.PUnitario = drd.GetDecimal(pos_PUnitario);
                            obe.Total = drd.GetDecimal(pos_Total);
                            obe.SubTotal = drd.GetDecimal(pos_SubTotal);
                            obe.IGV = drd.GetDecimal(pos_Total) - drd.GetDecimal(pos_SubTotal);
                            obe.NotaVenta = drd.GetString(pos_NotaVenta);
                            obe.NroDocumento = drd.GetString(pos_NroDocumento);
                            obe.Documento = drd.GetString(pos_Documento);
                            listadoDetalle.Add(obe);
                            #endregion Lista - campos
                        }
                    }
                }
            }
            lobe.listadoDetalle = listadoDetalle;

            return lobe;
        }

        public RespuestaBE Datos_Anular(SqlConnection cnBD, string usuario, int idVenta, out VentaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            obe = new VentaBE();
            List<VentaDetalleBE> lodetalle = new List<VentaDetalleBE>();
            VentaDetalleBE odetalle = new VentaDetalleBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_AnularVenta_Sin_NC]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_n_id_cabecera = drd.GetOrdinal("n_id_cabecera");
                        int pos_c_tipo_documento = drd.GetOrdinal("c_tipo_documento");
                        int pos_c_tipo_documento_nombre = drd.GetOrdinal("c_tipo_documento_nombre");
                        int pos_n_id_documento_parent = drd.GetOrdinal("n_id_documento_parent");
                        int pos_c_tipo_operacion = drd.GetOrdinal("c_tipo_operacion");
                        int pos_n_exoneradas = drd.GetOrdinal("n_exoneradas");
                        int pos_n_gratuitas = drd.GetOrdinal("n_gratuitas");
                        int pos_n_gravadas = drd.GetOrdinal("n_gravadas");
                        int pos_n_inafectas = drd.GetOrdinal("n_inafectas");
                        int pos_c_fecha_emision = drd.GetOrdinal("c_fecha_emision");
                        int pos_c_id_documento = drd.GetOrdinal("c_id_documento");
                        int pos_c_id_documentoNV = drd.GetOrdinal("c_id_documentoNV");
                        int pos_c_id_tienda = drd.GetOrdinal("c_id_tienda");
                        int pos_c_moneda = drd.GetOrdinal("c_moneda");
                        int pos_n_monto_detraccion = drd.GetOrdinal("n_monto_detraccion");
                        int pos_n_monto_percepcion = drd.GetOrdinal("n_monto_percepcion");
                        int pos_n_monto_letras = drd.GetOrdinal("n_monto_letras");
                        int pos_n_total_igv = drd.GetOrdinal("n_total_igv");
                        int pos_n_total_isc = drd.GetOrdinal("n_total_isc");
                        int pos_n_total_otros_tributos = drd.GetOrdinal("n_total_otros_tributos");
                        int pos_n_total_venta = drd.GetOrdinal("n_total_venta");
                        int pos_c_receptor_nombre_comercial = drd.GetOrdinal("c_receptor_nombre_comercial");
                        int pos_c_receptor_nombre_legal = drd.GetOrdinal("c_receptor_nombre_legal");
                        int pos_c_receptor_direccion = drd.GetOrdinal("c_receptor_direccion");
                        int pos_c_receptor_tipo_documento = drd.GetOrdinal("c_receptor_tipo_documento");
                        int pos_c_receptor_numero_documento = drd.GetOrdinal("c_receptor_numero_documento");
                        int pos_c_emisor_departamento = drd.GetOrdinal("c_emisor_departamento");
                        int pos_c_emisor_provincia = drd.GetOrdinal("c_emisor_provincia");
                        int pos_c_emisor_distrito = drd.GetOrdinal("c_emisor_distrito");
                        int pos_c_emisor_direccion = drd.GetOrdinal("c_emisor_direccion");
                        int pos_c_emisor_urbanizacion = drd.GetOrdinal("c_emisor_urbanizacion");
                        int pos_c_emisor_ubigeo = drd.GetOrdinal("c_emisor_ubigeo");
                        int pos_c_emisor_nombre_comercial = drd.GetOrdinal("c_emisor_nombre_comercial");
                        int pos_c_emisor_nombre_legal = drd.GetOrdinal("c_emisor_nombre_legal");
                        int pos_c_emisor_tipo_documento = drd.GetOrdinal("c_emisor_tipo_documento");
                        int pos_c_emisor_numero_documento = drd.GetOrdinal("c_emisor_numero_documento");
                        int pos_c_codigo_anexo = drd.GetOrdinal("c_codigo_anexo");
                        int pos_n_calculo_detraccion = drd.GetOrdinal("n_calculo_detraccion");
                        int pos_n_calculo_igv = drd.GetOrdinal("n_calculo_igv");
                        int pos_n_calculo_isc = drd.GetOrdinal("n_calculo_isc");
                        int pos_idCliente = drd.GetOrdinal("idCliente");
                        #endregion columnas
                        while (drd.Read())
                        {
                            obe = new VentaBE();
                            #region valores
                            obe.n_id_cabecera = drd.GetInt32(pos_n_id_cabecera);
                            obe.c_tipo_documento = drd.GetString(pos_c_tipo_documento);
                            obe.c_tipo_documento_nombre = drd.GetString(pos_c_tipo_documento_nombre);
                            obe.n_id_documento_parent = drd.GetInt32(pos_n_id_documento_parent);
                            obe.c_tipo_operacion = drd.GetString(pos_c_tipo_operacion);
                            obe.n_exoneradas = drd.GetDecimal(pos_n_exoneradas);
                            obe.n_gratuitas = drd.GetDecimal(pos_n_gratuitas);
                            obe.n_gravadas = drd.GetDecimal(pos_n_gravadas);
                            obe.n_inafectas = drd.GetDecimal(pos_n_inafectas);
                            obe.c_fecha_emision = drd.GetString(pos_c_fecha_emision);
                            obe.c_id_documento = drd.GetString(pos_c_id_documento);
                            obe.c_id_documentoNV = drd.GetString(pos_c_id_documentoNV);
                            obe.c_id_tienda = drd.GetInt32(pos_c_id_tienda);
                            obe.c_moneda = drd.GetString(pos_c_moneda);
                            obe.n_monto_detraccion = drd.GetDecimal(pos_n_monto_detraccion);
                            obe.n_monto_percepcion = drd.GetDecimal(pos_n_monto_percepcion);
                            obe.n_monto_letras = drd.GetString(pos_n_monto_letras);
                            obe.n_total_igv = drd.GetDecimal(pos_n_total_igv);
                            obe.n_total_isc = drd.GetDecimal(pos_n_total_isc);
                            obe.n_total_otros_tributos = drd.GetDecimal(pos_n_total_otros_tributos);
                            obe.n_total_venta = drd.GetDecimal(pos_n_total_venta);
                            obe.c_receptor_nombre_comercial = drd.GetString(pos_c_receptor_nombre_comercial);
                            obe.c_receptor_nombre_legal = drd.GetString(pos_c_receptor_nombre_legal);
                            obe.c_receptor_direccion = drd.GetString(pos_c_receptor_direccion);
                            obe.c_receptor_tipo_documento = drd.GetString(pos_c_receptor_tipo_documento);
                            obe.c_receptor_numero_documento = drd.GetString(pos_c_receptor_numero_documento);
                            obe.c_emisor_departamento = drd.GetString(pos_c_emisor_departamento);
                            obe.c_emisor_provincia = drd.GetString(pos_c_emisor_provincia);
                            obe.c_emisor_distrito = drd.GetString(pos_c_emisor_distrito);
                            obe.c_emisor_direccion = drd.GetString(pos_c_emisor_direccion);
                            obe.c_emisor_urbanizacion = drd.GetString(pos_c_emisor_urbanizacion);
                            obe.c_emisor_ubigeo = drd.GetString(pos_c_emisor_ubigeo);
                            obe.c_emisor_nombre_comercial = drd.GetString(pos_c_emisor_nombre_comercial);
                            obe.c_emisor_nombre_legal = drd.GetString(pos_c_emisor_nombre_legal);
                            obe.c_emisor_tipo_documento = drd.GetString(pos_c_emisor_tipo_documento);
                            obe.c_emisor_numero_documento = drd.GetString(pos_c_emisor_numero_documento);
                            obe.c_codigo_anexo = drd.GetString(pos_c_codigo_anexo);
                            obe.n_calculo_detraccion = drd.GetDecimal(pos_n_calculo_detraccion);
                            obe.n_calculo_igv = drd.GetDecimal(pos_n_calculo_igv);
                            obe.n_calculo_isc = drd.GetDecimal(pos_n_calculo_isc);
                            obe.IdCliente = drd.GetInt32(pos_idCliente);
                            obe.loDetalle = new List<VentaDetalleBE>();
                            #endregion valores
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_n_id_detalle = drd.GetOrdinal("n_id_detalle");
                        int pos_n_id_cabecera = drd.GetOrdinal("n_id_cabecera");
                        int pos_c_id_producto = drd.GetOrdinal("c_id_producto");
                        int pos_c_id_productoAlmacen = drd.GetOrdinal("c_id_productoAlmacen");
                        int pos_c_id_tienda = drd.GetOrdinal("c_id_tienda");
                        int pos_c_codigo_item = drd.GetOrdinal("c_codigo_item");
                        int pos_c_decripcion = drd.GetOrdinal("c_decripcion");
                        int pos_c_tipo_precio = drd.GetOrdinal("c_tipo_precio");
                        int pos_n_precio_referencial = drd.GetOrdinal("n_precio_referencial");
                        int pos_n_precio_unitario = drd.GetOrdinal("n_precio_unitario");
                        int pos_n_descuento = drd.GetOrdinal("n_descuento");
                        int pos_n_cantidad = drd.GetOrdinal("n_cantidad");
                        int pos_n_unidad_medida = drd.GetOrdinal("n_unidad_medida");
                        int pos_n_tipo_impuesto = drd.GetOrdinal("n_tipo_impuesto");
                        int pos_n_impuesto = drd.GetOrdinal("n_impuesto");
                        int pos_n_impuesto_selectivo = drd.GetOrdinal("n_impuesto_selectivo");
                        int pos_n_otro_impuesto = drd.GetOrdinal("n_otro_impuesto");
                        int pos_n_total_venta = drd.GetOrdinal("n_total_venta");
                        int pos_n_suma = drd.GetOrdinal("n_suma");
                        int pos_c_tipo_documento = drd.GetOrdinal("c_tipo_documento");
                        int pos_c_id_documento = drd.GetOrdinal("c_id_documento");
                        int pos_c_emisor_nombre_legal = drd.GetOrdinal("c_emisor_nombre_legal");
                        int pos_c_emisor_numero_documento = drd.GetOrdinal("c_emisor_numero_documento");
                        #endregion columnas
                        while (drd.Read())
                        {
                            odetalle = new VentaDetalleBE();
                            #region valores
                            odetalle.n_id_detalle = drd.GetInt32(pos_n_id_detalle);
                            odetalle.n_id_cabecera = drd.GetInt32(pos_n_id_cabecera);
                            odetalle.c_id_producto = drd.GetInt32(pos_c_id_producto);
                            odetalle.c_id_productoAlmacen = drd.GetInt32(pos_c_id_productoAlmacen);
                            odetalle.c_id_tienda = drd.GetInt32(pos_c_id_tienda);
                            odetalle.c_codigo_item = drd.GetString(pos_c_codigo_item);
                            odetalle.c_decripcion = drd.GetString(pos_c_decripcion);
                            odetalle.c_tipo_precio = drd.GetString(pos_c_tipo_precio);
                            odetalle.n_precio_referencial = drd.GetDecimal(pos_n_precio_referencial);
                            odetalle.n_precio_unitario = drd.GetDecimal(pos_n_precio_unitario);
                            odetalle.n_descuento = drd.GetDecimal(pos_n_descuento);
                            odetalle.n_cantidad = drd.GetDecimal(pos_n_cantidad);
                            odetalle.n_unidad_medida = drd.GetString(pos_n_unidad_medida);
                            odetalle.n_tipo_impuesto = drd.GetString(pos_n_tipo_impuesto);
                            odetalle.n_impuesto = drd.GetDecimal(pos_n_impuesto);
                            odetalle.n_impuesto_selectivo = drd.GetDecimal(pos_n_impuesto_selectivo);
                            odetalle.n_otro_impuesto = drd.GetDecimal(pos_n_otro_impuesto);
                            odetalle.n_total_venta = drd.GetDecimal(pos_n_total_venta);
                            odetalle.n_suma = drd.GetDecimal(pos_n_suma);
                            odetalle.c_tipo_documento = drd.GetString(pos_c_tipo_documento);
                            odetalle.c_id_documento = drd.GetString(pos_c_id_documento);
                            odetalle.c_emisor_nombre_legal = drd.GetString(pos_c_emisor_nombre_legal);
                            odetalle.c_emisor_numero_documento = drd.GetString(pos_c_emisor_numero_documento);
                            lodetalle.Add(odetalle);
                            #endregion valores
                        }
                        obe.loDetalle = lodetalle;
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        while (drd.Read())
                        {
                            rpta = new RespuestaBE();
                            rpta.codigo = drd.GetInt32(pos_Codigo);
                            rpta.descripcion = drd.GetString(pos_Descripcion);
                        }
                    }
                }
            }

            return rpta;
        }

        public List<ListaCorrelativoVentaBE> TraerCorrelativoAnulacionNC(SqlConnection cnBD, SqlTransaction trx, VentaBE obj)
        {
            List<ListaCorrelativoVentaBE> lobe = new List<ListaCorrelativoVentaBE>();
            ListaCorrelativoVentaBE obe = new ListaCorrelativoVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_TraerCorrelativo_AnulacionNC]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obj.IdCliente;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = obj.c_id_tienda;
                cmd.Parameters.Add("@TipoDoc", SqlDbType.VarChar,2).Value = obj.c_tipo_documento;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obj.UsrCreador;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("Serie");
                        int pos_Correlativo = drd.GetOrdinal("Correlativo");
                        int pos_SerieNV = drd.GetOrdinal("SerieNV");
                        int pos_CorrelativoNV = drd.GetOrdinal("CorrelativoNV");
                        int pos_TipoDocumentoNC = drd.GetOrdinal("TipoDocumentoNC");
                        int pos_TipoDocumentoNombreNC = drd.GetOrdinal("TipoDocumentoNombreNC");
                        int pos_ClaveDigital = drd.GetOrdinal("ClaveDigital");
                        int pos_URLCertificado = drd.GetOrdinal("URLCertificado");
                        int pos_RUC = drd.GetOrdinal("RUC");
                        int pos_IsFact = drd.GetOrdinal("isFact");
                        int pos_UsuarioSOL = drd.GetOrdinal("UsuarioSOL");
                        int pos_ClaveSOL = drd.GetOrdinal("ClaveSOL");
                        #endregion columnas

                        lobe = new List<ListaCorrelativoVentaBE>();
                        while (drd.Read())
                        {
                            obe = new ListaCorrelativoVentaBE();
                            obe.Serie = drd.GetString(pos_Serie);
                            obe.Correlativo = drd.GetString(pos_Correlativo);
                            obe.SerieNV = drd.GetString(pos_SerieNV);
                            obe.CorrelativoNV = drd.GetString(pos_CorrelativoNV);
                            obe.TipoDocumentoNC = drd.GetString(pos_TipoDocumentoNC);
                            obe.TipoDocumentoNombreNC = drd.GetString(pos_TipoDocumentoNombreNC);
                            obe.ClaveDigital = drd.GetString(pos_ClaveDigital);
                            obe.URLCertificado = drd.GetString(pos_URLCertificado);
                            obe.RUC = drd.GetString(pos_RUC);
                            obe.isFact = drd.GetBoolean(pos_IsFact);
                            obe.UsuarioSOL = drd.GetString(pos_UsuarioSOL);
                            obe.ClaveSOL = drd.GetString(pos_ClaveSOL);
                            if (obe.ClaveDigital != "" && obe.URLCertificado != "" && obe.UsuarioSOL != "" && obe.ClaveSOL != "")
                            {
                                lobe.Add(obe);
                            }
                        }
                    }
                }
            }
            return lobe;
        }

        public RespuestaBE Datos_AnularNC(SqlConnection cnBD, string usuario, int idVenta, out VentaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            obe = new VentaBE();
            List<VentaDetalleBE> lodetalle = new List<VentaDetalleBE>();
            VentaDetalleBE odetalle = new VentaDetalleBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_AnularVenta_Con_NC]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_n_id_cabecera = drd.GetOrdinal("n_id_cabecera");
                        int pos_c_tipo_documento = drd.GetOrdinal("c_tipo_documento");
                        int pos_c_tipo_documento_nombre = drd.GetOrdinal("c_tipo_documento_nombre");
                        int pos_n_id_documento_parent = drd.GetOrdinal("n_id_documento_parent");
                        int pos_c_tipo_operacion = drd.GetOrdinal("c_tipo_operacion");
                        int pos_n_exoneradas = drd.GetOrdinal("n_exoneradas");
                        int pos_n_gratuitas = drd.GetOrdinal("n_gratuitas");
                        int pos_n_gravadas = drd.GetOrdinal("n_gravadas");
                        int pos_n_inafectas = drd.GetOrdinal("n_inafectas");
                        int pos_c_fecha_emision = drd.GetOrdinal("c_fecha_emision");
                        int pos_c_id_documento = drd.GetOrdinal("c_id_documento");
                        int pos_c_id_documentoNV = drd.GetOrdinal("c_id_documentoNV");
                        int pos_c_id_tienda = drd.GetOrdinal("c_id_tienda");
                        int pos_c_moneda = drd.GetOrdinal("c_moneda");
                        int pos_n_monto_detraccion = drd.GetOrdinal("n_monto_detraccion");
                        int pos_n_monto_percepcion = drd.GetOrdinal("n_monto_percepcion");
                        int pos_n_monto_letras = drd.GetOrdinal("n_monto_letras");
                        int pos_n_total_igv = drd.GetOrdinal("n_total_igv");
                        int pos_n_total_isc = drd.GetOrdinal("n_total_isc");
                        int pos_n_total_otros_tributos = drd.GetOrdinal("n_total_otros_tributos");
                        int pos_n_total_venta = drd.GetOrdinal("n_total_venta");
                        int pos_c_receptor_nombre_comercial = drd.GetOrdinal("c_receptor_nombre_comercial");
                        int pos_c_receptor_nombre_legal = drd.GetOrdinal("c_receptor_nombre_legal");
                        int pos_c_receptor_direccion = drd.GetOrdinal("c_receptor_direccion");
                        int pos_c_receptor_tipo_documento = drd.GetOrdinal("c_receptor_tipo_documento");
                        int pos_c_receptor_numero_documento = drd.GetOrdinal("c_receptor_numero_documento");
                        int pos_c_emisor_departamento = drd.GetOrdinal("c_emisor_departamento");
                        int pos_c_emisor_provincia = drd.GetOrdinal("c_emisor_provincia");
                        int pos_c_emisor_distrito = drd.GetOrdinal("c_emisor_distrito");
                        int pos_c_emisor_direccion = drd.GetOrdinal("c_emisor_direccion");
                        int pos_c_emisor_urbanizacion = drd.GetOrdinal("c_emisor_urbanizacion");
                        int pos_c_emisor_ubigeo = drd.GetOrdinal("c_emisor_ubigeo");
                        int pos_c_emisor_nombre_comercial  = drd.GetOrdinal("c_emisor_nombre_comercial");
                        int pos_c_emisor_nombre_legal = drd.GetOrdinal("c_emisor_nombre_legal");
                        int pos_c_emisor_tipo_documento = drd.GetOrdinal("c_emisor_tipo_documento");
                        int pos_c_emisor_numero_documento = drd.GetOrdinal("c_emisor_numero_documento");
                        int pos_c_codigo_anexo = drd.GetOrdinal("c_codigo_anexo");
                        int pos_n_calculo_detraccion = drd.GetOrdinal("n_calculo_detraccion");
                        int pos_n_calculo_igv = drd.GetOrdinal("n_calculo_igv");
                        int pos_n_calculo_isc = drd.GetOrdinal("n_calculo_isc");
                        int pos_idCliente = drd.GetOrdinal("idCliente");
                        #endregion columnas
                        while (drd.Read())
                        {
                            obe = new VentaBE();
                            #region valores
                            obe.n_id_cabecera = drd.GetInt32(pos_n_id_cabecera);
                            obe.c_tipo_documento = drd.GetString(pos_c_tipo_documento);
                            obe.c_tipo_documento_nombre = drd.GetString(pos_c_tipo_documento_nombre);
                            obe.n_id_documento_parent = drd.GetInt32(pos_n_id_documento_parent);
                            obe.c_tipo_operacion = drd.GetString(pos_c_tipo_operacion);
                            obe.n_exoneradas = drd.GetDecimal(pos_n_exoneradas);
                            obe.n_gratuitas = drd.GetDecimal(pos_n_gratuitas);
                            obe.n_gravadas = drd.GetDecimal(pos_n_gravadas);
                            obe.n_inafectas = drd.GetDecimal(pos_n_inafectas);
                            obe.c_fecha_emision = drd.GetString(pos_c_fecha_emision);
                            obe.c_id_documento = drd.GetString(pos_c_id_documento);
                            obe.c_id_documentoNV = drd.GetString(pos_c_id_documentoNV);
                            obe.c_id_tienda = drd.GetInt32(pos_c_id_tienda);
                            obe.c_moneda = drd.GetString(pos_c_moneda);
                            obe.n_monto_detraccion = drd.GetDecimal(pos_n_monto_detraccion);
                            obe.n_monto_percepcion = drd.GetDecimal(pos_n_monto_percepcion);
                            obe.n_monto_letras = drd.GetString(pos_n_monto_letras);
                            obe.n_total_igv = drd.GetDecimal(pos_n_total_igv);
                            obe.n_total_isc = drd.GetDecimal(pos_n_total_isc);
                            obe.n_total_otros_tributos = drd.GetDecimal(pos_n_total_otros_tributos);
                            obe.n_total_venta = drd.GetDecimal(pos_n_total_venta);
                            obe.c_receptor_nombre_comercial = drd.GetString(pos_c_receptor_nombre_comercial);
                            obe.c_receptor_nombre_legal = drd.GetString(pos_c_receptor_nombre_legal);
                            obe.c_receptor_direccion = drd.GetString(pos_c_receptor_direccion);
                            obe.c_receptor_tipo_documento = drd.GetString(pos_c_receptor_tipo_documento);
                            obe.c_receptor_numero_documento = drd.GetString(pos_c_receptor_numero_documento);
                            obe.c_emisor_departamento = drd.GetString(pos_c_emisor_departamento);
                            obe.c_emisor_provincia = drd.GetString(pos_c_emisor_provincia);
                            obe.c_emisor_distrito = drd.GetString(pos_c_emisor_distrito);
                            obe.c_emisor_direccion = drd.GetString(pos_c_emisor_direccion);
                            obe.c_emisor_urbanizacion = drd.GetString(pos_c_emisor_urbanizacion);
                            obe.c_emisor_ubigeo = drd.GetString(pos_c_emisor_ubigeo);
                            obe.c_emisor_nombre_comercial = drd.GetString(pos_c_emisor_nombre_comercial);
                            obe.c_emisor_nombre_legal = drd.GetString(pos_c_emisor_nombre_legal);
                            obe.c_emisor_tipo_documento = drd.GetString(pos_c_emisor_tipo_documento);
                            obe.c_emisor_numero_documento = drd.GetString(pos_c_emisor_numero_documento);
                            obe.c_codigo_anexo = drd.GetString(pos_c_codigo_anexo);
                            obe.n_calculo_detraccion = drd.GetDecimal(pos_n_calculo_detraccion);
                            obe.n_calculo_igv = drd.GetDecimal(pos_n_calculo_igv);
                            obe.n_calculo_isc = drd.GetDecimal(pos_n_calculo_isc);
                            obe.IdCliente = drd.GetInt32(pos_idCliente);
                            obe.loDetalle = new List<VentaDetalleBE>();
                            #endregion valores
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_n_id_detalle = drd.GetOrdinal("n_id_detalle");
                        int pos_n_id_cabecera = drd.GetOrdinal("n_id_cabecera");
                        int pos_c_id_producto = drd.GetOrdinal("c_id_producto");
                        int pos_c_id_productoAlmacen = drd.GetOrdinal("c_id_productoAlmacen");
                        int pos_c_id_tienda = drd.GetOrdinal("c_id_tienda");
                        int pos_c_codigo_item = drd.GetOrdinal("c_codigo_item");
                        int pos_c_decripcion = drd.GetOrdinal("c_decripcion");
                        int pos_c_tipo_precio = drd.GetOrdinal("c_tipo_precio");
                        int pos_n_precio_referencial = drd.GetOrdinal("n_precio_referencial");
                        int pos_n_precio_unitario = drd.GetOrdinal("n_precio_unitario");
                        int pos_n_descuento = drd.GetOrdinal("n_descuento");
                        int pos_n_cantidad = drd.GetOrdinal("n_cantidad");
                        int pos_n_unidad_medida = drd.GetOrdinal("n_unidad_medida");
                        int pos_n_tipo_impuesto = drd.GetOrdinal("n_tipo_impuesto");
                        int pos_n_impuesto = drd.GetOrdinal("n_impuesto");
                        int pos_n_impuesto_selectivo = drd.GetOrdinal("n_impuesto_selectivo");
                        int pos_n_otro_impuesto = drd.GetOrdinal("n_otro_impuesto");
                        int pos_n_total_venta = drd.GetOrdinal("n_total_venta");
                        int pos_n_suma = drd.GetOrdinal("n_suma");
                        int pos_c_tipo_documento = drd.GetOrdinal("c_tipo_documento");
                        int pos_c_id_documento = drd.GetOrdinal("c_id_documento");
                        int pos_c_emisor_nombre_legal = drd.GetOrdinal("c_emisor_nombre_legal");
                        int pos_c_emisor_numero_documento = drd.GetOrdinal("c_emisor_numero_documento");
                        #endregion columnas
                        while (drd.Read())
                        {
                            odetalle = new VentaDetalleBE();
                            #region valores
                            odetalle.n_id_detalle = drd.GetInt32(pos_n_id_detalle);
                            odetalle.n_id_cabecera = drd.GetInt32(pos_n_id_cabecera);
                            odetalle.c_id_producto = drd.GetInt32(pos_c_id_producto);
                            odetalle.c_id_productoAlmacen = drd.GetInt32(pos_c_id_productoAlmacen);
                            odetalle.c_id_tienda = drd.GetInt32(pos_c_id_tienda);
                            odetalle.c_codigo_item = drd.GetString(pos_c_codigo_item);
                            odetalle.c_decripcion = drd.GetString(pos_c_decripcion);
                            odetalle.c_tipo_precio = drd.GetString(pos_c_tipo_precio);
                            odetalle.n_precio_referencial = drd.GetDecimal(pos_n_precio_referencial);
                            odetalle.n_precio_unitario = drd.GetDecimal(pos_n_precio_unitario);
                            odetalle.n_descuento = drd.GetDecimal(pos_n_descuento);
                            odetalle.n_cantidad = drd.GetDecimal(pos_n_cantidad);
                            odetalle.n_unidad_medida = drd.GetString(pos_n_unidad_medida);
                            odetalle.n_tipo_impuesto = drd.GetString(pos_n_tipo_impuesto);
                            odetalle.n_impuesto = drd.GetDecimal(pos_n_impuesto);
                            odetalle.n_impuesto_selectivo = drd.GetDecimal(pos_n_impuesto_selectivo);
                            odetalle.n_otro_impuesto = drd.GetDecimal(pos_n_otro_impuesto);
                            odetalle.n_total_venta = drd.GetDecimal(pos_n_total_venta);
                            odetalle.n_suma = drd.GetDecimal(pos_n_suma);
                            odetalle.c_tipo_documento = drd.GetString(pos_c_tipo_documento);
                            odetalle.c_id_documento = drd.GetString(pos_c_id_documento);
                            odetalle.c_emisor_nombre_legal = drd.GetString(pos_c_emisor_nombre_legal);
                            odetalle.c_emisor_numero_documento = drd.GetString(pos_c_emisor_numero_documento);
                            lodetalle.Add(odetalle);
                            #endregion valores
                        }
                        obe.loDetalle = lodetalle;
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        while (drd.Read())
                        {
                            rpta = new RespuestaBE();
                            rpta.codigo = drd.GetInt32(pos_Codigo);
                            rpta.descripcion = drd.GetString(pos_Descripcion);
                        }
                    }
                }
            }

            return rpta;
        }

        public List<ListaCorrelativoVentaBE> TraerCorrelativoAnulacion(SqlConnection cnBD, SqlTransaction trx, VentaBE obj)
        {
            List<ListaCorrelativoVentaBE> lobe = new List<ListaCorrelativoVentaBE>();
            ListaCorrelativoVentaBE obe = new ListaCorrelativoVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_TraerCorrelativo_Anulacion]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obj.IdCliente;
                cmd.Parameters.Add("@IdTienda", SqlDbType.Int).Value = obj.c_id_tienda;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obj.UsrCreador;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("Serie");
                        int pos_Correlativo = drd.GetOrdinal("Correlativo");
                        int pos_SerieNV = drd.GetOrdinal("SerieNV");
                        int pos_CorrelativoNV = drd.GetOrdinal("CorrelativoNV");
                        int pos_TipoDocumentoNC = drd.GetOrdinal("TipoDocumentoNC");
                        int pos_TipoDocumentoNombreNC = drd.GetOrdinal("TipoDocumentoNombreNC");
                        int pos_ClaveDigital = drd.GetOrdinal("ClaveDigital");
                        int pos_URLCertificado = drd.GetOrdinal("URLCertificado");
                        int pos_RUC = drd.GetOrdinal("RUC");
                        int pos_IsFact = drd.GetOrdinal("isFact");
                        int pos_UsuarioSOL = drd.GetOrdinal("UsuarioSOL");
                        int pos_ClaveSOL = drd.GetOrdinal("ClaveSOL");
                        #endregion columnas

                        lobe = new List<ListaCorrelativoVentaBE>();
                        while (drd.Read())
                        {
                            obe = new ListaCorrelativoVentaBE();
                            #region valores
                            obe.Serie = drd.GetString(pos_Serie);
                            obe.Correlativo = drd.GetString(pos_Correlativo);
                            obe.SerieNV = drd.GetString(pos_SerieNV);
                            obe.CorrelativoNV = drd.GetString(pos_CorrelativoNV);
                            obe.TipoDocumentoNC = drd.GetString(pos_TipoDocumentoNC);
                            obe.TipoDocumentoNombreNC = drd.GetString(pos_TipoDocumentoNombreNC);
                            obe.ClaveDigital = drd.GetString(pos_ClaveDigital);
                            obe.URLCertificado = drd.GetString(pos_URLCertificado);
                            obe.RUC = drd.GetString(pos_RUC);
                            obe.isFact = drd.GetBoolean(pos_IsFact);
                            obe.UsuarioSOL = drd.GetString(pos_UsuarioSOL);
                            obe.ClaveSOL = drd.GetString(pos_ClaveSOL);
                            if (obe.ClaveDigital != "" && obe.URLCertificado != "" && obe.UsuarioSOL != "" && obe.ClaveSOL != "")
                            {
                                lobe.Add(obe);
                            }
                            #endregion valores
                        }
                    }
                }
            }
            return lobe;
        }

        public RespuestaBE GuardarNC(SqlConnection cnBD, SqlTransaction trx, VentaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_GuardarNC]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@n_id_cabecera", SqlDbType.Int).Value = obe.n_id_cabecera;
                cmd.Parameters.Add("@c_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_tipo_documentoNC;
                cmd.Parameters.Add("@c_tipo_documento_nombre", SqlDbType.VarChar, 50).Value = obe.c_tipo_documento_nombreNC;
                cmd.Parameters.Add("@n_id_documento_parent", SqlDbType.Int).Value = obe.n_id_documento_parent;
                cmd.Parameters.Add("@c_tipo_operacion", SqlDbType.VarChar, 50).Value = obe.c_tipo_operacion;
                cmd.Parameters.Add("@n_exoneradas", SqlDbType.Decimal).Value = obe.n_exoneradas;
                cmd.Parameters.Add("@n_gratuitas", SqlDbType.Decimal).Value = obe.n_gratuitas;
                cmd.Parameters.Add("@n_gravadas", SqlDbType.Decimal).Value = obe.n_gravadas;
                cmd.Parameters.Add("@n_inafectas", SqlDbType.Decimal).Value = obe.n_inafectas;
                cmd.Parameters.Add("@c_fecha_emision", SqlDbType.VarChar, 50).Value = obe.c_fecha_emision;
                cmd.Parameters.Add("@c_id_documento", SqlDbType.VarChar, 50).Value = obe.c_id_documentoNC;
                cmd.Parameters.Add("@c_moneda", SqlDbType.VarChar, 50).Value = obe.c_moneda;
                cmd.Parameters.Add("@n_monto_detraccion", SqlDbType.Decimal).Value = obe.n_monto_detraccion;
                cmd.Parameters.Add("@n_monto_percepcion", SqlDbType.Decimal).Value = obe.n_monto_percepcion;
                cmd.Parameters.Add("@n_monto_letras", SqlDbType.VarChar, 500).Value = obe.n_monto_letras;
                cmd.Parameters.Add("@n_total_igv", SqlDbType.Decimal).Value = obe.n_total_igv;
                cmd.Parameters.Add("@n_total_isc", SqlDbType.Decimal).Value = obe.n_total_isc;
                cmd.Parameters.Add("@n_total_otros_tributos", SqlDbType.Decimal).Value = obe.n_total_otros_tributos;
                cmd.Parameters.Add("@n_total_venta", SqlDbType.Decimal).Value = obe.n_total_venta;
                cmd.Parameters.Add("@c_receptor_nombre_comercial", SqlDbType.VarChar, 500).Value = obe.c_receptor_nombre_comercial;
                cmd.Parameters.Add("@c_receptor_nombre_legal", SqlDbType.VarChar, 500).Value = obe.c_receptor_nombre_legal;
                cmd.Parameters.Add("@c_receptor_direccion", SqlDbType.VarChar, 500).Value = obe.c_receptor_direccion;
                cmd.Parameters.Add("@c_receptor_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_receptor_tipo_documento;
                cmd.Parameters.Add("@c_receptor_numero_documento", SqlDbType.VarChar, 50).Value = obe.c_receptor_numero_documento;
                cmd.Parameters.Add("@c_emisor_departamento", SqlDbType.VarChar, 50).Value = obe.c_emisor_departamento;
                cmd.Parameters.Add("@c_emisor_provincia", SqlDbType.VarChar, 50).Value = obe.c_emisor_provincia;
                cmd.Parameters.Add("@c_emisor_distrito", SqlDbType.VarChar, 50).Value = obe.c_emisor_distrito;
                cmd.Parameters.Add("@c_emisor_direccion", SqlDbType.VarChar, 500).Value = obe.c_emisor_direccion;
                cmd.Parameters.Add("@c_emisor_urbanizacion", SqlDbType.VarChar, 50).Value = obe.c_emisor_urbanizacion;
                cmd.Parameters.Add("@c_emisor_ubigeo", SqlDbType.VarChar, 50).Value = obe.c_emisor_ubigeo;
                cmd.Parameters.Add("@c_emisor_nombre_comercial", SqlDbType.VarChar, 500).Value = obe.c_emisor_nombre_comercial;
                cmd.Parameters.Add("@c_emisor_nombre_legal", SqlDbType.VarChar, 500).Value = obe.c_emisor_nombre_legal;
                cmd.Parameters.Add("@c_emisor_tipo_documento", SqlDbType.VarChar, 50).Value = obe.c_emisor_tipo_documento;
                cmd.Parameters.Add("@c_emisor_numero_documento", SqlDbType.VarChar, 50).Value = obe.c_emisor_numero_documento;
                cmd.Parameters.Add("@c_codigo_anexo", SqlDbType.VarChar, 20).Value = obe.c_codigo_anexo;
                cmd.Parameters.Add("@n_calculo_detraccion", SqlDbType.Decimal).Value = obe.n_calculo_detraccion;
                cmd.Parameters.Add("@n_calculo_igv", SqlDbType.Decimal).Value = obe.n_calculo_igv;
                cmd.Parameters.Add("@n_calculo_isc", SqlDbType.Decimal).Value = obe.n_calculo_isc;
                cmd.Parameters.Add("@claveDigital", SqlDbType.VarChar, 250).Value = obe.ClaveDigital;
                cmd.Parameters.Add("@urlCertificado", SqlDbType.VarChar, 500).Value = obe.URLCertificado;
                cmd.Parameters.Add("@UsrCreador", SqlDbType.VarChar, 50).Value = obe.UsrCreador;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = obe.IdCliente;
                cmd.Parameters.Add("@c_id_tienda", SqlDbType.Int).Value = obe.c_id_tienda;
                cmd.Parameters.Add("@loDetalle", SqlDbType.Structured).Value = CrearEstructuraNC(obe.loDetalle);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        while (drd.Read())
                        {
                            rpta = new RespuestaBE();
                            rpta.codigo = drd.GetInt32(pos_Codigo);
                            rpta.descripcion = drd.GetString(pos_Descripcion);
                        }
                    }
                }
            }
            return rpta;
        }

        public RespuestaBE GuardarNV(SqlConnection cnBD, SqlTransaction trx, VentaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_GuardarNV]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Transaction = trx;
                cmd.Parameters.Add("@n_id_cabecera", SqlDbType.Int).Value = obe.n_id_cabecera;
                
                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        int pos_Codigo = drd.GetOrdinal("Codigo");
                        int pos_Descripcion = drd.GetOrdinal("Descripcion");

                        while (drd.Read())
                        {
                            rpta = new RespuestaBE();
                            rpta.codigo = drd.GetInt32(pos_Codigo);
                            rpta.descripcion = drd.GetString(pos_Descripcion);
                        }
                    }
                }
            }
            return rpta;
        }

        //LISTADO DE VENTAS
        public ListadoVentaBE ListadoVentasDia(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteListadoVentaBE> listado = new List<ReporteListadoVentaBE>();
            List<ReporteListadoVentaExcelBE> listadoExcel = new List<ReporteListadoVentaExcelBE>();
            ReporteListadoVentaBE obe = new ReporteListadoVentaBE();
            ReporteListadoVentaExcelBE obeXLS = new ReporteListadoVentaExcelBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            ListadoVentaBE lobe = new ListadoVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_ListadoVentasDia]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructuraTienda(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_NombreTienda = drd.GetOrdinal("NombreTienda");
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_DesNombreGenerico = drd.GetOrdinal("DesNombreGenerico");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteListadoVentaBE>();
                        listadoExcel = new List<ReporteListadoVentaExcelBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteListadoVentaBE();
                            obeXLS = new ReporteListadoVentaExcelBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.NombreTienda = drd.GetString(pos_NombreTienda);
                            obe.IdProducto = drd.GetString(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);
                            
                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.Cantidad = drd.GetString(pos_Cantidad);
                            obe.Precio = drd.GetString(pos_Precio);
                            obe.PrecioCosto = drd.GetString(pos_PrecioCosto);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            obeXLS.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeXLS.NombreTienda = drd.GetString(pos_NombreTienda);
                            obeXLS.IdProducto = drd.GetString(pos_IdProducto);
                            obeXLS.NombreProducto = drd.GetString(pos_NombreProducto);
                            obeXLS.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obeXLS.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obeXLS.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);
                            
                            obeXLS.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obeXLS.Cantidad = drd.GetString(pos_Cantidad);
                            obeXLS.Precio = drd.GetString(pos_Precio);
                            obeXLS.PrecioCosto = drd.GetString(pos_PrecioCosto);
                            obeXLS.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            listado.Add(obe);
                            listadoExcel.Add(obeXLS);
                            #endregion Lista - campos
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
            lobe.listado = listado;
            lobe.listadoExcel = listadoExcel;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public ListadoVentaBE ListadoVentasMes(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteListadoVentaBE> listado = new List<ReporteListadoVentaBE>();
            List<ReporteListadoVentaExcelBE> listadoExcel = new List<ReporteListadoVentaExcelBE>();
            ReporteListadoVentaBE obe = new ReporteListadoVentaBE();
            ReporteListadoVentaExcelBE obeXLS = new ReporteListadoVentaExcelBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            ListadoVentaBE lobe = new ListadoVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_ListadoVentasMes]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructuraTienda(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_NombreTienda = drd.GetOrdinal("NombreTienda");
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_DesNombreGenerico = drd.GetOrdinal("DesNombreGenerico");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteListadoVentaBE>();
                        listadoExcel = new List<ReporteListadoVentaExcelBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteListadoVentaBE();
                            obeXLS = new ReporteListadoVentaExcelBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.NombreTienda = drd.GetString(pos_NombreTienda);
                            obe.IdProducto = drd.GetString(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);

                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.Cantidad = drd.GetString(pos_Cantidad);
                            obe.Precio = drd.GetString(pos_Precio);
                            obe.PrecioCosto = drd.GetString(pos_PrecioCosto);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            obeXLS.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeXLS.NombreTienda = drd.GetString(pos_NombreTienda);
                            obeXLS.IdProducto = drd.GetString(pos_IdProducto);
                            obeXLS.NombreProducto = drd.GetString(pos_NombreProducto);
                            obeXLS.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obeXLS.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obeXLS.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);

                            obeXLS.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obeXLS.Cantidad = drd.GetString(pos_Cantidad);
                            obeXLS.Precio = drd.GetString(pos_Precio);
                            obeXLS.PrecioCosto = drd.GetString(pos_PrecioCosto);
                            obeXLS.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            listado.Add(obe);
                            listadoExcel.Add(obeXLS);
                            #endregion Lista - campos
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
            lobe.listado = listado;
            lobe.listadoExcel = listadoExcel;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public ListadoVentaBE ListadoVentasAnio(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteListadoVentaBE> listado = new List<ReporteListadoVentaBE>();
            List<ReporteListadoVentaExcelBE> listadoExcel = new List<ReporteListadoVentaExcelBE>();
            ReporteListadoVentaBE obe = new ReporteListadoVentaBE();
            ReporteListadoVentaExcelBE obeXLS = new ReporteListadoVentaExcelBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            ListadoVentaBE lobe = new ListadoVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_ListadoVentasAnio]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructuraTienda(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_NombreTienda = drd.GetOrdinal("NombreTienda");
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_DesNombreGenerico = drd.GetOrdinal("DesNombreGenerico");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteListadoVentaBE>();
                        listadoExcel = new List<ReporteListadoVentaExcelBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteListadoVentaBE();
                            obeXLS = new ReporteListadoVentaExcelBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.NombreTienda = drd.GetString(pos_NombreTienda);
                            obe.IdProducto = drd.GetString(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);

                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.Cantidad = drd.GetString(pos_Cantidad);
                            obe.Precio = drd.GetString(pos_Precio);
                            obe.PrecioCosto = drd.GetString(pos_PrecioCosto);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            obeXLS.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeXLS.NombreTienda = drd.GetString(pos_NombreTienda);
                            obeXLS.IdProducto = drd.GetString(pos_IdProducto);
                            obeXLS.NombreProducto = drd.GetString(pos_NombreProducto);
                            obeXLS.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obeXLS.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obeXLS.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);

                            obeXLS.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obeXLS.Cantidad = drd.GetString(pos_Cantidad);
                            obeXLS.Precio = drd.GetString(pos_Precio);
                            obeXLS.PrecioCosto = drd.GetString(pos_PrecioCosto);
                            obeXLS.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            listado.Add(obe);
                            listadoExcel.Add(obeXLS);
                            #endregion Lista - campos
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
            lobe.listado = listado;
            lobe.listadoExcel = listadoExcel;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public ListadoVentaBE ListadoVentasRango(SqlConnection cnBD, string usuario, int idCliente, string fechaInicio, string fechaFin, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteListadoVentaBE> listado = new List<ReporteListadoVentaBE>();
            List<ReporteListadoVentaExcelBE> listadoExcel = new List<ReporteListadoVentaExcelBE>();
            ReporteListadoVentaBE obe = new ReporteListadoVentaBE();
            ReporteListadoVentaExcelBE obeXLS = new ReporteListadoVentaExcelBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            ListadoVentaBE lobe = new ListadoVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_ListadoVentasRango]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 10).Value = fechaInicio;
                cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = fechaFin;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructuraTienda(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_NombreTienda = drd.GetOrdinal("NombreTienda");
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_DesNombreGenerico = drd.GetOrdinal("DesNombreGenerico");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_FechaFinReporte = drd.GetOrdinal("FechaFinReporte");
                        #endregion Lista - columnas
                        listado = new List<ReporteListadoVentaBE>();
                        listadoExcel = new List<ReporteListadoVentaExcelBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteListadoVentaBE();
                            obeXLS = new ReporteListadoVentaExcelBE();
                            #region Lista - campos
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.NombreTienda = drd.GetString(pos_NombreTienda);
                            obe.IdProducto = drd.GetString(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);

                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.Cantidad = drd.GetString(pos_Cantidad);
                            obe.Precio = drd.GetString(pos_Precio);
                            obe.PrecioCosto = drd.GetString(pos_PrecioCosto);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.FechaFinReporte = drd.GetString(pos_FechaFinReporte);

                            obeXLS.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeXLS.NombreTienda = drd.GetString(pos_NombreTienda);
                            obeXLS.IdProducto = drd.GetString(pos_IdProducto);
                            obeXLS.NombreProducto = drd.GetString(pos_NombreProducto);
                            obeXLS.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obeXLS.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obeXLS.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);

                            obeXLS.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obeXLS.Cantidad = drd.GetString(pos_Cantidad);
                            obeXLS.Precio = drd.GetString(pos_Precio);
                            obeXLS.PrecioCosto = drd.GetString(pos_PrecioCosto);
                            obeXLS.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obeXLS.FechaFinReporte = drd.GetString(pos_FechaFinReporte);

                            listado.Add(obe);
                            listadoExcel.Add(obeXLS);
                            #endregion Lista - campos
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
            lobe.listado = listado;
            lobe.listadoExcel = listadoExcel;
            lobe.loColumns = loColumns;

            return lobe;
        }

        public ListadoVentaBE ListadoVentasACuenta(SqlConnection cnBD, string usuario, int idCliente, string codCliente, List<ListaComboBE> loTienda)
        {
            //listado
            List<ReporteListadoVentaBE> listado = new List<ReporteListadoVentaBE>();
            List<ReporteListadoVentaExcelBE> listadoExcel = new List<ReporteListadoVentaExcelBE>();
            ReporteListadoVentaBE obe = new ReporteListadoVentaBE();
            ReporteListadoVentaExcelBE obeXLS = new ReporteListadoVentaExcelBE();
            //listado - columnas
            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            ReporteColumnas obeColumns = new ReporteColumnas();
            //Objeto
            ListadoVentaBE lobe = new ListadoVentaBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Venta_ListadoVentasACuenta]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50).Value = idCliente;
                cmd.Parameters.Add("@CodCliente", SqlDbType.VarChar, 15).Value = codCliente;
                cmd.Parameters.Add("@loTienda", SqlDbType.Structured).Value = CrearEstructuraTienda(loTienda);

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Lista - columnas
                        int pos_Cliente = drd.GetOrdinal("Cliente");
                        int pos_IdTienda = drd.GetOrdinal("IdTienda");
                        int pos_NombreTienda = drd.GetOrdinal("NombreTienda");
                        int pos_IdProducto = drd.GetOrdinal("IdProducto");
                        int pos_NombreProducto = drd.GetOrdinal("NombreProducto");
                        int pos_DesNombreGenerico = drd.GetOrdinal("DesNombreGenerico");
                        int pos_DesProdLaboratorio = drd.GetOrdinal("DesProdLaboratorio");
                        int pos_DesProdTipoPresentacion = drd.GetOrdinal("DesProdTipoPresentacion");
                        int pos_PrecioCosto = drd.GetOrdinal("PrecioCosto");
                        int pos_PrecioVenta = drd.GetOrdinal("PrecioVenta");
                        int pos_Cantidad = drd.GetOrdinal("Cantidad");
                        int pos_Precio = drd.GetOrdinal("Precio");
                        int pos_FechaInicioReporte = drd.GetOrdinal("FechaInicioReporte");
                        int pos_isPagar = drd.GetOrdinal("isPagar");
                        int pos_idDetalle = drd.GetOrdinal("n_id_detalle");
                        #endregion Lista - columnas
                        listado = new List<ReporteListadoVentaBE>();
                        listadoExcel = new List<ReporteListadoVentaExcelBE>();
                        while (drd.Read())
                        {
                            obe = new ReporteListadoVentaBE();
                            obeXLS = new ReporteListadoVentaExcelBE();
                            #region Lista - campos
                            obe.Cliente = drd.GetString(pos_Cliente);
                            obe.IdTienda = drd.GetInt32(pos_IdTienda);
                            obe.NombreTienda = drd.GetString(pos_NombreTienda);
                            obe.IdProducto = drd.GetString(pos_IdProducto);
                            obe.NombreProducto = drd.GetString(pos_NombreProducto);
                            obe.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obe.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obe.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);

                            obe.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obe.Cantidad = drd.GetString(pos_Cantidad);
                            obe.Precio = drd.GetString(pos_Precio);
                            obe.PrecioCosto = drd.GetString(pos_PrecioCosto);
                            obe.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);
                            obe.isPagar = drd.GetBoolean(pos_isPagar);
                            obe.IdDetalle = drd.GetInt32(pos_idDetalle);

                            obeXLS.Cliente = drd.GetString(pos_Cliente);
                            obeXLS.IdTienda = drd.GetInt32(pos_IdTienda);
                            obeXLS.NombreTienda = drd.GetString(pos_NombreTienda);
                            obeXLS.IdProducto = drd.GetString(pos_IdProducto);
                            obeXLS.NombreProducto = drd.GetString(pos_NombreProducto);
                            obeXLS.DesNombreGenerico = drd.GetString(pos_DesNombreGenerico);
                            obeXLS.DesProdLaboratorio = drd.GetString(pos_DesProdLaboratorio);
                            obeXLS.DesProdTipoPresentacion = drd.GetString(pos_DesProdTipoPresentacion);

                            obeXLS.PrecioVenta = drd.GetString(pos_PrecioVenta);
                            obeXLS.Cantidad = drd.GetString(pos_Cantidad);
                            obeXLS.Precio = drd.GetString(pos_Precio);
                            obeXLS.PrecioCosto = drd.GetString(pos_PrecioCosto);
                            obeXLS.FechaInicioReporte = drd.GetString(pos_FechaInicioReporte);

                            listado.Add(obe);
                            listadoExcel.Add(obeXLS);
                            #endregion Lista - campos
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
            lobe.listado = listado;
            lobe.listadoExcel = listadoExcel;
            lobe.loColumns = loColumns;

            return lobe;
        }

    }
}
