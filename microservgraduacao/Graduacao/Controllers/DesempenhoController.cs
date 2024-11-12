using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Services.DesempenhoService;
using Microsoft.AspNetCore.Mvc;

namespace microservgraduacao.Graduacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DesempenhoController(IDesempenhoService _service) : ControllerBase
    {
        private readonly IDesempenhoService service = _service;

        [HttpGet]
        public async Task<ActionResult<List<DesempenhoDTO>>> Get()
        {
            var lista = await service.GetDesempenhoAsync();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<DesempenhoDTO>> Post([FromBody] DesempenhoInputDTO desempenho)
        {
            if (desempenho == null)
                return BadRequest("Desempenho não pode ser nulo");

            var desempenhoSalva = await service.SaveAsync(desempenho);
            return CreatedAtAction(nameof(Get), new { id = desempenhoSalva.Id }, desempenhoSalva);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DesempenhoDTO>> Update(Guid id, [FromBody] DesempenhoInputDTO desempenho)
        {
            if (desempenho == null)
                return BadRequest("Dados do desempenho não podem ser nulos");

            var desempenhoAtualizada = await service.UpdateAsync(id, desempenho);
            return Ok(desempenhoAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucesso = await service.DeleteAsync(id);
            if (!sucesso)
                return NotFound("Desempenho não encontrado");

            return NoContent();
        }
       
    }
}