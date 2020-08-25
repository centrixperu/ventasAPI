using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteCliente.VentaProducto
{
    public class VentaProductoBE
    {
        public List<ReporteVentaProductoBE> listado { get; set; }
        public List<ReporteColumnas> loColumns { get; set; }
    }
}
