using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes.Tienda
{
    public class TiendaExportBE
    {
        //public int IdCliente { get; set; }
        //public string DesCliente { get; set; }
        public int Id { get; set; }
        public string Tienda { get; set; }
        public string Direccion { get; set; }
        public string Urbanizacion { get; set; }
        public string Estado { get; set; }
        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string UsrModificador { get; set; }
        public string FchModificacion { get; set; }
    }
}
