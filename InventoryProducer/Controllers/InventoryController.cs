using InventoryProducer.Models;
using InventoryProducer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InventoryProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ProducerService _producerService;
        private string _topic;
        public InventoryController(ProducerService producerService, IConfiguration configuration)
        {
            _producerService = producerService;
            _topic = configuration["Kafka:Topic"] ?? "default";
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventory([FromBody] OrderModel request)
        {
            var message = JsonSerializer.Serialize(request);

            await _producerService.ProduceAsync(_topic, message);

            return Ok("Inventory Updated Successfully...");
        }
    }
}
