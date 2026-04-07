using Shared;
using System.Net.Http.Json;

namespace Web.Services
{
    public class Offenders
    {
        private readonly HttpClient _httpClient;

        public Offenders(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OffenderDto>> SearchOffenders(string? first, string? last)
        {
            var url = $"/api/reverseProxyOffenders?firstName={first}&lastName={last}";
            
            return await _httpClient.GetFromJsonAsync<List<OffenderDto>>(url) ?? [];
        }

        public async Task<OffenderDto> GetOffenderById(int id)
        {
            var url = $"/api/reverseProxyOffenders/{id}";

            return await _httpClient.GetFromJsonAsync<OffenderDto>(url) ?? new OffenderDto(); 
        }
    }
}
