using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Services.EnsalamentoService;
using Microsoft.AspNetCore.Mvc;

namespace microservgraduacao.Graduacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HorarioController(IHorarioService _service) : ControllerBase
    {
        private readonly IHorarioService service = _service;

        [HttpGet]
        public async Task<ActionResult<List<HorarioDTO>>> Get()
        {
            var lista = await service.GetHorarioAsync();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<HorarioDTO>> Post([FromBody] HorarioInputDTO horario)
        {
            if (horario == null)
                return BadRequest("Horario não pode ser nulo");

            var horarioSalva = await service.SaveAsync(horario);
            return CreatedAtAction(nameof(Get), new { id = horarioSalva.Id }, horarioSalva);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HorarioDTO>> Update(Guid id, [FromBody] HorarioInputDTO horario)
        {
            if (horario == null)
                return BadRequest("Dados do horario não podem ser nulos");

            var horarioAtualizada = await service.UpdateAsync(id, horario);
            return Ok(horarioAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucesso = await service.DeleteAsync(id);
            if (!sucesso)
                return NotFound("Horario não encontrado");

            return NoContent();
        }
       
    }
}