using AutoMapper;
using FTech.Application.DataTransferObjects.Categories;
using FTech.Domain.Entities.Categories;
using FTech.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FTech.Application.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly IBaseRepository<Category> _repository;
    private readonly IMapper mapper;

    public CategoryService(IMapper mapper, IBaseRepository<Category> baseRepository)
    {
        this.mapper = mapper;
        this._repository = baseRepository;
    }

    public async Task<CategoryForResultDTO> CreateAsync(CategoryForCreationDTO dto)
    {
        var mappedCategory = mapper.Map<Category>(dto);
        var result = await _repository.AddAsync(mappedCategory);

        return mapper.Map<CategoryForResultDTO>(result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var category = await _repository.FindAsync(c => c.Id == id);
        if (category is null)
        {
            throw new ValidationException("category is not found");
        }

        await _repository.RemoveAsync(category);
        return true;
    }

    public async Task<IEnumerable<CategoryForResultDTO>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync()
            .ToListAsync();

        return mapper.Map<IEnumerable<CategoryForResultDTO>>(categories);
    }

    public async Task<CategoryForResultDTO> GetByIdAsync(long id)
    {
        var category = await _repository.FindAsync(c => c.Id == id);
        if (category is null)
        {
            throw new ValidationException("category is not found");
        }

        return mapper.Map<CategoryForResultDTO>(category);
    }

    public async Task<CategoryForResultDTO> UpdateAsync(long id, CategoryForCreationDTO dto)
    {
        var category = await _repository.FindAsync(c => c.Id == id);
        if (category is null)
        {
            throw new ValidationException("category is not found");
        }

        var mappedCategory = mapper.Map(dto, category);
        var result = await _repository.UpdateAsync(mappedCategory);

        return mapper.Map<CategoryForResultDTO>(result);
    }
}
