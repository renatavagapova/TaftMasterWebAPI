using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaftMasterWebAPI.Data;
using TaftMasterWebAPI.Models;

namespace TaftMasterWebAPI.Controllers
{
    [Route("api/favorite")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavoriteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userIdentifier}")]
        public async Task<ActionResult<IEnumerable<FavoriteItem>>> GetFavrite(string userIdentifier)
        {
            var favoriteItems = await _context.FavoriteItems
               .Where(c => c.UserIdentifier == userIdentifier)
               .Include(c => c.Rug)
               .Include(c => c.Certificate)
               .ToListAsync();

            return Ok(favoriteItems);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddToFavorite([FromBody] FavoriteItem item)
        {
            if (string.IsNullOrEmpty(item.UserIdentifier))
            {
                return BadRequest("User identifier is required.");
            }

            if (item.RugId == null && item.CertificateId == null)
            {
                return BadRequest("Either RugId or CertificateId must be provided.");
            }

            _context.FavoriteItems.Add(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("remove/{id}/{userIdentifier}")]
        public async Task<ActionResult> RemoveFromFavorite(int id, string userIdentifier)
        {
            var item = await _context.FavoriteItems.FirstOrDefaultAsync(c => c.Id == id && c.UserIdentifier == userIdentifier);

            if (item == null) return NotFound();

            _context.FavoriteItems.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
