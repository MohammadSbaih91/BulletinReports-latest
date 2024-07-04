using BulletinReport.Common.DTOs.DepartmentDTO;
using BulletinReport.DAL.Entities;
using System;
using System.Collections.Generic;

namespace BulletinReports.Models.BulletinsViewModel
{
    public class BulletinsViewModel
    {
        public BulletinsViewModel()
        {
            //Bulletins = new List<BulletinViewModel>();
        }

        public string AccedentNumber { get; set; } // Already nullable as a string
        public int? PoliceOffice { get; set; }     // Now nullable
        public int? Department { get; set; }       // Now nullable
        public DateTime? BulletinDateFrom { get; set; } // Now nullable
        public DateTime? BulletinDateTo { get; set; }   // Now nullable
        public string UserId { get; set; }

        public IEnumerable<User> DBUsers { get; set; }
        public IEnumerable<AspNetUsersBulletinViewModel> Users { get; set; }
        public IEnumerable<DepartmentDTO> Departments { get; set; }
        public IEnumerable<PoliceOfficeDTO> PoliceOffices { get; set; }
        public IEnumerable<BulletinViewModel> Bulletins { get; set; }
    }
}