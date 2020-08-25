using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteCodigoBarra
{
    public class CodigoBarraBE : CodigoBarraReportBE
    {
        public string IdProducto { get; set; }
        public bool Habilitado { get; set; }
        public int Cantidad { get; set; }
    }
}
