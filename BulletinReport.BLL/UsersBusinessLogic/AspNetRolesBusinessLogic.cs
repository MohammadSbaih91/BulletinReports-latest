using BulletinReport.DAL;

using System.Collections.Generic;

namespace BulletinReport.BLL.UsersBusinessLogic
{
    public class AspNetRolesBusinessLogic
    {
        public List<string> GetRolesByUserName(string userName)
        {
            List<string> roles;
            //if (AppSettings.IsFrontEnd)
            //{
            using (var uow = new UnitOfWork())
            {
                roles = uow.Roles.GetRolesByUserName(userName);
                return roles;
            }
        }


    }
}
