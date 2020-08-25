using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEDocumentoRelacionado
    {
        [JsonProperty(Order = 1, Required = Required.Always)]
        public string NroDocumento { get; set; }
        [JsonProperty(Order = 2, Required = Required.Always)]
        public string TipoDocumento { get; set; }
    }
}
