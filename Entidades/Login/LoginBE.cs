using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Login
{
    public class LoginBE
    {
        public int usuarioId { get; set; }
        public string usuarioLogin { get; set; }
        public string passwordLogin { get; set; }
        public string usuarioNombre { get; set; }
        public string usuarioApePat { get; set; }
        public string usuarioApeMat { get; set; }
        public string usuarioDNI { get; set; }
        public string email { get; set; }
        public int idCliente { get; set; }
        public string cliente { get; set; }
        public bool isAdministrador { get; set; }
        public int idPerfil { get; set; }
        public string perfil { get; set; }
        public string imagen { get; set; }
        public string background { get; set; }
        public List<MenuBE> loMenu { get; set; }
        public List<DetalleInfoBE> loFooter { get; set; }
        public List<DetalleInfoBE> loNotification { get; set; }
        public List<ListaComboBE> loTienda { get; set; }
        //DATOS CLIENTE
        public string tittleHeader { get; set; }
        public string imageHeader { get; set; }
        public string tittleFooter { get; set; }
        public string footer { get; set; }
        public bool isTipoProducto { get; set; }
        public bool isCostoProduccion { get; set; }
        public bool isFechaVenProd { get; set; }
        public bool isLaboratorio { get; set; }
        public bool isNombreGenerico { get; set; }
        public bool isGrupoMedico { get; set; }
        public bool isTipoMedico { get; set; }
        public bool isTipoPresentacion { get; set; }
        public bool isComposicion { get; set; }
        public bool isContraIndicaciones { get; set; }
        public bool isUbicacion { get; set; }
        public bool isLote { get; set; }
    }
}
