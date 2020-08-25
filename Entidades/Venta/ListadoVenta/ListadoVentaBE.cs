using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Venta.ListadoVenta
{
    public class ListadoVentaBE
    {
        //LISTADO DE VENTAS
        public List<ReporteListadoVentaBE> listado { get; set; }
        public List<ReporteListadoVentaExcelBE> listadoExcel { get; set; }
        public List<ReporteColumnas> loColumns { get; set; }
    }
}
