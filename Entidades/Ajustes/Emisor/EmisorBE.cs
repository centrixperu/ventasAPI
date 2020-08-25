using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class EmisorBE
    {
        public int Id { get; set; }
        public int IdTienda { get; set; }
        public string desTienda { get; set; }
        public int IdCliente { get; set; }
        public string desCliente { get; set; }
        public string codSurcursal { get; set; }
        public string serieBoleta { get; set; }
        public string serieFactura { get; set; }
        public string nomComercial { get; set; }
        public string nomLegal { get; set; }
        public string ruc { get; set; }
        public string tipodoc { get; set; }
        public string direccion { get; set; }
        public string urbanizacion { get; set; }
        public string IdDepartamento { get; set; }
        public string desDepartamento { get; set; }
        public string IdProvincia { get; set; }
        public string desProvincia { get; set; }
        public string IdDistrito { get; set; }
        public string desDistrito { get; set; }
        public string ubigeo { get; set; }
        public string usuarioSOL { get; set; }
        public string claveSOL { get; set; }
        public decimal detraccion { get; set; }
        public decimal igv { get; set; }
        public decimal isc { get; set; }
        public bool activo { get; set; }
        public string impresion { get; set; }

        public string IdTipoOperacion { get; set; }
        public string desTipoOperacion { get; set; }

        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string UsrModificador { get; set; }
        public string FchModificacion { get; set; }
    }
}

