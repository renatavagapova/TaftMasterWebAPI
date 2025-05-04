using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaftMasterWebAPI.Data;
using TaftMasterWebAPI.Models;

namespace TaftMasterWebAPI.Controllers
{
    [Route("api/masterclass")]
    [ApiController]
    public class MasterClassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MasterClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterClass>>> GetMasterClasses()
        {
            return await _context.MasterClasses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MasterClass>> GetMasterClass(int id)
        {
            var mc = await _context.MasterClasses.FindAsync(id);
            if (mc == null) return NotFound();
            return mc;
        }

      
    }
}
