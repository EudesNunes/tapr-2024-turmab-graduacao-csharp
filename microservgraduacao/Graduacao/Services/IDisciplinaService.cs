using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservgraduacao.Graduacao.Entities.Aggregates.DisciplinaAggregate;

namespace microservgraduacao.Graduacao.Services
{
    public interface IDisciplinaService
    {
        Task<List<Disciplina>> GetDisciplinasAsync();
        Task<Disciplina> SaveAsync();
    }
}