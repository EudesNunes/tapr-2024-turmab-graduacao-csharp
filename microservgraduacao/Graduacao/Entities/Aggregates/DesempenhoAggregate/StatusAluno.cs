using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservgraduacao.Graduacao.Entities.Enumerations;

namespace microservgraduacao.Graduacao.Entities.Aggregates.DesempenhoAggregate
{
    public class StatusAluno
    {
        public Status Valor { get; private set; }

        public StatusAluno(Status status)
        {
            Valor = status;
        }
        public StatusAluno() { }

        public StatusAluno(Nota? nota, Frequencia? frequencia, Nota? notaExame)
        {
            if (nota is null || frequencia is null)
                Valor = Status.Pendente;
            else
            {
                Valor = (nota.Valor, frequencia.Valor) switch
                {
                    (>= 7, >= 75) => Status.Aprovado,
                    (>= 3 and < 7, >= 75) when notaExame is not null && (nota.Valor + notaExame.Valor) >= 10 => Status.Aprovado,
                    (>= 3 and < 7, >= 75) => Status.Recuperacao,
                    _ => Status.Reprovado
                };
            }
        }

        public static implicit operator Status(StatusAluno statusAluno) => statusAluno.Valor;
        public static implicit operator StatusAluno(Status status) => new StatusAluno(status);
    }
}