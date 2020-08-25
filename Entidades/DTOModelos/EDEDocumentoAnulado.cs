using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEDocumentoAnulado : EDEDocumento
    {
        public decimal TotalVenta { get; set; }
        public string NroNotaCredito { get; set; }
    }
}
