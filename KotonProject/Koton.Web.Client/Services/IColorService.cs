using Koton.Entities.Models;

namespace Koton.Web.Client.Services
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> GetAllColorAsync();

    }
}
