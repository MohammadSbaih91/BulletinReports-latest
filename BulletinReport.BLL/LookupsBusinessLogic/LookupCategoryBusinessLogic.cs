using BulletinReport.Common;
using BulletinReport.Common.DTOs.LookupsDTO;
using BulletinReport.Common.Exceptions;
using BulletinReport.DAL;

using System.Collections.Generic;

namespace BulletinReport.BLL.LookupsBusinessLogic
{
    public class LookupCategoryBusinessLogic
    {
        public IEnumerable<LookupsDTO> GetLookupsByLookupCategoryCode(string lookupCategoryCode, Enums.Culture cul)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.LookupCategories;
                var lookup = repo.GetLookupsByLookupCategoryCode(lookupCategoryCode, cul);
                if (lookup == null)
                {
                    throw new BusinessException("Lookup does not exist", Constants.ErrorsCodes.LookupDoesNotExist);
                }
                else
                {
                    return lookup;
                }
            }
        }
    }
}
