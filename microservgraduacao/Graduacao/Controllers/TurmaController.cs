using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Services.TurmasService;
using Microsoft.AspNetCore.Mvc;

namespace microservgraduacao.Graduacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TurmaController(ITurmaService _service) : ControllerBase
    {
        private readonly ITurmaService service = _service;

        [HttpGet]
        public async Task<ActionResult<List<TurmaDTO>>> Get()
        {
            var lista = await service.GetTurmasAsync();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<TurmaDTO>> Post([FromBody] TurmaInputDTO turma)
        {
            if (turma == null)
                return BadRequest("Turma não pode ser nula");

            var turmaSalva = await service.SaveAsync(turma);
            return CreatedAtAction(nameof(Get), new { id = turmaSalva.Id }, turmaSalva);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TurmaDTO>> Update(Guid id, [FromBody] TurmaInputDTO turma)
        {
            if (turma == null)
                return BadRequest("Dados da turma não podem ser nulos");

            var turmaAtualizada = await service.UpdateAsync(id, turma);
            return Ok(turmaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucesso = await service.DeleteAsync(id);
            if (!sucesso)
                return NotFound("Turma não encontrada");

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> Activate(Guid id)
        {
            var sucesso = await service.ActivateAsync(id);
            if (!sucesso)
                return NotFound("Turma não encontrada ou já está ativa");

            return Ok("Turma ativada com sucesso");
        }

        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(Guid id)
        {
            var sucesso = await service.DisableAsync(id);
            if (!sucesso)
                return NotFound("Turma não encontrada ou já está desativada");

            return Ok("Turma desativada com sucesso");
        }
    }
}