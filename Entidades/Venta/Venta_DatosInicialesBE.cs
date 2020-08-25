using Entidades.Ajustes;
using Entidades.Almacen.AsignarAlmacen;
using Entidades.ReporteCliente;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Venta
{
    public class Venta_DatosInicialesBE
    {
        public List<ListaComboBE> loComprobante { get; set; }
        public List<ListaComboBE> loTienda { get; set; }
        public List<AsignarAlmacen_ProductoBE> loProducto { get; set; }
        public List<AsignarAlmacen_ProductoBE> loTipoProducto { get; set; }
        public List<EmisorBE> loEmisor { get; set; }

        public List<ListaComboTextBE> loTipoDocIdentidad { get; set; }
        
    }
}
