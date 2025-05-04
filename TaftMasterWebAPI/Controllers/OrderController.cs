using Microsoft.AspNetCore.Mvc;
using TaftMasterWebAPI.Data;
using TaftMasterWebAPI.Models;

namespace TaftMasterWebAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = new Order
            {
                Name = orderDto.Name,
                Email = orderDto.Email,
                Phone = orderDto.Phone,
                City = orderDto.City,
                Address = orderDto.Address,
                Recipient = orderDto.Recipient,
                Comment = orderDto.Comment,
                CreatedAt = DateTime.UtcNow,
                Items = orderDto.Items.Select(i => new OrderItem
                {
                    Title = i.Title,
                    Image = i.Image,
                    Price = i.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Формирование информации о заказе
            var orderDetails = $"Заказ от {order.Name} ({order.Phone})\nАдрес: {order.Address}\nКомментарий: {order.Comment}\n";

            // Вызов сервиса для отправки сообщения в Telegram
            //var telegramService = new TelegramBotService();
            //await telegramService.SendOrderInfoToTelegramAsync(orderDetails);

            return Ok(new { message = "Заказ успешно оформлен" });
        }
    }
}
