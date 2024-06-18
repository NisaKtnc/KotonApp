
namespace Koton.Entities.Models
{
    public class File : BaseEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Extension { get; set; }
        public string ContentType { get; set; } 
        public byte[] Content { get; set; }
        public string ContentPath { get; set; }
    }
}
