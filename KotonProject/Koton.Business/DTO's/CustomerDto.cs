using Koton.Entities.Enums;
using Koton.Entities.Models;


namespace Koton.Business.DTO_s
{
    public class CustomerDto : BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime CustomerBirthday { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerAdress { get; set; }
        public Gender Gender { get; set; }
       
    }
}
