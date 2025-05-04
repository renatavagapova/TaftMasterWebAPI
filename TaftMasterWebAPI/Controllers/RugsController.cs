using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaftMasterWebAPI.Data;
using TaftMasterWebAPI.Models;

namespace TaftMasterWebAPI.Controllers
{
    [Route("api/rugs")]
    [ApiController]
    public class RugsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RugsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rug>>> GetRugs()
        {
            return await _context.Rugs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rug>> GetRug(int id)
        {
            var rug = await _context.Rugs.FindAsync(id);
            if (rug == null) return NotFound();
            return rug;
        }

        [HttpPost]
        public async Task<ActionResult<Rug>> AddRug(Rug rug)
        {
            _context.Rugs.Add(rug);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRug), new { id = rug.Id }, rug);
        }
    }
}
