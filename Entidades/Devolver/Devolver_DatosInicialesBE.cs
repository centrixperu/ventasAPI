using Entidades.Almacen.AsignarAlmacen;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Devolver
{
    public class Devolver_DatosInicialesBE
    {
        public List<ListaComboBE> loTienda { get; set; }
        public List<ListaComboBE> loAlmacen { get; set; }
        public List<AsignarAlmacen_ProductoBE> loProducto { get; set; }
        public int IdTiendaOrigen { get; set; }
        public string DesTiendaOrigen { get; set; }
        public int IdAlmacen { get; set; }
        public string DesAlmacen { get; set; }
        //public string GuiaEntrada { get; set; }
        public string GuiaSalida { get; set; }
        public string FechaGuia { get; set; }
        public string UsrCreador { get; set; }
        public int IdCliente { get; set; }
    }
}
