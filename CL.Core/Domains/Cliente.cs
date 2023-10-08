using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.Core.Domains
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }
    }
}