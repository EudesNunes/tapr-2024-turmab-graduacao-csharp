using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservgraduacao.Dtos
{
    public class DisciplinaDTO
    {       
        public Guid Id { get; set;}
        public Guid CursoId { get; set;}
        public Guid ProfessorId { get; set; }
        public required string Nome { get; set; }
        public bool Ativa { get; set; }
        public DateTimeOffset DataCadastro { get; set; }
    }

    public class DisciplinaInputDTO
    {       
        public Guid CursoId { get; set;}
        public Guid ProfessorId { get; set; }
        public required string Nome { get; set; }
    }
}