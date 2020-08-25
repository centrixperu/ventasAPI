using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ControlStock
{
    public class ControlStockBE
    {
        public Int64 IdProductoAlmacen { get; set; }
        public int IdAlmacen { get; set; }
        public int IdTienda { get; set; }
        public int IdProducto { get; set; }
        public string CodProducto { get; set; }
        public string NombreProducto { get; set; }
        public int idProductoBase { get; set; }
        public int Stock { get; set; }
        public int StockTotal { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioBlister { get; set; }
        public int IdTipo { get; set; }
        public string DesTipo { get; set; }
        public string CodProdLaboratorio { get; set; }
        public string DesProdLaboratorio { get; set; }
        public string CodProdTipoPresentacion { get; set; }
        public string DesProdTipoPresentacion { get; set; }
        public string RegistroSanitario { get; set; }
        public int Cantidad { get; set; }
        public int CantidadCaja { get; set; }
        public decimal PrecioCosto { get; set; }
        public string FecVencimiento { get; set; }
        public string DetalleStock { get; set; }
        public int StockN { get; set; }
        public string RecetaMedica { get; set; }
        public bool Val1 { get; set; }
        public bool Val2 { get; set; }
        public bool Val3 { get; set; }
        public decimal PrecioN { get; set; }
        public decimal PrecioBlisterN { get; set; }
    }
}
