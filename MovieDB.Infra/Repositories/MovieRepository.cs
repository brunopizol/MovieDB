using MovieDB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB.Infra.Repositories;
using MovieDB.Infra.Context;

namespace MovieDB.Domain.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        
        private readonly MyContextDatabase _dbContext;

        public MovieRepository(MyContextDatabase dbContext)
        {            
            _dbContext = dbContext;
        }

        public Movie GetById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _dbContext.Movies.ToList();
        }

        public void Insert(Movie movie)
        {
            
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

        }

        public void Update(Movie movie)
        {
            _dbContext.Movies.Update(movie);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _dbContext.Movies.Find(id);

            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }

           
        }

        public Task<Movie> GetById(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
