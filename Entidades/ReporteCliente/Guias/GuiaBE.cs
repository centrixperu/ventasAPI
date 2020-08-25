using Entidades.ReporteCliente.Guias;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteCliente
{
    public class GuiaBE
    {
        public List<ReporteGuiaBE> listado { get; set; }
        public List<ReporteColumnas> loColumns { get; set; }
        public List<ReporteGuia_DetalleBE> listadoDetalle { get; set; }
        public List<ReporteColumnas> loColumnsDetalle { get; set; }
    }

}
