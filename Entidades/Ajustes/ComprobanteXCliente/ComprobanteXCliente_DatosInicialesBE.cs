
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class ComprobanteXCliente_DatosInicialesBE
    {
        public List<ComprobanteXClienteBE> loListado { get; set; }
        public List<ListaComboBE> loCliente { get; set; }
        public List<ListaComboTextBE> loTipoDocVenta { get; set; }
    }
}
