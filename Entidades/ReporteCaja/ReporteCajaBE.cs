using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteCaja
{
    public class ReporteCajaBE
    {
        public int IdTienda { get; set; }
        public string DesTienda { get; set; }
        public string Clase { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        //public Decimal PrecioCosto { get; set; }
        public string Tipo { get; set; }
        public string FechaInicioReporte { get; set; }
        public string FechaFinReporte { get; set; }
    }
}
