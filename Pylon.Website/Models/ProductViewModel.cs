using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pylon.Website.Models
{
    public class ProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Maker { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int PartNumber { get; set; }
    }
}