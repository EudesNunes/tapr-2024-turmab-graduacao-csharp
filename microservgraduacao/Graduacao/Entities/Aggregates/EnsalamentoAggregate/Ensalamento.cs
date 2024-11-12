namespace microservgraduacao.Graduacao.Entities.Aggregates.EnsalamentoAggregate
{

    public class Ensalamento
    {
        // Identificação
        public Guid Id { get; }
        public Guid TurmaId { get;private set; }
        // Dados
        public List<Guid> Horarios { get; private set; }

        // Construtores
        public Ensalamento(){}
        private Ensalamento(Guid id, Guid turmaId, List<Guid> horarios)
        {
            Id = id;
            TurmaId = turmaId;
            Horarios = horarios;
        }
        public static Ensalamento Instanciar(Guid id, Guid turmaId, List<Guid> horarios)
            => new(id, turmaId, horarios);        

        // Alteração de dados   
        public void AlterarHorario(List<Guid> horarios, Guid turmaId)
        {
            TurmaId = turmaId;
            Horarios = horarios;
        }
       
       
    }
}
