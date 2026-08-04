using InterviewPrepApp.DTOs.Category;
using InterviewPrepApp.Models;

namespace InterviewPrepApp.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> AddCategory(CategoryDTO category);
        Task<CategoryDTO> UpdateCategory(CategoryDTO category);
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO?> GetCategoryById(int categoryId);
        Task<bool> DeleteCategory(int categoryId);
    }
}
