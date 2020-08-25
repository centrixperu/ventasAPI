using Entidades.Ajustes.AlmacenXTienda;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class AlmacenXTienda_DatosInicialesBE
    {
        public List<AlmacenXTiendaBE> loListado { get; set; }
        public List<ListaComboBE> loCliente { get; set; }
        public List<ListaComboBE> loTienda { get; set; }
        public List<ListaComboBE> loAlmacen { get; set; }

        public List<ReporteColumnas> loColumns { get; set; }
        public List<AlmacenXTiendaExportBE> loExport { get; set; }
    }
}
