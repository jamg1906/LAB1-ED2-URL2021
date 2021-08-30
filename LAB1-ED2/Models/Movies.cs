using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB1_ED2.Models
{
    public class Movies
    {
        public string id { get; set; }
        public string director { get; set; }
        public double imdbRating { get; set; }
        public string genre { get; set; }
        public string releaseDate { get; set; }
        public int rottenTomatoesRating { get; set; }
        public string title { get; set; }

        public static Comparison<int> MovieComparison = delegate (int a, int b)
        {
            return 1;
        };
        public int CompareTo(object obj)
        {
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

        Lab01.Models.CompararCon<Movies> CC;

    }
}
