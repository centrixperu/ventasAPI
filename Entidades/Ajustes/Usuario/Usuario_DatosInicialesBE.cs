using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class Usuario_DatosInicialesBE
    {
        public List<UsuarioBE> loListado { get; set; }
        public List<ListaComboBE> loPerfil { get; set; }
        public List<ListaComboBE> loCliente { get; set; }
        public List<ListaComboDetallado> loTienda { get; set; }
    }
}
