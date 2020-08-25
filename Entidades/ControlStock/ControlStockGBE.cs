using Entidades.ControlStockReporte;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ControlStock
{
    public class ControlStockGBE
    {
        public List<ControlStockBE> listado { get; set; }
        public List<ControlStockBEReporte> listadoReporte { get; set; }
        public List<ReporteColumnas> columnas { get; set; }
        public int idCliente { get; set; }
        public string usuario { get; set; }
    }
}
