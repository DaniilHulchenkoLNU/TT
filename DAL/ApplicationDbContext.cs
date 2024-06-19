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
}
