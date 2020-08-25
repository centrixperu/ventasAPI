using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Venta
{
    public class VentaDetalleBE
    {
        public int n_id_detalle { get; set; }
        public int n_id_cabecera { get; set; }
        public string c_codigo_item { get; set; }
        public string c_decripcion { get; set; }
        public string c_tipo_precio { get; set; }
        public decimal n_precio_referencial { get; set; }
        public decimal n_precio_unitario { get; set; }
        public decimal n_descuento { get; set; }
        public decimal n_cantidad { get; set; }
        public string n_unidad_medida { get; set; }
        public string n_tipo_impuesto { get; set; }
        public decimal n_impuesto { get; set; }
        public decimal n_impuesto_selectivo { get; set; }
        public decimal n_otro_impuesto { get; set; }
        public decimal n_total_venta { get; set; }
        public decimal n_suma { get; set; }
        public string c_tipo_documento { get; set; }
        public string c_id_documento { get; set; }
        public string c_emisor_nombre_legal { get; set; }
        public string c_emisor_numero_documento { get; set; }

        public int c_id_producto { get; set; }
        public int c_id_productoAlmacen { get; set; }
        public int c_id_tienda { get; set; }
    }
}
