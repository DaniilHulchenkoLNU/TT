using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT.DAL;
namespace TT.DAL.Interfaces
{
    public interface iBaseRepository<T> where T:class
    {
        public Task<bool> Create(T entity);
        public Task<bool> Delete(T entity);
        public Task<T> GetValueByID(int id);
        public Task<IEnumerable<T>> GetAll();
        public IQueryable<T> GetALL();
    }
}
