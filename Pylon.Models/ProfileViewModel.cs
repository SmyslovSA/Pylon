using System.ComponentModel.DataAnnotations;

namespace Pylon.Models
{
    public class ProfileViewModel
    {   
		[Required]
        public string FirstName { get; set; }

		[Required]
        public string LastName { get; set; }

		[Display(Name = "Phone Number:")]
		[Required(ErrorMessage = "Phone Number is required.")]
		[RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{2})[-. ]?([0-9]{2})$", ErrorMessage = "Invalid Phone Number.")]
		public string Phone { get; set; }
    }
}