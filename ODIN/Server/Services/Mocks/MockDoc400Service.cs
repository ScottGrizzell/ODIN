using Server.Interfaces;
using Shared;

namespace Server.Services.Mocks
{
    public class MockDoc400Service : IDoc400Service
    {
        private readonly List<CaseDto> _mockCases =
    [
        new CaseDto { Id = 101, OffenderId = 1, CaseNumber = "24-CR-001", CaseDescription = "Traffic Violation", FiledDate = DateTime.Now.AddMonths(-6) },
        new CaseDto { Id = 102, OffenderId = 1, CaseNumber = "24-CR-005", CaseDescription = "Public Disturbance", FiledDate = DateTime.Now.AddMonths(-2) },
        new CaseDto { Id = 103, OffenderId = 2, CaseNumber = "23-CV-999", CaseDescription = "Small Claims", FiledDate = DateTime.Now.AddYears(-1) },
        new CaseDto { Id = 104, OffenderId = 3, CaseNumber = "23-CV-008", CaseDescription = "Stolen Cookie", FiledDate = DateTime.Now.AddYears(-5) }

    ];
        public async Task<List<CaseDto>> GetCaseByOffenderId(int offenderId)
        {
            // Mock network latency
            await Task.Delay(500);
            var cases = _mockCases.Where(c => c.OffenderId == offenderId).ToList();
            return await Task.FromResult(cases);
        }
    }
}
