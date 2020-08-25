using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Maestro
{
    public class ConsultaDocumentoBE
    {
        public string ruc { get; set; }
        public string nombre_o_razon_social { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string nombres { get; set; }
        public string nombres_completos { get; set; }
        public string direccion_completa { get; set; }

        public string sNroDocumento { get; set; }
    }
}
