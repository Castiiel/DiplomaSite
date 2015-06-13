using System;
using System.Collections.Generic;
using Calabonga.Account.Data;
using ColumnAdministrator.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ColumnAdministrator.Web.Infrastructure
{
    internal static class InitializeHelper
    {
        internal static void SeedMembership(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            const string password = "123123";
            const string role = "Administrator";
            const string rolesecretar = "Secretar";
            const string roleuser = "Autor";
            const string rolerecensent = "Recenzent";


            //Create Role Admin if it does not exist
            if (!roleManager.RoleExists(role))
            {
                roleManager.Create(new IdentityRole(role));
            }
            if (!roleManager.RoleExists(rolesecretar))
            {
                roleManager.Create(new IdentityRole(rolesecretar));
            }
            if (!roleManager.RoleExists(roleuser))
            {
                roleManager.Create(new IdentityRole(roleuser));
            }
            if (!roleManager.RoleExists(rolerecensent))
            {
                roleManager.Create(new IdentityRole(rolerecensent));
            }

            //Create User=Admin with password=123123
            var admin = new ApplicationUser
            {
                AccessFailedCount = 0,
                Id = Guid.NewGuid().ToString(),
                Email = "calabonga@hotmail.com",
                EmailConfirmed = true,
                UserName = "calabonga@hotmail.com",
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false
            };
            var adminresult = userManager.Create(admin, password);
            if (adminresult.Succeeded)
                userManager.AddToRole(admin.Id, role);

            var recenzent = new ApplicationUser
            {
                AccessFailedCount = 0,
                Id = Guid.NewGuid().ToString(),
                Email = "recenzent@hotmail.com",
                EmailConfirmed = true,
                UserName = "recenzent@hotmail.com",
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false
            };
            var recenzentresult = userManager.Create(recenzent, password);
            if (recenzentresult.Succeeded)
                userManager.AddToRole(recenzent.Id, rolerecensent);

            var secretar = new ApplicationUser
            {
                AccessFailedCount = 0,
                Id = Guid.NewGuid().ToString(),
                Email = "secretar@hotmail.com",
                EmailConfirmed = true,
                UserName = "secretar@hotmail.com",
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false
            };
            var secretarresult = userManager.Create(secretar, password);
            if (secretarresult.Succeeded)
                userManager.AddToRole(secretar.Id, rolesecretar);

            var user = new ApplicationUser
            {
                AccessFailedCount = 0,
                Id = Guid.NewGuid().ToString(),
                Email = "autor@hotmail.com",
                EmailConfirmed = true,
                UserName = "autor@hotmail.com",
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false
            };
            var userresult = userManager.Create(user, password);
            if (userresult.Succeeded)
                userManager.AddToRole(user.Id, roleuser);
        }

        internal static void SeedItems(ApplicationDbContext context)
        {
            var appliances = new List<Appliance>
            {
                new Appliance()
                {
                    Id = 1,
                    CreateDate = new DateTime(2014, 2, 2),
                    Description = "Description of item 1",
                    InStock = false,
                    Name = "Appliance",
                  LastName = "Appliance",
                    Price = "435",
                    Attachment = null
                },
                new Appliance()
                {
                    Id = 2,
                    CreateDate = new DateTime(2014, 2, 12),
                    Description = "Description of item 2",
                    InStock = false,
                    Name = "Appliance",
                   LastName = "Appliance",
                    Price = "4335",
                    Attachment = null
                },new Appliance()
                {
                    Id = 3,
                    CreateDate = new DateTime(2014, 1, 2),
                    Description = "Description of item 3",
                    InStock = false,
                    Name = "Appliance",
                    LastName = "Appliance",
                    Price = "4325",
                    Attachment = null
                },new Appliance()
                {
                    Id = 4,
                    CreateDate = new DateTime(2014, 5, 4),
                    Description = "Description of item 4",
                    InStock = false,
                    Name = "Appliance",
                    LastName = "Appliance",
                    Price = "1435",
                    Attachment = null
                },
            };
            appliances.ForEach(x => context.Appliances.Add(x));
        }

    }
}