using Koton.Business.DTO_s;
using Koton.Entities.Models;


namespace Koton.Business.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Entities.Models.Category> GetCategoryById(int Id);
        Task<Category> AddCategory(CategoryDto categoryDto);
        Task<Entities.Models.Category> DeleteCategoryById(int Id);
        Task<Category> UpdateCategory(CategoryDto categoryDto);
    }
}
