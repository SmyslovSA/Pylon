using System.Collections.Generic;

namespace Pylon.DAL
{
    public class Product
    {
        public int Id { get; set; }

        public int PartNumber { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Maker { get; set; }

        public decimal Price { get; set; }

        public List<Order> Orders { get; set; }

        public virtual Profile Profile { get; set; }

        public string ProfileId { get; set; }
    }
}
