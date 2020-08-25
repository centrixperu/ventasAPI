using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class Perfil_DatosInicialesBE
    {
        public List<PerfilBE> loListado { get; set; }
        public List<ListaComboBE> loCliente { get; set; }
        public List<ListaComboBE> loModulos { get; set; }
    }
}
