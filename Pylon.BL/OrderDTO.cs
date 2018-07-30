using System;

namespace Pylon.BL
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Count { get; set; }
    }
}
