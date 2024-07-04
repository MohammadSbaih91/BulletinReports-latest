using BulletinReport.Common.DTOs.DepartmentDTO;

using GCAP.DAL.Entities;
using GCAP.DAL.Repositories;

using System.Collections.Generic;
using System.Linq;

namespace GCAP.DAL.CustomRepositories
{
    public class PoliceOfficesRepository : Repository<PoliceOffice>
    {
        public PoliceOfficesRepository(GCAPUnitOfWork uow) : base(uow) { }


        public PoliceOffice GetPoliceOfficeById(int departmentId)
        {

            var policeOffice = GetQuerable(x => x.ID == departmentId).FirstOrDefault();
            return policeOffice;



        }




        public List<PoliceOfficeDTO> GetPoliceAllOffices()
        {

            var policeOffice = _uow.PoliceOffices.GetAll()
                 .Where(x => x.Active == true)
                 .Select(u => new PoliceOfficeDTO
                 {
                     Description = u.Description,
                     ID = u.ID
                 }).ToList();
            return policeOffice;



        }


    }
}
