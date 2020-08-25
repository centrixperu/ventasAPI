using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Almacen.AsignarAlmacen
{
    public class AsignarAlmacen_DatosInicialesBE
    {
        public List<AsignarAlmacenBE> loListado { get; set; }
        public List<ListaComboBE> loAlmacen { get; set; }
        public List<AsignarAlmacen_ProductoBE> loProducto { get; set; }
    }
}
