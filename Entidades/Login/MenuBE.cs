using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Login
{
    public class MenuBE
    {
        public int id { get; set; }
        public int idParent { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public bool active { get; set; }
        public List<MenuDetalleBE> detalle { get; set; }
    }
}
