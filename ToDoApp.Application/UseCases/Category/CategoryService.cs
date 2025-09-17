using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Application.UseCases.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> CreateCategoryAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            await _categoryRepository.AddAsync(category);
            return category.Id;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var c = await _categoryRepository.GetByIdAsync(id);
            if (c == null) return null;

            return new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            };
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.Id);
            if (category == null) throw new Exception("Category not found");

            category.Name = dto.Name;
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
