using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOIntercambio
{
    public class EDERespuestaComun
    {
        public bool Exito { get; set; }
        public bool Procesado { get; set; }
        public string MensajeError { get; set; }
        public string Pila { get; set; }
    }
}
