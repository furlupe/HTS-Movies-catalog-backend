namespace MoviesCatalog.Models.DTO
{
    public class MoviesPagedListDto
    {
        public IEnumerable<MovieShortDto> Movies { get; set; }
        public PageDto PageInfo { get; set; }
    }
}
