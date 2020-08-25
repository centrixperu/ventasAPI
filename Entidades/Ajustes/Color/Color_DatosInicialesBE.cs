using Entidades.Ajustes.Color;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class Color_DatosInicialesBE
    {
        public List<ColorBE> loListado { get; set; }
        public List<ListaComboBE> loCliente { get; set; }

        public List<ReporteColumnas> loColumns { get; set; }
        public List<ColorExportBE> loExport { get; set; }
    }
}
