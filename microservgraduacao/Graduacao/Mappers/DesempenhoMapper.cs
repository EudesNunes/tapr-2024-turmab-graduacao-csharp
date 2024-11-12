using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Entities.Aggregates.DesempenhoAggregate;
using microservgraduacao.Graduacao.Entities.Aggregates.EnsalamentoAggregate;

namespace microservgraduacao.Graduacao.Mappers
{
    public static class DesempenhoMapper
    {
        public static DesempenhoDisciplina ToEntity(this DesempenhoDTO dto)
        {
            return DesempenhoDisciplina.Instanciar(
                Guid.NewGuid(),
                dto.AlunoId,
                dto.DisciplinaId,
                dto.Nota,
                dto.Frequencia,
                dto.NotaExame
                );
        }

        public static List<DesempenhoDisciplina> ToEntity(this IEnumerable<DesempenhoDTO> dtos)
        {
            return dtos.Select(dto => dto.ToEntity()).ToList();
        }
        public static DesempenhoDTO ToDto(this DesempenhoDisciplina dto)
        {
            return new DesempenhoDTO
            {
                Id = dto.Id,
                AlunoId = dto.AlunoId,
                DisciplinaId = dto.DisciplinaId,
                Nota = dto.Nota,
                Frequencia = dto.Frequencia,
                NotaExame = dto.NotaExame,
                StatusAluno = dto.StatusAluno
            };
            
           
        }
        public static List<DesempenhoDTO> ToDto(this IEnumerable<DesempenhoDisciplina> dtos)
        {
            return dtos.Select(dto => dto.ToDto()).ToList();
        }

    }
}