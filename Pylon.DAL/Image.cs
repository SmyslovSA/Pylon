using System.Collections.Generic;

namespace Pylon.DAL
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
