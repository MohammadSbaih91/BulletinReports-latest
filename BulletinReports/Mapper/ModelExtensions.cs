using BulletinReport.Common.DTOs;
using BulletinReport.Common.DTOs.BulletinsDTO;

using BulletinReports.Models.BulletinsViewModel;

using System;
using System.Collections.Generic;
using System.Linq;

using static BulletinReport.Common.Enums;

namespace BulittenReports.Mapper
{
    public static class ModelExtensions
    {
        public static List<ProsecutorDutyViewModel> ToProsecutorDutiesUI(this List<AspNetUserDTO> aspNetUsers)
        {

            List<ProsecutorDutyViewModel> ProsecutorDutiesList = new List<ProsecutorDutyViewModel>();
            if (aspNetUsers == null)
            {
                return ProsecutorDutiesList;
            }
            foreach (var duty in aspNetUsers.Take(4))
            {
                var newDuty = new ProsecutorDutyViewModel()
                {
                    Prosecutors = aspNetUsers.ToAspNetUsersBulittenWebUI(),
                };
                ProsecutorDutiesList.Add(newDuty);
            }
            return ProsecutorDutiesList;

        }
        public static List<ProsecutorDutyViewModel> ToProsecutorDutiesUI(this List<UsersDTO> aspNetUsers)
        {

            List<ProsecutorDutyViewModel> ProsecutorDutiesList = new List<ProsecutorDutyViewModel>();
            if (aspNetUsers == null)
            {
                return ProsecutorDutiesList;
            }
            foreach (var duty in aspNetUsers.Take(4))
            {
                var newDuty = new ProsecutorDutyViewModel()
                {
                    Prosecutors = aspNetUsers.ToAspNetUsersBulittenWebUI(),
                };
                ProsecutorDutiesList.Add(newDuty);
            }
            return ProsecutorDutiesList;

        }
        public static List<UsersDTO> ToAspNetUsersBulittenWebUI(this List<UsersDTO> aspNetUsers)
        {

            List<UsersDTO> prosecuters = new List<UsersDTO>();
            if (aspNetUsers == null)
            {
                return prosecuters;
            }
            foreach (var duty in aspNetUsers)
            {
                var newDuty = new UsersDTO()
                {
                    ID = duty.ID,
                    Name = duty.Name,
                    LogonName = duty.Name,
                };
                prosecuters.Add(newDuty);
            }
            return prosecuters;

        }
        public static BulletinsDTO ToBulletinDTO(this BulletinViewModel model)
        {

            BulletinsDTO dto = new BulletinsDTO();
            if (model == null)
            {
                return dto;
            }
            dto = new BulletinsDTO()
            {
                Id = model.Id,
                AccedentNumber = model.AccedentNumber,
                BulletinCreatedAt = DateTime.Now,
                BulletinUpdatedAt = model.BulletinUpdatedAt,
                BulletinCreatedBy = model.CreatedBy,
                BulletinDeletedAt = model.BulletinDeletedAt,
                BulletinDeletedBy = model.DeletedBy,
                BulletinDescription = model.BulletinDescription,
                BulletinNameAr = model.BulletinNameAr,
                OfficerRank = model.OfficerRank,
                BulletinPoName = model.BulletinPoName,
                BulletinPoNumber = model.BulletinPoNumber,
                BulletinType = model.BulletinType,
                BulletinUpdatedBy = model.UpdatedBy,
                Department = model.Department,
                OfficerPhoneNumber = model.OfficerPhoneNumber,
                PartyAge = model.PartyAge,
                PartyName = model.PartyName,
                PartyNameAr = model.PartyNameAr,
                PartyNationality = model.PartyNationality,
                PartyOtherDescription = model.PartyOtherDescription,
                PartyQatariId = model.PartyQatariId,
                PoliceOffice = model.PoliceOffice,
                ReportDate = Bulitten.Common.Helper.UIHelper.ConvertStringToDateTime(model.ReportDate),
                Procedures = model.Procedures.ToProceduresDTO(),
                ProsecutorDuties = (from e in model.ProsecutorDuties.Where(x => x.BulletinReportProsecutor != null)
                                    select new ProsecutorDutyDTO()
                                    {
                                        BulletinReportProsecutor = e.BulletinReportProsecutor,
                                        BulletinReportTime = e.BulletinReportTime,
                                        CallsCount = e.CallsCount,
                                        PhoneAnswerTime = e.PhoneAnswerTime,
                                        ProsecutorNotes = e.ProsecutorNotes,
                                        ProsecutorShiftId = e.ProsecutorShiftId,
                                        ProsecutorShiftTime = Convert.ToInt32(e.ProsecutorShiftId),
                                        //PublicProsecution = e.PublicProsecutionId.Value

                                    }).Distinct().ToList(),
            };

            return dto;
        }

        public static BulletinProcedureDTO ToProceduresDTO(this BulletinProcedureViewModel model)
        {
            BulletinProcedureDTO dto = new BulletinProcedureDTO();
            if (model == null)
            {
                return dto;
            }
            var date = model.ProcedureCreatedAt;
            var time = model.ProcedureTime;
            var combinedDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);

            dto = new BulletinProcedureDTO()
            {
                HasBeenMoved = model.HasBeenMoved,
                MessageBeenSent = model.HasBeenMoved,
                NotBeenMoved = model.HasBeenMoved,
                ProcedureCreatedAt = model.ProcedureCreatedAt,
                PublicProsecution = model.PublicProsecution,
                ProcedureTime = combinedDateTime,
                ProcedureCreatedBy = model.ProcedureCreatedBy,
                ProcedureNotes = model.ProcedureNotes,
                Prosecutor = model.Prosecutor,
                ProcedureDeletedAt = model.ProcedureDeletedAt,
                ProcedureUpdatedAt = model.ProcedureUpdatedAt,
                ProcedureDeletedBy = model.ProcedureDeletedBy,
                ProcedureUpdatedBy = model.ProcedureUpdatedBy,

            };

            return dto;
        }

        public static List<AspNetUsersBulletinViewModel> ToAspNetUsersBulittenUI(this List<AspNetUserDTO> aspNetUsers)
        {

            List<AspNetUsersBulletinViewModel> prosecuters = new List<AspNetUsersBulletinViewModel>();
            if (aspNetUsers == null)
            {
                return prosecuters;
            }
            foreach (var duty in aspNetUsers)
            {
                var newDuty = new AspNetUsersBulletinViewModel()
                {
                    Id = duty.Id,
                    NameAr = duty.Name,
                    NameEn = duty.FirstNameEn + " " + duty.LastNameEn,
                    UserName = duty.UserName,
                };
                prosecuters.Add(newDuty);
            }
            return prosecuters;

        }
        public static List<AspNetUsersBulletinViewModel> ToAspNetUsersBulittenUI(this List<UsersDTO> aspNetUsers)
        {

            List<AspNetUsersBulletinViewModel> prosecuters = new List<AspNetUsersBulletinViewModel>();
            if (aspNetUsers == null)
            {
                return prosecuters;
            }
            foreach (var duty in aspNetUsers)
            {
                var newDuty = new AspNetUsersBulletinViewModel()
                {
                    Id = duty.ID.ToString(),
                    NameAr = duty.Name,
                    NameEn = duty.Name,
                    UserName = duty.LogonName,
                };
                prosecuters.Add(newDuty);
            }
            return prosecuters;

        }
        public static List<UsersDTO> ToAspNetUsersBulittenWebUI(this List<AspNetUserDTO> aspNetUsers)
        {

            List<UsersDTO> prosecuters = new List<UsersDTO>();
            if (aspNetUsers == null)
            {
                return prosecuters;
            }
            foreach (var duty in aspNetUsers)
            {
                var newDuty = new UsersDTO()
                {
                    ID = Convert.ToInt32(duty.Id),
                    Name = duty.Name,
                    LogonName = duty.FirstNameEn + " " + duty.LastNameEn,
                };
                prosecuters.Add(newDuty);
            }
            return prosecuters;

        }
        public static List<BulletinViewModel> ToUIBulletins(this List<BulletinsDTO> bulletinsdtolist, Culture cul)
        {

            List<BulletinViewModel> bulletinsList = new List<BulletinViewModel>();
            if (bulletinsdtolist == null)
            {
                return bulletinsList;
            }
            foreach (var bulletin in bulletinsdtolist)
            {
                var newbulletin = new BulletinViewModel()
                {
                    AccedentNumber = bulletin.AccedentNumber,
                    BulletinCreatedAt = bulletin.BulletinCreatedAt,
                    BulletinCreatedBy = bulletin.BulletinCreatedBy,
                    BulletinDeletedAt = bulletin.BulletinDeletedAt,
                    BulletinDeletedBy = bulletin.BulletinDeletedBy,
                    BulletinDescription = bulletin.BulletinDescription,
                    BulletinNameAr = bulletin.BulletinNameAr,
                    BulletinPoName = bulletin.BulletinPoName,
                    BulletinPoNumber = bulletin.BulletinPoNumber,
                    BulletinType = bulletin.BulletinType,
                    BulletinUpdatedAt = bulletin.BulletinUpdatedAt,
                    BulletinUpdatedBy = bulletin.BulletinUpdatedBy,
                    CreatedBy = bulletin.BulletinCreatedBy,
                    DeletedBy = bulletin.BulletinDeletedBy,
                    Department = bulletin.Department,
                    Id = bulletin.Id,
                    OfficerPhoneNumber = bulletin.OfficerPhoneNumber,
                    OfficerRank = bulletin.OfficerRank,
                    PartyAge = bulletin.PartyAge,
                    PartyName = bulletin.PartyName,
                    PartyNameAr = bulletin.PartyNameAr,
                    PartyNationality = bulletin.PartyNationality,
                    PartyOtherDescription = bulletin.PartyOtherDescription,
                    PartyQatariId = bulletin.PartyQatariId,
                    PoliceOffice = bulletin.PoliceOffice,
                    Procedures = bulletin.Procedures.ToUIProcedures(),
                    ProsecutorDuties = bulletin.ProsecutorDuties.ToUIProsecutorDuties(),
                    ReportDate = bulletin.ReportDate.ToLongDateString(),
                    ReportTime = bulletin.ReportDate.ToLongDateString(),
                    UpdatedBy = bulletin.BulletinUpdatedBy,
                    DepartmentName = bulletin.DepartmentName,
                    PoliceOfficeName = bulletin.PoliceOfficeName
                };
                bulletinsList.Add(newbulletin);
            }
            return bulletinsList;

        }
        public static List<ProsecutorDutyViewModel> ToUIProsecutorDuties(this List<ProsecutorDutyDTO> Prosecutors)
        {

            List<ProsecutorDutyViewModel> ProsecutorDutiesList = new List<ProsecutorDutyViewModel>();
            if (Prosecutors == null)
            {
                return ProsecutorDutiesList;
            }
            foreach (var duty in Prosecutors)
            {
                var newDuty = new ProsecutorDutyViewModel()
                {
                    BulletinReportProsecutor = duty.BulletinReportProsecutor,
                    BulletinReportTime = duty.BulletinReportTime,
                    CallsCount = duty.CallsCount,
                    Id = duty.Id,
                    ProsecutorNotes = duty.ProsecutorNotes,
                    ProsecutorShiftId = duty.ProsecutorShiftId,
                    ProsecutorShiftTime = duty.ProsecutorShiftTime.ToString(),
                    PublicProsecutionId = duty.PublicProsecution,
                    UserId = duty.BulletinReportProsecutor,/*--aspnetuserid*/
                };
                ProsecutorDutiesList.Add(newDuty);
            }
            return ProsecutorDutiesList;

        }

        public static BulletinProcedureViewModel ToUIProcedures(this BulletinProcedureDTO dto)
        {
            BulletinProcedureViewModel model = new BulletinProcedureViewModel();
            if (dto == null)
            {
                return model;
            }
            var date = model.ProcedureCreatedAt;
            var combinedDateTime = new TimeSpan(date.Hour, date.Minute, date.Second);

            model = new BulletinProcedureViewModel()
            {
                PublicProsecution = dto.PublicProsecution,
                HasBeenMoved = dto.HasBeenMoved,
                Id = dto.Id,
                NotBeenMoved = dto.NotBeenMoved,
                ProcedureCreatedAt = dto.ProcedureCreatedAt,
                ProcedureCreatedBy = dto.ProcedureCreatedBy,
                ProcedureDeletedAt = dto.ProcedureDeletedAt,
                ProcedureDeletedBy = dto.ProcedureDeletedBy,
                ProcedureNotes = dto.ProcedureNotes,
                ProcedureTime = combinedDateTime,
                ProcedureUpdatedAt = dto.ProcedureUpdatedAt,
                ProcedureUpdatedBy = dto.ProcedureUpdatedBy,
                Prosecutor = dto.Prosecutor,
            };
            return model;
        }

        public static BulletinViewModel ToUIBulletin(this BulletinsDTO Bulletinsdto, Culture cul)
        {

            BulletinViewModel bulletinsviewmodel = new BulletinViewModel();
            if (Bulletinsdto == null)
            {
                return bulletinsviewmodel;
            }
            var newbulletin = new BulletinViewModel()
            {
                AccedentNumber = Bulletinsdto.AccedentNumber,
                BulletinCreatedAt = Bulletinsdto.ReportDate,
                BulletinCreatedBy = Bulletinsdto.BulletinCreatedBy,
                BulletinDeletedAt = Bulletinsdto.BulletinDeletedAt,
                BulletinDeletedBy = Bulletinsdto.BulletinDeletedBy,
                BulletinDescription = Bulletinsdto.BulletinDescription,
                BulletinNameAr = Bulletinsdto.BulletinNameAr,
                BulletinPoName = Bulletinsdto.BulletinPoName,
                BulletinPoNumber = Bulletinsdto.BulletinPoNumber,
                BulletinType = Bulletinsdto.BulletinType,
                BulletinUpdatedAt = Bulletinsdto.BulletinUpdatedAt,
                BulletinUpdatedBy = Bulletinsdto.BulletinUpdatedBy,
                CreatedBy = Bulletinsdto.BulletinCreatedBy,
                DeletedBy = Bulletinsdto.BulletinDeletedBy,
                Department = Bulletinsdto.Department,
                Id = Bulletinsdto.Id,
                OfficerPhoneNumber = Bulletinsdto.OfficerPhoneNumber,
                OfficerRank = Bulletinsdto.OfficerRank,
                PartyAge = Bulletinsdto.PartyAge,
                PartyName = Bulletinsdto.PartyName,
                PartyNameAr = Bulletinsdto.PartyNameAr,
                DepartmentUser = Convert.ToInt32(Bulletinsdto.Procedures.Prosecutor),
                PartyNationality = Bulletinsdto.PartyNationality,
                PartyOtherDescription = Bulletinsdto.PartyOtherDescription,
                PartyQatariId = Bulletinsdto.PartyQatariId,
                PoliceOffice = Bulletinsdto.PoliceOffice,
                Procedures = Bulletinsdto.Procedures.ToUIProcedures(),
                ProsecutorDuties = Bulletinsdto.ProsecutorDuties.ToUIProsecutorDuties(),
                ReportDate = Bulitten.Common.Helper.UIHelper.ConvertDateTimeToDateStringBulliten(Bulletinsdto.ReportDate),
                ReportTime = Bulitten.Common.Helper.UIHelper.ConvertDateTimeToTimeString(Bulletinsdto.ReportDate),
                UpdatedBy = Bulletinsdto.BulletinUpdatedBy,
                DepartmentName = Bulletinsdto.DepartmentName,
                PoliceOfficeName = Bulletinsdto.PoliceOfficeName
            };
            return newbulletin;
        }
    }
}