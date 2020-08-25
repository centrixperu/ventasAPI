using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utils
{
    public class ListaComboTextBE
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        //COLUMNAS ADICIONALES
        public string descripcionLarga { get; set; }
        public bool isDNI { get; set; }
        public bool isRUC { get; set; }
        public bool isNombre { get; set; }
        public bool isDireccion { get; set; }
    }
}
