using BackendManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly LogbookContext _context;

        public GoalController(LogbookContext context)
        {
            _context = context;
        }

        // GET: api/<GoalController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoal()
        {
            if (_context == null) return NotFound();
            return await _context.Goals.ToListAsync();
        }

        // GET api/<GoalController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goal>> GetGoal(int id)
        {
            if (_context == null) return NotFound();
            Goal goal = await _context.Goals.FindAsync(id);
            if (goal == null) return NotFound();
            return goal;
        }

        // POST api/<GoalController>
        [HttpPost]
        public async Task<ActionResult<Goal>> Post([FromBody] Goal goal)
        {
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGoal), new { person = goal.Person, exercise = goal.Exercise }, goal);
        }

        // PUT api/<GoalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GoalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
