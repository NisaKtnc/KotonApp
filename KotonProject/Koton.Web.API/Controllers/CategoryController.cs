using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetAllCategories")]
        public async Task<IEnumerable<Koton.Entities.Models.Category>> GetAllCategories()
        {
            var get = await _categoryService.GetAllCategoryAsync();
            return get;
           
        }
        [HttpGet("GetById")]
        public async Task<Koton.Entities.Models.Category> GetById(int Id)
        {
            var get = await _categoryService.GetCategoryById(Id);

            return get;
        }

        [HttpPost("AddCategory")]
        public async Task<Koton.Entities.Models.Category> AddCategory(CategoryDto categoryDto)
        {
            return await _categoryService.AddCategory(categoryDto);

        }
        [HttpPost("DeleteById")]
        public async Task<Koton.Entities.Models.Category> DeleteCategoryById(int Id)
        {
            return await _categoryService.DeleteCategoryById(Id);
        }
        [HttpPut("UpdateCategory")]
        public async Task<Koton.Entities.Models.Category> UpdateCategory(CategoryDto categoryDto)
        {
            var update = await _categoryService.UpdateCategory(categoryDto);    
            return update;
        }
    }
}
