using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservgraduacao.Dtos
{
    public class TurmaDTO
    {       
       public Guid Id { get; set;}
        public Guid CursoId { get; set;}
        public required string Nome { get; set; }
        public required  List<Guid> Alunos { get; set; }
        public bool Ativa { get; set; }
        public DateTimeOffset DataCadastro { get; set; }        
    }   

    public class TurmaInputDTO
    {       
        public Guid CursoId { get; set;}
        public required string Nome { get; set; }
        public required  List<Guid> Alunos { get; set; }
    }
}