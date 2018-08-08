namespace Pylon.Models
{
	public class ProductFilterModel
	{
		public string Name { get; set; }

		public decimal MinPrice { get; set; }

		public decimal MaxPrice { get; set; }

		public string CarModel { get; set; }
		
		public int MinYear { get; set; }

		public int MaxYear { get; set; }

		public string Fuel { get; set; }
	}
}
