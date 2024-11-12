using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Entities;
using microservgraduacao.Graduacao.Entities.Aggregates.EnsalamentoAggregate;
using microservgraduacao.Graduacao.Mappers;
using Microsoft.EntityFrameworkCore;

namespace microservgraduacao.Graduacao.Services.EnsalamentoService
{
    public class HorarioService(RepositoryDbContext dbContext) : IHorarioService
    {
        private RepositoryDbContext _dbContext = dbContext;

        public async Task<bool> DeleteAsync(Guid id)
        {
             var horario = await _dbContext.Horario
                .FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException("Horario não encontrado");
            _dbContext.Horario.Remove(horario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<HorarioDTO>> GetHorarioAsync()
        {
              var listaHorario = await _dbContext.Horario.ToListAsync();
              return listaHorario.ToDto();
        }

        public async Task<HorarioDTO> SaveAsync(HorarioInputDTO dto)
        {
            var horario = Horario.Instanciar(Guid.NewGuid(), dto.DisciplinaId, dto.Data);
            await _dbContext.AddAsync(horario);
            await _dbContext.SaveChangesAsync();
            return horario.ToDto();
        }

        public async Task<HorarioDTO> UpdateAsync(Guid id, HorarioInputDTO dto)
        {
             var horario = await _dbContext.Horario
                .FirstOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException("Horario não encontrado");
            
            horario.AlterarHorario(dto.Data, dto.DisciplinaId);
            await _dbContext.SaveChangesAsync();

            return horario.ToDto();
        }
    }
}