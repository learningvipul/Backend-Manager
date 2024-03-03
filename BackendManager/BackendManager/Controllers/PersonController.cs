using BackendManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly LogbookContext _context;

        public PersonController(LogbookContext context)
        {
            _context = context;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            if (_context == null) return NotFound();
            return await _context.People.ToListAsync();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            if (_context == null) return NotFound();
            Person person = await _context.People.FindAsync(id);
            if (person == null) return NotFound();
            return person;
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<ActionResult<Person>> Post([FromBody] Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }
    }
}
