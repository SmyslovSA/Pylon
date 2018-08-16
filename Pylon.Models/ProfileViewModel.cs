using System.ComponentModel.DataAnnotations;

namespace Pylon.Models
{
    public class ProfileViewModel
    {   
		[Required]
        public string FirstName { get; set; }

		[Required]
        public string LastName { get; set; }

		[Required(ErrorMessage = "Phone Number is required.")]
		public string Phone { get; set; }

		public string ImageMimeType { get; set; }

		public byte[] ImageData { get; set; }

		//[Required]
		//[DataType(DataType.Password)]
		//[StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		//[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Your Password doesn't strong enough")]
		//public string Password { get; set; }

		//[Required]
		//[DataType(DataType.Password)]
		//[Compare("Password")]
		//public string ConfirmPassword { get; set; }
	}
}