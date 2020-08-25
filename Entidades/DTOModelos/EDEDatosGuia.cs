using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEDatosGuia
    {
        [JsonProperty(Required = Required.Always)]
        public EDENegocio DireccionDestino { get; set; }

        [JsonProperty(Required = Required.Always)]
        public EDENegocio DireccionOrigen { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string RucTransportista { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoDocTransportista { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string NombreTransportista { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string NroLicenciaConducir { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string PlacaVehiculo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string CodigoAutorizacion { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string MarcaVehiculo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ModoTransporte { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string UnidadMedida { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PesoBruto { get; set; }
    }
}
