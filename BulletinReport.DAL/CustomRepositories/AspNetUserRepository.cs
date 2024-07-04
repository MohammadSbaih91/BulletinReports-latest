using BulletinReport.Common.DTOs;
using BulletinReport.Common.Utilities;
using BulletinReport.DAL.Entities;
using BulletinReport.DAL.Repositories;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BulletinReport.DAL.CustomRepositories
{
    public class AspNetUserRepository : Repository<AspNetUser>
    {
        public AspNetUserRepository(UnitOfWork uow) : base(uow) { }

        public AspNetUser GetUserByName(string userName)
        {
            var user = GetQuerable(x => x.UserName.Trim().ToLower() == userName.Trim().ToLower()).FirstOrDefault();
            return user;
        }

        public bool IsAlreadyRegistered(string SerialNumber)
        {
            var user = GetQuerable(x => x.Id.Trim() == SerialNumber.Trim()).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RegisterUser(AspNetUserDTO user)
        {
            try
            {
                var record = new AspNetUser()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    PasswordHash = user.PasswordHash,
                };
                Create(record);
                _uow.Save();
                //record.AspNetRoles.Add(new AspNetRole() { Id=(int)UserRole.Admin});
                if (!string.IsNullOrEmpty(record.Id))
                {
                    return record.Id;
                }
                return null;
            }
            catch (Exception ex)
            {
                Tracer.Error(ex);
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return "";
            }

        }

        public string GetUserIdByUserName(string UserName)
        {
            try
            {
                var user = GetQuerable(x => x.UserName == UserName).FirstOrDefault();
                if (user != null)
                {
                    var userId = GetQuerable(x => x.UserName == UserName).FirstOrDefault().Id;

                    if (!String.IsNullOrEmpty(userId))
                    {
                        return userId;
                    }
                    {
                        return "";
                    }
                }
                return string.Empty;

            }
            catch (Exception ex)
            {
                Tracer.Error(ex);
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }

        public string GetUserMobileByUserName(string UserName)
        {
            try
            {
                var user = GetQuerable(x => x.UserName == UserName).FirstOrDefault();
                if (user != null)
                {
                    var MobileNumber = GetQuerable(x => x.UserName == UserName).FirstOrDefault().Mobile;

                    if (!String.IsNullOrEmpty(MobileNumber))
                    {
                        return MobileNumber;


                    }
                    {
                        var PhoneNumber = GetQuerable(x => x.UserName == UserName).FirstOrDefault().PhoneNumber;
                        if (!String.IsNullOrEmpty(PhoneNumber))
                        {
                            return PhoneNumber;
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
                return string.Empty;

            }
            catch (Exception ex)
            {
                Tracer.Error(ex);
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }

        public List<AspNetUserDTO> GetUsersByRole(string userRole)
        {
            try
            {
                var role = _uow.Roles.GetByName(userRole);
                if (role != null)
                {
                    var roleId = role.Id; // Assuming Id is the primary key of AspNetRole

                    var users = GetQuerable(x => x.AspNetRoles.Any(r => r.Id == roleId)).Select(x => new AspNetUserDTO
                    {
                        UserName = x.UserName,
                        AccessFailedCount = x.AccessFailedCount,
                        Email = x.Email,
                        EmailConfirmed = x.EmailConfirmed,
                        Id = x.Id,
                        LockoutEnabled = x.LockoutEnabled,
                        LockoutEndDateUtc = x.LockoutEndDateUtc,
                        PasswordHash = x.PasswordHash,
                        PhoneNumber = x.PhoneNumber,
                        PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                        SecurityStamp = x.SecurityStamp,
                        TwoFactorEnabled = x.TwoFactorEnabled
                    }).ToList();

                    return users;
                }

                return null;
            }
            catch (Exception ex)
            {
                Tracer.Error(ex);
                // cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }

        public string GetUserNameByAspNetUserID(string aspnetid)
        {
            var user = GetQuerable(x => x.Id.ToLower() == aspnetid.ToLower()).FirstOrDefault().UserName;
            return user;
        }
        
        public List<User> GetUsersByDeptId(int? DepartmentID)
        {
            return _db.Users.Where(x => x.Department == DepartmentID && x.Deleted == 0 && (x.DefaultGroup.Contains("_Acting") || x.DefaultGroup.Contains("_Presedent"))).OrderByDescending(o => o.DefaultGroup).ToList();
        }

        public User GetUsersByUserName(string UserName)
        {
            return _db.Users.Where(x => x.LogonName == UserName && x.Deleted == 0).FirstOrDefault();
        }
    }
}
