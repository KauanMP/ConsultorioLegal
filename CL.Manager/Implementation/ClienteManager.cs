using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Manager.Interfaces;

namespace CL.Manager.Implementation
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteManager(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }
    }
}