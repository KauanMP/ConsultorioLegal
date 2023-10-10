using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.CoreShared.ModelViews
{
    public class NovoCliente
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Documento { get; set; }
        public NovoEndereco Endereco { get; set; }
        public ICollection<NovoTelefone> Telefones { get; set; }
    }
}