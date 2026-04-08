using Server.Interfaces;
using Shared;

namespace Server.Services.Mocks
{
    public class MockOffenderService : IOffenderService
    {
        private readonly List<OffenderDto> _fakeOffenderDb =
        [
            new() {Id = 1, FirstName = "John", LastName = "Smith", DOB = new(1990, 5, 9), FeesOwed = 150.50m},
            new() {Id = 2, FirstName = "Joe", LastName = "Public", DOB = new(1990, 5, 9), FeesOwed = 0}

        ];
        public async Task<OffenderDto?> GetOffenderByIdAsync(int id)
        {
            // Arbitrary delay to simulate network latency
            await Task.Delay(1000);
            
            return _fakeOffenderDb.FirstOrDefault(x=> x.Id == id);
        }

        public Task<IEnumerable<OffenderDto>> SearchOffenderAsync(string? firstName, string? lastName)
        {
           var results = _fakeOffenderDb.AsEnumerable();
            if(!string.IsNullOrEmpty(firstName))
            {
                results = results.Where(x => x.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                results = results.Where(x => x.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase));
            }

            return Task.FromResult(results);
        }
    }
}
