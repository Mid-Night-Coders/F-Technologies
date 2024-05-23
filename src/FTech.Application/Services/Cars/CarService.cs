using AutoMapper;
using FTech.Application.DataTransferObjects.Cars;
using FTech.Domain.Entities.Cars;
using FTech.Infrastructure.Repositories.Base;
using FTech.Infrastructure.Services.Cars;
using FTech.Infrastructure.Services.Files;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FTech.Application.Services.Cars;

public class CarService : ICarService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Car> _carRepository;
    private readonly IFileService _fileService;
    public CarService(IBaseRepository<Car> baseRepository,
        IMapper mapper,
        IFileService fileService)
    {
        _carRepository = baseRepository;
        _mapper = mapper;
        _fileService = fileService;
    }
    public async Task<CarForResultDTO> CreateAsync(CarForCreationDTO dto)
    {
        var existCar = await _carRepository.GetAllAsync()
            .Where(c => c.Number == dto.Number)
            .FirstOrDefaultAsync();

        if (existCar is not null)
            throw new ValidationException("Car already exist");

        var mappedCar = _mapper.Map<Car>(dto);
        if (dto.Image is not null)
        {
            mappedCar.Image = await _fileService.UploadImageAsync(dto.Image);
        }

        var result = await _carRepository.AddAsync(mappedCar);

        return _mapper.Map<CarForResultDTO>(result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var car = await _carRepository.FindAsync(c => c.Id == id);
        if (car is  null)
            throw new ValidationException($"Could not delete car");

        await _carRepository.RemoveAsync(car);

        return true;
    }

    public async Task<IEnumerable<CarForResultDTO>> GetAllAsync()
    {
        var Cars = await _carRepository.GetAllAsync()
            .Include(c => c.Category)
            .ToListAsync();

        var mappedCars = _mapper.Map<IEnumerable<CarForResultDTO>>(Cars);
        
        return mappedCars;
    }

    public async Task<CarForResultDTO> GetByIdAsync(long id)
    {
        var car = await _carRepository.GetAllAsync()
            .Include(c => c.Category)
            .ToListAsync();

        return _mapper.Map<CarForResultDTO>(car);
    }

    public async Task<CarForResultDTO> UpdateAsync(long id, CarForCreationDTO dto)
    {
        var existCar = await _carRepository.GetAllAsync()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

        if (existCar is  null)
            throw new ValidationException("Car not found ");

        var mappedCar = _mapper.Map(dto, existCar);
        mappedCar.UpdatedAt = DateTime.UtcNow;

        var updatedCar = await _carRepository.UpdateAsync(mappedCar);

        return _mapper.Map<CarForResultDTO>(updatedCar);
    }
}
