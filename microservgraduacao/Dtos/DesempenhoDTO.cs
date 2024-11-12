using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservgraduacao.Graduacao.Entities.Aggregates.DesempenhoAggregate;

namespace microservgraduacao.Dtos
{
    
    public class DesempenhoDTO
    {       
        public Guid Id { get; set;}
        public required Guid AlunoId { get; set;}
        public required Guid DisciplinaId { get; set; }
        public Nota? Nota { get; set; }
        public Frequencia? Frequencia { get; set; }
        public Nota? NotaExame { get; set; }
        public StatusAluno StatusAluno { get; set; }
    }
    

    public class DesempenhoInputDTO
    {
        public required Guid AlunoId { get; set;}
        public required Guid DisciplinaId { get; set; }
        public required Nota Nota { get; set; }
        public required Frequencia Frequencia { get; set; }
        public Nota? NotaExame { get; set; }
    }
}