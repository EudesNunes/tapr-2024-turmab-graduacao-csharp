using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Entities.Aggregates.EnsalamentoAggregate;

namespace microservgraduacao.Graduacao.Mappers
{
    public static class EnsalamentoMapper
    {
        public static Ensalamento ToEntity(this EnsalamentoDTO dto)
        {
            return Ensalamento.Instanciar(dto.Id, dto.TurmaId, dto.Horarios);
        }

        public static List<Ensalamento> ToEntity(this IEnumerable<EnsalamentoDTO> dtos)
        {
            return dtos.Select(dto => dto.ToEntity()).ToList();
        }
        public static EnsalamentoDTO ToDto(this Ensalamento dto)
        {
            return new EnsalamentoDTO
            {
                Id = dto.Id,
                TurmaId = dto.TurmaId,
                Horarios = dto.Horarios                
            };
           
        }
        public static List<EnsalamentoDTO> ToDto(this IEnumerable<Ensalamento> dtos)
        {
            return dtos.Select(dto => dto.ToDto()).ToList();
        }

    }
}