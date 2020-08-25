using Entidades.Ajustes.Tienda;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class Tienda_DatosInicialesBE
    {
        public List<TiendaBE> loListado { get; set; }
        public List<ListaComboBE> loCliente { get; set; }
        public List<ReporteColumnas> loColumns { get; set; }
        public List<TiendaExportBE> loExport { get; set; }
    }
}
