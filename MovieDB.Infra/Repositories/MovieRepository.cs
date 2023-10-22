using MovieDB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB.Infra.Repositories;

namespace MovieDB.Domain.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private List<Movie> _movies = new List<Movie>();

        public Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movies;
        }

        public void Insert(Movie movie)
        {
            // Implemente a lógica para inserir um filme na fonte de dados.
            _movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            // Implemente a lógica para atualizar um filme na fonte de dados.
            var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie != null)
            {
                // Atualize as propriedades relevantes.
                existingMovie.Title = movie.Title;
                existingMovie.Overview = movie.Overview;
                // Atualize outras propriedades...
            }
        }

        public void Delete(int id)
        {
            // Implemente a lógica para excluir um filme da fonte de dados.
            var movieToRemove = _movies.FirstOrDefault(m => m.Id == id);
            if (movieToRemove != null)
            {
                _movies.Remove(movieToRemove);
            }
        }
    }
}
