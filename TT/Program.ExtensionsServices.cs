using Microsoft.EntityFrameworkCore;
using Service;
using System.Configuration;
using TT.DAL;
using TT.DAL.Interfaces;
using WWW.DAL.Repositories;

namespace TT
{
    public static class ExtensionsServices
    {

       public static void AddMyServices(this WebApplicationBuilder builder) {

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                connectionString: builder.Configuration.GetConnectionString("StoreDatabase")
                ));


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("StoreDatabase")));

            builder.Services.AddScoped(typeof(iBaseRepository<>), typeof(BaseRepository<>));

            builder.Services.AddScoped<EmployeeService>();
        }

    }
}
