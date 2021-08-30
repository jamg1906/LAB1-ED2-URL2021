namespace Lab01.Models
{
    public class Pelis
    {
        //Constructor de modelo Pelis
        public Pelis(string _title, string _director, string _genre, string _rottenTomatoesRating, string _casa_productora)
        {
            title = _title;
            director = _director;
            genre = _genre;
            rottenTomatoesRating = _rottenTomatoesRating;
            releaseDate = _casa_productora;
        }

        public string title { get; set; }
        public string director { get; set; }
        public string genre { get; set; }
        public string rottenTomatoesRating { get; set; }
        public string releaseDate { get; set; }
    }
}
