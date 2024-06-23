using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Service;
using TT.DAL;
using TT.DAL.Interfaces;
using WWW.DAL.Repositories;

namespace TT
{
    public static class ExtensionsApp
    {

       public static void AddMyAppExtensions(this WebApplication app) {

            app.UseAuthentication(); 
            app.UseAuthorization();

            
        }

    }
}
