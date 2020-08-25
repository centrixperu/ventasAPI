using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteCliente.KardexPrecio
{
    public class ReporteKardexPrecioBE
    {
        public int IdTienda { get; set; }
        public string DesTienda { get; set; }
        public string PrecioVenta { get; set; }
        public string Stock { get; set; }
        public string Entrada { get; set; }
        public string EntradaTraspaso { get; set; }
        public string Salida { get; set; }
        public string SalidaTraspaso { get; set; }
        public string Anulacion { get; set; }
        public string Venta { get; set; }
        public string Total { get; set; }
        public string FechaInicioReporte { get; set; }
        public string FechaFinReporte { get; set; }
        
    }
}
