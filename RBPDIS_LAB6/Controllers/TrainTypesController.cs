using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RBPDIS_LAB6.Models;

namespace RBPDIS_LAB6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainTypesController : ControllerBase
    {
        private readonly RailwayTrafficContext _context;

        public TrainTypesController(RailwayTrafficContext context)
        {
            _context = context;
        }

        // GET: api/TrainTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainType>>> GetTrainTypes()
        {
          if (_context.TrainTypes == null)
          {
              return NotFound();
          }
            return await _context.TrainTypes.ToListAsync();
        }

        // GET: api/TrainTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainType>> GetTrainType(int id)
        {
          if (_context.TrainTypes == null)
          {
              return NotFound();
          }
            var trainType = await _context.TrainTypes.FindAsync(id);

            if (trainType == null)
            {
                return NotFound();
            }

            return trainType;
        }

        // PUT: api/TrainTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainType(int id, TrainType trainType)
        {
            if (id != trainType.TrainTypeId)
            {
                return BadRequest();
            }

            _context.Entry(trainType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainTypeExists(id))
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

        // POST: api/TrainTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainType>> PostTrainType(TrainType trainType)
        {
          if (_context.TrainTypes == null)
          {
              return Problem("Entity set 'RailwayTrafficContext.TrainTypes'  is null.");
          }
            _context.TrainTypes.Add(trainType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainType", new { id = trainType.TrainTypeId }, trainType);
        }

        // DELETE: api/TrainTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainType(int id)
        {
            if (_context.TrainTypes == null)
            {
                return NotFound();
            }
            var trainType = await _context.TrainTypes.FindAsync(id);
            if (trainType == null)
            {
                return NotFound();
            }

            _context.TrainTypes.Remove(trainType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainTypeExists(int id)
        {
            return (_context.TrainTypes?.Any(e => e.TrainTypeId == id)).GetValueOrDefault();
        }
    }
}
