using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;
using CL.CoreShared.ModelViews.Usuario;
using CL.Manager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CL.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioManager manager;

        public UsuarioController(IUsuarioManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var usuarioLogado = await manager.ValidaUsuarioEGeraTokenAsync(usuario);

            if(usuarioLogado != null)
            {
                return Ok(usuarioLogado);
            }

            return Unauthorized();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var login = User.Identity.Name;
            var usuario = await manager.GetUserByIdAsync(login);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewUsuario newUsuario)
        {
            var insertUsuario = await manager.InsertUserAsync(newUsuario);
            return CreatedAtAction(nameof(Login), new {login = newUsuario.Login}, insertUsuario);
        }
    }
}