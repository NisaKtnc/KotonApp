using AutoMapper;
using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Koton.DAL.Abstract;

namespace Koton.Business.Concrete
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        public FileService(IMapper mapper, IFileRepository fileRepository)
        {
            this._fileRepository = fileRepository;
            this._mapper = mapper;
        }

        public async Task<Entities.Models.File> AddFile(FileDto fileDto)
        {
            var file = _mapper.Map<Koton.Entities.Models.File>(fileDto);
            return await _fileRepository.AddAsync(file);
        }

       
    }
}
