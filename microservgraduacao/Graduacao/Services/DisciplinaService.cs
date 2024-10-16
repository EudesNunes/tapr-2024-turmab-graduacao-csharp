using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservgraduacao.Graduacao.Entities;
using microservgraduacao.Graduacao.Entities.Aggregates.DisciplinaAggregate;
using Microsoft.EntityFrameworkCore;

namespace microservgraduacao.Graduacao.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private RepositoryDbContext _dbContext;
        public DisciplinaService(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Disciplina>> GetDisciplinasAsync()
        {
            var listaDisciplina = await _dbContext.Disciplinas.ToListAsync();
            return listaDisciplina;
        }

        public Task<Disciplina> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}