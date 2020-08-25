using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Venta.RegistroVenta
{
    public class RegistroVentaBE
    {
        //REGISTRO DE VENTAS
        public List<ReporteRegistroVentaBE> listado { get; set; }
        public List<ReporteRegistroVentaExcelBE> listadoExcel { get; set; }
        public List<ReporteColumnas> loColumns { get; set; }
        //DETALLE DE VENTA
        public List<RegistroVentaDetalleBE> listadoDetalle { get; set; }
    }
}
