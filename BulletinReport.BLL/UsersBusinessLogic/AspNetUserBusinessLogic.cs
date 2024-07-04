using BulletinReport.Common.DTOs;
using BulletinReport.DAL;
using BulletinReport.DAL.Entities;
using GCAP.DAL;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;

namespace BulletinReport.BLL.UsersBusinessLogic
{
    public class AspNetUserBusinessLogic
    {
        public string RegisterUser(UsersDTO user)
        {
            using (var uow = new UnitOfWork())
            {
                //string UserId = uow.AspNetUsers.RegisterUser(user);
                //return UserId;
                return "ss";
            }
        }

        public List<AspNetUserDTO> GetAllLDAPUsers(int DepartmentID)
        {
            List<AspNetUserDTO> users = new List<AspNetUserDTO>();

            // LDAP path from Web.config
            string ldapPath = ConfigurationManager.AppSettings["LDAPServer"];

            // Set up LDAP connection and search object
            DirectoryEntry directoryEntry = new DirectoryEntry(ldapPath);
            DirectorySearcher searcher = new DirectorySearcher(directoryEntry)
            {
                Filter = "(objectClass=user)"  // Retrieves all users
            };

            try
            {
                // Perform search
                SearchResultCollection results = searcher.FindAll();
                if (results != null && results.Count > 0)
                {   // Map results to AspNetUserDTO
                    foreach (SearchResult result in results)
                    {
                        if (result.Properties["samAccountName"].Count > 0 && result.Properties["displayName"].Count > 0)
                        {
                            users.Add(new AspNetUserDTO
                            {
                                UserName = result.Properties["samAccountName"][0].ToString(),
                                Name = result.Properties["displayName"][0].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., logging)
                Console.WriteLine(ex.Message);
            }
            finally
            {
                directoryEntry.Close();
                searcher.Dispose();
            }

            return users;
        }

        public List<UsersDTO> GetAllLDAPUsers()
        {
            List<UsersDTO> users = new List<UsersDTO>();

            // LDAP path from Web.config
            string ldapPath = ConfigurationManager.AppSettings["LDAPServer"];

            // Set up LDAP connection and search object
            DirectoryEntry directoryEntry = new DirectoryEntry(ldapPath);
            DirectorySearcher searcher = new DirectorySearcher(directoryEntry)
            {
                Filter = "(objectClass=user)"  // Retrieves all users
            };

            try
            {
                // Perform search
                SearchResultCollection results = searcher.FindAll();
                if (results != null && results.Count > 0)
                {   // Map results to AspNetUserDTO
                    foreach (SearchResult result in results)
                    {
                        if (result.Properties["samAccountName"].Count > 0 && result.Properties["displayName"].Count > 0)
                        {
                            users.Add(new UsersDTO
                            {
                                LogonName = result.Properties["samAccountName"][0].ToString(),
                                Name = result.Properties["displayName"][0].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., logging)
                Console.WriteLine(ex.Message);
            }
            finally
            {
                directoryEntry.Close();
                searcher.Dispose();
            }

            return users;
        }

        public List<UsersDTO> GetUsersByRole(int? DepartmentId)
        {
            List<UsersDTO> users = new List<UsersDTO>();

            using (var uow = new GCAPUnitOfWork())
            {
                users = uow.Users.GetDepartmentUsers(DepartmentId);
                return users;
            }
        }

        public string GetUserNameByAspNetUserID(string aspnetid)
        {
            string username = string.Empty;
            using (var uow = new UnitOfWork())
            {
                username = uow.AspNetUsers.GetUserNameByAspNetUserID(aspnetid);
                return username;
            }
        }

        public AspNetUserDTO GetUserByName(string userName)
        {
            using (var uow = new UnitOfWork())
            {

                var userEntity = uow.AspNetUsers.GetUserByName(userName);
                var user = new AspNetUserDTO()
                {
                    Id = userEntity.Id,
                    UserName = userEntity.UserName,
                    Email = userEntity.Email,
                    EmailConfirmed = userEntity.EmailConfirmed,
                    AccessFailedCount = userEntity.AccessFailedCount,
                };
                return user;
            }
        }

        public string GetUserIdByUserName(string UserName)
        {

            using (var uow = new UnitOfWork())
            {
                string UserId = uow.AspNetUsers.GetUserIdByUserName(UserName);
                return UserId;
            }

        }

        public string GetUserMobileByUserName(string UserName)
        {

            using (var uow = new UnitOfWork())
            {
                string mobileNumber = uow.AspNetUsers.GetUserMobileByUserName(UserName);
                return mobileNumber;
            }

        }

        public List<User> GetAllUsersByDeptID(int? DepartmentID)
        {
            List<User> users = new List<User>();
            try
            {
                using (var uow = new UnitOfWork())
                {
                    users = uow.AspNetUsers.GetUsersByDeptId(DepartmentID);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., logging)
                Console.WriteLine(ex.Message);
            }

            return users;
        }

        public User GetUserByUserName(string UserName)
        {
            User users = new User();
            try
            {
                using (var uow = new UnitOfWork())
                {
                    users = uow.AspNetUsers.GetUsersByUserName(UserName);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., logging)
                Console.WriteLine(ex.Message);
            }

            return users;
        }
    }
}
