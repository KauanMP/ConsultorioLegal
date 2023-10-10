using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CL.Core.Domains
{
    public class Telefone
    {
        public int ClienteId { get; set; }
        public string Numero { get; set; }
        public Cliente Cliente { get; set; }
    }
}
