using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class Comprobante_DatosInicialesBE
    {
        public List<ComprobanteBE> loListado { get; set; }
        public List<ListaComboBE> loCliente { get; set; }
        public List<ListaComboTextBE> loTipoDocIden { get; set; }
    }
}
