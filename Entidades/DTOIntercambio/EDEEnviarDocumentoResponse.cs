using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOIntercambio
{
    public class EDEEnviarDocumentoResponse : EDERespuestaComunConArchivo
    {
        public string CodigoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public string TramaZipCdr { get; set; }
    }
}
