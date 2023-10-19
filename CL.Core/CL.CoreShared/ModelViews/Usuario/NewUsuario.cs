using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.CoreShared.ModelViews.Usuario
{
    public class NewUsuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public ICollection<ReferenciaFuncao> Funcoes { get; set; }
    }
}