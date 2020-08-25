using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteClienteTienda.GuiasTienda
{
    public class ReporteGuiaTienda_DetalleBE
    {
        public int IdProducto { get; set; }
        public string DesProducto { get; set; }
        public int Cantidad { get; set; }
        public int CantidadCaja { get; set; }
        public string NroGuia { get; set; }
        public string TipoMovimiento { get; set; }
    }
}
