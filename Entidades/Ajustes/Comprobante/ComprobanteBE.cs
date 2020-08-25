using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class ComprobanteBE
    {
        public int Id { get; set; }
        public string CodigoSUNAT { get; set; }
        public string Descripcion { get; set; }
        public string CodDocDefecto { get; set; }
        public string DesDocDefecto { get; set; }
        public bool Estado { get; set; }
        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string UsrModificador { get; set; }
        public string FchModificacion { get; set; }
        
    }
}
