using Pylon.BL.Interface;
using Pylon.DAL.Interface;
using Pylon.DAL.UserManager;

namespace Pylon.BL.Sevices
{
    public class ProfileService : IProfileService
    {
        private IUnitOfWork _unitOfWork;
        private readonly PylonUserManager _userManager;
 
        public ProfileService(IUnitOfWork unitOfWork, PylonUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public UserDTO GetProfile(string id)
        {
            var profile = _unitOfWork.ProfileManager.GetById(id);
            return AutoMapper.Mapper.Map<UserDTO>(profile);
        }

        public void ChangePassword(string id,string newPassword, string newPasswordConfirm)
        {
            var profile =  _unitOfWork.ProfileManager.GetById(id);
            //TODO: password validate method
            profile.User.PasswordHash = _userManager.PasswordHasher.HashPassword(newPassword);
            _unitOfWork.ProfileManager.Update(profile);
            _unitOfWork.SaveChanges();
        }

        public void ChangePersonalData(UserDTO user)
        {
            var profile = _unitOfWork.ProfileManager.GetById(user.Id);
            //TODO: user data validate
            profile.FirstName = user.FirstName;
            profile.LastName = user.LastName;
            profile.Phone = user.Phone;
            profile.CompanyName = user.CompanyName;
            _unitOfWork.ProfileManager.Update(profile);
            _unitOfWork.SaveChanges();
        }
    }
}
