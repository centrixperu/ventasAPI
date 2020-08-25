using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEDiscrepancia
    {
        [JsonProperty(Required = Required.Always)]
        public string NroReferencia { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Tipo { get; set; }

        [JsonProperty(Required = Required.Always)]
        [StringLength(500)]
        public string Descripcion { get; set; }
    }
}
