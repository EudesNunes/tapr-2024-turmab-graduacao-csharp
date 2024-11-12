using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservgraduacao.Dtos
{
    public class HorarioDTO
    {       
       public Guid Id { get; set;}
       public Guid DisciplinaId { get; set;}
       public DateTimeOffset Data  { get; set; }
           
    }   
    public class HorarioInputDTO
    {       
        public Guid DisciplinaId { get; set;}
        public required DateTimeOffset Data { get; set; }
    }
    public class EnsalamentoDTO
    {       
       public Guid Id { get; set;}
       public Guid TurmaId { get; set;}
       public List<Guid> Horarios { get; set; } = [];           
    }   

    public class EnsalamentoInputDTO
    {       
        public Guid TurmaId { get; set;}
        public required List<Guid> Horarios { get; set; }
    }
}