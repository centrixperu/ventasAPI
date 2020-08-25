using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOIntercambio
{
    public class EDEFirmadoResponse : EDERespuestaComun
    {
        public string ResumenFirma { get; set; }
        public string TramaXmlFirmado { get; set; }
        public string ValorFirma { get; set; }
    }
}
