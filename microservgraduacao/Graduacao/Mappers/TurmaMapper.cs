using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Entities.Aggregates.TurmaAggregate;

namespace microservgraduacao.Graduacao.Mappers
{
    public static class TurmaMapper
    {
        public static Turma ToEntity(this TurmaDTO dto)
        {
            return Turma.Existente(dto.Id, dto.CursoId, dto.Nome, dto.DataCadastro, dto.Ativa, dto.Alunos);
        }

        public static List<Turma> ToEntity(this IEnumerable<TurmaDTO> dtos)
        {
            return dtos.Select(dto => dto.ToEntity()).ToList();
        }
        public static TurmaDTO ToDto(this Turma dto)
        {
            return new TurmaDTO
            {
                Id = dto.Id,
                CursoId = dto.CursoId,
                Alunos = dto.AlunosId,
                Nome = dto.Nome,
                DataCadastro = dto.DataCadastro,
                Ativa = dto.Ativa
            };
        }
        public static List<TurmaDTO> ToDto(this IEnumerable<Turma> dtos)
        {
            return dtos.Select(dto => dto.ToDto()).ToList();
        }

    }
}