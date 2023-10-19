using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CL.Core.Domains;
using CL.CoreShared.ModelViews.Usuario;
using CL.Manager.Interfaces;
using CL.Manager.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace CL.Manager.Implementation
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUsuarioRepository repository;
        private readonly IMapper mapper;
        private readonly IJWTService jWTService;

        public UsuarioManager(IUsuarioRepository repository, IMapper mapper, IJWTService jWTService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.jWTService = jWTService;
        }
        public async Task<IEnumerable<UsuarioView>> GetAllUsersAsync()
        {
            return mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioView>>(await repository.GetAllUsersAsync());
        }

        public async Task<UsuarioView> GetUserByIdAsync(string login)
        {
            return mapper.Map<UsuarioView>(await repository.GetUserByIdAsync(login));
        }

        public async Task<UsuarioView> InsertUserAsync(NewUsuario newUsuario)
        {
            var usuario = mapper.Map<Usuario>(newUsuario);
            ConverteSenhaEmHash(usuario);
            return mapper.Map<UsuarioView>(await repository.InsertUserAsync(usuario));
        }

        private static void ConverteSenhaEmHash(Usuario usuario)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHasher.HashPassword(usuario, usuario.Senha);
        }

        public async Task<UsuarioView> UpdateUserAsync(Usuario usuario)
        {
            ConverteSenhaEmHash(usuario);
            return mapper.Map<UsuarioView>(await repository.UpdateUserAsync(usuario));
        }

        public async Task<UsuarioLogado> ValidaUsuarioEGeraTokenAsync(Usuario usuario)
        {
            var findUser = await repository.GetUserByIdAsync(usuario.Login);
            if (findUser == null)
            {
                return null;
            }

            if (await ValidaEAtualizaHashAsync(usuario, findUser))
            {
                var usuarioLogado = mapper.Map<UsuarioLogado>(findUser);
                usuarioLogado.Token = jWTService.GerarToken(findUser);

                return usuarioLogado;
            };
            return null;
        }

        private async Task<bool> ValidaEAtualizaHashAsync(Usuario usuario, Usuario findUser)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            var status = passwordHasher.VerifyHashedPassword(usuario, findUser.Senha, usuario.Senha);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdateUserAsync(usuario);
                    return true;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}