using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEDetalleDocumento
    {
        [JsonProperty(Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal Cantidad { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string UnidadMedida { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string CodigoItem { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Descripcion { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PrecioUnitario { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PrecioReferencial { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoPrecio { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoImpuesto { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal Impuesto { get; set; }

        public decimal ImpuestoSelectivo { get; set; }

        public decimal TasaImpuestoSelectivo { get; set; }

        public decimal OtroImpuesto { get; set; }

        public decimal Descuento { get; set; }

        public string PlacaVehiculo { get; set; }

        public string CodigoProductoSunat { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalVenta { get; set; }

        public List<EDEDatoAdicional> DatosAdcionales { get; set; }
    }
}
