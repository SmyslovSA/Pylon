using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pylon.BL.Interface
{
	public interface IAdminService
	{
		ICollection<UserDTO> GetAll();
		Task AddRole(string id, string role);
		Task RemoveRole(string id, string role);
		void BlockUser(string id);
		void UnBlockUser(string id);
		void DeleteUser(string id);
	}
}
