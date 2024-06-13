using Koton.Entities.Models;


namespace Koton.Business.Abstract
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> GetAllColorAsync();
    }
}
