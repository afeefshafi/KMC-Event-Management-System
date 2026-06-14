using Microsoft.AspNetCore.Mvc;
using KMCEventManagement.Web.Models;
using System.Text;
using System.Text.Json;

namespace KMCEventManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var json = JsonSerializer.Serialize(user);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "https://localhost:7126/api/User/register",
                content
            );

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Registration Successful!";
                return RedirectToAction("Login");
            }

            TempData["Error"] = "Registration Failed!";
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var json = JsonSerializer.Serialize(login);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "https://localhost:7126/api/User/login",
                content
            );

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Login Successful!";

                // Redirect to Dashboard
                return RedirectToAction("Index", "Dashboard");
            }

            TempData["Error"] = "Invalid Email or Password!";
            return View(login);
        }
    }
}