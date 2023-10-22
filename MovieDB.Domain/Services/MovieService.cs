using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB.Domain.Entities;
using MovieDB.Infra.Repositories;

namespace MovieDB.Domain.Services
{
    public class MovieService
    {
        private readonly IRepository<Movie> _context;

        public MovieService(IRepository<Movie> context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _context.GetById(id);
        }

        public Movie CreateMovie(Movie movie)
        {
            _context.Insert(movie);
            return movie;
        }

        public void UpdateMovie(int id, Movie updatedMovie)
        {
            _context.Update(updatedMovie);
        }

        public void DeleteMovie(int id)
        {
            _context.Delete(id);
        }
    }
}
