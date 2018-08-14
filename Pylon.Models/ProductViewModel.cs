using System.ComponentModel.DataAnnotations;

namespace Pylon.Models
{
    public class ProductViewModel
    {
		public int Id { get; set; }

		[Required]
        public string Name { get; set; }

        [Required]
		[DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string CarModel { get; set; }

		[Required]
		public int Year { get; set; }

        public string Fuel { get; set; }

		public string ImageMimeType { get; set; }

		public byte[] ImageData { get; set; }
	}
}