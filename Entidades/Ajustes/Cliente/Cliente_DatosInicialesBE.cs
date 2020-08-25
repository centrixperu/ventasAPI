using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class Cliente_DatosInicialesBE
    {
        public List<ClienteBE> loListado { get; set; }
        public List<ListaComboTextBE> loTipoDocIdentidad { get; set; }
    }
}
