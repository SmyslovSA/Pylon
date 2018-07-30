using System.ComponentModel.DataAnnotations;

namespace Pylon.Website.Models
{
    public class ProfileViewModel
    {   
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}