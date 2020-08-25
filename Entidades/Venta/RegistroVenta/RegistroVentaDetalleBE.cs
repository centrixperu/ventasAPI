using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Venta.RegistroVenta
{
    public class RegistroVentaDetalleBE
    {
        public int IdProducto { get; set; }
        public string DesProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PUnitario { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IGV { get; set; }
        public string NotaVenta { get; set; }
        public string Documento { get; set; }
        public string NroDocumento { get; set; }
    }
}
