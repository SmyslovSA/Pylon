using Microsoft.AspNet.Identity;
using Pylon.BL.Interface;
using Pylon.DAL;
using Pylon.DAL.Interface;
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
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await SetInitialData(new List<string> { "admin", "customer", "saler" });
               // await _unitOfWork.UserManager.AddToRoleAsync(user.Id, "admin");
                await _unitOfWork.UserManager.AddToRoleAsync(user.Id, "saler");
                await _unitOfWork.UserManager.AddToRoleAsync(user.Id, "customer");
                // создаем профиль клиента
                Profile clientProfile = new Profile { Id = user.Id, FirstName = userDto.FirstName, LastName = userDto.LastName };
                _unitOfWork.ProfileManager.Create(clientProfile);
                await _unitOfWork.SaveChanges();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            User user = await _unitOfWork.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await _unitOfWork.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
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
