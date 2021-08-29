namespace Lab01.Models
{
    public class Comparador
    {
        public int CompararPortitle(Pelis Pelis1, Pelis Pelis2)
        {
            return Pelis1 == null || Pelis2 == null ? 1 : Pelis1.title.CompareTo(Pelis2.title);
        }
    }
}
