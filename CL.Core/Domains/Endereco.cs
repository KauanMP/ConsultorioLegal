using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CL.Core.Domains
{
    public class Endereco
    {
        [Key, ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public int CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public Cliente Cliente { get; set; }
    }
}
