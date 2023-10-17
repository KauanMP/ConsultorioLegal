using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.Core.Domains
{
    public class Funcao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}