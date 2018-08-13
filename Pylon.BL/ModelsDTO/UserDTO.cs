using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pylon.BL
{
    public class UserDTO 
    {
        public string Id { get; set; }

		public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

		public bool IsBlocked { get; set; }

		public bool IsDeleted { get; set; }

		public string ImageMimeType { get; set; }

		public byte[] ImageData { get; set; }

		public Task<IList<string>> UserRoles { get; set; }

		public List<string> Roles { get; set; } = new List<string>();
	}
}
