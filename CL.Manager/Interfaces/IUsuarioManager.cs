using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;
using CL.CoreShared.ModelViews.Usuario;

namespace CL.Manager.Interfaces
{
    public interface IUsuarioManager
    {
        Task<IEnumerable<UsuarioView>> GetAllUsersAsync();
        Task<UsuarioView> GetUserByIdAsync(string login);
        Task<UsuarioView> InsertUserAsync(NewUsuario newUsuario);
        Task<UsuarioView> UpdateUserAsync(Usuario usuario);
        Task<UsuarioLogado> ValidaUsuarioEGeraTokenAsync(Usuario usuario);
    }
}