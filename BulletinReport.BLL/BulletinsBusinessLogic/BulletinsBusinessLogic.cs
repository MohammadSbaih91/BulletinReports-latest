using BulletinReport.Common;
using BulletinReport.Common.DTOs.BulletinsDTO;
using BulletinReport.Common.DTOs.DepartmentDTO;
using BulletinReport.Common.Exceptions;
using BulletinReport.Common.Utilities;
using BulletinReport.DAL;

using GCAP.DAL;

using System;
using System.Collections.Generic;
using System.Linq;

using Culture = BulletinReport.Common.Enums.Culture;

namespace BulletinReport.BLL.BulletinsBusinessLogic
{
    public class BulletinsBusinessLogic
    {
        public int CreateBulletin(BulletinsDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Bulletins;
                dto.ProsecutorDuties.RemoveAll(item => item.CallsCount <= 0 || item.ProsecutorShiftTime <= 0);
                var BulletinId = repo.CreateBulletin(dto);

                if (BulletinId == 0)
                {
                    throw new BusinessException("CreateBulletin BLL", Constants.ErrorsCodes.CANNOTCreateBulletin);
                }

                return BulletinId;
            }
        }

        public int UpdateBulliten(BulletinsDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var BulletinId = uow.Bulletins.UpdateBulletin(dto);

                if (BulletinId == 0)
                {
                    throw new BusinessException("UpdateBulliten BLL", Constants.ErrorsCodes.CANNOTCreateBulletin);
                }

                return BulletinId;
            }
        }
        public int DeleteBulliten(int BulletinId, string UserId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {

                var Id = uow.Bulletins.DeleteBulliten(BulletinId, UserId);

                if (Id == 0)
                {
                    throw new BusinessException("DeleteBulliten BLL", Constants.ErrorsCodes.CANNOTCreateBulletin);
                }

                return Id;
            }
        }

        public List<BulletinsDTO> GetAllBulletins(
            out int totalRecords,
            Culture culture,
            string AccidentNumber = "",
            int? PoliceOfficeId = 0,
            int? DepartmentId = 0,
            DateTime? FromDate = null,
            DateTime? ToDate = null,
            string BulletinCreatedBy = "",
            int page = 1,
            int pageSize = 10)
        {
            List<BulletinsDTO> bulletins = new List<BulletinsDTO>();
            totalRecords = 0;

            try
            {
                using (var uow = new UnitOfWork())
                {
                    bulletins = uow.Bulletins.GetAllBulletins();

                    // Filter by parameters
                    if (!string.IsNullOrWhiteSpace(AccidentNumber))
                        bulletins = bulletins.Where(x => x.AccedentNumber.Contains(AccidentNumber.Trim())).ToList();

                    if (PoliceOfficeId != null && PoliceOfficeId != 0)
                        bulletins = bulletins.Where(x => x.PoliceOffice == PoliceOfficeId).ToList();

                    if (DepartmentId != null && DepartmentId != 0)
                        bulletins = bulletins.Where(x => x.Department == DepartmentId).ToList();

                    if (FromDate != null)
                        bulletins = bulletins.Where(x => x.ReportDate >= FromDate).ToList();

                    if (ToDate != null)
                        bulletins = bulletins.Where(x => x.ReportDate <= ToDate).ToList();

                    if (BulletinCreatedBy != null && !string.IsNullOrWhiteSpace(BulletinCreatedBy.Trim()))
                        bulletins = bulletins.Where(x => x.BulletinCreatedBy.Contains(BulletinCreatedBy)).ToList();

                    totalRecords = bulletins.Count();
                    foreach (var bullet in bulletins)
                    {
                        //bullet.BulletinCreatedBy = uow.AspNetUsers.get(bullet.BulletinCreatedBy).UserName;
                        //if (!string.IsNullOrEmpty(bullet.BulletinUpdatedBy))
                        //    bullet.BulletinCreatedBy = uow.AspNetUsers.GetById(bullet.BulletinUpdatedBy).UserName;

                        //if (!string.IsNullOrEmpty(bullet.BulletinDeletedBy))
                        //    bullet.BulletinCreatedBy = uow.AspNetUsers.GetById(bullet.BulletinDeletedBy).UserName;
                        using (var GCAPuow = new GCAPUnitOfWork())
                        {
                            if (culture == Culture.Arabic)
                            {
                                bullet.PoliceOfficeName = GCAPuow.PoliceOffices.GetPoliceOfficeById(bullet.PoliceOffice).Description;
                                bullet.DepartmentName = GCAPuow.Departments.GetById(bullet.Department).Name;

                            }
                            else
                            {
                                bullet.PoliceOfficeName = GCAPuow.PoliceOffices.GetPoliceOfficeById(bullet.PoliceOffice).DisplayNameEn;
                                bullet.DepartmentName = GCAPuow.Departments.GetById(bullet.Department).Name;

                            }
                        }

                    }
                    // Pagination
                    bulletins = bulletins.OrderByDescending(x => x.Id)
                                         .Skip((page - 1) * pageSize)
                                         .Take(pageSize)
                                         .ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetAllBulletins BLL", Constants.ErrorsCodes.GetAllBulletins);
                Tracer.Error(ex);
            }

            return bulletins;
        }

        public BulletinsDTO GetBullitenById(int bulletinId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Bulletins;
                var Bulletin = repo.GetBullitenById(bulletinId);

                if (Bulletin == null)
                {
                    throw new BusinessException("DeleteBulletin BLL", Constants.ErrorsCodes.CANNOTDeleteBulletin);
                }
                using (var GCAPuow = new GCAPUnitOfWork())
                {
                    Bulletin.DepartmentName = GCAPuow.Departments.GetById(Bulletin.Department).Name;
                    Bulletin.PoliceOfficeName = GCAPuow.PoliceOffices.GetPoliceOfficeById(Bulletin.PoliceOffice).Description;
                }
                return Bulletin;
            }
        }


        public List<PoliceOfficeDTO> GetPoliceAllOffices()
        {
            var policeOffice = new List<PoliceOfficeDTO>();
            using (var GCAPuow = new GCAPUnitOfWork())
            {
                policeOffice = GCAPuow.PoliceOffices.GetPoliceAllOffices();
            }
            return policeOffice;
        }
    }
}
