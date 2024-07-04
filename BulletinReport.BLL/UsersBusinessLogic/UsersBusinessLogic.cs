using BulletinReport.Common.DTOs;

using GCAP.DAL;

using System.Collections.Generic;

namespace BulletinReport.BLL.UsersBusinessLogic
{
    public class UsersBusinessLogic
    {
        public List<UsersDTO> GetDepartmentUsers(int? DepartmentId)
        {
            List<UsersDTO> users = new List<UsersDTO>();

            using (var uow = new GCAPUnitOfWork())
            {
                users = uow.Users.GetDepartmentUsers(DepartmentId);
                return users;
            }
        }
        public List<UsersDTO> GetUserById(int DepartmentId)
        {
            List<UsersDTO> users = new List<UsersDTO>();

            using (var uow = new GCAPUnitOfWork())
            {
                users = uow.Users.GetDepartmentUsers(DepartmentId);
                return users;
            }
        }

        public UsersDTO GetUserByUserId(string UserId)
        {
            UsersDTO user = new UsersDTO();
            int userId = 0;
            userId = int.Parse(UserId);
            using (var uow = new GCAPUnitOfWork())
            {
                user = uow.Users.GetUserByUserId(userId);
                return user;
            }
        }
        public List<NationalitiesDTO> GetAllCodingTablesData()
        {
            List<NationalitiesDTO> Nationalities = new List<NationalitiesDTO>();

            using (var uow = new GCAPUnitOfWork())
            {
                Nationalities = uow.CodingTablesData.GetAllCodingTablesData();
                return Nationalities;
            }
        }
        public string GetNationalityById(int Id)
        {

            using (var uow = new GCAPUnitOfWork())
            {
                return uow.CodingTablesData.GetNationalityById(Id);
            }
        }

    }
}
