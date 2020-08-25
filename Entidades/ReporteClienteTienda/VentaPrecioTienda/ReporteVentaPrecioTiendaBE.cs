using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteClienteTienda.VentaPrecioTienda
{
    public class ReporteVentaPrecioTiendaBE
    {
        public int IdTienda { get; set; }
        public string DesTienda { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string PrecioVenta { get; set; }
        public string VentaTienda { get; set; }
        public string AnulacionVentaTienda { get; set; }
        public string DescuentoVentas { get; set; }
        public string TotalVenta { get; set; }
        public string SumaTotalVenta { get; set; }
        public string FechaInicioReporte { get; set; }
        public string FechaFinReporte { get; set; }
    }
}
