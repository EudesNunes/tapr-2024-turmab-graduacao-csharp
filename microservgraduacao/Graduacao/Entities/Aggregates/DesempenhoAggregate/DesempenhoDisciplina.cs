namespace microservgraduacao.Graduacao.Entities.Aggregates.DesempenhoAggregate
{
    public class DesempenhoDisciplina
    {
        // Identificação
        public Guid Id { get; }
        public Guid AlunoId { get; }
        public Guid DisciplinaId { get; }
        public Nota? Nota { get; private set; }
        public Nota? NotaExame { get; private set; }
        public Frequencia? Frequencia { get; private set; }
        public StatusAluno StatusAluno { get; private set; }

        public DesempenhoDisciplina() { }

        private DesempenhoDisciplina(Guid id, Guid alunoId, Guid disciplinaId, Nota? nota, Frequencia? frequencia, Nota? notaExame)
        {
            Id = id;
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
            Nota = nota;
            Frequencia = frequencia;
            NotaExame = notaExame;
            StatusAluno = new StatusAluno(nota, frequencia, notaExame);
        }
        public static DesempenhoDisciplina Instanciar(Guid id, Guid alunoId, Guid disciplinaId, Nota? nota, Frequencia? frequencia, Nota? notaExame)
            => new(id, alunoId, disciplinaId, nota, frequencia, notaExame);

        public void AtualizarNota(Nota? novaNota)
        {
            Nota = novaNota;
            RecalcularStatus();
        }
        public void AtualizarFrequencia(Frequencia? novaFrequencia)
        {
            Frequencia = novaFrequencia;
            RecalcularStatus();
        }
        public void AtualizarNotaExame(Nota? novaNotaExame)
        {
            NotaExame = novaNotaExame;
            RecalcularStatus();
        }
        private void RecalcularStatus()
        {
            StatusAluno = new StatusAluno(Nota, Frequencia, NotaExame);
        }


    }
}
