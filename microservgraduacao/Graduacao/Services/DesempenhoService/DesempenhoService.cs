using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Entities;
using microservgraduacao.Graduacao.Entities.Aggregates.DesempenhoAggregate;
using microservgraduacao.Graduacao.Mappers;
using Microsoft.EntityFrameworkCore;

namespace microservgraduacao.Graduacao.Services.DesempenhoService
{
    public class DesempenhoService(RepositoryDbContext dbContext) : IDesempenhoService
    {
        private RepositoryDbContext _dbContext = dbContext;

        public async Task<bool> DeleteAsync(Guid id)
        {
            var desempenho = await _dbContext.Desempenho
               .FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException("Desempenho não encontrado");
            _dbContext.Desempenho.Remove(desempenho);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<DesempenhoDTO>> GetDesempenhoAsync()
        {
            var listaDesempenho = await _dbContext.Desempenho.ToListAsync();
            return listaDesempenho.ToDto();
        }

        public async Task<DesempenhoDTO> SaveAsync(DesempenhoInputDTO dto)
        {
            var desempenho = DesempenhoDisciplina.Instanciar(Guid.NewGuid(), dto.AlunoId, dto.DisciplinaId, dto.Nota, dto.Frequencia, dto.NotaExame);
            await _dbContext.AddAsync(desempenho);
            await _dbContext.SaveChangesAsync();
            return desempenho.ToDto();
        }

        public async Task<DesempenhoDTO> UpdateAsync(Guid id, DesempenhoInputDTO dto)
        {
            var desempenho = await _dbContext.Desempenho
               .FirstOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException("Desempenho não encontrado");

            desempenho.AtualizarFrequencia(dto.Frequencia);
            desempenho.AtualizarNota(dto.Nota);
            desempenho.AtualizarNotaExame(dto.NotaExame);
            await _dbContext.SaveChangesAsync();

            return desempenho.ToDto();
        }
    }
}