using System.Linq;
using SocialWS.EF.DomainEntities;

namespace SocialWS.EF.DataLayer.Repositorys
{
    public interface IUserRepository
    {
        void RegisterNewUser(User user);

        User GetUserByUsernamePassword(string userName, string password);

        bool CheckUserExists(string userName);
    }
}