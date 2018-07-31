using System;

namespace Pylon.BL
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public string ProductMaker { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProductId { get; set; }

        public string ProfileId { get; set; }
    }
}
