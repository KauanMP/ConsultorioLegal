using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;
using CL.CoreShared.ModelViews.Usuario;
using CL.Manager.Interfaces;

namespace CL.Manager.Implementation
{
    public class UsuarioManager : IUsuarioManager
    {
        public Task<IEnumerable<UsuarioView>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioView> GetUserByIdAsync(string login)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioView> InsertUserAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioView> UpdateUserAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidaSenhaAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}