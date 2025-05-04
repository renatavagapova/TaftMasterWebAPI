using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaftMasterWebAPI.Data;
using TaftMasterWebAPI.Models;

namespace TaftMasterWebAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userIdentifier}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCart(string userIdentifier)
        {
            var cartItems = await _context.CartItems
               .Where(c => c.UserIdentifier == userIdentifier)
               .Include(c => c.Rug)
               .Include(c => c.Certificate)
               .ToListAsync();

            return Ok(cartItems);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddToCart([FromBody] CartItem item)
        {
            if (string.IsNullOrEmpty(item.UserIdentifier))
            {
                return BadRequest("User identifier is required.");
            }

            if (item.RugId == null && item.CertificateId == null)
            {
                return BadRequest("Either RugId or CertificateId must be provided.");
            }

            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("remove/{id}/{userIdentifier}")]
        public async Task<ActionResult> RemoveFromCart(int id, string userIdentifier)
        {
            var item = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == id && c.UserIdentifier == userIdentifier);

            if (item == null) return NotFound();

            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Очистка корзины пользователя
        [HttpDelete("clear/{userIdentifier}")]
        public async Task<ActionResult> ClearCart(string userIdentifier)
        {
            var cartItems = await _context.CartItems
                .Where(c => c.UserIdentifier == userIdentifier)
                .ToListAsync();

            if (!cartItems.Any()) return NotFound("Cart is already empty.");

            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
