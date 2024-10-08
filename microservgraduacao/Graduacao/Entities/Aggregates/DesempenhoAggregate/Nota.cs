using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservgraduacao.Graduacao.Entities.Aggregates.DesempenhoAggregate
{
    public readonly record struct Nota
    {
        public float Valor { get; }

        public Nota(float valor)
        {
            if (valor < 0 || valor > 10)
                throw new ArgumentOutOfRangeException(nameof(valor), "A nota deve estar entre 0 e 10.");

            Valor = valor;
        }

        public static implicit operator float(Nota nota) => nota.Valor;
        public static implicit operator Nota(float valor) => new(valor);
        
    }
}