using BulletinReport.DAL.Entities;
using BulletinReport.DAL.Repositories;

namespace BulletinReport.DAL.CustomRepositories
{
    public class AspNetUserLoginRepository : Repository<AspNetUserLogin>
    {

        public AspNetUserLoginRepository(UnitOfWork uow) : base(uow) { }
    }
}
