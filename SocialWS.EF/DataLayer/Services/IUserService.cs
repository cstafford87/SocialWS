using System;
using SocialWS.EF.DomainEntities;
using SocialWS.EF.UserData;

namespace SocialWS.EF.DataLayer.Services
{
    public interface IUserService
    {
        void RegisterNewUser(UserRegistration user);

        bool VerifyNewUser(Guid registrationKey);

        User UserLoginRequest(string userName, string password);

        bool CheckUsernameExists(string username);
    }
}