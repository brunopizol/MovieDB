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
    public class DirectorRepository : IRepository<Director>
        {
        private readonly MyContextDatabase _dbContext;

        public DirectorRepository(MyContextDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public Director GetById(int id)
            {
                return _dbContext.Directors.FirstOrDefault(m => m.Id == id);
            }

            public IEnumerable<Director> GetAll()
            {
                return _dbContext.Directors.ToList();
            }

            public void Insert(Director director)
            {
                _dbContext.Directors.Add(director);
                _dbContext.SaveChanges();
            }

            public void Update(Director director)
            {

                var existingDirector = _dbContext.Directors.FirstOrDefault(m => m.Id == director.Id);
                if (existingDirector != null)
                {
                existingDirector.Name = existingDirector.Name;
                existingDirector.BirthDate = existingDirector.BirthDate;
                _dbContext.SaveChanges();
                }
            }

            public void Delete(int id)
            {
                var directorToRemove = _dbContext.Directors.FirstOrDefault(m => m.Id == id);
                if (directorToRemove != null)
                {
                    _dbContext.Directors.Remove(directorToRemove);
                    _dbContext.SaveChanges();
                }
            }

        public Task<Director> GetById(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
    }

