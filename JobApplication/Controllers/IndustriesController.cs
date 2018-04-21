using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApplication.Data;
using JobApplication.Model;

namespace JobApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Industries")]
    public class IndustriesController : Controller
    {
        private readonly DataContext _context;

        public IndustriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Industries
        [HttpGet]
        public IEnumerable<Industry> Getindustry()
        {
            return _context.industry;
        }

        // GET: api/Industries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIndustry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var industry = await _context.industry.SingleOrDefaultAsync(m => m.Id == id);

            if (industry == null)
            {
                return NotFound();
            }

            return Ok(industry);
        }

        // PUT: api/Industries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndustry([FromRoute] int id, [FromBody] Industry industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != industry.Id)
            {
                return BadRequest();
            }

            _context.Entry(industry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryExists(id))
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

        // POST: api/Industries
        [HttpPost]
        public async Task<IActionResult> PostIndustry([FromBody] Industry industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.industry.Add(industry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndustry", new { id = industry.Id }, industry);
        }

        // DELETE: api/Industries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndustry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var industry = await _context.industry.SingleOrDefaultAsync(m => m.Id == id);
            if (industry == null)
            {
                return NotFound();
            }

            _context.industry.Remove(industry);
            await _context.SaveChangesAsync();

            return Ok(industry);
        }

        private bool IndustryExists(int id)
        {
            return _context.industry.Any(e => e.Id == id);
        }
    }
}