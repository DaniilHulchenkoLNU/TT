using DAL.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT.DAL;
using WWW.DAL.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Implementations
{
    public class UserInfoRepository : iUserInfoRepository
    {
        private readonly ApplicationDbContext _data;
        public UserInfoRepository(ApplicationDbContext db)
        {
            _data = db;
        }

        public UserInfo FindUserAuth(string email, string password)
        {

            UserInfo user = _data.UserInfo.First(u => u.Email == email);
             VerifyPassword(user, password);
            return user;
            


        }

        private bool VerifyPassword(UserInfo user, string password)
        {
            var hashedPassword = HashPassword(password);
            return user.PasswordHash == hashedPassword;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public UserInfo FindUserByEmail(string email)
        {
            return _data.UserInfo.First(u => u.Email == email);
        }

        public Task<bool> Create(UserInfo entity)
        {
                throw new NotImplementedException();
        }

        public bool Update(UserInfo userInfo)
        {
            try
            {
                _data.UserInfo.Update(userInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
