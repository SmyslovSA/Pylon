using System;

namespace Pylon.DAL
{
    public class Order
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Count { get; set; }
    }
}
