using System;

namespace Pylon.BL
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        public string ProductName { get; set; }

        public string ProductModel { get; set; }

        public decimal ProductPrice { get; set; }

		public byte[] ProductImage { get; set; }

		public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProductId { get; set; }

        public string ProfileId { get; set; }
	}
}
