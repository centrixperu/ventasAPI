using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEComunicacionBaja : EDEDocumentoResumen
    {
        [JsonProperty(Required = Required.Always)]
        public List<EDEDocumentoBaja> Bajas { get; set; }
    }
}
