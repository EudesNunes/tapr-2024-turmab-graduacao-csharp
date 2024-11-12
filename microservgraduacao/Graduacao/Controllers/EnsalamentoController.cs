using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Services.EnsalamentoService;
using Microsoft.AspNetCore.Mvc;

namespace microservgraduacao.Graduacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnsalamentoController(IEnsalamentoService _service) : ControllerBase
    {
        private readonly IEnsalamentoService service = _service;

        [HttpGet]
        public async Task<ActionResult<List<EnsalamentoDTO>>> Get()
        {
            var lista = await service.GetEnsalamentoAsync();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<EnsalamentoDTO>> Post([FromBody] EnsalamentoInputDTO ensalamento)
        {
            if (ensalamento == null)
                return BadRequest("Ensalamento não pode ser nulo");

            var ensalamentoSalva = await service.SaveAsync(ensalamento);
            return CreatedAtAction(nameof(Get), new { id = ensalamentoSalva.Id }, ensalamentoSalva);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EnsalamentoDTO>> Update(Guid id, [FromBody] EnsalamentoInputDTO ensalamento)
        {
            if (ensalamento == null)
                return BadRequest("Dados do ensalamento não podem ser nulos");

            var ensalamentoAtualizada = await service.UpdateAsync(id, ensalamento);
            return Ok(ensalamentoAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucesso = await service.DeleteAsync(id);
            if (!sucesso)
                return NotFound("Ensalamento não encontrado");

            return NoContent();
        }
       
    }
}