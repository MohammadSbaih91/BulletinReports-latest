using BulletinReport.Common.Utilities;
using BulletinReport.DAL.Entities;
using BulletinReport.DAL.Repositories;

using System;

namespace BulletinReport.DAL.CustomRepositories
{
    public class ProcedureRepository : Repository<Procedure>
    {
        public ProcedureRepository(UnitOfWork uow) : base(uow) { }



        public int CreateProcedure(Procedure entity)
        {
            try
            {
                var record = new Procedure()
                {
                    BulletinId = entity.BulletinId,
                    NotBeenMoved = entity.NotBeenMoved,
                    HasBeenMoved = entity.HasBeenMoved,
                    ProcedureCreatedAt = entity.ProcedureCreatedAt,
                    ProcedureCreatedBy = entity.ProcedureCreatedBy,
                    ProcedureTime = entity.ProcedureTime,
                    ProcedureNotes = entity.ProcedureNotes,
                    PublicProsecution = entity.PublicProsecution,
                    Prosecutor = entity.Prosecutor
                };
                Create(record);
                _uow.Save();

                return record.Id;
            }
            catch (Exception ex)
            {
                ex.Data.Add("CreateProcedure", "An error occurred while trying to CreateProcedure ( Procedure ) Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return 0;
            }
        }

    }
}
