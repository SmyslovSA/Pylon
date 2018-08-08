using Pylon.BL.Interface;
using Pylon.DAL.Interface;
using Pylon.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
			return AutoMapper.Mapper.Map<List<UserDTO>>(list);
		}

		public async Task AddRole(string id, string role)
		{
			await _unitOfWork.UserManager.AddToRoleAsync(id, role);
		}

		public async Task RemoveRole(string id, string role)
		{
			await _unitOfWork.UserManager.RemoveFromRoleAsync(id, role);
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
