using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Entities;
using microservgraduacao.Graduacao.Entities.Aggregates.DisciplinaAggregate;
using microservgraduacao.Graduacao.Mappers;
using Microsoft.EntityFrameworkCore;

namespace microservgraduacao.Graduacao.Services.DisciplinasService
{
    public class DisciplinaService(RepositoryDbContext dbContext) : IDisciplinaService
    {
        private RepositoryDbContext _dbContext = dbContext;

        public async Task<bool> ActivateAsync(Guid id)
        {
            var disciplina = await _dbContext.Disciplinas
                .FirstOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException("Disciplina não encontrada");
            if (disciplina.Ativa)
                return true;

            disciplina.Ativar();
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var disciplina = await _dbContext.Disciplinas
                .FirstOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException("Disciplina não encontrada");

            _dbContext.Disciplinas.Remove(disciplina);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DisableAsync(Guid id)
        {
             var disciplina = await _dbContext.Disciplinas
                .FirstOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException("Disciplina não encontrada");
            if (!disciplina.Ativa)
                return true;

            disciplina.Desativar();
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<DisciplinaDTO>> GetDisciplinasAsync()
        {
            var listaDisciplina = await _dbContext.Disciplinas.ToListAsync();
            return listaDisciplina.ToDto();
        }

        public async Task<DisciplinaDTO> SaveAsync(DisciplinaInputDTO dto)
        {
            var disciplina = Disciplina.Nova(dto.CursoId,dto.ProfessorId,dto.Nome);
            await _dbContext.AddAsync(disciplina);
            await _dbContext.SaveChangesAsync();
            return disciplina.ToDto();
        }

        public async Task<DisciplinaDTO> UpdateAsync(Guid id, DisciplinaInputDTO dto)
        {
            var disciplina = await _dbContext.Disciplinas
                .FirstOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException("Disciplina não encontrada");
            
            disciplina.AlterarDados(dto.CursoId, dto.ProfessorId, dto.Nome);
            await _dbContext.SaveChangesAsync();

            return disciplina.ToDto();
        }
    }
}