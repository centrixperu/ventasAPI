﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEGrupoResumenNuevo : EDEGrupoResumen
    {
        [JsonProperty(Required = Required.Always)]
        public string IdDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoDocumentoReceptor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string NroDocumentoReceptor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int CodigoEstadoItem { get; set; }

        public string DocumentoRelacionado { get; set; }

        public string TipoDocumentoRelacionado { get; set; }
    }
}
