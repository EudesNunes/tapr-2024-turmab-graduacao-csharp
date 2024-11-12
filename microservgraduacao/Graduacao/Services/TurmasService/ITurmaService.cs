using microservgraduacao.Dtos;

namespace microservgraduacao.Graduacao.Services.TurmasService
{
    public interface ITurmaService
    {
        Task<List<TurmaDTO>> GetTurmasAsync();
        Task<TurmaDTO> SaveAsync(TurmaInputDTO dto);
        Task<TurmaDTO> UpdateAsync(Guid id, TurmaInputDTO dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ActivateAsync(Guid id);
        Task<bool> DisableAsync(Guid id);

    }
}