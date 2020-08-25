using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utils
{
    public class ListaCorrelativoVentaBE
    {
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public string TipoDocumentoNC { get; set; }
        public string TipoDocumentoNombreNC { get; set; }
        public string SerieNV { get; set; }
        public string CorrelativoNV { get; set; }

        public string ClaveDigital { get; set; }
        public string URLCertificado { get; set; }
        public string RUC { get; set; }
        public string UsuarioSOL { get; set; }
        public string ClaveSOL { get; set; }
        public bool isFact { get; set; }

        public string impresion { get; set; }
    }
}
