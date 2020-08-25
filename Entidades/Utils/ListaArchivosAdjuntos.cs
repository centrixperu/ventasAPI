using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utils
{
    public class ListaArchivosAdjuntos
    {
        public string NombreCarpeta { get; set; }
        public byte[] DatosAdjuntosByte { get; set; }
        public string DatosAdjuntos { get; set; }
        public string DatosAdjuntosName { get; set; }
        public string URL { get; set; }
        public int Id { get; set; }
        //detalle
        public string Descripcion { get; set; }
        public string DesNombreGenerico { get; set; }
        public string DesProdLaboratorio { get; set; }
        public string DesProdGrupo { get; set; }
        public string DesProdTipoPresentacion { get; set; }
        public string DesTipoProducto { get; set; }
        public string DesComposicion { get; set; }
        public string DesIndicaciones { get; set; }
        public string DesContraIndicaciones { get; set; }
    }
}
