using GCAP.DAL.Entities;
using GCAP.DAL.Repositories;

namespace GCAP.DAL.CustomRepositories
{
    public class PoliceOfficesGroupsRepository : Repository<PoliceOfficesGroup>
    {
        public PoliceOfficesGroupsRepository(GCAPUnitOfWork uow) : base(uow) { }
    }
}
