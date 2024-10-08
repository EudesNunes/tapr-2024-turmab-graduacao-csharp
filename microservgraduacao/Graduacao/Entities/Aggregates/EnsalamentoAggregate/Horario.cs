
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace microservgraduacao.Graduacao.Entities.Aggregates.EnsalamentoAggregate
{
    public class Horario
    {
        // Identificação
        public Guid Id { get; }
        public Guid DisciplinaId { get; }
        // Dados
        public DateTimeOffset Data { get; private set; }

        private Horario(Guid id, Guid disciplinaId, DateTimeOffset data)
        {
            Id = id;
            DisciplinaId = disciplinaId;
            Data = data;
        }
        public static Horario Instanciar(Guid id, Guid disciplinaId, DateTimeOffset data)
            => new(id, disciplinaId, data);
        
        // Alteração de horario   
        public void AlterarHorario(DateTimeOffset data)
        {
            Data = data;
        }


    }
}
