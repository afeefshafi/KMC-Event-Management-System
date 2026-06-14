using Microsoft.AspNetCore.Mvc;
using KMCEventManagement.Web.Models;
using System.Text.Json;

namespace KMCEventManagement.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HttpClient _httpClient;

        public DashboardController(
            IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            DashboardViewModel dashboard =
                new DashboardViewModel();

            try
            {
                var response =
                    await _httpClient.GetAsync(
                    "https://localhost:7126/api/Dashboard");

                if (response.IsSuccessStatusCode)
                {
                    var json =
                        await response.Content.ReadAsStringAsync();

                    dashboard =
                        JsonSerializer.Deserialize<DashboardViewModel>(
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        })!;
                }
            }
            catch
            {
            }

            return View(dashboard);
        }
    }
}