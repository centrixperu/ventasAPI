using System;
using Entidades.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Venta
{
    public class VentaBE
    {
        public int n_id_cabecera { get; set; }
        public string c_tipo_documento { get; set; }
        public string c_tipo_documento_nombre { get; set; }
        public int n_id_documento_parent { get; set; }
        public string c_tipo_operacion { get; set; }
        public decimal n_exoneradas { get; set; }
        public decimal n_gratuitas { get; set; }
        public decimal n_gravadas { get; set; }
        public decimal n_inafectas { get; set; }
        public string c_fecha_emision { get; set; }
        public string c_id_documento { get; set; }
        public string c_moneda { get; set; }
        public decimal n_monto_detraccion { get; set; }
        public decimal n_monto_percepcion { get; set; }
        public string n_monto_letras { get; set; }
        public decimal n_total_igv { get; set; }
        public decimal n_total_isc { get; set; }
        public decimal n_total_otros_tributos { get; set; }
        public decimal n_total_venta { get; set; }
        public string c_receptor_nombre_comercial { get; set; }
        public string c_receptor_nombre_legal { get; set; }
        public string c_receptor_direccion { get; set; }
        public string c_receptor_tipo_documento { get; set; }
        public string c_receptor_numero_documento { get; set; }
        public string c_emisor_departamento { get; set; }
        public string c_emisor_provincia { get; set; }
        public string c_emisor_distrito { get; set; }
        public string c_emisor_direccion { get; set; }
        public string c_emisor_urbanizacion { get; set; }
        public string c_emisor_ubigeo { get; set; }
        public string c_emisor_nombre_comercial { get; set; }
        public string c_emisor_nombre_legal { get; set; }
        public string c_emisor_tipo_documento { get; set; }
        public string c_emisor_numero_documento { get; set; }
        public string c_codigo_anexo { get; set; }
        public decimal n_calculo_detraccion { get; set; }
        public decimal n_calculo_igv { get; set; }
        public decimal n_calculo_isc { get; set; }
        public List<VentaDetalleBE> loDetalle { get; set; }
        public string UsrCreador { get; set; }
        public int IdCliente { get; set; }
        public int IdTienda { get; set; }

        //DATOS FACTURACION ELECTRONICA
        public string RUC { get; set; }
        public string UsuarioSOL { get; set; }
        public string ClaveSOL { get; set; }
        public string URLCertificado { get; set; }
        public string ClaveDigital { get; set; }
        public string c_id_documentoNV { get; set; }
        public string c_id_documentoNC { get; set; }
        public string c_tipo_documentoNC { get; set; }
        public string c_tipo_documento_nombreNC { get; set; }
        public int c_id_tienda { get; set; }
        public bool Acuenta { get; set; }

        //DATOS PDF
        public string t_impresion { get; set; }
        //ARCHIVOS ADJUNTO
        public List<ListaArchivosAdjuntos> loarchivos { get; set; }
    }
}
