using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace Web.Services
{
    public class JwtAuthorizationHandler : DelegatingHandler
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navigationManager;

        public JwtAuthorizationHandler(IJSRuntime jsRuntime, NavigationManager navigationManager)
        {
            _jsRuntime = jsRuntime;
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");

                _navigationManager.NavigateTo("/login");
            }

            return response;
        }

    }
}
