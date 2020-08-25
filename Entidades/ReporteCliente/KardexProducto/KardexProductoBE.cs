using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteCliente.KardexProducto
{
    public class KardexProductoBE
    {
        public List<ReporteKardexProductoBE> listado { get; set; }
        public List<ReporteColumnas> loColumns { get; set; }
    }
}
