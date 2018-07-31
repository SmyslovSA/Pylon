using System;

namespace Pylon.DAL
{
    public class Order
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Profile Profile { get; set; }

        public string ProfileId { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
