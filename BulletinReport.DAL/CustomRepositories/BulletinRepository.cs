using BulletinReport.Common.DTOs.BulletinsDTO;
using BulletinReport.Common.Utilities;
using BulletinReport.DAL;
using BulletinReport.DAL.Entities;
using BulletinReport.DAL.Repositories;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Bulitten.DAL.CustomRepositories
{
    public class BulletinRepository : Repository<Bulletin>
    {
        public BulletinRepository(UnitOfWork uow) : base(uow) { }


        public int CreateBulletin(BulletinsDTO dto)
        {
            try
            {
                var record = new Bulletin()
                {
                    BulletinPoName = dto.BulletinPoName,
                    BulletinPoNumber = dto.BulletinPoNumber,
                    AccedentNumber = dto.AccedentNumber,
                    ReportDate = dto.ReportDate,
                    OfficerPhoneNumber = string.IsNullOrEmpty(dto.OfficerPhoneNumber) ? "000000" : dto.OfficerPhoneNumber,
                    BulletinType = dto.BulletinType,
                    BulletinDescription = dto.BulletinDescription,
                    PartyName = dto.PartyName,
                    PartyAge = dto.PartyAge,
                    PartyOtherDescription = dto.PartyOtherDescription,
                    BulletinNameAr = dto.BulletinNameAr,
                    PartyNameAr = dto.PartyNameAr,
                    BulletinCreatedBy = dto.BulletinCreatedBy,
                    BulletinCreatedAt = dto.BulletinCreatedAt,
                    PoliceOffice = dto.PoliceOffice,
                    OfficerRank = dto.OfficerRank,
                    Department = dto.Department,
                    PartyQatariId = dto.PartyQatariId,
                    PartyNationality = dto.PartyNationality,
                    IsUpdated = false,
                    IsDeleted = false
                };
                Create(record);
                _uow.Save();

                if (record.Id > 0)
                {
                    List<int> dutyIds = _uow.Duties.CreateProsecutorDuty(ConvertProsecutorDutyDTOToEntity(dto.ProsecutorDuties));
                    if (dutyIds.Count > 0)
                    {
                        _uow.Procedures.CreateProcedure(ConvertProcedureDTOToEntity(dto.Procedures, record.Id));
                        foreach (int dutyId in dutyIds)
                        {
                            UpdateProsecuterDutiesBulletinTable(record.Id, dutyId);
                        }
                        return record.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("CreateBulletin", "An error occurred while trying to create Bulletin record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
            }
            return 0; // Return 0 to indicate failure
        }


        public int UpdateBulletin(BulletinsDTO dto)
        {
            int DutyId = 0;
            try
            {
                var record = GetQuerable(x => x.Id == dto.Id).FirstOrDefault();
                if (record != null)
                {
                    // Update properties of the existing record
                    record.BulletinPoName = dto.BulletinPoName;
                    if (string.IsNullOrWhiteSpace(dto.PartyOtherDescription))
                    {
                        record.PartyOtherDescription = string.Empty;
                    }
                    else
                    {
                        record.PartyOtherDescription = dto.PartyOtherDescription; //opt

                    }
                    if (string.IsNullOrWhiteSpace(dto.PartyNameAr))
                    {
                        record.PartyNameAr = dto.PartyName;
                    }
                    record.BulletinPoNumber = dto.BulletinPoNumber;
                    record.AccedentNumber = dto.AccedentNumber;
                    record.ReportDate = dto.ReportDate;
                    record.OfficerPhoneNumber = string.IsNullOrWhiteSpace(dto.OfficerPhoneNumber) ? "00000000" : dto.OfficerPhoneNumber;
                    record.BulletinType = dto.BulletinType;
                    record.BulletinDescription = dto.BulletinDescription;
                    record.PartyName = dto.PartyName;
                    record.PartyAge = dto.PartyAge;
                    record.BulletinNameAr = dto.BulletinNameAr;
                    record.BulletinUpdatedAt = dto.BulletinUpdatedAt; //opt
                    record.BulletinUpdatedBy = dto.BulletinUpdatedBy; //opt
                    record.PoliceOffice = dto.PoliceOffice;
                    record.OfficerRank = dto.OfficerRank;
                    record.Department = dto.Department;
                    record.PartyQatariId = dto.PartyQatariId;
                    record.PartyNationality = dto.PartyNationality;
                    record.IsUpdated = true;
                    record.IsDeleted = false;

                    // Now the record is tracked by the context and marked as modified
                    _uow.Save(); // Save changes


                    //later to handle
                    //if (record.Id > 0)
                    //{
                    //    List<int> dutyIds = _uow.Duties.CreateProsecutorDuty(ConvertProsecutorDutyDTOToEntity(dto.ProsecutorDuties));
                    //    if (dutyIds.Count > 0)
                    //    {
                    //        _uow.Procedures.CreateProcedure(ConvertProcedureDTOToEntity(dto.Procedures, record.Id));
                    //        foreach (int dutyId in dutyIds)
                    //        {
                    //            UpdateProsecuterDutiesBulletinTable(record.Id, dutyId);
                    //        }
                    //        return record.Id;
                    //    }
                    //}
                    return record.Id;
                }
                return 0;
            }
            catch (Exception ex)
            {
                ex.Data.Add("UpdateBulletin", "An error occurred while trying to UpdateBulletin( Bulletin ) Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return 0;
            }
        }


        public int DeleteBulliten(int BulletinId, string UserId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == BulletinId).FirstOrDefault();
                record.IsDeleted = true;
                record.BulletinDeletedAt = DateTime.Now;
                record.BulletinDeletedBy = UserId;

                Update(record);
                _uow.Save();
                return record.Id;
            }
            catch (Exception ex)
            {
                ex.Data.Add("DeleteBulliten", "An error occurred while trying to DeleteBulliten ( Bulletin ) Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return 0;
            }
        }
        public bool UpdateProsecuterDutiesBulletinTable(int BulletinId, int DutyId)
        {
            try
            {
                // Execute raw SQL to insert into the junction table
                _db.Database.ExecuteSqlCommand(
                    "INSERT INTO BulletinProsecuterDuties (BulletinId, ProsecutorId) VALUES (@BulletinId, @DutyId)",
                    new SqlParameter("@BulletinId", BulletinId),
                    new SqlParameter("@DutyId", DutyId));

                // Save changes
                _uow.Save();

                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("UpdateProsecuterDutiesBulletinTable", "An error occurred while trying to Create Service Request (Bulletin) Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }

        private Procedure ConvertProcedureDTOToEntity(BulletinProcedureDTO dto, int BulletinId)
        {
            return new Procedure
            {
                HasBeenMoved = dto.HasBeenMoved,
                NotBeenMoved = dto.NotBeenMoved,
                ProcedureCreatedAt = dto.ProcedureCreatedAt,
                ProcedureCreatedBy = dto.ProcedureCreatedBy,
                Prosecutor = dto.Prosecutor,
                BulletinId = BulletinId,
                ProcedureNotes = dto.ProcedureNotes,
                ProcedureTime = dto.ProcedureTime,
                PublicProsecution = 100

            };
        }

        private List<ProsecutorDuty> ConvertProsecutorDutyDTOToEntity(List<ProsecutorDutyDTO> dtoList)
        {
            if (dtoList == null)
            {
                return null;
            }

            return dtoList.Select(dto => new ProsecutorDuty
            {
                // Assuming each property exists in ProsecutorDutyDTO and maps directly.
                BulletinReportProsecutor = dto.BulletinReportProsecutor,
                BulletinReportTime = dto.BulletinReportTime,
                CallsCount = dto.CallsCount,
                PhoneAnswerTime = dto.PhoneAnswerTime,
                ProsecutorNotes = dto.ProsecutorNotes,
                ProsecutorShiftTime = dto.ProsecutorShiftTime
            }).ToList();
        }
        public List<BulletinsDTO> GetAllBulletins()
        {
            var bulletins = GetQuerable(x => x.IsDeleted != true).Select(u => new BulletinsDTO()
            {
                AccedentNumber = u.AccedentNumber,
                BulletinCreatedAt = u.BulletinCreatedAt,
                BulletinCreatedBy = u.BulletinCreatedBy,
                BulletinUpdatedAt = u.BulletinUpdatedAt,
                BulletinUpdatedBy = u.BulletinUpdatedBy,
                BulletinPoNumber = u.BulletinPoNumber,
                BulletinPoName = u.BulletinPoName,
                BulletinType = u.BulletinType,
                BulletinDescription = u.BulletinDescription,
                BulletinNameAr = u.BulletinNameAr,
                BulletinDeletedAt = u.BulletinDeletedAt,
                BulletinDeletedBy = u.BulletinDeletedBy,
                Id = u.Id,
                OfficerPhoneNumber = u.OfficerPhoneNumber,
                OfficerRank = u.OfficerRank,
                PartyAge = u.PartyAge,
                PartyName = u.PartyName,
                PartyNameAr = u.PartyNameAr,
                PartyNationality = u.PartyNationality,
                PartyOtherDescription = u.PartyOtherDescription,
                PartyQatariId = u.PartyQatariId,
                PoliceOffice = u.PoliceOffice,
                ReportDate = u.ReportDate,
                Department = u.Department,
                //Procedures=,
                //ProsecutorDuties=
                //AspNetUser=
                //AspNetUser1=
                //AspNetUser2=
                //Lookup=
                //Lookup1=
                //Lookup2=
                //Lookup3=
                //Lookup = _db.LookupCultures.Where(x => x.LookupID == u.ToolkitType).Select(x => x.Value).FirstOrDefault(),

            }).ToList();
            return bulletins;
        }
        public BulletinsDTO GetBullitenById(int bulletinId)
        {
            var bulletin = GetQuerable(x => x.Id == bulletinId).Include(x => x.Procedures).Include(x => x.ProsecutorDuties).Select(u => new BulletinsDTO()
            {
                AccedentNumber = u.AccedentNumber,
                BulletinCreatedAt = u.BulletinCreatedAt,
                BulletinCreatedBy = u.BulletinCreatedBy,
                BulletinUpdatedAt = u.BulletinUpdatedAt,
                BulletinUpdatedBy = u.BulletinUpdatedBy,
                BulletinPoNumber = u.BulletinPoNumber,
                BulletinPoName = u.BulletinPoName,
                BulletinType = u.BulletinType,
                BulletinDescription = u.BulletinDescription,
                BulletinNameAr = u.BulletinNameAr,
                BulletinDeletedAt = u.BulletinDeletedAt,
                BulletinDeletedBy = u.BulletinDeletedBy,
                Id = u.Id,
                OfficerPhoneNumber = u.OfficerPhoneNumber,
                OfficerRank = u.OfficerRank,
                PartyAge = u.PartyAge,
                PartyName = u.PartyName,
                PartyNameAr = u.PartyNameAr,
                PartyNationality = u.PartyNationality,
                PartyOtherDescription = u.PartyOtherDescription,
                PartyQatariId = u.PartyQatariId,
                PoliceOffice = u.PoliceOffice,
                ReportDate = u.ReportDate,
                Department = u.Department,
                Procedures = (from d in u.Procedures.Where(x => x.BulletinId == bulletinId)
                              select new BulletinProcedureDTO()
                              {
                                  HasBeenMoved = d.HasBeenMoved,
                                  Id = d.Id,
                                  NotBeenMoved = d.NotBeenMoved,
                                  ProcedureCreatedAt = d.ProcedureCreatedAt,
                                  ProcedureUpdatedAt = d.ProcedureUpdatedAt,
                                  ProcedureCreatedBy = d.ProcedureCreatedBy,
                                  ProcedureUpdatedBy = d.ProcedureUpdatedBy,
                                  ProcedureDeletedAt = d.ProcedureDeletedAt,
                                  ProcedureDeletedBy = d.ProcedureDeletedBy,
                                  ProcedureNotes = d.ProcedureNotes,
                                  ProcedureTime = d.ProcedureTime,
                                  Prosecutor = d.Prosecutor,
                                  PublicProsecution = d.PublicProsecution,
                              }).FirstOrDefault(),
                ProsecutorDuties = (from c in u.ProsecutorDuties
                                    select new ProsecutorDutyDTO()
                                    {
                                        BulletinReportProsecutor = c.BulletinReportProsecutor,
                                        BulletinReportTime = c.BulletinReportTime,
                                        CallsCount = c.CallsCount,
                                        Id = c.Id,
                                        PhoneAnswerTime = c.PhoneAnswerTime,
                                        ProsecutorNotes = c.ProsecutorNotes,
                                        ProsecutorShiftId = c.ProsecutorShiftTime.ToString(),
                                        ProsecutorShiftTime = c.ProsecutorShiftTime,
                                        PublicProsecutionAspNetId = c.BulletinReportProsecutor
                                    }).ToList(),
            }).FirstOrDefault();
            return bulletin;
        }

        //public BulletinsDTO GetTemplateByType(int bulletinType/*, Enums.Culture cul*/)
        //{
        //    try
        //    {
        //        var record = GetQuerable(x => x.BulletinType == bulletinType)
        //            .Include(x => x.BaseQuestionsDetails)
        //            .Include(x => x.Attachments).Select(u => new TemplateDTO()
        //            {
        //                Id = u.Id,
        //                TemplateNameAr = u.TemplateNameAr,
        //                TemplateNameEn = u.TemplateNameEn,
        //                TemplateSubType = u.TemplateSubType,
        //                TemplateType = u.TemplateType,
        //                baseQuestions = (from d in u.BaseQuestionsDetails
        //                                 select new BaseQuestionsDetailsDTO()
        //                                 {
        //                                     Id = d.Id,
        //                                     BaseQuestionNameAr = d.BaseClauseNameAr,
        //                                     BaseQuestionNameEn = d.BaseClauseNameEn,
        //                                     BaseQuestionNumberAr = d.BaseClauseNumberAr,
        //                                     BaseQuestionNumberEn = d.BaseClauseNumberEn,
        //                                     IsMandatory = d.IsMandatory,
        //                                     baseTemplateId = u.Id,
        //                                     questions = (from j in d.QuestionsDetails
        //                                                  select new QuestionsDetailsDTO()
        //                                                  {
        //                                                      NameAr = j.clauseNameAr,
        //                                                      NameEn = j.clauseNameEn,
        //                                                      Id = j.Id,
        //                                                      IsMandatory = j.IsMandatory,
        //                                                      NumberAr = j.clauseNumberAr,
        //                                                      NumberEn = j.clauseNumberEn,
        //                                                      //CompianceLevel=_uow.LookupCategory.GetLookupsByLookupCategoryCode("CompianceLevel",cul),
        //                                                      QuestionsAttachments = (from z in j.QuestionsDetailsAttachments
        //                                                                              select new QuestionAttachmentsDTO()
        //                                                                              {
        //                                                                                  AttachmentID = z.AttachmentID,
        //                                                                                  AttachmentId = z.AttachmentID,
        //                                                                                  Caption = z.caption,
        //                                                                                  ContentType = z.caption,
        //                                                                                  Data = z.data,
        //                                                                                  FileName = z.fileName,
        //                                                                                  Id = z.AttachmentID,
        //                                                                                  QuestionId = z.QuestionDetailsID,
        //                                                                              }).ToList(),
        //                                                  }).ToList(),
        //                                 }).ToList(),
        //                attachments = (from d in u.Attachments
        //                               select new AttachmentDTO()
        //                               {
        //                                   AttachmentID = d.AttachmentID,
        //                                   AttachmentId = d.AttachmentID,
        //                                   Caption = d.caption,
        //                                   ContentType = d.caption,
        //                                   Data = d.data,
        //                                   FileName = d.fileName,
        //                                   Id = d.AttachmentID,
        //                                   TemplateId = d.TemplateID,
        //                               }).Distinct().ToList(),
        //            }).FirstOrDefault();

        //        return record;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("GetTemplateByType ", "An error occurred while trying to GetTemplateByType  in DAL ");
        //        Tracer.Error(ex);
        //        _uow.Rollback();
        //        return null;
        //    }
        //}
    }
}
