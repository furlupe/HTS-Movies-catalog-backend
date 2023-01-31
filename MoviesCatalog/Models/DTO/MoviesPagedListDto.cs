namespace MoviesCatalog.Models.DTO
{
    public class MoviesPagedListDto
    {
        public List<MovieShortDto> Movies { get; set; }
        public PageDto PageInfo { get; set; }
    }
}
