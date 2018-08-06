using System.Collections.Generic;

namespace Pylon.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public string Fuel { get; set; }

        public decimal Price { get; set; }

        public List<Order> Orders { get; set; }

        public virtual Profile Profile { get; set; }

        public string ProfileId { get; set; }

		public string ImageMimeType { get; set; }

		public byte[] ImageData { get; set; }
	}
}
