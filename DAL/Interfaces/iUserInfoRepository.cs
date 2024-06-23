using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT.DAL.Interfaces;

namespace DAL.Interfaces
{
    public interface iUserInfoRepository
    {
        public UserInfo FindUserAuth(string email, string password);
        public UserInfo FindUserByEmail(string email);
        public Task<bool> Create(UserInfo entity);
        public bool Update(UserInfo userInfo);
    }
}
