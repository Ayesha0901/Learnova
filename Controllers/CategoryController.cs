using InterviewPrepApp.DTOs.Category;
using InterviewPrepApp.Models;
using InterviewPrepApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrepApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;

        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTO category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = await _categoryService.AddCategory(category);

                _logger.LogInformation("Category Created Successfully.");

                return CreatedAtAction(
                    nameof(GetCategoryById),
                    new { id = data.CategoryId },
                    data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating category.");

                return StatusCode(500,"Something went wrong.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDTO category)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _categoryService.UpdateCategory(category);

                if (data == null)
                {
                    _logger.LogWarning("Category not found.");
                    return NotFound("Category not found.");
                }

                _logger.LogInformation("Category Updated Successfully.");

                return Ok(data);
            }

            catch (Exception ex) {
                _logger.LogError(ex, "Error while updating category.");

                return StatusCode(500, "Something went wrong.");
            }

            
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var data = await _categoryService.GetCategories();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");

                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = await _categoryService.GetCategoryById(id);

                _logger.LogInformation("Category Retrieved Successfully.");

                if (data == null)
                {
                    return NotFound("Category not found.");
                }

                return Ok(data);
            }

            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error while retrieving category.");

                return StatusCode(500, "Something went wrong.");
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var data = await _categoryService.GetCategoryById(id);

                if (data == null)
                {
                    return NotFound("Category not found.");
                }
                var result = await _categoryService.DeleteCategory(id);
                _logger.LogInformation("Category Deleted Successfully.");
                return NoContent();
            }

            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error while deleting the category");

                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
