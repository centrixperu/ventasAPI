using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEResumenDiarioNuevo : EDEDocumentoResumen
    {
        [JsonProperty(Required = Required.Always)]
        public List<EDEGrupoResumenNuevo> Resumenes { get; set; }
    }
}
