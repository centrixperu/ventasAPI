using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Venta.ListadoVenta
{
    public class ReporteListadoVentaExcelBE
    {
        public string Cliente { get; set; }
        public int IdTienda { get; set; }
        public string NombreTienda { get; set; }
        public string IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DesNombreGenerico { get; set; }
        public string DesProdLaboratorio { get; set; }
        public string DesProdTipoPresentacion { get; set; }
        public string PrecioCosto { get; set; }
        public string PrecioVenta { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public string FechaInicioReporte { get; set; }
        public string FechaFinReporte { get; set; }
    }
}
