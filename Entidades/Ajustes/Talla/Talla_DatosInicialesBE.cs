﻿using Entidades.Ajustes.Talla;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class Talla_DatosInicialesBE
    {
        public List<TallaBE> loListado { get; set; }
        public List<ListaComboBE> loCliente { get; set; }

        public List<ReporteColumnas> loColumns { get; set; }
        public List<TallaExportBE> loExport { get; set; }
    }
}