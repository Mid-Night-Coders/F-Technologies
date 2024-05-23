using FTech.Application.DataTransferObjects.Cars;
using FTech.Application.DataTransferObjects.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTech.Application.Services.Categories
{
    public interface ICategoryService
    {
        public Task<CategoryForResultDTO> CreateAsync(CategoryForCreationDTO dto);
        public Task<CategoryForResultDTO> UpdateAsync(long id, CategoryForCreationDTO dto);
        public Task<bool> DeleteAsync(long id);
        public Task<CategoryForResultDTO> GetByIdAsync(long id);
        public Task<IEnumerable<CategoryForResultDTO>> GetAllAsync();
    }
}
