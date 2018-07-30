namespace Pylon.BL.Interface
{
    public interface IProfileService
    {
        UserDTO GetProfile(string id);
        void ChangePassword(string id,string newPassword, string newPasswordConfirm);
        void ChangePersonalData(UserDTO user);
    }
}
