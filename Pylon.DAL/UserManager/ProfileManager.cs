using Pylon.DAL.Context;
using Pylon.DAL.Interface;

namespace Pylon.DAL.UserManager
{
    public class ProfileManager : IProfileManager
    {
        private PylonContext _pylonContext;

        public ProfileManager(PylonContext context)
        {
            _pylonContext = context;
        }

        public void Create(Profile profile)
        {
            _pylonContext.Profile.Add(profile);
            _pylonContext.SaveChanges();
        }

        public void Dispose()
        {
            _pylonContext.Dispose();
        }
    }
}
