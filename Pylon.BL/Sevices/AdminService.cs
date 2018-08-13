using Pylon.BL.Interface;
using Pylon.DAL.Interface;
using System.Collections.Generic;

namespace Pylon.BL.Sevices
{
	public class AdminService : IAdminService
	{
		private readonly IUnitOfWork _unitOfWork;

		public AdminService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public ICollection<UserDTO> GetAll()
		{
			var list = _unitOfWork.ProfileManager.Get();
			var profiles =  AutoMapper.Mapper.Map<List<UserDTO>>(list);
			foreach (var user in profiles)
			{
				user.UserRoles = _unitOfWork.UserManager.GetRolesAsync(user.Id);
				user.UserRoles.Wait();
				var roles = _unitOfWork.RoleManager.Roles;
				foreach (var role in roles)
				{
					user.Roles.Add(role.Name);
				}
			}
			return profiles;
		}

		public void AddRole(string id, string role)
		{
			_unitOfWork.UserManager.AddToRoleAsync(id, role).Wait();
		}

		public void RemoveRole(string id, string role)
		{
			_unitOfWork.UserManager.RemoveFromRoleAsync(id, role).Wait();
		}

		public void BlockUser(string id)
		{
			var user = _unitOfWork.ProfileManager.GetById(id);
			user.IsBlocked = true;
			_unitOfWork.ProfileManager.Update(user);
			_unitOfWork.SaveChanges();
		}

		public void UnBlockUser(string id)
		{
			var user = _unitOfWork.ProfileManager.GetById(id);
			user.IsBlocked = false;
			_unitOfWork.ProfileManager.Update(user);
			_unitOfWork.SaveChanges();
		}

		public void DeleteUser(string id)
		{
			var user = _unitOfWork.ProfileManager.GetById(id);
			user.IsDeleted = true;
			_unitOfWork.ProfileManager.Update(user);
			_unitOfWork.SaveChanges();
		}
	}
}
