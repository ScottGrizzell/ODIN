using Shared;

namespace Server.Interfaces
{
    public interface IOffenderService
    {
        Task<OffenderDto?> GetOffenderByIdAsync(int id);
        Task<IEnumerable<OffenderDto>> SearchOffenderAsync(string? firstName, string?  lastName);
    }
}
