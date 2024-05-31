using Koton.Entities.Models;

namespace Koton.Web.API.Models
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }

        public string CustomerUsername { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerGender { get; set; }
        public DateTime CustomerBirthday { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerAdress { get; set; }
          
    }
}
