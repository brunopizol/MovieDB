using MovieDB.Domain.Entities;
using MovieDB.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

public class DirectorService
{
    private readonly IRepository<Director> _directorRepository;

    public DirectorService(IRepository<Director> directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public IEnumerable<Director> GetAllDirectors()
    {
        return _directorRepository.GetAll();
    }

    public Director GetDirectorById(int id)
    {
        return _directorRepository.GetById(id);
    }

    public Director CreateDirector(Director director)
    {
        _directorRepository.Insert(director);
        return director;
    }

    public void UpdateDirector(int id, Director updatedDirector)
    {
        _directorRepository.Update(updatedDirector);
    }

    public void DeleteDirector(int id)
    {
        _directorRepository.Delete(id);
    }
}
