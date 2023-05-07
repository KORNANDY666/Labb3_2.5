using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb3_2._5.Data;
using Labb3_2._5.Models;
using AutoMapper;
using Labb3_2._5.Models.DTO;

namespace Labb3_2._5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public InterestsController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interest>>> GetInterests()
        {
            if (_context.Interests == null)
            {
                return NotFound();
            }
            return await _context.Interests.ToListAsync();
        }


        [HttpGet("PersonId")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetInterests(int? personId)
        {
            if (_context.Interests == null)
            {
                return NotFound();
            }

            var interests = _context.Interests.AsQueryable();

            if (personId != null)
            {
                interests = interests.Where(i => i.FK_PersonId == personId);
            }

            return await interests.ToListAsync();
        }

        // GET: api/Interests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interest>> GetInterest(int id)
        {
          if (_context.Interests == null)
          {
              return NotFound();
          }
            var interest = await _context.Interests.FindAsync(id);

            if (interest == null)
            {
                return NotFound();
            }

            return interest;
        }

        // PUT: api/Interests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterest(int id, Interest interest)
        {
            if (id != interest.InterestId)
            {
                return BadRequest();
            }

            _context.Entry(interest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestExists(id))
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

        

        [HttpPost("Add Interest by PersonId")]
        public async Task<ActionResult<InterestCreateDto>> PostInterest(InterestCreateDto interestDto)
        {
            if (_context.Interests == null)
            {
                return Problem("Entity set 'ApiDbContext.Interests' is null.");
            }

            var interest = new Interest
            {
                Title = interestDto.Title,
                Description = interestDto.Description,
                FK_PersonId = interestDto.PersonId
            };

            _context.Interests.Add(interest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterest", new { id = interest.InterestId }, interestDto);
        }

        // DELETE: api/Interests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterest(int id)
        {
            if (_context.Interests == null)
            {
                return NotFound();
            }
            var interest = await _context.Interests.FindAsync(id);
            if (interest == null)
            {
                return NotFound();
            }

            _context.Interests.Remove(interest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterestExists(int id)
        {
            return (_context.Interests?.Any(e => e.InterestId == id)).GetValueOrDefault();
        }
    }
}
