using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Domain.Services
{
    using MovieDB.Domain.Entities;
    using MovieDB.Infra.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ActorService
    {
        private readonly IRepository<Actor> _actorRepository;

        public ActorService(IRepository<Actor> actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public IEnumerable<Actor> GetAllActors()
        {
            return _actorRepository.GetAll();
        }

        public Actor GetActorById(int id)
        {
            return _actorRepository.GetById(id);
        }

        public Actor CreateActor(Actor actor)
        {
            _actorRepository.Insert(actor);
            return actor;
        }

        public void UpdateActor(int id, Actor updatedActor)
        {
            _actorRepository.Update(updatedActor);
        }

        public void DeleteActor(int id)
        {
            _actorRepository.Delete(id);
        }
    }

}
