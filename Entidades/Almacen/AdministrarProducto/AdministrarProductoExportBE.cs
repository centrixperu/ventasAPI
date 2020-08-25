using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Almacen.AdministrarProducto
{
    public class AdministrarProductoExportBE
    {
        public string CodProducto { get; set; }
        public string CodUNSPSC { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        //public string IdUnidad { get; set; }
        public string DesUnidad { get; set; }
        //public int IdTalla { get; set; }
        public string DesTalla { get; set; }
        //public int IdColor { get; set; }
        public string DesColor { get; set; }
        //public int IdTipo { get; set; }
        public string DesTipo { get; set; }
        //----
        public string DesProdLaboratorio { get; set; }
        public string DesProdGrupo { get; set; }
        public string DesProdTipoPresentacion { get; set; }
        public string DesNombreGenerico { get; set; }
        public string isGenerico { get; set; }
        public string RegSanitario { get; set; }
        public string DesTipoProducto { get; set; }
        public string DesComposicion { get; set; }
        public string DesIndicaciones { get; set; }
        public string DesContraIndicaciones { get; set; }
        public string RecetaMedica { get; set; }
        //----
        public string Estatus { get; set; }
        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string UsrModificador { get; set; }
        public string FchModificacion { get; set; }
        
    }
}
