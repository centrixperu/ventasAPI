using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEDocumento
    {
        public string IdDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumentoEmisor { get; set; }
        public string NombreLegalEmisor { get; set; }
    }
}
