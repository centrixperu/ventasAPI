using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class Emisor_DatosInicialesBE
    {
        public List<EmisorBE> loListado { get; set; }
        public List<ListaComboDetallado> loTienda { get; set; }
        public List<ListaComboTextBE> loDepartamento { get; set; }
        public List<ListaComboTextBE> loProvincia { get; set; }
        public List<ListaComboTextBE> loDistrito { get; set; }
        public List<ListaComboBE> loCliente { get; set; }
    }
}
