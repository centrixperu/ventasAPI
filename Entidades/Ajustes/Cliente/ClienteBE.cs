using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class ClienteBE
    {
        public int Id { get; set; }
        public string DesCliente { get; set; }
        public string TipoDoc { get; set; }
        public string RUC { get; set; }
        public string DNI { get; set; }
        public string NombreLegal { get; set; }
        public string NombreComercial { get; set; }
        public bool Estado { get; set; }
        public bool isFactOnline { get; set; }
        public bool isFactProg { get; set; }
        public string isFactProgHour { get; set; }
        public bool isTipoProducto { get; set; }
        public bool isCostoProduccion { get; set; }
        public bool isFechaVenProd { get; set; }
        public int isPrecioConIGV { get; set; }
        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string UsrModificador { get; set; }
        public string FchModificacion { get; set; }
        //ARCHIVOS ADJUNTO
        public string URLCertificado { get; set; }
        public string URLLogo { get; set; }
        public string UsuarioSOL { get; set; }
        public string ClaveSOL { get; set; }
        public string ClaveDigital { get; set; }
        public List<ListaArchivosAdjuntos> loarchivos { get; set; }
        public List<ListaArchivosAdjuntos> lologo { get; set; }
        // RUBRO MEDICO
        public bool isLaboratorio { get; set; }
        public bool isNombreGenerico { get; set; }
        public bool isGrupoMedico { get; set; }
        public bool isTipoMedico { get; set; }
        public bool isTipoPresentacion { get; set; }
        public bool isComposicion { get; set; }
        public bool isContraIndicaciones { get; set; }
        public bool isUbicacion { get; set; }
        public bool isLote { get; set; }
        public bool isRecetaMedica { get; set; }
    }
}
