
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace microservgraduacao.Graduacao.Entities.Aggregates.TurmaAggregate
{

    public class Turma
    {
        // Identificação
        public Guid Id { get; }
        public Guid CursoId { get;  private set; }
        public List<Guid> AlunosId { get;  private set; }
        public string Nome { get; private set;}
        public bool Ativa { get; private set;}
        public DateTimeOffset DataCadastro { get; private set;}

        public Turma() { }

        private Turma(Guid cursoId, string nome, List<Guid> alunosId)
        {
            Id = Guid.NewGuid();
            CursoId = cursoId;
            Nome = nome;
            AlunosId = alunosId;    
            DataCadastro = DateTimeOffset.Now;
            Ativa = true;
        }
        public static Turma Nova(Guid cursoId, string nome, List<Guid> alunosId)
            => new(cursoId, nome, alunosId);

        // Instanciação de uma Turma existente
        private Turma(Guid id, Guid cursoId, string nome, DateTimeOffset dataCadastro, bool ativa, List<Guid> alunosId)
        {
            Id = id;
            CursoId = cursoId;
            Nome = nome;
            AlunosId = alunosId;
            DataCadastro = dataCadastro;
            Ativa = ativa;               
            
        }
        public static Turma Existente(Guid id, Guid cursoId, string nome, DateTimeOffset dataCadastro, bool ativa, List<Guid> alunosId)
            => new(id, cursoId, nome, dataCadastro, ativa, alunosId);

        // Alteração de dados   
        public void AlterarDados(Guid cursoId, List<Guid> alunosId, string nome)
        {
            CursoId = cursoId;
            AlunosId = alunosId;
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
