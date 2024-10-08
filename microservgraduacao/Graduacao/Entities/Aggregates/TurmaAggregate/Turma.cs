
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace microservgraduacao.Graduacao.Entities.Aggregates.TurmaAggregate
{

    public record HistoricoTurma(DateTimeOffset DataCadastro);
    public record StatusTurma(bool Ativa);
    public record DadosTurma(
        string Nome,
        List<Guid> Alunos
    );

    public class Turma
    {
        // Identificação
        public Guid Id { get; }
        public Guid CursoId { get; }
        // Dados
        public DadosTurma Dados { get; private set; }
        public HistoricoTurma Historico { get; private set; }
        public StatusTurma Status { get; private set; }

        private Turma(Guid id, Guid cursoId, DadosTurma dados)
        {
            Id = id;
            CursoId = cursoId;
            Dados = dados;
            Historico = new(DateTimeOffset.Now);
            Status = new(true);
        }
        public static Turma Nova(Guid id, Guid cursoId, DadosTurma dados)
            => new(id, cursoId, dados);

        // Instanciação de uma Turma existente
        private Turma(Guid id, Guid cursoId, DadosTurma dados, HistoricoTurma historico, StatusTurma status)
        {
            Id = id;
            CursoId = cursoId;
            Dados = dados;
            Historico = historico;
            Status = status;
        }
        public static Turma Existente(Guid id, Guid cursoId, DadosTurma dados, HistoricoTurma historico, StatusTurma status)
            => new(id, cursoId, dados, historico, status);

        // Alteração de dados   
        public void AlterarDados(DadosTurma dados)
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
