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
    [Route("api/CompanyTypes")]
    public class CompanyTypesController : Controller
    {
        private readonly DataContext _context;

        public CompanyTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CompanyTypes
        [HttpGet]
        public IEnumerable<CompanyType> GetcompanyType()
        {
            return _context.companyType;
        }

        // GET: api/CompanyTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyType = await _context.companyType.SingleOrDefaultAsync(m => m.Id == id);

            if (companyType == null)
            {
                return NotFound();
            }

            return Ok(companyType);
        }

        // PUT: api/CompanyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyType([FromRoute] int id, [FromBody] CompanyType companyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyType.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyTypeExists(id))
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

        // POST: api/CompanyTypes
        [HttpPost]
        public async Task<IActionResult> PostCompanyType([FromBody] CompanyType companyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.companyType.Add(companyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyType", new { id = companyType.Id }, companyType);
        }

        // DELETE: api/CompanyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyType = await _context.companyType.SingleOrDefaultAsync(m => m.Id == id);
            if (companyType == null)
            {
                return NotFound();
            }

            _context.companyType.Remove(companyType);
            await _context.SaveChangesAsync();

            return Ok(companyType);
        }

        private bool CompanyTypeExists(int id)
        {
            return _context.companyType.Any(e => e.Id == id);
        }
    }
}