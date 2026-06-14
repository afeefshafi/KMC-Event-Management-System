using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace KMCEventManagement.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly HttpClient _httpClient;

        public RegistrationController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public IActionResult Register(int id)
        {
            ViewBag.EventId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterEvent(int eventId)
        {
            var registration = new
            {
                userId = 1,
                eventId = eventId
            };

            var json = JsonSerializer.Serialize(registration);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "https://localhost:7126/api/Registration/register",
                content
            );

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] =
                    "Event Registration Successful!";
            }
            else
            {
                TempData["Error"] =
                    "Registration Failed!";
            }

            return RedirectToAction(
                "Register",
                new { id = eventId }
            );
        }
    }
}