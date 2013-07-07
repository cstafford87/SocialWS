using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SocialWS.EF.DataLayer.Repositorys;
using SocialWS.EF.DomainEntities;
using SocialWS.EF.UserData;

namespace SocialWS.EF.DataLayer.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
            
        }
        public void RegisterNewUser(UserRegistration user)
        {

            var newUser = new User
                {
                    UserId = Guid.NewGuid(),
                    EmailAddress = user.EmailAddress,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                    UserName = user.UserName
                };
            IUserRepository repo = new UserRepository();

            repo.RegisterNewUser(newUser);            
        }

        public bool VerifyNewUser(Guid registrationKey)
        {
            var registrationKeyActual = Guid.Parse("3BCA3E75-1FC7-4DDC-9304-1CC80D6FF611");

            return registrationKey == registrationKeyActual;
        }

        public User UserLoginRequest(string userName, string password)
        {
            IUserRepository repo = new UserRepository();

            var user = repo.GetUserByUsernamePassword(userName, password);

            return user;
        }

        public bool CheckUsernameExists(string username)
        {
            IUserRepository repo = new UserRepository();
            var exists = repo.CheckUserExists(username);

            return exists;
        }
    }
}
