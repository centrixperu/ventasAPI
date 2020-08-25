using Entidades.Ajustes.ComprobanteXTienda;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class ComprobanteXTienda_DatosInicialesBE
    {
        public List<ComprobanteXTiendaBE> loListado { get; set; }
        public List<ListaComboBE> loCliente { get; set; }
        public List<ListaComboBE> loTienda { get; set; }
        public List<ListaComboBE> loComprobante { get; set; }

        public List<ReporteColumnas> loColumns { get; set; }
        public List<ComprobanteXTiendaExportBE> loExport { get; set; }
    }
}
