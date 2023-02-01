namespace MoviesCatalog.Models.DTO
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Text { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime CreationDateTime { get; set; }
        public UserShortDto Author { get; set; }
    }
}
