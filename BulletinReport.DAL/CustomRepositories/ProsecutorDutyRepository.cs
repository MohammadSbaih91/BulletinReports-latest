using BulletinReport.Common.Utilities;
using BulletinReport.DAL.Entities;
using BulletinReport.DAL.Repositories;

using System;
using System.Collections.Generic;

namespace BulletinReport.DAL.CustomRepositories
{
    public class ProsecutorDutyRepository : Repository<ProsecutorDuty>
    {
        public ProsecutorDutyRepository(UnitOfWork uow) : base(uow) { }



        public List<int> CreateProsecutorDuty(List<ProsecutorDuty> prosecutorDuty)
        {
            List<int> ids = new List<int>(); // Initialize a list to store the IDs.
            try
            {
                foreach (var entity in prosecutorDuty)
                {
                    var record = new ProsecutorDuty()
                    {
                        BulletinReportProsecutor = entity.BulletinReportProsecutor,
                        BulletinReportTime = entity.BulletinReportTime,
                        ProsecutorShiftTime = entity.ProsecutorShiftTime,
                        ProsecutorNotes = entity.ProsecutorNotes,
                        PhoneAnswerTime = entity.PhoneAnswerTime,
                        CallsCount = entity.CallsCount,
                    };
                    Create(record);  // Assuming this method sets the Id of the record upon creation.
                    _uow.Save();
                    ids.Add(record.Id);  // Add the newly created record ID to the list.
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("CreateProsecutorDuty", "An error occurred while trying to create ProsecutorDuty records - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return new List<int>(); // Return an empty list in case of an error.
            }
            return ids; // Return the list of IDs after all records have been processed.
        }





    }
}
