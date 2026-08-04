using InterviewPrepApp.DTOs.Category;
using InterviewPrepApp.Models;
using InterviewPrepApp.Repositories;

namespace InterviewPrepApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<CategoryDTO> AddCategory(CategoryDTO category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
                throw new ArgumentException("Category Name is required.");

            var data = new CategoryModel
            {
                CategoryName = category.CategoryName,
                Description = category.Description,
                IsActive = category.IsActive
            };
            var result = await _categoryRepo.AddCategory(data);

            return new CategoryDTO
            {
                CategoryId = result.CategoryId,
                CategoryName = result.CategoryName,
                Description = result.Description,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate,
                IsActive = result.IsActive
            };
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
                throw new ArgumentException("Category Name is required.");

            var data = new CategoryModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                IsActive = category.IsActive
            };

            var result = await _categoryRepo.UpdateCategory(data);

            if (result == null)
                return null;

            return new CategoryDTO
            {
                CategoryId = result.CategoryId,
                CategoryName = result.CategoryName,
                Description = result.Description,
                IsActive = result.IsActive,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };

        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var result = await _categoryRepo.GetCategories();

            return result.Select(category => new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                IsActive = category.IsActive,
                CreatedDate = category.CreatedDate,
                UpdatedDate = category.UpdatedDate
            });
        }
        public async Task<CategoryDTO?> GetCategoryById(int categoryId)
        {
            var result = await _categoryRepo.GetCategoryById(categoryId);

            if (result == null)
                return null;

            return new CategoryDTO
            {
                CategoryId = result.CategoryId,
                CategoryName = result.CategoryName,
                Description = result.Description,
                IsActive = result.IsActive,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            return await _categoryRepo.DeleteCategory(categoryId);
        }

    }
}
