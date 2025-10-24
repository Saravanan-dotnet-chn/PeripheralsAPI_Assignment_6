using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeripheralsAPI_Assignment_6.Models;
using PeripheralsAPI_Assignment_6.Data;
using PeripheralsAPI_Assignment_6.Repositories;

namespace PeripheralsAPI_Assignment_6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeripheralsController : ControllerBase
    {
        private readonly IPeripheralRepository<Peripheral> _repository;
        private readonly ILogger<Peripheral> _logger;

        public PeripheralsController(IPeripheralRepository<Peripheral> repository, ILogger<Peripheral> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/peripherals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peripheral>>> GetPeripherals()
        {
            _logger.LogInformation("Getting all Peripherals");
            var peripherals = await _repository.GetAllAsync();
            return Ok(peripherals);
        }

        // GET: api/peripherals/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Peripheral>> GetPeripheral(int id)
        {
            _logger.LogInformation("Getting Peripheral By ID");
            var peripheral = await _repository.GetByIdAsync(id);
            if (peripheral == null)
                return NotFound();

            return Ok(peripheral);
        }

        // POST: api/peripherals
        [HttpPost]
        public async Task<ActionResult<Peripheral>> AddPeripheral(Peripheral peripheral)
        {
            _logger.LogInformation("Adding Peripherals");
            var created = await _repository.AddAsync(peripheral);
            return CreatedAtAction(nameof(GetPeripheral), new { id = created.Id }, created);
        }

        // PUT: api/peripherals/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePeripheral(int id, Peripheral peripheral)
        {
            if (id != peripheral.Id)
                return BadRequest();

            try
            {
                _logger.LogInformation("Updating Peripheral By ID");
                await _repository.UpdateAsync(peripheral);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/peripherals/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeripheral(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();
            _logger.LogInformation("Deleting all Peripheral By ID");
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}