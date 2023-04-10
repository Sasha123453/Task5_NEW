using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task5_NEW.Models;

namespace Task5_NEW.Controllers
{
    [Route("api/fix")]
    [ApiController]
    public class FixModelsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FixModelsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/FixModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FixModel>>> GetFixModels()
        {
          if (_context.FixModels == null)
          {
              return NotFound();
          }
            return await _context.FixModels.ToListAsync();
        }

        // GET: api/FixModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FixModel>> GetFixModel(int id)
        {
          if (_context.FixModels == null)
          {
              return NotFound();
          }
            var fixModel = await _context.FixModels.FindAsync(id);

            if (fixModel == null)
            {
                return NotFound();
            }

            return fixModel;
        }

        // PUT: api/FixModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFixModel(int id, FixModel fixModel)
        {
            if (id != fixModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(fixModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixModelExists(id))
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

        // POST: api/FixModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FixModel>> PostFixModel(FixModel fixModel)
        {
          if (_context.FixModels == null)
          {
              return Problem("Entity set 'ApplicationContext.FixModels'  is null.");
          }
            _context.FixModels.Add(fixModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFixModel", new { id = fixModel.Id }, fixModel);
        }

        // DELETE: api/FixModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFixModel(int id)
        {
            if (_context.FixModels == null)
            {
                return NotFound();
            }
            var fixModel = await _context.FixModels.FindAsync(id);
            if (fixModel == null)
            {
                return NotFound();
            }

            _context.FixModels.Remove(fixModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FixModelExists(int id)
        {
            return (_context.FixModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
