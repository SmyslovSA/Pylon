using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylon.BL.Interface
{
	public interface IAdminService
	{
		ICollection<UserDTO> GetAll();
		Task AddRole(string id, string role);
		Task RemoveRole(string id, string role);
	}
}
