using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEDocumentoElectronico
    {
        [JsonProperty(Required = Required.Always)]
        public string IdDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public EDECompania Emisor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public EDECompania Receptor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FechaEmision { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string HoraEmision { get; set; }

        public string FechaVencimiento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Moneda { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string TipoOperacion { get; set; }

        public decimal Gravadas { get; set; }

        public decimal Gratuitas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exoneradas { get; set; }

        public decimal Exportacion { get; set; }

        public decimal DescuentoGlobal { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<EDEDetalleDocumento> Items { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalVenta { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosTributos { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string MontoEnLetras { get; set; }

        public decimal MontoPercepcion { get; set; }

        public decimal MontoDetraccion { get; set; }

        public decimal TasaDetraccion { get; set; }

        public string CuentaBancoNacion { get; set; }

        public string CodigoBienOServicio { get; set; }

        public string CodigoMedioPago { get; set; }

        public List<EDEDatoAdicional> DatoAdicionales { get; set; }

        public string TipoDocAnticipo { get; set; }

        public string DocAnticipo { get; set; }

        public string MonedaAnticipo { get; set; }

        public decimal MontoAnticipo { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public EDEDatosGuia DatosGuiaTransportista { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public List<EDEDocumentoRelacionado> Relacionados { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public List<EDEDocumentoRelacionado> OtrosDocumentosRelacionados { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public List<EDEDiscrepancia> Discrepancias { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public List<EDELeyenda> Leyendas { get; set; }

        //VARIABLES DEL CLIENTE
        [JsonProperty(Required = Required.Always)]
        public string RUC { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string UsuarioSOL { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ClaveSOL { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string URLCertificado { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ClaveDigital { get; set; }

    }
}
