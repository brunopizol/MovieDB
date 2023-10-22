using MovieDB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Infra.Repositories
{ 
    public class ActorRepository : IRepository<Actor>
    {
        private List<Actor> _actors = new List<Actor>();

        public Actor GetById(int id)
        {
            return _actors.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Actor> GetAll()
        {
            return _actors;
        }

        public void Insert(Actor actor)
        {            
            _actors.Add(actor);
        }

        public void Update(Actor actor)
        {
           
            var existingActor = _actors.FirstOrDefault(m => m.Id == actor.Id);
            if (existingActor != null)
            {               
                existingActor.Name = actor.Name;
                existingActor.Movies.AddRange(actor.Movies);
                existingActor.BirthDate = actor.BirthDate;               
            }
        }

        public void Delete(int id)
        {            
            var actorToRemove = _actors.FirstOrDefault(m => m.Id == id);
            if (actorToRemove != null)
            {
                _actors.Remove(actorToRemove);
            }
        }
    }
}
