using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDECompania : EDEContribuyente
    {
        [JsonProperty(Order = 5)]
        [JsonRequired]
        public string CodigoAnexo { get; set; }
    }
}
