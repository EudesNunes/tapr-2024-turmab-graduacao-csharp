using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Services.DisciplinasService;
using Microsoft.AspNetCore.Mvc;

namespace microservgraduacao.Graduacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DisciplinaController(IDisciplinaService service) : ControllerBase
    {
        private readonly IDisciplinaService service = service;

        [HttpGet]
        public async Task<ActionResult<List<DisciplinaDTO>>> Get()
        {
            var lista = await service.GetDisciplinasAsync();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<DisciplinaDTO>> Post([FromBody] DisciplinaInputDTO disciplina)
        {
            if (disciplina == null)
                return BadRequest("Disciplina não pode ser nula");

            var disciplinaSalva = await service.SaveAsync(disciplina);
            return CreatedAtAction(nameof(Get), new { id = disciplinaSalva.Id }, disciplinaSalva);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DisciplinaDTO>> Update(Guid id, [FromBody] DisciplinaInputDTO disciplina)
        {
            if (disciplina == null)
                return BadRequest("Dados da disciplina não podem ser nulos");

            var disciplinaAtualizada = await service.UpdateAsync(id, disciplina);
            return Ok(disciplinaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucesso = await service.DeleteAsync(id);
            if (!sucesso)
                return NotFound("Disciplina não encontrada");

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> Activate(Guid id)
        {
            var sucesso = await service.ActivateAsync(id);
            if (!sucesso)
                return NotFound("Disciplina não encontrada ou já está ativa");

            return Ok("Disciplina ativada com sucesso");
        }

        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(Guid id)
        {
            var sucesso = await service.DisableAsync(id);
            if (!sucesso)
                return NotFound("Disciplina não encontrada ou já está desativada");

            return Ok("Disciplina desativada com sucesso");
        }
    }
}
