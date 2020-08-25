using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utils
{
    public class ListaComboBE
    {
        public int codigo { get; set; }
        public string codcorto { get; set; }
        public string descripcion { get; set; }
        public int isBase { get; set; }
        //------- Modulos (Menu Padre)
        public string menuPadre { get; set; }
        public bool isTipoBase { get; set; }
        public string isTipoDocDefecto { get; set; }
        public string codigoSUNAT { get; set; }
        public int isTipoParent { get; set; }
        public int isTipoPrecio { get; set; }
    }
}
