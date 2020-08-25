using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.AdministrarProducto
{
    public class AdministrarProductoBE
    {
        public int Id { get; set; }
        public string CodProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int IdTalla { get; set; }
        public string DesTalla { get; set; }
        public int IdColor { get; set; }
        public string DesColor { get; set; }
        public int IdTipo { get; set; }
        public string DesTipo { get; set; }
        //public int idProductoBase { get; set; }
        public string IdUnidad { get; set; }
        public string DesUnidad { get; set; }
        public string IdSegmento { get; set; }
        public string DesSegmento { get; set; }
        public string IdFamilia { get; set; }
        public string DesFamilia { get; set; }
        public string IdClase { get; set; }
        public string DesClase { get; set; }
        public string IdProducto { get; set; }
        public string DesProducto { get; set; }
        public string CodUNSPSC { get; set; }
        public bool Estatus { get; set; }
        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string UsrModificador { get; set; }
        public string FchModificacion { get; set; }
        public int IdProductoBase { get; set; }
        public string NombreProductoBase { get; set; }
        public bool isFechaVencimiento { get; set; }
        //ARCHIVOS ADJUNTO
        public List<ListaArchivosAdjuntos> loarchivos { get; set; }
        //
        public bool isTipoProducto { get; set; }
        public bool isCostoProduccion { get; set; }
        public bool isFechaVenProd { get; set; }
        public int IdCliente { get; set; }
        //RUBRO MEDICO
        public int IdProdLaboratorio { get; set; }
        public string CodProdLaboratorio { get; set; }
        public string DesProdLaboratorio { get; set; }
        public int IdProdGrupo { get; set; }
        public string DesProdGrupo { get; set; }
        public int IdProdTipoPresentacion { get; set; }
        public string CodProdTipoPresentacion { get; set; }
        public string DesProdTipoPresentacion { get; set; }
        public string DesNombreGenerico { get; set; }
        public string DesTipoProducto { get; set; }
        public string DesComposicion { get; set; }
        public string DesIndicaciones { get; set; }
        public string DesContraIndicaciones { get; set; }
        public string RecetaMedica { get; set; }
        public string isGenerico { get; set; }
        public string RegSanitario { get; set; }
    }
}
