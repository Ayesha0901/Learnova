using InterviewPrepApp.Models;

namespace InterviewPrepApp.Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryModel> AddCategory(CategoryModel category);
        Task<CategoryModel> UpdateCategory(CategoryModel category);
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<CategoryModel?> GetCategoryById(int categoryId);
        Task<bool> DeleteCategory(int categoryId);
    }
}
