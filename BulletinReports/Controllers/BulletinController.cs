using Aspose.Pdf;
using Aspose.Pdf.Forms;

using BulittenReports.Mapper;

using BulletinReport.BLL.BulletinsBusinessLogic;
using BulletinReport.BLL.DepartmentsBusinessLogic;
using BulletinReport.BLL.LookupsBusinessLogic;
using BulletinReport.BLL.UsersBusinessLogic;
using BulletinReport.Common;
using BulletinReport.Common.App_LocalResources;
using BulletinReport.Common.DTOs;
using BulletinReport.DAL.Entities;

using BulletinReports.Base;
using BulletinReports.Models.BulletinsViewModel;
using BulletinReports.PagedList.UIHelper;
using BulletinReports.UIHelper;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
namespace BulletinReports.Controllers
{
    //[LdapAuthorize]
    public class BulletinController : BaseController
    {
        private LookupCategoryBusinessLogic _LookupCategoryBusinessLogic;

        private LookupsBusinessLogic _LookupsBusinessLogic;

        private BulletinsBusinessLogic _BulletinsBusinessLogic;

        private AspNetUserBusinessLogic _AspNetUserBusinessLogic;

        private UsersBusinessLogic _UsesrBusinessLogic;

        private DepartmentsBusinessLogic _DepartmentsBusinessLogic;

        public BulletinController()
        {
            _LookupCategoryBusinessLogic = new LookupCategoryBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
            _BulletinsBusinessLogic = new BulletinsBusinessLogic();
            _AspNetUserBusinessLogic = new AspNetUserBusinessLogic();
            _UsesrBusinessLogic = new UsersBusinessLogic();
            _DepartmentsBusinessLogic = new DepartmentsBusinessLogic();
        }

        // GET: Bulletin
        public ActionResult Index()
        {
            //int totalRecords = 0;
            //int page = 1;
            //int pageSize = 10;
            //var Bulletins = _BulletinsBusinessLogic.GetAllBulletins(
            //    out totalRecords,
            //    base.CurrentCulture,
            //    null,
            //    null,
            //    null,
            //    null,
            //    null,
            //    null,
            //    page,
            //    pageSize
            //).ToUIBulletins(base.CurrentCulture);
            BulletinsViewModel model = new BulletinsViewModel();
            List<BulletinViewModel> List = new List<BulletinViewModel>();
            model.Departments = _DepartmentsBusinessLogic.GetAllDepartments();
            model.PoliceOffices = _BulletinsBusinessLogic.GetPoliceAllOffices();
            // You can access ViewBag.LoginMethod directly since it's set in the BaseController
            string loginMethod = ViewBag.LoginMethod as string;
            if (model.Department != null)
                model.DBUsers = _AspNetUserBusinessLogic.GetAllUsersByDeptID(model.Department);

            //var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");
            //List = Bulletins;

            //var pagedList = List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);
            model.Bulletins = new List<BulletinViewModel>();

            return View(model);

        }

        private IEnumerable<BulletinViewModel> GetBulletins(out int totalRecords, int page = 1, int pageSize = 10)
        {
            List<BulletinViewModel> List = new List<BulletinViewModel>();
            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");

            var Bulletins = _BulletinsBusinessLogic.GetAllBulletins(
                out totalRecords,
                base.CurrentCulture,
                null,
                null,
                null,
                null,
                null,
                null,
                page,
                pageSize
            ).ToUIBulletins(base.CurrentCulture);
            List = Bulletins;

            return List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);


        }

        public ActionResult LoadResultsPage(BulletinsViewModel model = null, int page = 1)
        {
            int totalRecords;
            var pagedList = GetBulletinsList(model, out totalRecords, page, BackendSettings.DefaultPageSize);
            // get the corresponding page for the results table            
            return PartialView("~/Views/Shared/Partials/_BulletinsList.cshtml", pagedList);
        }

        private List<BulletinViewModel> GetBulletinsList(BulletinsViewModel model, out int totalRecords, int page = 1, int pageSize = 10, bool isReport = false)
        {
            List<BulletinViewModel> List = new List<BulletinViewModel>();
            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");
            var Bulletins = _BulletinsBusinessLogic.GetAllBulletins(
                out totalRecords,
                base.CurrentCulture,
                model.AccedentNumber,
                model.PoliceOffice,
                model.Department,
                model.BulletinDateFrom,
                model.BulletinDateTo,
                model.UserId,
                page,
                pageSize
            ).ToUIBulletins(base.CurrentCulture);

            foreach (var item in Bulletins)
            {
                List.Add(item);

            }
            return List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);

        }

        [HttpPost]
        public ActionResult Index(BulletinsViewModel model)
        {
            int totalRecords = 0;
            int page = 1;
            int pageSize = 10;
            var Bulletins = _BulletinsBusinessLogic.GetAllBulletins(
                out totalRecords,
                base.CurrentCulture,
                model.AccedentNumber,
                model.PoliceOffice,
                model.Department,
                model.BulletinDateFrom,
                model.BulletinDateTo,
                model.UserId,
                page,
                pageSize
            ).ToUIBulletins(base.CurrentCulture);
            List<BulletinViewModel> List = new List<BulletinViewModel>();
            model.Departments = _DepartmentsBusinessLogic.GetAllDepartments();
            model.PoliceOffices = _BulletinsBusinessLogic.GetPoliceAllOffices();
            // You can access ViewBag.LoginMethod directly since it's set in the BaseController
            string loginMethod = ViewBag.LoginMethod as string;
            model.DBUsers = _AspNetUserBusinessLogic.GetAllUsersByDeptID(model.Departments.FirstOrDefault().ID);

            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");
            List = Bulletins;

            var pagedList = List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);
            model.Bulletins = pagedList;

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateBulletin()
        {
            BulletinViewModel model = new BulletinViewModel();
            // You can access ViewBag.LoginMethod directly since it's set in the BaseController
            string loginMethod = ViewBag.LoginMethod as string;
            model.ProsecutorDuties = new List<ProsecutorDutyViewModel>()
            {
                new ProsecutorDutyViewModel(),
                new ProsecutorDutyViewModel(),
                new ProsecutorDutyViewModel(),
                new ProsecutorDutyViewModel()
            };

            foreach (var duty in model.ProsecutorDuties)
            {
                duty.ShiftTime = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ShiftTime", base.CurrentCulture);
                duty.PublicProsecutions = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("PublicProsecution", base.CurrentCulture);
            }

            model.Departments = _DepartmentsBusinessLogic.GetAllDepartments();
            model.PoliceOffices = _BulletinsBusinessLogic.GetPoliceAllOffices();
            model.OfficerRanks = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("OfficerRanks", base.CurrentCulture);
            model.PartyNationalities = _UsesrBusinessLogic.GetAllCodingTablesData();
            model.BulletinTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("BulletinTypes", base.CurrentCulture);
            //model.BulletinTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("BulletinTypes", base.CurrentCulture);
            model.DepartmentUsers = new List<UsersDTO>();

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateBulletin(BulletinViewModel model)
        {
            model.BulletinCreatedAt = System.DateTime.Now;
            model.BulletinNameAr = model.BulletinPoName;
            // You can access ViewBag.LoginMethod directly since it's set in the BaseController
            string loginMethod = ViewBag.LoginMethod as string;
            if (loginMethod == null || loginMethod == "Web")
            {
                model.CreatedBy = base.CurrentUserName;
                model.Procedures.ProcedureCreatedBy = base.CurrentUserName;
                model.OfficerPhoneNumber = _AspNetUserBusinessLogic.GetUserMobileByUserName(base.CurrentUserName);
            }
            else if (loginMethod == "LDAP")
            {
                model.CreatedBy = base.GetCurrentUserName();
                model.Procedures.ProcedureCreatedBy = base.GetCurrentUserName();
                model.OfficerPhoneNumber = base.GetCurrentUserPhoneNumber();
            }

            model.Procedures.ProcedureCreatedAt = System.DateTime.Now;
            if (model.Procedures.HasBeenMoved.HasValue)
            {
                model.Procedures.NotBeenMoved = true;
            }
            else
            {
                model.Procedures.NotBeenMoved = false;
            }
            foreach (var prosecutor in model.ProsecutorDuties)
            {
                prosecutor.BulletinReportTime = System.DateTime.Now;
                prosecutor.PhoneAnswerTime = System.DateTime.Now;
            }

            ModelState.Remove("PoliceOffices");
            ModelState.Remove("OfficerRanks");
            ModelState.Remove("PartyNationalities");
            ModelState.Remove("Departments");
            ModelState.Remove("OfficerPhoneNumber");
            ModelState.Remove("BulletinNameAr");
            ModelState.Remove("PartyNameAr");
            foreach (var prosecutor in model.ProsecutorDuties)
            {
                var index = model.ProsecutorDuties.IndexOf(prosecutor);
                ModelState.Remove($"ProsecutorDuties[{index}].Id");
                ModelState.Remove($"ProsecutorDuties[{index}].CallsCount");
                ModelState.Remove($"ProsecutorDuties[{index}].PublicProsecutionId");
            }
            model.PartyNameAr = model.PartyName;
            model.Procedures.Prosecutor = model.DepartmentUser.ToString();//temp should be change later 
            bool isSamePolice = false;
            if (model.ProsecutorDuties != null)
            {
                foreach (var item in model.ProsecutorDuties)
                {
                    if (item.CallsCount <= 0 || item.ProsecutorShiftId == null || string.IsNullOrWhiteSpace(item.ProsecutorShiftId))
                    {
                        isSamePolice = true;
                    }
                    else
                    {
                        isSamePolice = false;
                        break; // Exit the loop if any condition is not met
                    }
                }
            }
            if (isSamePolice)
            {
                ProsecutorDutyViewModel ProsecuterModel = new ProsecutorDutyViewModel();
                ProsecuterModel.BulletinReportProsecutor = model.BulletinPoName;
                ProsecuterModel.BulletinReportTime = DateTime.Now;
                ProsecuterModel.CallsCount = 1;
                ProsecuterModel.PhoneAnswerTime = DateTime.Now;
                ProsecuterModel.ProsecutorNotes = "";
                ProsecuterModel.ProsecutorShiftId = "6";//Shift A
                ProsecuterModel.ProsecutorShiftTime = DateTime.Now.ToLongDateString();
                model.ProsecutorDuties.Add(ProsecuterModel);
            }
            int BulletinId = _BulletinsBusinessLogic.CreateBulletin(model.ToBulletinDTO());

            if (!ModelState.IsValid)
            {
                model.ProsecutorDuties = _AspNetUserBusinessLogic.GetAllLDAPUsers().ToProsecutorDutiesUI();
                model.ProsecutorDuties.ForEach(u => u.ShiftTime = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ShiftTime", base.CurrentCulture));
                model.BulletinTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("BulletinTypes", base.CurrentCulture);
                model.Departments = _DepartmentsBusinessLogic.GetAllDepartments();
                model.PoliceOffices = _BulletinsBusinessLogic.GetPoliceAllOffices();
                model.OfficerRanks = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("OfficerRanks", base.CurrentCulture);
                model.PartyNationalities = _UsesrBusinessLogic.GetAllCodingTablesData();
                foreach (var duty in model.ProsecutorDuties)
                {
                    duty.ShiftTime = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ShiftTime", base.CurrentCulture);
                    duty.Prosecutors = new List<UsersDTO>();
                }

                model.DepartmentUsers = _UsesrBusinessLogic.GetDepartmentUsers(null);

                TempData["Error"] = Resource.GenericError;
                return View(model);
            }

            if (BulletinId > 0)
            {
                TempData["Success"] = Resource.CreateBulletinSucces;
                model.Id = BulletinId;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBulletin(int BulletinId)
        {
            BulletinViewModel model = new BulletinViewModel();
            model = _BulletinsBusinessLogic.GetBullitenById(BulletinId).ToUIBulletin(base.CurrentCulture);
            model.BulletinCreatedAt = System.DateTime.Now;
            model.CreatedBy = base.CurrentAspNetId;
            model.Procedures.ProcedureCreatedBy = base.CurrentAspNetId;
            model.Procedures.ProcedureCreatedAt = System.DateTime.Now;
            model.DepartmentUsers = _UsesrBusinessLogic.GetDepartmentUsers(model.Department);
            model.DepartmentUser = Convert.ToInt32(model.Procedures.Prosecutor);
            foreach (var prosecutor in model.ProsecutorDuties)
            {
                prosecutor.BulletinReportTime = System.DateTime.Now;
                prosecutor.PhoneAnswerTime = System.DateTime.Now;
            }

            model.BulletinType = model.BulletinType;
            ModelState.Remove("PoliceOffices");
            ModelState.Remove("OfficerRanks");
            ModelState.Remove("PartyNationalities");
            ModelState.Remove("Departments");
            ModelState.Remove("OfficerPhoneNumber");
            ModelState.Remove("BulletinNameAr");
            foreach (var prosecutor in model.ProsecutorDuties)
            {
                var index = model.ProsecutorDuties.IndexOf(prosecutor);
                ModelState.Remove($"ProsecutorDuties[{index}].Id");
                ModelState.Remove($"ProsecutorDuties[{index}].CallsCount");
                ModelState.Remove($"ProsecutorDuties[{index}].PublicProsecutionId");
                //ModelState.Remove($"ProsecutorDuties[{index}].Id");
                //ModelState.Remove($"ProsecutorDuties[{index}].Id");
            }
            // You can access ViewBag.LoginMethod directly since it's set in the BaseController
            string loginMethod = ViewBag.LoginMethod as string;
            //model.ProsecutorDuties = _AspNetUserBusinessLogic.GetAllLDAPUsers().ToProsecutorDutiesUI();

            //model.ProsecutorDuties.ForEach(u => u.ShiftTime = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ShiftTime", base.CurrentCulture));
            model.BulletinTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("BulletinTypes", base.CurrentCulture);
            model.Departments = _DepartmentsBusinessLogic.GetAllDepartments();
            model.PoliceOffices = _BulletinsBusinessLogic.GetPoliceAllOffices();
            model.OfficerRanks = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("OfficerRanks", base.CurrentCulture);
            model.PartyNationalities = _UsesrBusinessLogic.GetAllCodingTablesData();
            foreach (var duty in model.ProsecutorDuties)
            {
                duty.ShiftTime = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ShiftTime", base.CurrentCulture);
                if (loginMethod == null || loginMethod == "Web")
                {
                    //duty.Prosecutors = _UsesrBusinessLogic.GetDepartmentUsers(null); // Example method
                    duty.Prosecutors = new List<UsersDTO>();
                }
                else if (loginMethod == "LDAP")
                {
                    //duty.Prosecutors = _AspNetUserBusinessLogic.GetAllLDAPUsers(); // Example method
                    duty.Prosecutors = new List<UsersDTO>();
                }
                duty.PublicProsecutions = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("PublicProsecution", base.CurrentCulture);
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateBulletin(BulletinViewModel model)
        {
            model.BulletinUpdatedAt = System.DateTime.Now;
            model.BulletinNameAr = model.BulletinPoName;
            // You can access ViewBag.LoginMethod directly since it's set in the BaseController
            string loginMethod = ViewBag.LoginMethod as string;
            if (loginMethod == null || loginMethod == "Web")
            {
                model.UpdatedBy = base.CurrentUserName;
                model.Procedures.ProcedureUpdatedBy = base.CurrentUserName;
                model.OfficerPhoneNumber = _AspNetUserBusinessLogic.GetUserMobileByUserName(base.CurrentUserName);
            }
            else if (loginMethod == "LDAP")
            {
                model.CreatedBy = base.GetCurrentUserName();
                model.Procedures.ProcedureCreatedBy = base.GetCurrentUserName();
                model.OfficerPhoneNumber = base.GetCurrentUserPhoneNumber();
            }

            foreach (var prosecutor in model.ProsecutorDuties)
            {
                prosecutor.BulletinReportTime = System.DateTime.Now;
                prosecutor.PhoneAnswerTime = System.DateTime.Now;
            }
            //model.Procedures.PublicProsecution = model.ProsecutorDuties.FirstOrDefault().PublicProsecutionId.Value;//first selected
            int BulletinId = _BulletinsBusinessLogic.UpdateBulliten(model.ToBulletinDTO());

            ModelState.Remove("PoliceOffices");
            ModelState.Remove("OfficerRanks");
            ModelState.Remove("PartyNationalities");
            ModelState.Remove("Departments");
            ModelState.Remove("OfficerPhoneNumber");
            ModelState.Remove("BulletinNameAr");
            foreach (var prosecutor in model.ProsecutorDuties)
            {
                var index = model.ProsecutorDuties.IndexOf(prosecutor);
                ModelState.Remove($"ProsecutorDuties[{index}].Id");
                ModelState.Remove($"ProsecutorDuties[{index}].CallsCount");
                ModelState.Remove($"ProsecutorDuties[{index}].PublicProsecutionId");
                //ModelState.Remove($"ProsecutorDuties[{index}].Id");
                //ModelState.Remove($"ProsecutorDuties[{index}].Id");
            }

            model.ProsecutorDuties = _AspNetUserBusinessLogic.GetAllLDAPUsers().ToProsecutorDutiesUI();
            model.ProsecutorDuties.ForEach(u => u.ShiftTime = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ShiftTime", base.CurrentCulture));
            model.BulletinTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("BulletinTypes", base.CurrentCulture);
            model.Departments = _DepartmentsBusinessLogic.GetAllDepartments();
            model.PoliceOffices = _BulletinsBusinessLogic.GetPoliceAllOffices();
            model.OfficerRanks = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("OfficerRanks", base.CurrentCulture);
            model.PartyNationalities = _UsesrBusinessLogic.GetAllCodingTablesData();
            model.DepartmentUsers = _UsesrBusinessLogic.GetDepartmentUsers(null);

            foreach (var duty in model.ProsecutorDuties)
            {
                duty.ShiftTime = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ShiftTime", base.CurrentCulture);
                if (loginMethod == null || loginMethod == "Web")
                {
                    //duty.Prosecutors = _UsesrBusinessLogic.GetDepartmentUsers(null); // Example method
                    duty.Prosecutors = new List<UsersDTO>();
                }
                else if (loginMethod == "LDAP")
                {
                    //duty.Prosecutors = _AspNetUserBusinessLogic.GetAllLDAPUsers(); // Example method
                    duty.Prosecutors = new List<UsersDTO>();
                }
                duty.PublicProsecutions = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("PublicProsecution", base.CurrentCulture);
            }
            ModelState.Remove("PartyNameAr");
            ModelState.Remove("PartyOtherDescription");
            //ModelState.Remove("ProsecutorDuties[3].PublicProsecutionId");
            if (!ModelState.IsValid)
            {
                TempData["Error"] = Resource.GenericError;
                return View(model);
            }

            if (BulletinId > 0)
            {
                TempData["Success"] = Resource.UpdateBulletinSuccessfully;
                model.Id = BulletinId;
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteBulletin(int BulletinId)
        {
            BulletinViewModel model = new BulletinViewModel();
            string loginMethod = ViewBag.LoginMethod as string;
            int BId = 0;
            if (loginMethod == null || loginMethod == "Web")
            {
                BId = _BulletinsBusinessLogic.DeleteBulliten(BulletinId, base.CurrentUserName);
            }
            else if (loginMethod == "LDAP")
            {
                BId = _BulletinsBusinessLogic.DeleteBulliten(BulletinId, base.GetCurrentUserName());
            }
            if (BId > 0)
            {
                TempData["Success"] = Resource.DeleteBulletinSuccessfully;
                model.Id = BulletinId;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Viewer(int BtnID)
        {
            var bulletin = _BulletinsBusinessLogic.GetBullitenById(BtnID);
            if (bulletin == null)
            {
                return Content("Bulletin not found.");
            }

            // Paths to the PDF template and output
            string pdfTemplatePath = Server.MapPath("~/Files/Template.pdf");
            string filledPdfPath = Server.MapPath($"~/Files/Report-{BtnID}.pdf");

            // Initialize the Pdf file
            Document pdfDocument = new Document(pdfTemplatePath);
            Aspose.Pdf.Facades.Form form = new Aspose.Pdf.Facades.Form(pdfTemplatePath, filledPdfPath);
            int Day = bulletin.BulletinCreatedAt.Day;
            int Month = bulletin.BulletinCreatedAt.Month;
            string dayName = bulletin.BulletinCreatedAt.ToString("dddd", new CultureInfo("ar-SA"));
            string Year = bulletin.BulletinCreatedAt.Year.ToString();
            string time = bulletin.BulletinCreatedAt.ToLongTimeString().ToString();
            string rankWithName = _LookupsBusinessLogic.GetLookupByLookupId(bulletin.OfficerRank, Enums.Culture.Arabic).ValueAr + " " + bulletin.BulletinPoName;
            string bullTypeNameAr = _LookupsBusinessLogic.GetLookupByLookupId(bulletin.BulletinType, Enums.Culture.Arabic).ValueAr + " " + bulletin.BulletinPoName;
            string PartyNationalityName = _UsesrBusinessLogic.GetNationalityById(bulletin.PartyNationality);
            if (bulletin.Procedures != null)
            {
                bool isMoved = bulletin.Procedures.HasBeenMoved.HasValue ? bulletin.Procedures.HasBeenMoved.Value : false;
                if (isMoved)
                {
                    CheckboxField checkbox = pdfDocument.Form["checkbox_1"] as CheckboxField;

                    if (checkbox != null)
                    {
                        // Check the checkbox by setting its value
                        checkbox.Checked = true; // This directly checks the checkbox
                    }
                    else
                    {
                        return Content("Checkbox field not found.");
                    }
                }
                else
                {
                    CheckboxField checkbox2 = pdfDocument.Form["checkbox_2"] as CheckboxField;

                    if (checkbox2 != null)
                    {
                        // Check the checkbox by setting its value
                        checkbox2.Checked = true; // This directly checks the checkbox
                    }
                    else
                    {
                        return Content("Checkbox field not found.");
                    }
                }
            }

            int duties = bulletin.ProsecutorDuties.Count;
            string dutyname1 = string.Empty;
            string dutyname2 = string.Empty;
            string dutyname3 = string.Empty;
            string dutyname4 = string.Empty;
            string dutytime1 = string.Empty;
            string dutytime2 = string.Empty;
            string dutytime3 = string.Empty;
            string dutytime4 = string.Empty;
            string dutyshifttime1 = string.Empty;
            string dutyshifttime2 = string.Empty;
            string dutyshifttime3 = string.Empty;
            string dutyshifttime4 = string.Empty;
            string duty1calls = string.Empty;
            string duty2calls = string.Empty;
            string duty3calls = string.Empty;
            string duty4calls = string.Empty;
            if (duties > 0)
            {
                if (duties > 0)
                {
                    dutyname1 = bulletin.ProsecutorDuties[0].BulletinReportProsecutor;  //_UsesrBusinessLogic.GetUserByUserId(bulletin.ProsecutorDuties[0].BulletinReportProsecutor).Name;
                    dutytime1 = bulletin.ProsecutorDuties[0].BulletinReportTime.ToString();
                    dutyshifttime1 = bulletin.ProsecutorDuties[0].ProsecutorShiftTime.ToString();
                    duty1calls = bulletin.ProsecutorDuties[0].CallsCount.ToString();
                }
                if (duties > 1)
                {
                    dutyname2 = bulletin.ProsecutorDuties[0].BulletinReportProsecutor;  //_UsesrBusinessLogic.GetUserByUserId(bulletin.ProsecutorDuties[1].BulletinReportProsecutor).Name;
                    dutytime2 = bulletin.ProsecutorDuties[1].BulletinReportTime.ToString();
                    dutyshifttime2 = bulletin.ProsecutorDuties[1].ProsecutorShiftTime.ToString();
                    duty2calls = bulletin.ProsecutorDuties[1].CallsCount.ToString();
                }
                if (duties > 2)
                {
                    dutyname3 = bulletin.ProsecutorDuties[0].BulletinReportProsecutor;  //_UsesrBusinessLogic.GetUserByUserId(bulletin.ProsecutorDuties[2].BulletinReportProsecutor).Name;
                    dutytime3 = bulletin.ProsecutorDuties[2].BulletinReportTime.ToString();
                    dutyshifttime3 = bulletin.ProsecutorDuties[2].ProsecutorShiftTime.ToString();
                    duty3calls = bulletin.ProsecutorDuties[2].CallsCount.ToString();
                }
                if (duties > 3)
                {
                    dutyname4 = bulletin.ProsecutorDuties[0].BulletinReportProsecutor;  //_UsesrBusinessLogic.GetUserByUserId(bulletin.ProsecutorDuties[3].BulletinReportProsecutor).Name;
                    dutytime4 = bulletin.ProsecutorDuties[3].BulletinReportTime.ToString();
                    dutyshifttime4 = bulletin.ProsecutorDuties[3].ProsecutorShiftTime.ToString();
                    duty4calls = bulletin.ProsecutorDuties[3].CallsCount.ToString();
                }
            }
            try
            {
                form.FillField("AccidentNumber", bulletin.AccedentNumber);

                // Fill the fields
                form.FillField("A1", Day.ToString());
                form.FillField("A2", Month.ToString());
                //formFields.SetField("A3", dayName);
                form.FillField("Ahead", bulletin.AccedentNumber);
                form.FillField("ADate", Year);
                form.FillField("A4", time);
                form.FillField("A5", bulletin.AccedentNumber);
                form.FillField("A6", bulletin.PoliceOfficeName);
                form.FillField("A7", rankWithName);
                form.FillField("A8", bulletin.BulletinPoNumber);
                form.FillField("A9", bullTypeNameAr);
                form.FillField("A10", bulletin.BulletinDescription);
                form.FillField("A11", bulletin.PartyNameAr);
                form.FillField("A12", bulletin.PartyAge.ToString());
                form.FillField("A13", bulletin.PartyQatariId.ToString());
                form.FillField("A14", PartyNationalityName);
                form.FillField("A15", bulletin.PartyOtherDescription);
                form.FillField("A16", bulletin.DepartmentName);
                if (bulletin.Procedures != null)
                {
                    form.FillField("A17", bulletin.Procedures.ProcedureTime.ToString());
                    form.FillField("A18", bulletin.Procedures.Prosecutor);
                }

                if (!string.IsNullOrWhiteSpace(dutyname1))
                {
                    form.FillField("A22", dutyname1);
                }
                if (!string.IsNullOrWhiteSpace(dutytime1))
                {
                    form.FillField("A23", dutytime1);
                }
                if (!string.IsNullOrWhiteSpace(duty1calls))
                {
                    form.FillField("A24", duty1calls);
                }

                if (!string.IsNullOrWhiteSpace(dutyname2))
                {
                    form.FillField("A25", dutyname2);
                }
                if (!string.IsNullOrWhiteSpace(dutytime2))
                {
                    form.FillField("A26", dutytime2);
                }
                if (!string.IsNullOrWhiteSpace(duty2calls))
                {
                    form.FillField("A27", duty2calls);
                }

                if (!string.IsNullOrWhiteSpace(dutyname3))
                {
                    form.FillField("A28", dutyname3);
                }
                if (!string.IsNullOrWhiteSpace(dutytime3))
                {
                    form.FillField("A29", dutytime3);
                }
                if (!string.IsNullOrWhiteSpace(duty3calls))
                {
                    form.FillField("A30", duty3calls);
                }

                if (!string.IsNullOrWhiteSpace(dutyname4))
                {
                    form.FillField("A31", dutyname4);
                }
                if (!string.IsNullOrWhiteSpace(dutytime4))
                {
                    form.FillField("A32", dutytime4);
                }
                if (!string.IsNullOrWhiteSpace(duty4calls))
                {
                    form.FillField("A33", duty4calls);
                }

                form.FillField("A18", bulletin.BulletinCreatedAt.ToShortDateString());
                User user = _AspNetUserBusinessLogic.GetUserByUserName(base.GetCurrentUserName());
                if (user != null)
                    form.FillField("A40", user.Name);

                form.FillField("A41", DateTime.Now.ToString("MM-dd-yyyy"));
                // Continue with other fields
                pdfDocument.Flatten();
                form.FlattenAllFields();
                // Save the filled PDF
                form.Save();

                ViewBag.FilePath = $"/Files/Report-{BtnID}.pdf";
                return View();
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error message
                return Content("Error filling or printing PDF: " + ex.Message);
            }
            finally
            {
                form.Dispose();
                pdfDocument.Dispose();
            }
        }

        public ActionResult GetDepartmentUsers(int departmentId)
        {
            var users = _UsesrBusinessLogic.GetDepartmentUsers(departmentId); // Implement this method to fetch users based on department
            return Json(users.Select(x => new { id = x.ID, name = x.Name }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsersByDeptID(int? DeptID)
        {
            var users = _AspNetUserBusinessLogic.GetAllUsersByDeptID(DeptID);
            return Json(users.Select(x => new { id = x.ID, name = x.Name }), JsonRequestBehavior.AllowGet);
        }
    }
}