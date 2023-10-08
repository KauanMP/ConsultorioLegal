using System.ComponentModel.DataAnnotations;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;
using Microsoft.AspNetCore.Mvc;
using CL.Manager.Interfaces;
using CL.Manager.Implementation;
using CL.Manager.Validator;

namespace CL.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager clienteManager;

        public ClientesController(IClienteManager clienteManager)
        {
            this.clienteManager = clienteManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await clienteManager.GetClientesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await clienteManager.GetClienteAsync(id));
        }

        [HttpPost]

        public async Task<IActionResult> Post(Cliente cliente)
        {
            var clienteInserido = await clienteManager.InsertClienteAsync(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Cliente cliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(cliente);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(clienteAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await clienteManager.DeleteClienteAsync(id);

            return NoContent();
        }
    }
}