
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace microservgraduacao.Graduacao.Entities.Aggregates.EnsalamentoAggregate
{   
    public record DadosEnsalamento(
        List<Horario> Horarios
    );
    public class Ensalamento
    {
        // Identificação
        public Guid Id { get; }
        public Guid TurmaId { get; }
        // Dados
        public DadosEnsalamento Dados { get; private set; }

        private Ensalamento(Guid id, Guid turmaId, DadosEnsalamento dados)
        {
            Id = id;
            TurmaId = turmaId;
            Dados = dados;
        }
        public static Ensalamento Instanciar(Guid id, Guid turmaId, DadosEnsalamento dados)
            => new(id, turmaId, dados);        

        // Alteração de dados   
        public void AlterarDados(DadosEnsalamento dados)
        {
            Dados = dados;
        }
       
       
    }
}
