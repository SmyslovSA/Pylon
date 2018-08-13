using System;

namespace Pylon.Models
{
	public class OrderFilterModel
	{
		public string Id { get; set; }

		public string ProductName { get; set; }

		public string ProductModel { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }
	}
}
