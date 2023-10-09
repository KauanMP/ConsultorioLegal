using CL.Core.Domains;
using CL.CoreShared.ModelViews;
using CL.Manager.Interfaces;
using CL.WebApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace CL.WebApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CLContext context;
        public ClienteRepository(CLContext context)
        {
            this.context = context;
        }

        // GetAll
        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await context.Clientes.AsNoTracking().ToListAsync();
        }

        // GetById
        public async Task<Cliente> GetClienteAsync(int id)
        {
            // return await context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
            // return await context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            // return await context.Clientes.SingleOrDefaultAsync(c => c.Id == id);

            return await context.Clientes.FindAsync(id);
        }

        // Insert
        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();

            return cliente;
        }

        // Update
        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteConsultado = await context.Clientes.FindAsync(cliente.Id);
            if (cliente == null)
            {
                return null;
            }

            // clienteConsultado.Nome = cliente.Nome;
            // clienteConsultado.DataNascimento = cliente.DataNascimento;

            context.Entry(clienteConsultado).CurrentValues.SetValues(cliente);
            // context.Clientes.Update(clienteConsultado);

            await context.SaveChangesAsync();
            return clienteConsultado;
        }

        // Delete
        public async Task DeleteClienteAsync(int id)
        {
            var clienteConsultado = await context.Clientes.FindAsync(id);

            context.Clientes.Remove(clienteConsultado);
            await context.SaveChangesAsync();
        }
    }
}