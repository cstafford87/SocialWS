using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialWS.EF.DomainEntities;

namespace SocialWS.EF.DataLayer.Context
{
    public class UserContext: DbContext 
    {
        public UserContext() : base()
        {
            
        }

        public DbSet<User> CreateNewUser { get; set; }
    }
}
