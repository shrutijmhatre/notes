namespace Notes.API.Models.DTO
{
    public class UpdateNoteRequest
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
