
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace microservgraduacao.Graduacao.Entities.Aggregates.DisciplinaAggregate
{  

    public class Disciplina
    {
        // Identificação
        public Guid Id { get; }
        public Guid CursoId { get; private set;}
        public Guid ProfessorId { get; private set;}
        public string Nome { get; private set;}
        public bool Ativa { get; private set;}
        public DateTimeOffset DataCadastro { get; private set;}
       

        public Disciplina() { }

        private Disciplina(Guid cursoId, Guid professorId, string nome)
        {
            Id = Guid.NewGuid();
            CursoId = cursoId;
            ProfessorId = professorId;
            Nome = nome;
            DataCadastro = DateTimeOffset.Now;
            Ativa = true;
        }
        public static Disciplina Nova(Guid cursoId, Guid professorId, string nome)
            => new(cursoId, professorId,nome);

        // Instanciação de uma disciplina existente
        private Disciplina(Guid id, Guid cursoId,  Guid professorId, string nome, DateTimeOffset dataCadastro, bool ativa)
        {
            Id = id;
            CursoId = cursoId;
            ProfessorId = professorId;
            Nome = nome;
            DataCadastro = dataCadastro;
            Ativa = ativa;
        }
        public static Disciplina Existente(Guid id, Guid cursoId, Guid professorId, string nome, DateTimeOffset dataCadastro, bool ativa)
            => new(id, cursoId, professorId, nome, dataCadastro,ativa);

        // Alteração de dados   
        public void AlterarDados(Guid cursoId,Guid professorId, string nome)
        {
            CursoId = cursoId;
            ProfessorId = professorId;
            Nome = nome;
        }
        public void Desativar()
        {
            Ativa = false;
        }

        public void Ativar()
        {
            Ativa = true;
        }
    }
}
