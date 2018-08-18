using System.ComponentModel.DataAnnotations;

namespace Pylon.Models
{
    public class ProductViewModel
    {
		public int Id { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				  ErrorMessageResourceName = "CarRequired")]
		[Display(Name = "Car", ResourceType = typeof(Resources.Resource))]
		public string Name { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				  ErrorMessageResourceName = "PriceRequired")]
		[Display(Name = "Price", ResourceType = typeof(Resources.Resource))]
		public decimal Price { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				  ErrorMessageResourceName = "ModelRequired")]
		[Display(Name = "Model", ResourceType = typeof(Resources.Resource))]
		public string CarModel { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
				  ErrorMessageResourceName = "YearRequired")]
		[Display(Name = "Year", ResourceType = typeof(Resources.Resource))]
		public int Year { get; set; }

        public string Fuel { get; set; }

		public string ImageMimeType { get; set; }

		public byte[] ImageData { get; set; }
	}
}