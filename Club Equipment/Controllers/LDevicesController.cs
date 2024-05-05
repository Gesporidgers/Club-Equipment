using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Club_Equipment;

namespace Club_Equipment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LDevicesController : ControllerBase
    {
        private readonly LD_context _context;

        public LDevicesController(LD_context context)
        {
            _context = context;
        }

        // GET: api/LDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LDevice>>> GetLDevice()
        {
            return await _context.LDevice.ToListAsync();
        }

        // GET: api/LDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LDevice>> GetLDevice(long id)
        {
            var lDevice = await _context.LDevice.FindAsync(id);

            if (lDevice == null)
            {
                return NotFound();
            }

            return lDevice;
        }

        // PUT: api/LDevices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLDevice(long id, LDevice lDevice)
        {
            if (id != lDevice.Id)
            {
                return BadRequest();
            }

            _context.Entry(lDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LDeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LDevices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LDevice>> PostLDevice(LDevice lDevice)
        {
            _context.LDevice.Add(lDevice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLDevice", new { id = lDevice.Id }, lDevice);
        }

        // DELETE: api/LDevices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLDevice(long id)
        {
            var lDevice = await _context.LDevice.FindAsync(id);
            if (lDevice == null)
            {
                return NotFound();
            }

            _context.LDevice.Remove(lDevice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LDeviceExists(long id)
        {
            return _context.LDevice.Any(e => e.Id == id);
        }
    }
}
