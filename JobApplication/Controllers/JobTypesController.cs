﻿using System;
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
    [Route("api/JobTypes")]
    public class JobTypesController : Controller
    {
        private readonly DataContext _context;

        public JobTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/JobTypes
        [HttpGet]
        public IEnumerable<JobType> GetjobType()
        {
            return _context.jobType;
        }

        // GET: api/JobTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobType = await _context.jobType.SingleOrDefaultAsync(m => m.Id == id);

            if (jobType == null)
            {
                return NotFound();
            }

            return Ok(jobType);
        }

        // PUT: api/JobTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobType([FromRoute] int id, [FromBody] JobType jobType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobType.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTypeExists(id))
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

        // POST: api/JobTypes
        [HttpPost]
        public async Task<IActionResult> PostJobType([FromBody] JobType jobType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.jobType.Add(jobType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobType", new { id = jobType.Id }, jobType);
        }

        // DELETE: api/JobTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobType = await _context.jobType.SingleOrDefaultAsync(m => m.Id == id);
            if (jobType == null)
            {
                return NotFound();
            }

            _context.jobType.Remove(jobType);
            await _context.SaveChangesAsync();

            return Ok(jobType);
        }

        private bool JobTypeExists(int id)
        {
            return _context.jobType.Any(e => e.Id == id);
        }
    }
}