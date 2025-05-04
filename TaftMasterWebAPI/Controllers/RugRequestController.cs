using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaftMasterWebAPI.Data;
using TaftMasterWebAPI.Models;

namespace TaftMasterWebAPI.Controllers
{
    [Route("api/rugrequest")]
    [ApiController]
    public class RugRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public RugRequestController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRugRequest([FromForm] RugRequest rugRequestForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string filePath = null;

            // Создаем новый запрос
            var request = new RugRequest
            {
                Name = rugRequestForm.Name,
                Email = rugRequestForm.Email,
                Phone = rugRequestForm.Phone,
                Description = rugRequestForm.Description,
                Agreement = rugRequestForm.Agreement,
                CreatedAt = DateTime.UtcNow
            };

            _context.RugRequests.Add(request);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Запрос на создание ковра успешно отправлен" });
        }
    }
}
