using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utils
{
    public class ListaComboDetallado
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        //EMISOR ELECTRONICO
        public string direccion { get; set; }
        public string urbanizacion { get; set; }
        public string NombreComercial { get; set; }
        public string NombreLegal { get; set; }
    }
}
