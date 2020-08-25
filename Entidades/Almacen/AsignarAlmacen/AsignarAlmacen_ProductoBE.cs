using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Almacen.AsignarAlmacen
{
    public class AsignarAlmacen_ProductoBE
    {
        public int Id { get; set; }
        public string CodProducto { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int CantidadCaja { get; set; }
        public decimal PrecioCosto { get; set; }
        public string DireccionCosto { get; set; }
        public bool Selec { get; set; }
        //DATOS DE ALMACEN
        public int IdAlmacen { get; set; }
        public int IdTienda { get; set; }
        public int CantidadTienda { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioBlister { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal OldPrecio { get; set; }
        public decimal OldPrecioBlister { get; set; }
        public int Stock { get; set; }
        //DATOS TIPO PRODUCTO
        public List<ListaComboBE> loTipoProducto { get; set; }
        public int idTipo { get; set; }
        public string desTipo { get; set; }
        public int idProductoBase { get; set; }
        public string idUnidad { get; set; }
        public string desUnidad { get; set; }
        public string codUNSPSC { get; set; }
        public string FecVencimiento { get; set; }
        public bool isXVencer { get; set; }
        public bool isAddStock { get; set; }
        public string Color { get; set; }
        public string Talla { get; set; }
        //public bool isFechaVencimiento { get; set; }
        public int IdProductoAlmacen { get; set; }
        //
        public bool isTipoBase { get; set; }
        public bool isTipoProducto { get; set; }
        public bool isCostoProduccion { get; set; }
        public bool isFechaVenProd { get; set; }
        public bool isUbicacion { get; set; }
        public bool isLote { get; set; }

        public string Ubicacion { get; set; }
        public string Lote { get; set; }
        public string RegistroSanitario { get; set; }
        //RUBRO BOTICA
        public string Descripcion { get; set; }
        public string CodProdLaboratorio { get; set; }
        public string DesProdLaboratorio { get; set; }
        public string DesProdGrupo { get; set; }
        public string CodProdTipoPresentacion { get; set; }
        public string DesProdTipoPresentacion { get; set; }
        public string DesNombreGenerico { get; set; }
        public string DesTipoProducto { get; set; }
        public string DesComposicion { get; set; }
        public string DesIndicaciones { get; set; }
        public string DesContraIndicaciones { get; set; }
        public string RecetaMedica { get; set; }
        public string isGenerico { get; set; }
        public int StockTotal { get; set; }
        public bool Val1 { get; set; }
        public bool Val2 { get; set; }
        public bool Val3 { get; set; }
    }
}
