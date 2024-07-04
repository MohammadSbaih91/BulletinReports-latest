using BulletinReport.Common.DTOs;

using GCAP.DAL.Entities;
using GCAP.DAL.Repositories;

using System.Collections.Generic;
using System.Linq;

namespace GCAP.DAL.CustomRepositories
{
    public class CodingTablesDataRepository : Repository<CodingTablesData>
    {
        public CodingTablesDataRepository(GCAPUnitOfWork uow) : base(uow) { }

        //Nationality
        public List<NationalitiesDTO> GetAllCodingTablesData()
        {

            var nationalities = GetQuerable(x => x.ID > 0 && x.CodeTableID == 2).Select(u => new BulletinReport.Common.DTOs.NationalitiesDTO()
            {
                ID = u.ID,
                CodeTableID = u.CodeTableID,
                Description = u.Description

            }).ToList();
            return nationalities;
        }

        public string GetNationalityById(int Id)
        {
            var nationalities = GetQuerable(x => x.ID == Id).FirstOrDefault().Description;
            return nationalities;

        }



    }
}
