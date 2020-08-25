using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.DashBoard;

namespace Entidades.ReporteCaja
{
    public class CajaBE
    {
        public List<ReporteCajaBE> listado { get; set; }
        public List<ReporteColumnas> loColumns { get; set; }
        public List<DashBoardBE> loGraficoIngreso { get; set; }
        public List<DashBoardBE> loGraficoEgreso { get; set; }
        public string Usuario { get; set; }
        public int IdCliente { get; set; }
        public int IdTienda { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int CodProducto { get; set; }
        public string Tipo { get; set; }
        public List<ListaComboBE> loTienda { get; set; }
        //TOTAL CAJA DIA ANTERIOR
        public Decimal CajaAnterior { get; set; }
    }
}
