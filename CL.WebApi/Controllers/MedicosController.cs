using CL.CoreShared.ModelViews;
using CL.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CL.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoManager manager;

        public MedicosController(IMedicoManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await manager.GetAllMedicosAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await manager.GetMedicoByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(NovoMedico novoMedico)
        {

            var medicoInserido = await manager.InsertMedicoAsync(novoMedico);
            return CreatedAtAction(nameof(Get), new { id = medicoInserido.Id}, medicoInserido);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraMedico alteraMedico)
        {
            var medicoAtualizado = await manager.UpdateMedicoAsync(alteraMedico);

            if (medicoAtualizado == null)
            {
                return NotFound();
            }

            return Ok(medicoAtualizado);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await manager.DeleteMedicoAsync(id);
            return NoContent();
        }
    }
}