using BulletinReport.Common.DTOs.DepartmentDTO;

using GCAP.DAL.Entities;
using GCAP.DAL.Repositories;

using System.Collections.Generic;
using System.Linq;

namespace GCAP.DAL.CustomRepositories
{
    public class DepartmentsRepository : Repository<Department>
    {
        public DepartmentsRepository(GCAPUnitOfWork uow) : base(uow) { }

        public List<DepartmentDTO> GetAllDepartments()
        {
            var bulletins = GetQuerable(x => x.ID > 0 &&  x.Type == 1 || x.Type == 2 || x.Type== 6 || x.Type == 7).Select(u => new DepartmentDTO()
            {
                ID = u.ID,
                Name = u.Name,
                ActiveGroup = u.ActiveGroup,
                Archive = u.Archive,
                BookReqIDs = u.BookReqIDs,
                BulletinSerial = u.BulletinSerial,
                CaseSerial = u.CaseSerial,
                CreateDate = u.CreateDate,
                FaxNo = u.FaxNo,
                FinanceID = u.FinanceID,
                FinanceSource = u.FinanceSource,
                GeneralProsID = u.GeneralProsID,
                GroupID = u.GroupID,
                IsActive_HT = u.IsActive_HT,
                IsBookReq = u.IsBookReq,
                Manager = u.Manager,
                ModifyDate = u.ModifyDate,
                NameEng = u.NameEng,
                Parent = u.Parent,
                PrefixName = u.PrefixName,
                RFID_Enabled = u.RFID_Enabled,
                RFID_Hidden = u.RFID_Hidden,
                RFID_InActive = u.RFID_InActive,
                SearchWarrantGroup = u.SearchWarrantGroup,
                StampID = u.StampID,
                SubSourceID = u.SubSourceID,
                Type = u.Type
            }).ToList();
            return bulletins;
        }
    }
}
