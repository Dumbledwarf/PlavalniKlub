using web.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SpljocContext context)
        {
            context.Database.EnsureCreated();

            var roles = new IdentityRole[] {
                new IdentityRole{Id="1", Name="Administrator"},
                new IdentityRole{Id="2", Name="Trener"},
                new IdentityRole{Id="3", Name="Plavalec"}
            };

            foreach (IdentityRole r in roles)
            {
                context.Roles.Add(r);
            }

            context.SaveChanges();
           
            var hasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser{
                    FirstName = "Bob",
                    LastName = "Dilon",
                    UserName = "bob@example.com",
                    NormalizedUserName = "BOB@EXAMPLE.COM",
                    Email = "bob@example.com",
                    NormalizedEmail = "XXXX@EXAMPLE.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PhoneNumber = "+111111111111",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = false,
                    TwoFactorEnabled = false,
                    };

            user.PasswordHash = hasher.HashPassword(user,"Testni123!");
            context.Users.Add(user);
            context.SaveChanges();

            var UserRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>{RoleId = roles[0].Id, UserId=user.Id},
                new IdentityUserRole<string>{RoleId = roles[1].Id, UserId=user.Id},
                new IdentityUserRole<string>{RoleId = roles[2].Id, UserId=user.Id},
            };

            foreach (IdentityUserRole<string> r in UserRoles)
            {
                context.UserRoles.Add(r);
            }
            context.SaveChangesAsync();

        }
    }
}