using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylon.BL
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public int PartNumber { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Maker { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public string ProfileID { get; set;}
    }
}
