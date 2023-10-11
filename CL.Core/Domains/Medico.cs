using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.Core.Domains
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CRM { get; set; }
        public ICollection<Especialidade> Especialidades { get; set; }
    }
}