using GCAP.DAL.Entities;
using GCAP.DAL.Repositories;

namespace GCAP.DAL.CustomRepositories
{
    public class CodingTableRepository : Repository<CodingTable>
    {
        public CodingTableRepository(GCAPUnitOfWork uow) : base(uow) { }
    }
}
