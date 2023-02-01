namespace MoviesCatalog.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
