using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Entities;
using microservgraduacao.Graduacao.Entities.Aggregates.TurmaAggregate;
using microservgraduacao.Graduacao.Mappers;
using Microsoft.EntityFrameworkCore;

namespace microservgraduacao.Graduacao.Services.TurmasService
{
    public class TurmaService(RepositoryDbContext dbContext) : ITurmaService
    {
        private RepositoryDbContext _dbContext = dbContext;

        public async Task<bool> ActivateAsync(Guid id)
        {
             var turma = await _dbContext.Turmas
                .FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException("Turma não encontrada");
            if (turma.Ativa)
                return true;

            turma.Ativar();
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
             var turma = await _dbContext.Turmas
                .FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException("Turma não encontrada");
            _dbContext.Turmas.Remove(turma);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DisableAsync(Guid id)
        {
            var turma = await _dbContext.Turmas
                .FirstOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException("Turma não encontrada");
            if (!turma.Ativa)
                return true;

            turma.Desativar();
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TurmaDTO>> GetTurmasAsync()
        {
            var listaturma = await _dbContext.Turmas.ToListAsync();
            return listaturma.ToDto();
        }

        public async Task<TurmaDTO> SaveAsync(TurmaInputDTO dto)
        {
            var turma = Turma.Nova(dto.CursoId, dto.Nome, dto.Alunos);
            await _dbContext.AddAsync(turma);
            await _dbContext.SaveChangesAsync();
            return turma.ToDto();
        }

        public async Task<TurmaDTO> UpdateAsync(Guid id, TurmaInputDTO dto)
        {
            var turma = await _dbContext.Turmas
                .FirstOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException("Turma não encontrada");
            
            turma.AlterarDados(dto.CursoId, dto.Alunos, dto.Nome);
            await _dbContext.SaveChangesAsync();

            return turma.ToDto();
        }
    }
}