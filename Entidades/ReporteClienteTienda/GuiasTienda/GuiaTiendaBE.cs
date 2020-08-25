using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteClienteTienda.GuiasTienda
{
    public class GuiaTiendaBE
    {
        public List<ReporteGuiaTiendaBE> listado { get; set; }
        public List<ReporteColumnas> loColumns { get; set; }
        public List<ReporteGuiaTienda_DetalleBE> listadoDetalle { get; set; }
        public List<ReporteColumnas> loColumnsDetalle { get; set; }
    }
}
