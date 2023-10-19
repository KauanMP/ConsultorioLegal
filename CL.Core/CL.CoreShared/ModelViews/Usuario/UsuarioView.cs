using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;

namespace CL.CoreShared.ModelViews.Usuario
{
    public class UsuarioView
    {
        public string Login { get; set; }
        public ICollection<FuncaoView> Funcoes { get; set; }
    }
}