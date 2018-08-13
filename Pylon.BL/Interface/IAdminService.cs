using System.Collections.Generic;

namespace Pylon.BL.Interface
{
	public interface IAdminService
	{
		ICollection<UserDTO> GetAll();
		void AddRole(string id, string role);
		void RemoveRole(string id, string role);
		void BlockUser(string id);
		void UnBlockUser(string id);
		void DeleteUser(string id);
	}
}
