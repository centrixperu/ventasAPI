using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteCodigoBarra
{
    public class CodigoBarraReportBE
    {
        public string NombreProducto { get; set; }
        public string CodigoBarras { get; set; }
        public byte[] BarCodeImage { get; set; }
    }
}
