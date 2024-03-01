using BackendManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseSetController : ControllerBase
    {

        private readonly LogbookContext _context;

        public ExerciseSetController(LogbookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseSet>>> GetExerciseSets()
        {
            if (_context == null) return NotFound();
            return await _context.ExerciseSets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseSet>> GetExerciseSet(int id)
        {
            if (_context == null) return NotFound();
            ExerciseSet exerciseSet = await _context.ExerciseSets.FindAsync(id);
            if (exerciseSet == null) return NotFound();
            return exerciseSet;
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseSet>> PostExerciseSet([FromBody] ExerciseSet exerciseSet)
        {
            _context.ExerciseSets.Add(exerciseSet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExerciseSet), new { id = exerciseSet.Id }, exerciseSet);
        }
    }
}
