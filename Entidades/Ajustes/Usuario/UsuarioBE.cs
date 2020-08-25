using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class UsuarioBE
    {
        public int Id { get; set; }
        public string UsuarioSesion { get; set; }
        public int IdCliente { get; set; }
        public string DesCliente { get; set; }
        public int IdPerfil { get; set; }
        public string DesPerfil { get; set; }
        public string Nombre { get; set; }
        public string ApePat { get; set; }
        public string ApeMat { get; set; }
        public string DNI { get; set; }
        public string Sexo { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }
        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string UsrModificador { get; set; }
        public string FchModificacion { get; set; }
        public List<ListaComboBE> loTienda { get; set; }
        public string URLFoto { get; set; }
        public List<ListaArchivosAdjuntos> lologo { get; set; }
    }
}
