﻿using Microsoft.AspNet.Identity;
using Pylon.BL.Interface;
using Pylon.DAL.Interface;
using Pylon.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pylon.BL
{
    class UserService : IUserService
    {
        IUnitOfWork _unitOfWork { get; set; }

        public UserService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            var user = _unitOfWork.UserManager?.FindByEmail(userDto.Email);
            if (user == null)
            {
                user = new User { Email = userDto.Email, UserName = userDto.Email };
                var result = await _unitOfWork.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, LogicResource.BLResource.RegistrationFailedPassword, "");
                // добавляем роль
                await SetInitialData(new List<string> { "admin", "customer", "saler" });
               await _unitOfWork.UserManager.AddToRoleAsync(user.Id, "admin");
               // await _unitOfWork.UserManager.AddToRoleAsync(user.Id, "saler");
               // await _unitOfWork.UserManager.AddToRoleAsync(user.Id, "customer");
                // создаем профиль клиента
                Profile clientProfile = new Profile { Id = user.Id, FirstName = userDto.FirstName, LastName = userDto.LastName, IsBlocked = false, IsDeleted = false, Phone = userDto.Phone};
                _unitOfWork.ProfileManager.Insert(clientProfile);
                _unitOfWork.SaveChanges();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, LogicResource.BLResource.RegistrationFailedEmail, "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
			// находим пользователя
			User user = await _unitOfWork.UserManager.FindAsync(userDto.Email, userDto.Password);
			// авторизуем его и возвращаем объект ClaimsIdentity
			if (user != null)
			{
				var profile = _unitOfWork.ProfileManager.GetById(user.Id);
				if (profile.IsDeleted == true || profile.IsBlocked == true)
				{
					return new ClaimsIdentity();
				}
				claim = await _unitOfWork.UserManager.CreateIdentityAsync(
						user, DefaultAuthenticationTypes.ApplicationCookie);
			}
            return claim;
        }

        // начальная инициализация бд
        private async Task SetInitialData(List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await _unitOfWork.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new Role { Name = roleName };
                    await _unitOfWork.RoleManager.CreateAsync(role);
                }
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
