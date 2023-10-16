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
        private readonly IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("ValidaUsuario")]
        public async Task<IActionResult> ValidaUsuario(Usuario usuario)
        {
            var valido = await repository.ValidaSenhaAsync(usuario);

            if(valido)
            {
                return Ok();
            }

            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> InsertUsuario(Usuario usuario)
        {
            var insertUsuario = await repository.InsertUserAsync(usuario);
            return CreatedAtAction(nameof(ValidaUsuario), new {login = usuario.Login}, insertUsuario);
        }
    }
}