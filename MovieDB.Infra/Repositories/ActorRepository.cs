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
    public class ActorRepository : IRepository<Actor>
    {
        private readonly MyContextDatabase _dbContext;

        public ActorRepository(MyContextDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public Actor GetById(int id)
        {
            return _dbContext.Actors.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Actor> GetAll()
        {
            return _dbContext.Actors.ToList();
        }

        public void Insert(Actor actor)
        {
            _dbContext.Actors.Add(actor);
            _dbContext.SaveChanges();
        }

        public void Update(Actor actor)
        {
           
            var existingActor = _dbContext.Actors.FirstOrDefault(m => m.Id == actor.Id);
            if (existingActor != null)
            {               
                existingActor.Name = actor.Name;
                existingActor.BirthDate = actor.BirthDate;               
            }
            _dbContext.Actors.Update(existingActor);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {            
            var actorToRemove = _dbContext.Actors.FirstOrDefault(m => m.Id == id);
            if (actorToRemove != null)
            {
                _dbContext.Actors.Remove(actorToRemove);
            }
            _dbContext.SaveChanges();
        }

        public Task<Actor> GetById(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
