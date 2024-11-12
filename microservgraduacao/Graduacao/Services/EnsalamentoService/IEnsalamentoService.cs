using microservgraduacao.Dtos;

namespace microservgraduacao.Graduacao.Services.EnsalamentoService
{
    public interface IEnsalamentoService
    {
        Task<List<EnsalamentoDTO>> GetEnsalamentoAsync();
        Task<EnsalamentoDTO> SaveAsync(EnsalamentoInputDTO dto);
        Task<EnsalamentoDTO> UpdateAsync(Guid id, EnsalamentoInputDTO dto);
        Task<bool> DeleteAsync(Guid id);        

    }
}