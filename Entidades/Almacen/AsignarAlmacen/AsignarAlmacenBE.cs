using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Almacen.AsignarAlmacen
{
    public class AsignarAlmacenBE
    {
        public int Id { get; set; }
        public int IdAlmacen { get; set; }
        public string Nombre { get; set; }
        public int IdCliente { get; set; }
        public string DesCliente { get; set; }
        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string UsrModificador { get; set; }
        public string FchModificacion { get; set; }
        public List<AsignarAlmacen_ProductoBE> loProducto { get; set; }
        //ASIGNAR A TIENDA
        public string NroGuia { get; set; }
        public string FechaGuia { get; set; }
        public int IdTienda { get; set; }
        public bool isTipoProducto { get; set; }
        public bool isCostoProduccion { get; set; }
        public bool isFechaVenProd { get; set; }
        //ASIGNAR A ALMACEN
        public string BoletaCompra { get; set; }
        public string RazonCompra { get; set; }
        public string RucCompra { get; set; }
        public string DireccionCompra { get; set; }
    }
}
