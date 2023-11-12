using MovieDB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Infra.Repositories
{
        public class DirectorRepository : IRepository<Director>
        {
            private List<Director> _directors = new List<Director>();

            public Director GetById(int id)
            {
                return _directors.FirstOrDefault(m => m.Id == id);
            }

            public IEnumerable<Director> GetAll()
            {
            return _directors;
            }

            public void Insert(Director director)
            {
            _directors.Add(director);
            }

            public void Update(Director director)
            {

                var existingDirector = _directors.FirstOrDefault(m => m.Id == director.Id);
                if (existingDirector != null)
                {
                existingDirector.Name = existingDirector.Name;
                //existingDirector.Movies.AddRange(existingDirector.Movies);
                existingDirector.BirthDate = existingDirector.BirthDate;
            }
            }

            public void Delete(int id)
            {
                var directorToRemove = _directors.FirstOrDefault(m => m.Id == id);
                if (directorToRemove != null)
                {
                _directors.Remove(directorToRemove);
                }
            }
        }
    }

