using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;

namespace CL.Manager.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsersAsync();
        Task<Usuario> GetUserByIdAsync(string login);
        Task<Usuario> InsertUserAsync(Usuario usuario);
        Task<Usuario> UpdateUserAsync(Usuario usuario);
        Task<bool> ValidaSenhaAsync(Usuario usuario);
    }
}