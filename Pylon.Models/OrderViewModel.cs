using System;
using System.ComponentModel.DataAnnotations;

namespace Pylon.Models
{
    public class OrderViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}