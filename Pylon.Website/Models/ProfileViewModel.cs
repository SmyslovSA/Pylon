using System.ComponentModel.DataAnnotations;

namespace Pylon.Website.Models
{
    public class ProfileViewModel
    {   
		[Required]
        public string FirstName { get; set; }

		[Required]
        public string LastName { get; set; }

		[Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}