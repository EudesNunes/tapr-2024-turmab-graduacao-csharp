using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Entities.Aggregates.EnsalamentoAggregate;

namespace microservgraduacao.Graduacao.Mappers
{
    public static class HorarioMapper
    {
        public static Horario ToEntity(this HorarioDTO dto)
        {
            return Horario.Instanciar(dto.Id, dto.DisciplinaId, dto.Data);
        }

        public static List<Horario> ToEntity(this IEnumerable<HorarioDTO> dtos)
        {
            return dtos.Select(dto => dto.ToEntity()).ToList();
        }
        public static HorarioDTO ToDto(this Horario dto)
        {
            return new HorarioDTO
            {
                Id = dto.Id,
                DisciplinaId = dto.DisciplinaId,
                Data = dto.Data
            };
           
        }
        public static List<HorarioDTO> ToDto(this IEnumerable<Horario> dtos)
        {
            return dtos.Select(dto => dto.ToDto()).ToList();
        }

    }
}