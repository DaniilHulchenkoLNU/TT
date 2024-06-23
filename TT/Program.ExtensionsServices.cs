using DAL.Implementations;
using DAL.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service;
using TT.DAL;
using TT.DAL.Interfaces;
using WWW.DAL.Repositories;


namespace TT
{
    public static class ExtensionsServices
    {

        public static void AddMyServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                connectionString: builder.Configuration.GetConnectionString("StoreDatabase")
                ));


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            // Добавление служб авторизации
            //builder.Services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            //});

            // Конфигурация Identity
            builder.Services.AddIdentity<UserInfo, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();


            builder.Services.AddScoped(typeof(iBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient<iUserInfoRepository, UserInfoRepository>();
            builder.Services.AddScoped<AccountService>();
            builder.Services.AddScoped<EmployeeService>();
        }

    }
}
