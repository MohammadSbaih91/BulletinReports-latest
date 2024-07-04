using BulletinReport.Common;
using BulletinReport.Common.DTOs.DepartmentDTO;
using BulletinReport.Common.Exceptions;

using GCAP.DAL;

using System.Collections.Generic;

namespace BulletinReport.BLL.DepartmentsBusinessLogic
{
    public class DepartmentsBusinessLogic
    {
        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            using (GCAPUnitOfWork GCAPuow = new GCAPUnitOfWork())
            {
                var repo = GCAPuow.Departments;
                var departments = repo.GetAllDepartments();
                if (departments == null)
                {
                    throw new BusinessException("departments does not exist", Constants.ErrorsCodes.LookupDoesNotExist);
                }
                else
                {
                    return departments;
                }
            }
        }
    }
}
