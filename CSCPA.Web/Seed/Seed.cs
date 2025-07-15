using Microsoft.AspNetCore.Identity;
using System;
using CSCPA.Core;
using CSCPA.Repo;
using CSCPA.Service;
using CSCPA.Model;
using System.Threading.Tasks;
using CSCPA.Data;
using System.Linq;
using CSCPA.Data.Entities;
using System.Collections.Generic;

namespace CSCPA.Web.Seed
{
    public class Seed
    {
        private AppDbContext _context;
        private IUnitOfWork _uow;
        public Seed(AppDbContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
        }

        public void SeedAdminUser()
        {
            var user = CreateUser();
            var role = CreateRole();
       /*     var param = CreateParameterType();
            CreateAccountGroup();*/
            var userRole = _context.UserAccountRoles.Where(x => x.UserAccountId == user && x.RoleId == role).FirstOrDefault();
            if(userRole == null)
            {
                UserAccountRole accountRole = new UserAccountRole()
                {
                    UserAccountId = user,
                    RoleId = role,
                };
                _context.UserAccountRoles.Add(accountRole);
                _context.SaveChanges();
            }
        }
        public Guid CreateUser()
        {
            var userAccounts = _context.UserAccounts.Where(x => x.Name == "SystemAdministrator").FirstOrDefault();
            if (userAccounts == null)
            {
                UserAccount userAccount = new UserAccount()
                {
                    Name = "SystemAdministrator",
                    NameAlias = "SystemAdministrator",
                    Username = "SystemAdministrator",
                    Password = "Password@12345",
                    ConfirmPassword = "Password@12345",
                    Email = "SystemAdministrator@localhost.com",
                    LocalisationId = Guid.Parse("340a778c-17e4-4b34-b4bc-ffa36b74a0a1")
                };
                _context.UserAccounts.Add(userAccount);
                _context.SaveChanges();
                return userAccount.ObjectUid;
            }
            return userAccounts.ObjectUid;
        }
        public Guid CreateRole()
        {
            var roles = _context.Roles.Where(x => x.Name == "SystemAdmin").FirstOrDefault();
            if(roles == null)
            {
                Role role = new Role()
                {
                    Name = "SystemAdmin",
                    NameAlias = "SystemAdmin"
                };
                _context.Roles.Add(role);
                _context.SaveChanges();
                return role.ObjectUid;
            }
            return roles.ObjectUid;
        }
        /*        public Guid CreateParameterType()
                {
                    var parameters = _context.BdgreportParameterTypes.Where(x => x.Name.ToLower() == "radio").FirstOrDefault();
                    if (parameters == null)
                    {
                        BdgreportParameterType param = new BdgreportParameterType()
                        {
                            Name = "radio",
                            NameAlias = "radio"
                        };
                        _context.BdgreportParameterTypes.Add(param);
                        _context.SaveChanges();
                        return param.ObjectUid;
                    }
                    return parameters.ObjectUid;
                }
                public void CreateAccountGroup()
                {
                    List<BdgaccountGroupSubGroupSubGroupSubGroup> accountGroup = new List<BdgaccountGroupSubGroupSubGroupSubGroup>()
                        {
                            new BdgaccountGroupSubGroupSubGroupSubGroup{
                            Name = "SubSubSubGroup22",
                            Display = "SubSubSubGroup22",
                            NameAlias = "SubSubSubGroup22",
                            BdgaccountGroupSubGroupSubGroupId = Guid.Parse("DF324268-2252-4E40-A0B4-985360CB1CDC")
                            },
                            new BdgaccountGroupSubGroupSubGroupSubGroup{
                            Name = "SubSubSubGroup14",
                            Display = "SubSubSubGroup14",
                            NameAlias = "SubSubSubGroup14",
                             BdgaccountGroupSubGroupSubGroupId = Guid.Parse("FFF83A55-1CB6-4D9C-AD3B-EF352AA6B7F6")
                        },
                                 new BdgaccountGroupSubGroupSubGroupSubGroup{
                            Name = "SubSubSubGroup34",
                            Display = "SubSubSubGroup34",
                            NameAlias = "SubSubSubGroup34",
                             BdgaccountGroupSubGroupSubGroupId = Guid.Parse("FFF83A55-1CB6-4D9C-AD3B-EF352AA6B7F6")
                        },
                                      new BdgaccountGroupSubGroupSubGroupSubGroup{
                            Name = "SubSubSubGroup13",
                            Display = "SubSubSubGroup13",
                            NameAlias = "SubSubSubGroup13",
                             BdgaccountGroupSubGroupSubGroupId = Guid.Parse("AFDD615D-0349-4338-B81C-9C90B1812948")
                        }
                        };

                    _context.BdgaccountGroupSubGroupSubGroupSubGroups.AddRange(accountGroup);
                    _context.SaveChanges();


                }*/
        /*public async Task CreateUser()
        {
            var users = _uow.UserAccountRepository.Query().Where(x => x.Name == "SystemAdministrator").FirstOrDefault();
            if(users == null)
            {
                UserAccount userAccount = new UserAccount()
                {
                    Name = "SystemAdministrator",
                    Username = "SystemAdministrator",
                    Password = "Password@12345",
                    ConfirmPassword = "Password@12345",
                    Email = "SystemAdministrator@localhost.com",
                };

                await _uow.UserAccountRepository.Add(userAccount);
                await _uow.SaveAsync();
            }
        }
        public async Task CreateRole()
        {
            var roles = _uow.RoleRepository.Query().Where(x => x.Name == "SystemAdmin").FirstOrDefault();
            if (roles == null)
            {
                Role role = new Role()
                {
                    Name = "SystemAdmin"
                };

                await _uow.RoleRepository.Add(role);
                await _uow.SaveAsync();
            }
        }*/
    }
}