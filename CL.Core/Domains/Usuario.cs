using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CL.Core.Domains
{
    public class Usuario
    {
        [Key]
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}