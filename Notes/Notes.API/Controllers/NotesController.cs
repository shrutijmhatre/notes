using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes.API.Data;
using Notes.API.Models.DomainModels;
using Notes.API.Models.DTO;

namespace NotesApp.API.Controllers
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

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var notes = dbContext.Notes.ToList();

            var notesDTO = new List<Notes.API.Models.DTO.GetNote>();

            foreach (var note in notes)
            {
                notesDTO.Add(new Notes.API.Models.DTO.GetNote
                {
                    Id = note.Id,
                    Title = note.Title,
                    Description = note.Description,
                    DateCreated = note.DateCreated,
                });

            }

            return Ok(notesDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetNoteById(Guid id)
        {
            var noteDomainObject = dbContext.Notes.Find(id);

            if (noteDomainObject != null)
            {
                var noteDTO = new Notes.API.Models.DTO.GetNote
                {
                    Id = noteDomainObject.Id,
                    Title = noteDomainObject.Title,
                    Description = noteDomainObject.Description,
                    DateCreated = noteDomainObject.DateCreated,
                };

                return Ok(noteDTO);
            }

            return BadRequest();
        }

    }
}
