using microservgraduacao.Dtos;

namespace microservgraduacao.Graduacao.Services.DesempenhoService
{
    public interface IDesempenhoService
    {
        Task<List<DesempenhoDTO>> GetDesempenhoAsync();
        Task<DesempenhoDTO> SaveAsync(DesempenhoInputDTO dto);
        Task<DesempenhoDTO> UpdateAsync(Guid id, DesempenhoInputDTO dto);
        Task<bool> DeleteAsync(Guid id);

    }
}