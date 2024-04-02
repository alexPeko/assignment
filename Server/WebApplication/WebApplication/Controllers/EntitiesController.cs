using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        private readonly EntityContext _context;

        public EntitiesController(EntityContext context)
        {
            _context = context;
        }

        // GET: api/Entities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entity>>> GetEntities()
        {
            return await _context.Entities.ToListAsync();
        }

        // GET: api/Entities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entity>> GetEntity(long id)
        {
            var entity = await _context.Entities.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Entities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntity(Guid id, Entity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Entities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entity>> PostEntity(Entity entity)
        {
            _context.Entities.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEntity), new { id = entity.Id }, entity);
        }

        // DELETE: api/Entities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(Guid id)
        {
            var entity = await _context.Entities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Entities.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool EntityExists(Guid id)
        {
            return _context.Entities.Any(e => e.Id == id);
        }
    }
}
