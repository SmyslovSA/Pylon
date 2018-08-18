using System.ComponentModel.DataAnnotations;

namespace Pylon.Models
{
    public class ProfileViewModel
    {
		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				  ErrorMessageResourceName = "NameRequired")]
		[Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
		public string FirstName { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				  ErrorMessageResourceName = "LastNameRequired")]
		[Display(Name = "LastName", ResourceType = typeof(Resources.Resource))]
		public string LastName { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				  ErrorMessageResourceName = "PhoneRequired")]
		[Display(Name = "Phone", ResourceType = typeof(Resources.Resource))]
		public string Phone { get; set; }

		public string ImageMimeType { get; set; }

		public byte[] ImageData { get; set; }
	}
}