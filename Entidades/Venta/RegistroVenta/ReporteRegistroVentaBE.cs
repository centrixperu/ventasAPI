using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Venta
{
    public class ReporteRegistroVentaBE
    {
        public int IdTienda { get; set; }
        public string DesTienda { get; set; }
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public string NotaVenta { get; set; }
        public string BoletaVenta { get; set; }
        public string FacturaVenta { get; set; }
        public string NotaCreditoVenta { get; set; }
        public string NotaDebitoVenta { get; set; }
        public string TotalSinIGV { get; set; }
        public string TotalVenta { get; set; }
        public string EstadoFABO { get; set; }
        public string EstadoResumen { get; set; }
        public string FechaInicioReporte { get; set; }
        public string FechaFinReporte { get; set; }

        public bool isNC { get; set; }
        public bool isND { get; set; }
        public bool isAnular { get; set; }
    }
}
