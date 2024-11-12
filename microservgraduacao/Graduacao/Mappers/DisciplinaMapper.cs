using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservgraduacao.Dtos;
using microservgraduacao.Graduacao.Entities.Aggregates.DisciplinaAggregate;

namespace microservgraduacao.Graduacao.Mappers
{
    public static class DisciplinaMapper
    {
        public static Disciplina ToEntity(this DisciplinaDTO dto)
        {
            return Disciplina.Existente(dto.Id, dto.CursoId, dto.ProfessorId, dto.Nome, dto.DataCadastro, dto.Ativa);
        }

        public static List<Disciplina> ToEntity(this IEnumerable<DisciplinaDTO> dtos)
        {
            return dtos.Select(dto => dto.ToEntity()).ToList();
        }
        public static DisciplinaDTO ToDto(this Disciplina dto)
        {
            return new DisciplinaDTO
            {
                Id = dto.Id,
                CursoId = dto.CursoId,
                ProfessorId = dto.ProfessorId,
                Nome = dto.Nome,
                DataCadastro = dto.DataCadastro,
                Ativa = dto.Ativa
            };
        }
        public static List<DisciplinaDTO> ToDto(this IEnumerable<Disciplina> dtos)
        {
            return dtos.Select(dto => dto.ToDto()).ToList();
        }

    }
}