using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Entities;
using Server.Interfaces;
using Shared;

namespace Server.Services
{
    public class SqlOffenderService : IOffenderService
    {
        private readonly OdinDbContext _context;

        public SqlOffenderService(OdinDbContext context)
        {
            _context = context;
        }

        public async Task<OffenderDto?> GetOffenderByIdAsync(int id)
        {
            var offender = await _context.Offenders.FindAsync(id);

            if (offender == null) return null;

            return new OffenderDto()
            {
                // Could use a library to handle mapping but for small scale I prefer this
                Id = offender.Id,
                FirstName = offender.FirstName,
                LastName = offender.LastName,
                DOB = offender.DOB,
                FeesOwed = offender.FeesOwed,
                Notes = offender.Notes,
                Status = offender.Status

            };
        }

        public async Task<IEnumerable<OffenderDto>> SearchOffenderAsync(string? firstName, string? lastName)
        {
            var query = _context.Offenders.AsQueryable();
            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(x => x.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(x => x.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase));
            }

            return await query.Select(o => new OffenderDto
            {
                // Could use a library to handle mapping but for small scale I prefer this
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                DOB = o.DOB,
                FeesOwed = o.FeesOwed,
                Notes = o.Notes,
                Status = o.Status
            }).ToListAsync();

        }
    }
}
