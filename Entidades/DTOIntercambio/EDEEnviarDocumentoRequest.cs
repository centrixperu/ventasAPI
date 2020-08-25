using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOIntercambio
{
    public class EDEEnviarDocumentoRequest : EDEEnvioDocumentoComun
    {
        [JsonProperty(Required = Required.Always)]
        public string TramaXmlFirmado { get; set; }
    }
}
