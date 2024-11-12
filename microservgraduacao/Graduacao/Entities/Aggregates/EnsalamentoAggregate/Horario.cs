
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace microservgraduacao.Graduacao.Entities.Aggregates.EnsalamentoAggregate
{
    public class Horario
    {
        // Identificação
        public Guid Id { get; }
        public Guid DisciplinaId { get; private set; }
        // Dados
        public DateTimeOffset Data { get; private set; }

        public Horario(){}

        private Horario(Guid id, Guid disciplinaId, DateTimeOffset data)
        {
            Id = id;
            DisciplinaId = disciplinaId;
            Data = data;
        }
        public static Horario Instanciar(Guid id, Guid disciplinaId, DateTimeOffset data)
            => new(id, disciplinaId, data);
        
        // Alteração de horario   
        public void AlterarHorario(DateTimeOffset data, Guid disciplinaId)
        {
            DisciplinaId = disciplinaId;
            Data = data;
        }


    }
}
