using System;

namespace Pylon.DAL.Interface
{
    public interface IProfileManager : IDisposable
    {
        void Create(Profile profile);
    }
}
