using CL.Core.Domains;
using CL.Manager.Interfaces;
using CL.WebApi.Context;
using Microsoft.EntityFrameworkCore;

namespace CL.WebApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CLContext context;
        public ClienteRepository(CLContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            // return await context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
            // return await context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            // return await context.Clientes.SingleOrDefaultAsync(c => c.Id == id);
            
            return await context.Clientes.FindAsync(id);
        }
    }
}