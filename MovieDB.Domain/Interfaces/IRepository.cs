using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Domain.Repositories
{
    public interface IRepository<T>
    {
        T GetById(int id);
        Task<T> GetById(string email, string password);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }

}
