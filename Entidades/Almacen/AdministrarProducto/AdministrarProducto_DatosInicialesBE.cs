using Entidades.Almacen.AdministrarProducto;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.AdministrarProducto
{
    public class AdministrarProducto_DatosInicialesBE
    {
        #region UNSPSC
        public List<ListaComboTextBE> loSegmentos { get; set; }
        public List<ListaComboTextBE> loFamilia { get; set; }
        public List<ListaComboTextBE> loClase { get; set; }
        public List<ListaComboTextBE> loProducto { get; set; }
        #endregion
        public List<ListaComboBE> loTalla { get; set; }
        public List<ListaComboBE> loColor { get; set; }
        public List<ListaComboBE> loTipoProducto { get; set; }
        public List<ListaComboTextBE> loUnidadMedida { get; set; }
        public List<AdministrarProductoBE> loLista { get; set; }

        public List<ReporteColumnas> loColumns { get; set; }
        public List<AdministrarProductoExportBE> loExport { get; set; }
        //RUBRO MEDICO
        public List<ListaComboBE> loProdTipoPresentacion { get; set; }
        public List<ListaComboBE> loProdGrupo { get; set; }
        public List<ListaComboBE> loProdLaboratorio { get; set; }
    }
}
