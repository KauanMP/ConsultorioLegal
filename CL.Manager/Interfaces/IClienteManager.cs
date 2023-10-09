using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;
using CL.CoreShared.ModelViews;

namespace CL.Manager.Interfaces
{
    public interface IClienteManager
    {

        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteAsync(int id);
        Task<Cliente> InsertClienteAsync(NovoCliente novoCliente);
        Task<Cliente> UpdateClienteAsync(AlteraCliente alteraCliente);
        Task DeleteClienteAsync(int id);
    }
}