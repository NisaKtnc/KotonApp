using Koton.Business.DTO_s;
using Koton.Entities.Models;



namespace Koton.Business.Abstract
{
    public interface IFileService
    {
        //Task<IEnumerable<List<Entities.Models.File>>> GetAllFilesAsync();
        //Task<List<Entities.Models.File>> GetFileById(int Id);
        Task<Entities.Models.File> AddFile(FileDto fileDto);
        //Task<List<Entities.Models.File>> DeleteFileById(int Id);
        //Task<List<Entities.Models.File>> UpdateFile(ProductDto productDto);

    }
}
