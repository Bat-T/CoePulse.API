using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoePulse.API.Data
{
    public class AuthDbContext:IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "de72a30c-4259-4947-b774-f94fcdc5ae86";
            var writerRoleId = "dcb8c120-4f0a-47eb-b536-98a65f0d5d6a";
            var adminRoleId = "3d0d9a28-3994-42c8-947b-b7d8046c79d1";

            var roles = new IdentityRole[]
            {
                // Add reader role
                new IdentityRole
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "READER",
                    ConcurrencyStamp = readerRoleId
                },
                // Add writer role
                new IdentityRole
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER",
                    ConcurrencyStamp = writerRoleId
                },
                //Add admin role
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "3d0d9a28-3994-42c8-947b-b7d8046c79d1"
                }
            };

            //Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            //Create admin user
            var adminUser2 = new IdentityUser
            {
                Id = "4db4f2cd-aef6-4559-bd90-8c2b0669f1ba",
                UserName = "admin2",
                NormalizedUserName = "ADMIN2",
                Email = "tamal.karmakar96@yahoo.com",
                NormalizedEmail = "tamal.karmakar96@yahoo.com"
            };
            adminUser2.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser2,"Admin@123");


            //Seed the admin user
            builder.Entity<IdentityUser>().HasData(adminUser2);
            
            var admin2role = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = readerRoleId,
                    UserId = adminUser2.Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = writerRoleId,
                    UserId = adminUser2.Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUser2.Id
                },
            };

            //Seed the admin role
            builder.Entity<IdentityUserRole<string>>().HasData(admin2role);
        }
    }
}
