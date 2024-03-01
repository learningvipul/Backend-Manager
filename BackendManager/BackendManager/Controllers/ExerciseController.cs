using BackendManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly LogbookContext _context;

        public ExerciseController(LogbookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            if (_context.Exercises == null)
                return NotFound();
            return await _context.Exercises.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            if (_context == null) return NotFound();
            Exercise exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null) return NotFound();
            return exercise;
        }
    }
}
