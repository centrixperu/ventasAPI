using Entidades.DTOIntercambio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOModelos
{
    public class EDEConfigParameter : EDERespuestaComun
    {
        public decimal CalculoDetraccion { get; set; }
        public decimal CalculoIgv { get; set; }
        public decimal CalculoIsc { get; set; }
    }
}
