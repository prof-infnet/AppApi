using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppApi.Data;
using AppApi.Models;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciciosController : ControllerBase
    {
        private readonly AppApiContext _context;

        public ExerciciosController(AppApiContext context)
        {
            _context = context;
        }

        // GET: api/Exercicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercicio>>> GetExercicio()
        {
            return await _context.Exercicio.ToListAsync();
        }

        // GET: api/Exercicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercicio>> GetExercicio(int id)
        {
            var exercicio = await _context.Exercicio.FindAsync(id);

            if (exercicio == null)
            {
                return NotFound();
            }

            return exercicio;
        }

        // PUT: api/Exercicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercicio(int id, Exercicio exercicio)
        {
            if (id != exercicio.ExercicioId)
            {
                return BadRequest();
            }

            _context.Entry(exercicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercicioExists(id))
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

        // POST: api/Exercicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exercicio>> PostExercicio(Exercicio exercicio)
        {
            _context.Exercicio.Add(exercicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercicio", new { id = exercicio.ExercicioId }, exercicio);
        }

        // DELETE: api/Exercicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercicio(int id)
        {
            var exercicio = await _context.Exercicio.FindAsync(id);
            if (exercicio == null)
            {
                return NotFound();
            }

            _context.Exercicio.Remove(exercicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExercicioExists(int id)
        {
            return _context.Exercicio.Any(e => e.ExercicioId == id);
        }
    }
}
