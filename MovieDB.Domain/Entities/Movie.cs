using MovieDB.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public int ReleaseYear { get; set; }
        //public List<Actor>? Actors { get; set; }
        //public Director? Director { get; set; }
        public string Genres { get; set; }
    }
}
