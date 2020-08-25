using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DashBoard
{
    public class DashBoard_DatosInicialesBE
    {
        public List<DashBoardBE> loGraficoDia { get; set; }
        public List<DashBoardBE> loGraficoSemana { get; set; }
        public List<DashBoardBE> loGraficoMes { get; set; }
    }
}
