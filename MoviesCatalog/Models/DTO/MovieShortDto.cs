namespace MoviesCatalog.Models.DTO
{
    public class MovieShortDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Poster { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
        public ICollection<ReviewShortDto> Reviews { get; set; }

    }
}
