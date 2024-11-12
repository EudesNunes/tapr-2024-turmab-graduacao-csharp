using microservgraduacao.Dtos;

namespace microservgraduacao.Graduacao.Services.DisciplinasService
{
    public interface IDisciplinaService
    {
        Task<List<DisciplinaDTO>> GetDisciplinasAsync();
        Task<DisciplinaDTO> SaveAsync(DisciplinaInputDTO dto);
        Task<DisciplinaDTO> UpdateAsync(Guid id, DisciplinaInputDTO dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ActivateAsync(Guid id);
        Task<bool> DisableAsync(Guid id);

    }
}