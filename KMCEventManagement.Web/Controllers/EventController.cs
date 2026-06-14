using Microsoft.AspNetCore.Mvc;
using KMCEventManagement.Web.Models;
using System.Text.Json;

namespace KMCEventManagement.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly HttpClient _httpClient;

        public EventController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // Event List Page
        public async Task<IActionResult> Index()
        {
            List<Event> events = new List<Event>();

            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7126/api/Event/all");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    events = JsonSerializer.Deserialize<List<Event>>(
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    ) ?? new List<Event>();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View(events);
        }

        // Event Details Page
        public async Task<IActionResult> Details(int id)
        {
            Event? eventItem = null;

            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7126/api/Event/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    eventItem = JsonSerializer.Deserialize<Event>(
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View(eventItem);
        }
    }
}