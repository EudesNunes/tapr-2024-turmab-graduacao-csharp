using microservgraduacao.Dtos;

namespace microservgraduacao.Graduacao.Services.EnsalamentoService
{
    public interface IHorarioService
    {
        Task<List<HorarioDTO>> GetHorarioAsync();
        Task<HorarioDTO> SaveAsync(HorarioInputDTO dto);
        Task<HorarioDTO> UpdateAsync(Guid id, HorarioInputDTO dto);
        Task<bool> DeleteAsync(Guid id);        

    }
}