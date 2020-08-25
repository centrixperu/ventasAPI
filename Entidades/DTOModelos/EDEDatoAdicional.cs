using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEDatoAdicional
    {
        [JsonProperty(Order = 1, Required = Required.Always)]
        public string Codigo { get; set; }

        [JsonProperty(Order = 2, Required = Required.AllowNull)]
        public string Nombre { get; set; }

        [JsonProperty(Order = 3, Required = Required.Always)]
        public string Contenido { get; set; }

        [JsonProperty(Order = 4, Required = Required.AllowNull)]
        public string FechaInicio { get; set; }

        [JsonProperty(Order = 5, Required = Required.AllowNull)]
        public string FechaFin { get; set; }

        [JsonProperty(Order = 6, Required = Required.AllowNull)]
        public int Duracion { get; set; }
    }
}
