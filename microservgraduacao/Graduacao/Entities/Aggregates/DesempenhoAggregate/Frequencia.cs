using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservgraduacao.Graduacao.Entities.Aggregates.DesempenhoAggregate
{
    public class Frequencia
    {
        public float Valor { get; private set; }

        public Frequencia(float valor)
        {
            if (valor < 0 || valor > 100)
                throw new ArgumentOutOfRangeException(nameof(valor), "A frequência deve estar entre 0 e 100.");

            Valor = valor;
        }

        public static implicit operator float(Frequencia frequencia) => frequencia.Valor;
        public static implicit operator Frequencia(float valor) => new Frequencia(valor);
    }
}