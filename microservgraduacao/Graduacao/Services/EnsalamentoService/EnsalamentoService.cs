using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Entities;
using microservgraduacao.Graduacao.Entities.Aggregates.EnsalamentoAggregate;
using microservgraduacao.Graduacao.Mappers;
using Microsoft.EntityFrameworkCore;

namespace microservgraduacao.Graduacao.Services.EnsalamentoService
{
    public class EnsalamentoService(RepositoryDbContext dbContext) : IEnsalamentoService
    {
        private RepositoryDbContext _dbContext = dbContext;

        public async Task<bool> DeleteAsync(Guid id)
        {
             var ensalamento = await _dbContext.Ensalamento
                .FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException("Ensalamento não encontrado");  
            _dbContext.Ensalamento.Remove(ensalamento);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<EnsalamentoDTO>> GetEnsalamentoAsync()
        {
              var listaEnsalamento = await _dbContext.Ensalamento.ToListAsync();
              return listaEnsalamento.ToDto();
        }

        public async Task<EnsalamentoDTO> SaveAsync(EnsalamentoInputDTO dto)
        {
            var ensalamento = Ensalamento.Instanciar(Guid.NewGuid(), dto.TurmaId, dto.Horarios);
            await _dbContext.AddAsync(ensalamento);
            await _dbContext.SaveChangesAsync();
            return ensalamento.ToDto();
        }

        public async Task<EnsalamentoDTO> UpdateAsync(Guid id, EnsalamentoInputDTO dto)
        {
             var ensalamento = await _dbContext.Ensalamento
                .FirstOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException("Ensalamento não encontrado");
            
            ensalamento.AlterarHorario(dto.Horarios, dto.TurmaId);
            await _dbContext.SaveChangesAsync();

            return ensalamento.ToDto();
        }
    }
}