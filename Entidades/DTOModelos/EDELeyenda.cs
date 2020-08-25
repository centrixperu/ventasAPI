using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDELeyenda
    {
        [JsonProperty(Required = Required.Always)]
        public string Codigo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Descripcion { get; set; }
    }
}
