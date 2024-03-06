using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes.API.Data;
using Notes.API.Models.DomainModels;
using Notes.API.Models.DTO;

namespace Notes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesDbContext dbContext;

        public NotesController(NotesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddNote(AddNoteRequest addNoteRequest)
        {
            var note = new Note
            {
                Title = addNoteRequest.Title,
                Description = addNoteRequest.Description,
                DateCreated = DateTime.Now,
            };

            dbContext.Notes.Add(note);
            dbContext.SaveChanges();

            return Ok(note);

        }
    }
}
