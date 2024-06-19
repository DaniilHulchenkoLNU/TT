using Microsoft.EntityFrameworkCore;
//using WWW.Domain.Entity;
//using WWW.DAL;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using Castle.Core.Configuration;
using Domain.Entity;

namespace TT.DAL {
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; } 
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Project> Projects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.PeoplePartner)
                .WithMany(e => e.PeoplePartners)
                .HasForeignKey(e => e.PeoplePartnerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApprovalRequest>()
                .HasOne(ar => ar.Approver)
                .WithMany(e => e.ApprovalRequests)
                .HasForeignKey(ar => ar.ApproverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApprovalRequest>()
                .HasOne(ar => ar.LeaveRequest)
                .WithMany(lr => lr.ApprovalRequests)
                .HasForeignKey(ar => ar.LeaveRequestId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserInfo>()
                .HasOne(u => u.Employee)
                .WithOne(e => e.UserInfo)
                .HasForeignKey<Employee>(e => e.UserInfoId)
                .OnDelete(DeleteBehavior.Cascade);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // UserInfo data
            var user1 = new UserInfo
            {
                Id = "1",
                UserName = "john.doe",
                Email = "john.doe@example.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEBaKxU/EG+u0C5pW/VsH1jRZ0o1a+uzt4ToOeZ1dr6iST4lbk4Fomg==",
                SecurityStamp = "JBSY6Z5DZGPMZ5MN4NXQ4KOB4HCEAQ6Z",
                ConcurrencyStamp = "9ae6fe15-15b8-4c5b-9e0c-6751b6c6d8f1",
                PhoneNumber = "1234567890",
                LockoutEnabled = true,
            };

            var user2 = new UserInfo
            {
                Id = "2",
                UserName = "jane.doe",
                Email = "jane.doe@example.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEJXrQbU/JB7Z4VLZMQ0pMflTeC1xB5DHzGxeL0O+flZ5g4rHkX5TRg==",
                SecurityStamp = "2SYI8S5DZGPMZ5MN4NXQ4KOB4HCEAQ6Z",
                ConcurrencyStamp = "6ae6fe15-15b8-4c5b-9e0c-6751b6c6d8f1",
                PhoneNumber = "0987654321",
                LockoutEnabled = true,
            };

            // Employee data
            var employee1 = new Employee
            {
                Id = 1,
                UserInfoId = user1.Id,
                FullName = "John Doe",
                Subdivision = "IT",
                Position = "Developer",
                Status = "Active",
                OutOfOfficeBalance = 10,
                Photo = "photo_url_1",
            };

            var employee2 = new Employee
            {
                Id = 2,
                UserInfoId = user2.Id,
                FullName = "Jane Doe",
                Subdivision = "HR",
                Position = "Manager",
                Status = "Active",
                OutOfOfficeBalance = 8,
                Photo = "photo_url_2",
                PeoplePartnerId = 1, // Assuming Jane's people partner is John
            };

            // Role data
            var role1 = new Role
            {
                Id = 1,
                RoleName = "Admin",
                Description = "Administrator role with full permissions"
            };

            var role2 = new Role
            {
                Id = 2,
                RoleName = "User",
                Description = "Regular user role with limited permissions"
            };

            // Permission data
            var permission1 = new Permission
            {
                Id = 1,
                PermissionName = "Read",
            };

            var permission2 = new Permission
            {
                Id = 2,
                PermissionName = "Write",
            };

            // LeaveRequest data
            var leaveRequest1 = new LeaveRequest
            {
                Id = 1,
                EmployeeId = 1,
                AbsenceReason = "Vacation",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(10),
                Status = "New",
                Comment = "Annual vacation" // Указываем значение для Comment
            };

            var leaveRequest2 = new LeaveRequest
            {
                Id = 2,
                EmployeeId = 2,
                AbsenceReason = "Medical",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                Status = "New",
                Comment = "Medical leave" // Указываем значение для Comment
            };

            // ApprovalRequest data
            var approvalRequest1 = new ApprovalRequest
            {
                Id = 1,
                ApproverId = 2,
                LeaveRequestId = 1,
                Status = "Approved",
                Comment = "Enjoy your vacation!",
            };

            var approvalRequest2 = new ApprovalRequest
            {
                Id = 2,
                ApproverId = 1,
                LeaveRequestId = 2,
                Status = "Pending",
                Comment = "Get well soon!",
            };

            // Project data
            var project1 = new Project
            {
                Id = 1,
                ProjectType = "Internal",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6),
                ProjectManagerId = 1,
                Status = "Active",
                Comment = "Project A description",
            };

            var project2 = new Project
            {
                Id = 2,
                ProjectType = "External",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                ProjectManagerId = 2,
                Status = "Active",
                Comment = "Project B description",
            };

            modelBuilder.Entity<UserInfo>().HasData(user1, user2);
            modelBuilder.Entity<Employee>().HasData(employee1, employee2);
            modelBuilder.Entity<Role>().HasData(role1, role2);
            modelBuilder.Entity<Permission>().HasData(permission1, permission2);
            modelBuilder.Entity<LeaveRequest>().HasData(leaveRequest1, leaveRequest2);
            modelBuilder.Entity<ApprovalRequest>().HasData(approvalRequest1, approvalRequest2);
            modelBuilder.Entity<Project>().HasData(project1, project2);
        }

            ////modelBuilder.Entity<Article>()
            ////.HasIndex(a => a.Title)
            ////.HasDatabaseName("IX_Articles_Title");

            //modelBuilder.Entity<Article>().HasOne(a => a.Autor).WithMany(u=>u.AutorEvent);
            //modelBuilder.Entity<Article>().HasMany(a => a.User).WithMany(u=>u.FavEvent);
            ////modelBuilder.Entity<User_Details>()
            ////    .Ignore(x => x.Id);
            ////modelBuilder.Entity<Article>()
            ////    .HasMany(a => a.UserFavorite)
            ////    .WithMany(u => u.UserFavoriteEvents)
            ////    .UsingEntity(j => j.ToTable("UserFavoriteArticles"));
            //User[] users=new [] { 
            //    new User { Id=1, NickName="admin",Email="admin@gmail.com",Role=Domain.Enum.UserRole.Admin },
            //    new User { Id=2, NickName="TicketMaster",Email="ticketmaster@gmail.com",Role=Domain.Enum.UserRole.Moderator },
            //};
            //User_Details[] user_Details = new[]{
            //    new User_Details{ UserID=1, Introdaction="Admin Account", Password=HashPasswordHelper.HashPassowrd("admin320")},
            //    new User_Details{ UserID=2, Introdaction="TicketMaster Official Account",Password=HashPasswordHelper.HashPassowrd("ticketmaster320")},
            //};

            //modelBuilder.Entity<User>().HasData(users);
            //modelBuilder.Entity<User_Details>().HasData(user_Details);

        }
    }


    //public class HashPasswordHelper
    //{
    //    public static string HashPassowrd(string password)
    //    {
    //        using (var sha256 = SHA256.Create())
    //        {
    //            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
    //            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

    //            return hash;
    //        }
    //    }
    //}

