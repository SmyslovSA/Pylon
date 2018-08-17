using System.ComponentModel.DataAnnotations;

namespace Pylon.Models
{
    public class RegisterModel
    {
		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
					ErrorMessageResourceName = "EmailRequired")]
		[Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
		public string Email { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				   ErrorMessageResourceName = "PasswordRequired")]
		[Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
		[DataType(DataType.Password)]
        public string Password { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				   ErrorMessageResourceName = "PasswordConfirmRequired")]
		[Display(Name = "PasswordConfirm", ResourceType = typeof(Resources.Resource))]
		[DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				  ErrorMessageResourceName = "NameRequired")]
		[Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
		public string FirstName { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				  ErrorMessageResourceName = "LastNameRequired")]
		[Display(Name = "LastName", ResourceType = typeof(Resources.Resource))]
        public string LastName { get; set; }
    }
}