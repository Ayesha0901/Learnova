using InterviewPrepApp.DataContext;
using InterviewPrepApp.DTOs.Category;
using InterviewPrepApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;
        public CategoryRepository(AppDBContext context) 
        {
            _context = context;
        }

        public async Task<CategoryModel> AddCategory(CategoryModel category)
        {
            var data = await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<CategoryModel> UpdateCategory(CategoryModel category)
        {
            var data = await _context.Category.FindAsync(category.CategoryId);

            if (data == null)
            {
                return null;
            }

            data.CategoryName = category.CategoryName;
            data.Description = category.Description;
            data.IsActive = category.IsActive;
            data.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            return await _context.Category.Where(c => c.IsActive).ToListAsync();
        }

        public async Task<CategoryModel?> GetCategoryById(int categoryId)
        {
            return await _context.Category.FirstOrDefaultAsync(x => x.CategoryId == categoryId && x.IsActive);
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var data = await _context.Category.FindAsync(categoryId);

            if (data == null) return false;

            data.IsActive = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
