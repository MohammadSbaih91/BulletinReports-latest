using BulletinReport.Common.DTOs.LookupsDTO;
using BulletinReport.DAL.Entities;
using BulletinReport.DAL.Repositories;

using System.Linq;

namespace BulletinReport.DAL.CustomRepositories
{
    public class LookupRepository : Repository<Lookup>
    {
        public LookupRepository(UnitOfWork uow) : base(uow) { }
        public int GetLookupIDByCode(string code)
        {

            var record = GetQuerable(l => l.LookupCode == code).Select(x => new { x.Id }).SingleOrDefault();

            if (record == null)
            {
                return -1;
            }

            return record.Id;
        }

        public LookupsDTO GetLookupValueAndIDByCode(string code)
        {
            var arabicCultureLookupID = GetLookupIDByCode(code);
            var englishCultureLookupID = GetLookupIDByCode(code);

            var query = from look in _db.Lookups
                        join lookCul in _db.LookupCultures
                        on look.Id equals lookCul.LookupID
                        where look.LookupCode == code
                        select new LookupsDTO()
                        {
                            Id = look.Id,
                            ValueAr = look.LookupCultures.Where(x => x.LookupID == arabicCultureLookupID).FirstOrDefault().Value,
                            ValueEn = look.LookupCultures.Where(x => x.LookupID == englishCultureLookupID).FirstOrDefault().Value,

                        };

            var result = query.FirstOrDefault();

            return result;

        }


        public LookupsDTO GetLookupByLookupId(int Id)
        {
            var arabicCultureLookupID = Id;
            var englishCultureLookupID = Id + 1;

            var query = from look in _db.Lookups
                        join lookCul in _db.LookupCultures
                        on look.Id equals lookCul.LookupID
                        where look.Id == Id
                        select new LookupsDTO()
                        {
                            Id = look.Id,
                            ValueAr = look.LookupCultures.Where(x => x.LookupID == arabicCultureLookupID).FirstOrDefault().Value,
                            ValueEn = look.LookupCultures.Where(x => x.LookupID == englishCultureLookupID).FirstOrDefault().Value,

                        };

            var result = query.FirstOrDefault();

            return result;

        }

        public LookupsDTO GetLookupByID(int ID)
        {
            var query = from look in _db.Lookups
                        join lookCul in _db.LookupCultures
                        on look.Id equals lookCul.LookupID
                        where look.Id == ID
                        select new LookupsDTO()
                        {
                            Id = look.Id,
                            ValueAr = look.LookupCultures.Where(x => x.LookupID == ID).FirstOrDefault().Value,
                            ValueEn = look.LookupCultures.Where(x => x.LookupID == ID && x.CultureID == 2).FirstOrDefault().Value,
                        };

            var result = query.FirstOrDefault();

            return result;

        }




    }
}
