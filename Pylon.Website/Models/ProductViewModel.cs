using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Pylon.Website.Models
{
    public class ProductViewModel
    {
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }

		[Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string CarModel { get; set; }

		[Required]
		public int Year { get; set; }

        public string Fuel { get; set; }
	}
}