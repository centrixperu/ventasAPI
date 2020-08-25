using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOIntercambio
{
    public class EDECommonRequest
    {
        public int IdCliente { get; set; }
        public int IdTienda { get; set; }
        public string NombreMetodoProcesoAPI { get; set; }
        public string NombreMetodoEnvioAPI { get; set; }
        public string Proceso { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreCarpetaSinFirmar { get; set; }
        public string NombreCarpetaFirmado { get; set; }
        public string NombreCarpeaCDR { get; set; }
        public string IdDocumento { get; set; }
        public string RUC { get; set; }
        public string UsuarioSOL { get; set; }
        public string ClaveSOL { get; set; }
        public string ClaveDigital { get; set; }
        public string URLCertificado { get; set; }
    }
}
