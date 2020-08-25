using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOIntercambio
{
    public class EDEPaqueteResponse : EDERespuestaComun
    {
        public string Client { get; set; }
        public string OperativeUnity { get; set; }
        public string FolderName { get; set; }
        public string FileName { get; set; }
        public string Package { get; set; }
    }
}
