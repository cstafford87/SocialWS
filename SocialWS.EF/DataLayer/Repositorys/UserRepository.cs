using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SocialWS.EF.DataLayer.Context;
using SocialWS.EF.DomainEntities;

namespace SocialWS.EF.DataLayer.Repositorys
{
    public class UserRepository : IUserRepository
    {
        public void RegisterNewUser(User user)
        {
            using (var db = new UserContext())
            {
                db.CreateNewUser.Add(user);
                db.SaveChanges();
            }
        }

        public User GetUserByUsernamePassword(string userName, string password)
        {
            using (var db = new UserContext())
            {
                var query = (from user in db.CreateNewUser
                            where user.UserName == userName &&
                                  user.Password == password
                            select user).FirstOrDefault();
                return query;
            }
        }

        public bool CheckUserExists(string userName)
        {
            using (var db = new UserContext())
            {
                var query = (from user in db.CreateNewUser
                             where userName == user.UserName
                             select user).Count();
                return query > 0;
            }         
        }
    }
}
