using Koton.Entities.Models;

namespace Koton.Web.Client.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
