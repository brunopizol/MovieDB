using Microsoft.EntityFrameworkCore;
using MovieDB.Domain.Entities;
using MovieDB.Domain.Repositories;
using MovieDB.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Infra.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly MyContextDatabase _dbContext;

        public UserRepository(MyContextDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        

        public async Task<User> GetById(string email, string password)
        {
            return _dbContext.Users.FirstOrDefault(m => m.Email == email && m.PasswordHash == password);
        }
    }
    
}
