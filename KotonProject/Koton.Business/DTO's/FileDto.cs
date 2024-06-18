using Koton.Entities.Models;

namespace Koton.Business.DTO_s
{
    public class FileDto : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public string ContentPath { get; set; }
        public int ProductId { get; set; }  
    }
}
