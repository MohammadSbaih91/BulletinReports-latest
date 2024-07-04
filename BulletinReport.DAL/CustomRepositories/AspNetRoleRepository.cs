using BulletinReport.DAL.Entities;
using BulletinReport.DAL.Repositories;

using System.Collections.Generic;
using System.Linq;

namespace BulletinReport.DAL.CustomRepositories
{
    public class AspNetRoleRepository : Repository<AspNetRole>
    {
        public AspNetRoleRepository(UnitOfWork uow) : base(uow) { }

        public List<string> GetRolesByUserName(string userName)
        {
            List<string> roles;


            roles = GetQuerable(u => u.AspNetUsers.Any(x => x.UserName == userName)).Select(x => x.Name)
                   .ToList();
            return roles;
        }
        public AspNetRole GetByName(string userRole)
        {
            AspNetRole roles;

            roles = GetQuerable(u => u.Name == userRole).FirstOrDefault();
            return roles;
        }


    }
}
