using BackendManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleGroupController : ControllerBase
    {
        private readonly LogbookContext _context;

        public MuscleGroupController(LogbookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuscleGroup>>> GetMuscleGroups()
        {
            if (_context == null) return NotFound();
            return await _context.MuscleGroups.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MuscleGroup>> GetMuscleGroup(int id)
        {
            if (_context == null) return NotFound();
            MuscleGroup muscleGroup = await _context.MuscleGroups.FindAsync(id);
            if (muscleGroup == null) return NotFound();
            return muscleGroup;
        }
    }
}
