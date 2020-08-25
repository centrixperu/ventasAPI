using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEGrupoResumen : EDEDocumentoResumenDetalle
    {
        public int CorrelativoInicio { get; set; }

        public int CorrelativoFin { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Moneda { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalVenta { get; set; }

        public decimal TotalDescuentos { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosImpuestos { get; set; }

        public decimal Gravadas { get; set; }

        public decimal Exoneradas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exportacion { get; set; }

        public decimal Gratuitas { get; set; }
    }
}
