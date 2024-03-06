namespace Notes.API.Models.DomainModels
{
    public class Note
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
