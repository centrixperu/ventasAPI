using Entidades.Almacen.AsignarAlmacen;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Traspaso
{
    public class Traspaso_DatosInicialesBE
    {
        public List<ListaComboDetallado> loTienda { get; set; }
        public List<AsignarAlmacen_ProductoBE> loProducto { get; set; }
        public int IdTiendaOrigen { get; set; }
        public string DesTiendaOrigen { get; set; }
        public int IdTiendaDestino { get; set; }
        public string DesTiendaDestino { get; set; }
        public string GuiaEntrada { get; set; }
        public string GuiaSalida { get; set; }
        public string FechaGuia { get; set; }
        public string UsrCreador { get; set; }
        public int IdCliente { get; set; }
    }
}
