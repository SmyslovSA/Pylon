using Pylon.BL.ModelsDTO;
using System.Collections.Generic;

namespace Pylon.BL
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public string Fuel { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public string ProfileID { get; set;}

		public string ImageMimeType { get; set; }

		public byte[] ImageData { get; set; }

		public List<DateDTO> Orders { get; set; }
	}
}
