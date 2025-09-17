using ToDoApp.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Application.UseCases.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<int> CreateCategoryAsync(CreateCategoryDto dto);
        Task UpdateCategoryAsync(UpdateCategoryDto dto);
        Task DeleteCategoryAsync(int id);
    }
}
