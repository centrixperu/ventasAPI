using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEDocumentoBaja : EDEDocumentoResumenDetalle
    {
        [JsonProperty(Required = Required.Always)]
        public string Correlativo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string MotivoBaja { get; set; }
    }
}
