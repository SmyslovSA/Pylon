﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pylon.DAL.Models
{
    public class Profile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string CompanyName { get; set; }

        public virtual User User { get; set; }

        public List<Product> Products { get; set; }

		public bool IsBlocked { get; set; }

		public bool IsDeleted { get; set; }

		public string ImageMimeType { get; set; }

		public byte[] ImageData { get; set; }
	}
}