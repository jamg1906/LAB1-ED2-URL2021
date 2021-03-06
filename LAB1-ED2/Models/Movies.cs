using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB1_ED2.Models
{
    public class MovieFriend
    {
        public List<Movies> data { get; set;}
    }
    public class Movies
    {
        //public string id { get; set; }
        public string director { get; set; }
        public double imdbRating { get; set; }
        public string genre { get; set; }
        public string releaseDate { get; set; }
        public int rottenTomatoesRating { get; set; }
        public string title { get; set; }


        public static Comparison<Movies> Comparison = delegate (Movies movie1, Movies movie2)
        {
            return movie1.CompareTo(movie2);
        };

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            try
            {
                var Movie = (Movies)obj;
                if (title.CompareTo(Movie.title) != 0)
                {
                    return title.CompareTo(Movie.title);
                }
                else if (releaseDate.CompareTo(Movie.releaseDate) != 0)
                {
                    return releaseDate.CompareTo(Movie.releaseDate);
                }
                else if (rottenTomatoesRating.CompareTo(Movie.rottenTomatoesRating) != 0)
                {
                    return rottenTomatoesRating.CompareTo(Movie.rottenTomatoesRating);
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

    }
}
