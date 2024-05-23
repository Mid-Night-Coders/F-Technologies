using FTech.Application.DataTransferObjects.Cars;

namespace FTech.Infrastructure.Services.Cars;

public interface ICarService
{
    public Task<CarForResultDTO> CreateAsync(CarForCreationDTO dto);
    public Task<CarForResultDTO> UpdateAsync(long id, CarForCreationDTO dto);
    public Task<bool> DeleteAsync(long id);
    public Task<CarForResultDTO> GetByIdAsync(long id);
    public Task<IEnumerable<CarForResultDTO>> GetAllAsync();
}
