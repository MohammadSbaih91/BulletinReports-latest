using BulletinReport.Common.DTOs;

using GCAP.DAL.Entities;
using GCAP.DAL.Repositories;

using System.Collections.Generic;
using System.Linq;

namespace GCAP.DAL.CustomRepositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(GCAPUnitOfWork uow) : base(uow) { }
        //public List<UsersDTO> GetDepartmentUsers(int? departmentId)
        //{
        //    List<UsersDTO> users = new List<UsersDTO>();

        //    if (departmentId != null)
        //    {
        //        var department = _uow.Departments.GetAll()
        //            .Where(d => d.ID == departmentId)
        //            .Select(d => new
        //            {
        //                ProsPresidentGroup = d.PrefixName + "_President"
        //            })
        //            .FirstOrDefault();

        //        if (department != null)
        //        {
        ////            users = _uow.Users.GetAll()
        ////                .Where(u => u.Deleted != 1 && (u.Department == departmentId || u.Department == null) &&
        ////                            _uow.Departments.GetAll().Any(d => d.ID == u.Department && d.Name == department.ProsPresidentGroup))
        ////                .Select(u => new UsersDTO
        ////                {
        ////                    ADGroupsList = u.ADGroupsList,
        ////                    Assistant = u.Assistant,
        ////                    AttSearchFilter = u.AttSearchFilter,
        ////                    CorrespDefaultGroup = u.CorrespDefaultGroup,
        ////                    DefaultGroup = u.DefaultGroup,
        ////                    Deleted = u.Deleted,
        ////                    Department = u.Department,
        ////                    EmpCode = u.EmpCode,
        ////                    GroupID = u.GroupID,
        ////                    HRID = u.HRID,
        ////                    HR_EmployeeTitle = u.HR_EmployeeTitle,
        ////                    HR_EmploymentStatusID = u.HR_EmploymentStatusID,
        ////                    ID = u.ID,
        ////                    LogonName = u.LogonName,
        ////                    Name = u.Name,
        ////                    PhoneExt = u.PhoneExt,
        ////                    PoliceOfficeID = u.PoliceOfficeID,
        ////                    Rank = u.Rank,
        ////                    RankOrder = u.RankOrder,
        ////                    RfidEnabled = u.RfidEnabled,
        ////                    Role = u.Role,
        ////                    RoleID = u.RoleID,
        ////                    SearchFilter = u.SearchFilter,
        ////                    SectionID = u.SectionID
        ////                }).ToList();
        ////        }
        ////    }
        ////    else
        //////    {
        //////        users = _uow.Users.GetAll()
        //////            .Where(x => x.Department != null && x.Deleted != 1 &&
        //////                        _uow.Departments.GetAll().Any(d => d.ID == x.Department && d.Name == d.PrefixName + "_President"))
        //////            .Select(u => new UsersDTO
        //////            {
        //////                ADGroupsList = u.ADGroupsList,
        //////                Assistant = u.Assistant,
        //////                AttSearchFilter = u.AttSearchFilter,
        //////                CorrespDefaultGroup = u.CorrespDefaultGroup,
        //////                DefaultGroup = u.DefaultGroup,
        //////                Deleted = u.Deleted,
        //////                Department = u.Department,
        //////                EmpCode = u.EmpCode,
        //////                GroupID = u.GroupID,
        //////                HRID = u.HRID,
        //////                HR_EmployeeTitle = u.HR_EmployeeTitle,
        //////                HR_EmploymentStatusID = u.HR_EmploymentStatusID,
        //////                ID = u.ID,
        //////                LogonName = u.LogonName,
        //////                Name = u.Name,
        //////                PhoneExt = u.PhoneExt,
        //////                PoliceOfficeID = u.PoliceOfficeID,
        //////                Rank = u.Rank,
        //////                RankOrder = u.RankOrder,
        //////                RfidEnabled = u.RfidEnabled,
        //////                Role = u.Role,
        //////                RoleID = u.RoleID,
        //////                SearchFilter = u.SearchFilter,
        //////                SectionID = u.SectionID
        //////            }).ToList();
        //////    }

        //////    return users;
        //////}


        public List<UsersDTO> GetDepartmentUsers(int? departmentId)
        {
            List<UsersDTO> users = new List<UsersDTO>();

            if (departmentId == null)
            {
                users = _uow.Users.GetAll()
                    .Where(x => x.Department != null && x.Deleted != 1)
                    .Select(u => new UsersDTO
                    {
                        ADGroupsList = u.ADGroupsList,
                        Assistant = u.Assistant,
                        AttSearchFilter = u.AttSearchFilter,
                        CorrespDefaultGroup = u.CorrespDefaultGroup,
                        DefaultGroup = u.DefaultGroup,
                        Deleted = u.Deleted,
                        Department = u.Department,
                        EmpCode = u.EmpCode,
                        GroupID = u.GroupID,
                        HRID = u.HRID,
                        HR_EmployeeTitle = u.HR_EmployeeTitle,
                        HR_EmploymentStatusID = u.HR_EmploymentStatusID,
                        ID = u.ID,
                        LogonName = u.LogonName,
                        Name = u.Name,
                        PhoneExt = u.PhoneExt,
                        PoliceOfficeID = u.PoliceOfficeID,
                        Rank = u.Rank,
                        RankOrder = u.RankOrder,
                        RfidEnabled = u.RfidEnabled,
                        Role = u.Role,
                        RoleID = u.RoleID,
                        SearchFilter = u.SearchFilter,
                        SectionID = u.SectionID
                    }).ToList();
            }
            else
            {
                users = _uow.Users.GetAll()
                    .Where(u => u.Deleted != 1 && (u.Department == departmentId || u.Department == null))
                    .Select(u => new UsersDTO
                    {
                        ADGroupsList = u.ADGroupsList,
                        Assistant = u.Assistant,
                        AttSearchFilter = u.AttSearchFilter,
                        CorrespDefaultGroup = u.CorrespDefaultGroup,
                        DefaultGroup = u.DefaultGroup,
                        Deleted = u.Deleted,
                        Department = u.Department,
                        EmpCode = u.EmpCode,
                        GroupID = u.GroupID,
                        HRID = u.HRID,
                        HR_EmployeeTitle = u.HR_EmployeeTitle,
                        HR_EmploymentStatusID = u.HR_EmploymentStatusID,
                        ID = u.ID,
                        LogonName = u.LogonName,
                        Name = u.Name,
                        PhoneExt = u.PhoneExt,
                        PoliceOfficeID = u.PoliceOfficeID,
                        Rank = u.Rank,
                        RankOrder = u.RankOrder,
                        RfidEnabled = u.RfidEnabled,
                        Role = u.Role,
                        RoleID = u.RoleID,
                        SearchFilter = u.SearchFilter,
                        SectionID = u.SectionID
                    }).ToList();
            }

            return users;
        }
        public UsersDTO GetUserByUserId(int UserId)
        {
            var user = new UsersDTO();

            user = GetQuerable(x => x.ID == UserId).Select(u => new UsersDTO()
            {

                ID = u.ID,
                ADGroupsList = u.ADGroupsList,
                Assistant = u.Assistant,
                AttSearchFilter = u.AttSearchFilter,
                CorrespDefaultGroup = u.CorrespDefaultGroup,
                DefaultGroup = u.DefaultGroup,
                Deleted = u.Deleted,
                Department = u.Department,
                EmpCode = u.EmpCode,
                GroupID = u.GroupID,
                HRID = u.HRID,
                HR_EmployeeTitle = u.HR_EmployeeTitle,
                HR_EmploymentStatusID = u.HR_EmploymentStatusID,
                LogonName = u.LogonName,
                Name = u.Name,
                PhoneExt = u.PhoneExt,
                PoliceOfficeID = u.PoliceOfficeID,
                Rank = u.Rank,
                RankOrder = u.RankOrder,
                RfidEnabled = u.RfidEnabled,
                Role = u.Role,
                RoleID = u.RoleID,
                SearchFilter = u.SearchFilter,
                SectionID = u.SectionID,
            }).FirstOrDefault();


            return user;

        }
    }
}
