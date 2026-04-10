using Shared;
using System;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Web.Services
{
    // Error handling for this class should be more robust if things like a 500 error are returned
    // you don't want a silent failure for single error type
    public class Offenders
    {
        private readonly HttpClient _httpClient;

        public Offenders(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OffenderDto>> SearchOffenders(string? first, string? last)
        {
            var sanitizedFirst = Uri.EscapeDataString(first ?? string.Empty);
            var sanitizedLast = Uri.EscapeDataString(last ?? string.Empty);
            var url = $"/api/reverseProxyOffenders?firstName={sanitizedFirst}&lastName={sanitizedLast}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<OffenderDto>>() ?? [];
            }

            return [];
        }

        public async Task<OffenderDto> GetOffenderById(int id)
        {
            var url = $"/api/reverseProxyOffenders/{id}";

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<OffenderDto>() ?? new OffenderDto();
            }

            return new OffenderDto();
        }

        public async Task<List<CaseDto>> GetOffenderCases(int offenderId)
        {
            var url = $"/api/reverseProxyCases/{offenderId}";
            var response = await _httpClient.GetAsync(url);
           
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<CaseDto>>() ?? [];
            }

            return [];
        }

        public async Task<List<FeeDto>> GetFees(int offenderId)
        {
            var url = $"/api/reverseProxyFees/{offenderId}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<FeeDto>>() ?? [];
            }

            return [];
        }
    }
}
