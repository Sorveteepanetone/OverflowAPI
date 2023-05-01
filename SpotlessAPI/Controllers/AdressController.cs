using SpotlessAPI.Context;
using SpotlessAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SpotlessAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly EFContext _efContext;

        public AddressController(EFContext context)
        {
            _efContext = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            return await _efContext.Addresses.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _efContext.Addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, Address address)
        {

            _efContext.Entry(address).State = EntityState.Modified;
            await _efContext.SaveChangesAsync();

            return Ok();
        }
        
        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress(Address address)
        {
            _efContext.Addresses.Add(address);
            await _efContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAddress), new { id = address.Id }, address);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _efContext.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _efContext.Addresses.Remove(address);
            await _efContext.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return _efContext.Addresses.Any(e => e.Id == id);
        }
    }
}