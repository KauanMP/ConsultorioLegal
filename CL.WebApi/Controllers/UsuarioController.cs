using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;
using CL.Manager.Interfaces;
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
        [Route("ValidaUsuario")]
        public async Task<IActionResult> ValidaUsuario(Usuario usuario)
        {
            var valido = await manager.ValidaSenhaAsync(usuario);

            if(valido)
            {
                return Ok();
            }

            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> InsertUsuario(Usuario usuario)
        {
            var insertUsuario = await manager.InsertUserAsync(usuario);
            return CreatedAtAction(nameof(ValidaUsuario), new {login = usuario.Login}, insertUsuario);
        }
    }
}