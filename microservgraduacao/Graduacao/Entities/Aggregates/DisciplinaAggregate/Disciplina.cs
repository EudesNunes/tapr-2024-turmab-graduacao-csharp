
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace microservgraduacao.Graduacao.Entities.Aggregates.DisciplinaAggregate
{

    public record HistoricoDisciplina(DateTimeOffset DataCadastro);
    public record StatusDisciplina(bool Ativa);
    public record DadosDisciplina(
        string Nome,
        Guid ProfessorId
    );

    public class Disciplina
    {
        // Identificação
        public Guid Id { get; }
        public Guid CursoId { get; }
        // Dados
        public DadosDisciplina Dados { get; private set; }
        public HistoricoDisciplina Historico { get; private set; }
        public StatusDisciplina Status { get; private set; }

        private Disciplina(Guid id, Guid cursoId, DadosDisciplina dados)
        {
            Id = id;
            CursoId = cursoId;
            Dados = dados;
            Historico = new(DateTimeOffset.Now);
            Status = new(true);
        }
        public static Disciplina Nova(Guid id, Guid cursoId, DadosDisciplina dados)
            => new(id, cursoId, dados);

        // Instanciação de uma disciplina existente
        private Disciplina(Guid id, Guid cursoId, DadosDisciplina dados, HistoricoDisciplina historico, StatusDisciplina status)
        {
            Id = id;
            CursoId = cursoId;
            Dados = dados;
            Historico = historico;
            Status = status;
        }
        public static Disciplina Existente(Guid id, Guid cursoId, DadosDisciplina dados, HistoricoDisciplina historico, StatusDisciplina status)
            => new(id, cursoId, dados, historico, status);

        // Alteração de dados   
        public void AlterarDados(DadosDisciplina dados)
        {
            Dados = dados;
        }
        public void Desativar()
        {
            Status = new(false);
        }

        public void Ativar()
        {
            Status = new(true);
        }
    }
}
