using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ReporteClienteTienda.GuiasTienda
{
    public class ReporteGuiaTiendaBE
    {
        public int IdTienda { get; set; }
        public string DesTienda { get; set; }
        public string NroGuiaSalida { get; set; }
        public string NroGuiaEntrada { get; set; }
        public string FchGuia { get; set; }
        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string FechaInicioReporte { get; set; }
        public string FechaFinReporte { get; set; }
    }
}
