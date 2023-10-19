using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.CoreShared.ModelViews.Usuario
{
    public class UsuarioLogado
    {
        public string Login { get; set; }
        public ICollection<FuncaoView> Funcoes { get; set; }
        public string Token { get; set; }
    }
}