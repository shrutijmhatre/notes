namespace Notes.API.Models.DTO
{
    public class GetNote
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
