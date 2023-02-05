namespace MoviesCatalog.Models.DTO
{
    public class MoviesPagedListDto
    {
        public ICollection<MovieShortDto> Movies { get; set; }
        public PageDto PageInfo { get; set; }
    }
}
