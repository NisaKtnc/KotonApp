using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("AddFile")]
        public async Task<Koton.Entities.Models.File> AddFiles(FileDto fileDto)
        {
            return await _fileService.AddFile(fileDto);

        }
    }
}
