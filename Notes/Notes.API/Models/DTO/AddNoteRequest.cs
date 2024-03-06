namespace Notes.API.Models.DTO
{
    public class AddNoteRequest
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
