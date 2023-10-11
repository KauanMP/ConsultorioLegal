using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.CoreShared.ModelViews
{
    public class NovoEndereco
    {
        public int CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}