using GCAP.DAL.Entities;
using GCAP.DAL.Repositories;

namespace GCAP.DAL.CustomRepositories
{
    public class Department_TypeRepository : Repository<Department_Type>
    {
        public Department_TypeRepository(GCAPUnitOfWork uow) : base(uow) { }



    }
}
