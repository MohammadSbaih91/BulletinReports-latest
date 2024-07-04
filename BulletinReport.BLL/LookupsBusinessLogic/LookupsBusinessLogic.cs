using BulletinReport.Common;
using BulletinReport.Common.DTOs.LookupsDTO;
using BulletinReport.Common.Exceptions;
using BulletinReport.DAL;

using System;

namespace BulletinReport.BLL.LookupsBusinessLogic
{
    public class LookupsBusinessLogic
    {

        public int GetLookupIDByCode(string code)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Lookups;
                var lookupID = repo.GetLookupIDByCode(code);

                if (lookupID == -1)
                {
                    throw new BusinessException("Lookup does not exist", Constants.ErrorsCodes.LookupDoesNotExist);
                }

                return lookupID;
            }
        }

        public LookupsDTO GetLookupValueAndIDByCode(string code, Enums.CultureID culture)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Lookups;
                var lookup = repo.GetLookupValueAndIDByCode(code);


                if (lookup == null)
                {
                    throw new BusinessException("Lookup does not exist", Constants.ErrorsCodes.LookupDoesNotExist);
                }

                return lookup;
            }
        }

        public LookupsDTO GetLookupByLookupCategoryCode(string code, Enums.CultureID culture)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Lookups;
                var lookup = repo.GetLookupValueAndIDByCode(code);
                if (culture == Enums.CultureID.Ar)
                {
                    lookup = new LookupsDTO()
                    {
                        Id = lookup.Id,
                        Value = lookup.ValueAr
                    };
                }
                else
                {
                    lookup = new LookupsDTO()
                    {
                        Id = lookup.Id,
                        Value = lookup.ValueEn
                    };
                }
                if (lookup == null)
                {
                    throw new BusinessException("Lookup does not exist", Constants.ErrorsCodes.LookupDoesNotExist);
                }

                return lookup;
            }
        }


        public LookupsDTO GetLookupByLookupCode(string code, Enums.Culture culture)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Lookups;
                var lookup = repo.GetLookupValueAndIDByCode(code);
                if (culture == Enums.Culture.Arabic)
                {
                    lookup = new LookupsDTO()
                    {
                        Id = lookup.Id,
                        Value = lookup.ValueAr
                    };
                }
                else
                {
                    lookup = new LookupsDTO()
                    {
                        Id = lookup.Id,
                        Value = lookup.ValueEn
                    };
                }
                if (lookup == null)
                {
                    throw new BusinessException("Lookup does not exist", Constants.ErrorsCodes.LookupDoesNotExist);
                }

                return lookup;
            }
        }

        public LookupsDTO GetLookupByLookupId(int Id, Enums.Culture culture)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Lookups;
                var lookup = repo.GetLookupByLookupId(Id);
                if (culture == Enums.Culture.Arabic)
                {
                    lookup = new LookupsDTO()
                    {
                        Id = lookup.Id,
                        Value = lookup.ValueAr
                    };
                }
                else
                {
                    lookup = new LookupsDTO()
                    {
                        Id = lookup.Id,
                        Value = lookup.ValueEn
                    };
                }
                if (lookup == null)
                {
                    throw new BusinessException("Lookup does not exist", Constants.ErrorsCodes.LookupDoesNotExist);
                }

                return lookup;
            }
        }
        public LookupsDTO GetLookupByID(int LookupID)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Lookups;
                var lookup = repo.GetLookupByID(LookupID);
                if (String.IsNullOrEmpty(lookup.ValueAr))
                {
                    lookup.Value = lookup.ValueAr;
                }
                else
                {
                    lookup.Value = lookup.ValueEn;
                }
                if (lookup == null)
                {
                    throw new BusinessException("Lookup does not exist", Constants.ErrorsCodes.LookupDoesNotExist);
                }

                return lookup;
            }
        }





    }
}
