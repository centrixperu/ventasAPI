using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class AlmacenXTiendaBE
    {
        public int Id { get; set; }
        public int IdAlmacen { get; set; }
        public string NomAlmacen { get; set; }
        public int IdTienda { get; set; }
        public string DesTienda { get; set; }
        public int IdCliente { get; set; }
        public string DesCliente { get; set; }
        public bool Estado { get; set; }
        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string UsrModificador { get; set; }
        public string FchModificacion { get; set; }
    }
}
