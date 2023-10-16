using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;
using CL.Manager.Interfaces;
using CL.WebApi.Context;
using Microsoft.EntityFrameworkCore;

namespace CL.WebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CLContext clContext;

        public UsuarioRepository(CLContext clContext)
        {
            this.clContext = clContext;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsersAsync()
        {
            return await clContext.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> GetUserByIdAsync(string login)
        {
            return await clContext.Usuarios.AsNoTracking().SingleOrDefaultAsync(p => p.Login == login);
        }

        public async Task<Usuario> InsertUserAsync(Usuario usuario)
        {
            await clContext.Usuarios.AddAsync(usuario);
            await clContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateUserAsync(Usuario usuario)
        {
            var findUser = await clContext.Usuarios.FindAsync(usuario.Login);

            if (findUser == null)
            {
                return null;
            }
            clContext.Entry(findUser).CurrentValues.SetValues(usuario);
            await clContext.SaveChangesAsync();
            return findUser;
        }

        public Task<bool> ValidaSenhaAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}