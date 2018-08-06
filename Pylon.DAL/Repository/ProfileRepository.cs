using Pylon.DAL.Context;
using Pylon.DAL.Interface;
using Pylon.DAL.Models;

namespace Pylon.DAL.UserManager
{
    public class ProfileRepository : BaseRepository<Profile>,IProfileRepository
    {
        private PylonContext _pylonContext;

        public ProfileRepository(PylonContext context) : base(context)
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
