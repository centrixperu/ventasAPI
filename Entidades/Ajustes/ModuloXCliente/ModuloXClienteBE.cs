﻿using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ajustes
{
    public class ModuloXClienteBE
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string DesCliente { get; set; }
        public string RUC { get; set; }
        public bool Estado { get; set; }
        public string UsrCreador { get; set; }
        public string FchCreacion { get; set; }
        public string UsrModificador { get; set; }
        public string FchModificacion { get; set; }
        public List<ListaComboBE> loModulos { get; set; }
    }
}